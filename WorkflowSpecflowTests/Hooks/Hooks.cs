using System.Text.RegularExpressions;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using Retry;
using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow.Infrastructure;
using WorkflowSpecflowTests.Config;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IPlaywrightDriver _playwrightDriver;
        private readonly TestSettings _settings;
        private readonly Task<IPage> _page;
        private static ExtentReports? _extentReports;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _sceanrioContext;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
        private ExtentTest _scenario;
        private readonly Task<IBrowserContext> _context;
        private int _retryCount = 0;
        private readonly ILogger<Hooks> _logger;

        public Hooks(IPlaywrightDriver playwrightDriver, TestSettings settings, FeatureContext featureContext, ScenarioContext sceanrioContext, ISpecFlowOutputHelper specFlowOutputHelper, ILogger<Hooks> logger)
        {
            _playwrightDriver = playwrightDriver;
            _settings = settings;
            _featureContext = featureContext;
            _sceanrioContext = sceanrioContext;
            _specFlowOutputHelper = specFlowOutputHelper;
            _page = playwrightDriver.Page;
            _context = playwrightDriver.BrowserContext;
            _logger = logger;

        }

        [BeforeTestRun]
        public static void InitializeExtentReports()
        {
            _extentReports = new ExtentReports();
            _extentReports.AddSystemInfo("Win", "Windows");
            _extentReports.AddSystemInfo("browser", "Chrome");
            _extentReports.AddSystemInfo("browserVersion", "98.0");
            var spark = new ExtentSparkReporter("TestReport.html");
            _extentReports.AttachReporter(spark);
        }

       
    [BeforeScenario]
        public async Task BeforeScenario()
        {
            if (!_sceanrioContext.ContainsKey("RetryCount"))
            {
                _sceanrioContext["RetryCount"] = 0;
            }

            await (await _context).Tracing.StartAsync(new TracingStartOptions
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });
            switch (_settings.DynamicsEnv)
            { 
                
                case "Test":
                    await (await _page).GotoAsync("https://hiscoxuk-workflow-Test.crm4.dynamics.com");
                    _logger.LogInformation($"Logged in to Dynamics Test {"https://hiscoxuk-workflow-Test.crm4.dynamics.com"}");
                    break;
                case "dev":
                    await (await _page).GotoAsync("https://hiscoxuk-workflow-dev.crm4.dynamics.com");
                    _logger.LogInformation($"Logged in to Dynamics Dev {"https://hiscoxuk-workflow-dev.crm4.dynamics.com"}");
                    break;
                case "uat":
                    await (await _page).GotoAsync("https://hiscoxuk-workflow-uat.crm4.dynamics.com");
                    _logger.LogInformation($"Logged in to Dynamics UAT {"https://hiscoxuk-workflow-Test.crm4.dynamics.com"}");
                    break;
                case "prod":
                    await (await _page).GotoAsync("https://hiscoxuk-workflow.crm4.dynamics.com");
                    _logger.LogInformation($"Logged in to Dynamics Prod {"https://hiscoxuk-workflow.crm4.dynamics.com"}");
                    break;
                    default:
                    _logger.LogInformation($"Selected invalid environment");
                    break;
            }

            var feature = _extentReports.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
            _scenario = feature.CreateNode<Scenario>(_sceanrioContext.ScenarioInfo.Title);
        }

        [BeforeScenario]
        [Scope(Tag = "merlinScreen")]
        public async Task BeforeScenarioMerlin()
        {
            await (await _page).GotoAsync("https://automation1.merlin.sapiens.hiscox.com/");
        }

        [AfterTestRun]
        public static void tearDownReport()
        {
            _extentReports?.Flush();
        }

        [AfterStep]
        public async Task AfterStep()
        {
            var fileName =
                $"{_featureContext.FeatureInfo.Title.Trim()}_{Regex.Replace(_sceanrioContext.ScenarioInfo.Title, @"\s", "")}";

            if (_sceanrioContext.TestError == null)
            {
                switch (_sceanrioContext.StepContext.StepInfo.StepDefinitionType)
                {
                    case StepDefinitionType.Given:
                        _scenario.CreateNode<Given>(_sceanrioContext.StepContext.StepInfo.Text)
                            .Pass("Pass", MediaEntityBuilder
                            .CreateScreenCaptureFromBase64String(await _playwrightDriver.TakeScreenshotAsBase64Async(), "Pass Screenshot")
                            .Build());
                        break;
                    case StepDefinitionType.Then:
                        _scenario.CreateNode<Then>(_sceanrioContext.StepContext.StepInfo.Text)
                            .Pass("Pass", MediaEntityBuilder
                            .CreateScreenCaptureFromBase64String(await _playwrightDriver.TakeScreenshotAsBase64Async(), "Pass Screenshot")
                            .Build());
                        break;
                    case StepDefinitionType.When:
                        _scenario.CreateNode<When>(_sceanrioContext.StepContext.StepInfo.Text)
                            .Pass("Pass", MediaEntityBuilder
                            .CreateScreenCaptureFromBase64String(await _playwrightDriver.TakeScreenshotAsBase64Async(), "Pass Screenshot")
                            .Build());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                switch (_sceanrioContext.StepContext.StepInfo.StepDefinitionType)
                {
                    case StepDefinitionType.Given:
                        _scenario.CreateNode<Given>(_sceanrioContext.StepContext.StepInfo.Text)
                            .Fail(_sceanrioContext.TestError.Message, MediaEntityBuilder
                            .CreateScreenCaptureFromBase64String(await _playwrightDriver.TakeScreenshotAsBase64Async(),"Error Screenshot")
                            .Build());
                        break;
                    case StepDefinitionType.Then:
                        _scenario.CreateNode<Then>(_sceanrioContext.StepContext.StepInfo.Text)
                            .Fail(_sceanrioContext.TestError.Message, MediaEntityBuilder
                            .CreateScreenCaptureFromBase64String(await _playwrightDriver.TakeScreenshotAsBase64Async(), "Error Screenshot")
                            .Build());
                        break;
                    case StepDefinitionType.When:
                        _scenario.CreateNode<When>(_sceanrioContext.StepContext.StepInfo.Text)
                            .Fail(_sceanrioContext.TestError.Message, MediaEntityBuilder
                            .CreateScreenCaptureFromBase64String(await _playwrightDriver.TakeScreenshotAsBase64Async(), "Error Screenshot")
                            .Build());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }



        [AfterScenario]
        public async Task AfterScenario()
        {
            string screenshotPath =
            Path.Combine("screenshots", $"{_sceanrioContext.ScenarioInfo.Title}_screenshot.png");
            string tracesPath = Path.Combine("traces", $"{_sceanrioContext.ScenarioInfo.Title}_trace.zip");
            if (_sceanrioContext.ScenarioExecutionStatus != ScenarioExecutionStatus.OK)
            {
                await(await _page).ScreenshotAsync(new PageScreenshotOptions
                {
                    Path = screenshotPath,
                    FullPage = true
                });
                _sceanrioContext["screenshotsPath"] = screenshotPath;
            }
            string videoPath = await (await _page).Video.PathAsync();
            _specFlowOutputHelper.AddAttachment(screenshotPath);
            if (_settings.Video)
            {
                _specFlowOutputHelper.AddAttachment(videoPath);
            }

            if (_settings.Trace)
            {
                _specFlowOutputHelper.AddAttachment(tracesPath);
            }
            await (await _context).Tracing.StopAsync(new TracingStopOptions
            {
                Path = tracesPath
            });
            
            await (await _context).CloseAsync();

            if (_sceanrioContext.TestError != null && (int)_sceanrioContext["RetryCount"] < _settings.MaxRetries)
            {
                // Increment the retry count
                _sceanrioContext["RetryCount"] = _retryCount + 1;

                // Optionally, log or perform actions before retrying
                Console.WriteLine($"Retrying the scenario... Attempt {_retryCount + 1} of {_settings.MaxRetries}");

                // Retry the scenario
                var retry = new RetryHelper();
                retry.TryAsync(ScenarioStepContext.Current.ToString);
               
            }

        }
    }
}
