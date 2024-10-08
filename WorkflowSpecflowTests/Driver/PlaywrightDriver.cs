using System.Reflection;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Config;

namespace WorkflowSpecflowTests.Driver
{
    public class PlaywrightDriver : IDisposable, IPlaywrightDriver
    {
        private readonly AsyncTask<IBrowser> _browser;
        private readonly AsyncTask<IBrowserContext> _browserContext;
        private readonly AsyncTask<IPage> _page;
        private readonly TestSettings _settings;
        private readonly IPlaywrightDriverInitializer _playwrightDriverInitializer;
        private bool _isDisposed;

        public PlaywrightDriver(TestSettings settings, IPlaywrightDriverInitializer playwrightDriverInitializer)
        {
            _settings = settings;
            _playwrightDriverInitializer = playwrightDriverInitializer;
            _browser = new AsyncTask<IBrowser>(CreateBrowserAsync);
            _browserContext = new AsyncTask<IBrowserContext>(CreateBrowserContextAsync);
            _page = new AsyncTask<IPage>(CreatePageAsync);
        }

        public Task<IPage> Page => _page.Value;
        public Task<IBrowser> Browser => _browser.Value;
        public Task<IBrowserContext> BrowserContext => _browserContext.Value;

        private async Task<IBrowser> CreateBrowserAsync()
        {
            return _settings.DriverType switch
            {
                DriverType.Chromium => await _playwrightDriverInitializer.GetChromiumDriverAsync(_settings),
                DriverType.Chrome => await _playwrightDriverInitializer.GetChromiumDriverAsync(_settings),
                DriverType.Edge => await _playwrightDriverInitializer.GetEdgeDriverAsync(_settings),
                DriverType.Firefox => await _playwrightDriverInitializer.GetFirefoxDriverAsync(_settings),
                DriverType.Webkit => await _playwrightDriverInitializer.GetWebkitDriverAsync(_settings),
                _ => await _playwrightDriverInitializer.GetChromiumDriverAsync(_settings)
            };
        }

        private async Task<IAPIRequestContext> CreateApiContext()
        {
            var driver = await Playwright.CreateAsync();
            return await driver.APIRequest.NewContextAsync(new APIRequestNewContextOptions()
            {
                BaseURL = _settings.ApiUrl,
                //can be moved to Config
                IgnoreHTTPSErrors = true
            });
        }


        private async Task<IBrowserContext> CreateBrowserContextAsync()
        {
            return await(await _browser).NewContextAsync(new BrowserNewContextOptions
            {
                HttpCredentials = new HttpCredentials
                {
                    Username = "Svc_HiscoxUKWorkflowAuto4@hiscox.com",
                    Password = "uDdgltoiA3VB2LnmQ55b"
                },
                RecordVideoDir = "videos/",
                RecordVideoSize = new RecordVideoSize() { Width = 1920, Height = 1080 },
                //ViewportSize = new ViewportSize() { Width = 1100, Height = 1080 }
            });
            
        }

        private async Task<IPage> CreatePageAsync()
        {
            return await (await _browserContext).NewPageAsync();
        }

        public async Task<string> TakeScreenshotAsBase64Async()
        {
            // Capture screenshot as a Base64 string
            byte[] screenBytes =  await Page.Result.ScreenshotAsync(new PageScreenshotOptions
            {
                Type = ScreenshotType.Png,
                FullPage = true
            });
            return Convert.ToBase64String(screenBytes);
        }

        public void Dispose()
        {
            if (!_isDisposed) return;
            if (_browser.IsValueCreated)
                Task.Run(async () =>
                {
                    await (await Browser).CloseAsync();
                    await (await Browser).DisposeAsync();
                });
            
            _isDisposed = true;
        }
    }
}
