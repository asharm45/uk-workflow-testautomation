using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using SolidToken.SpecFlow.DependencyInjection;
using WorkflowSpecflowTests.Apis;
using WorkflowSpecflowTests.Config;
using WorkflowSpecflowTests.Driver;
using WorkflowSpecflowTests.Email;
using WorkflowSpecflowTests.Pages;
using WorkflowSpecflowTests.StepDefinitions;

namespace WorkflowSpecflowTests
{
    public class Startup
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {

            var services = new ServiceCollection();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            services
                .AddSingleton(ConfigReader.ReadConfig())
                .AddSingleton(ConfigReader.ReadCredentials())

                .AddLogging(configure =>
                {
                    configure.AddSerilog();
                    configure.AddConsole();
                    configure.AddDebug();
                    configure.SetMinimumLevel(LogLevel.Information);
                })
                .AddScoped<IPlaywrightDriver, PlaywrightDriver>()
                .AddScoped<ILoginPage, LoginPage>()
                .AddScoped<IDashboardPage, DashboardPage>()
                .AddScoped<ILogoutPage, LogoutPage>()
                .AddScoped<IXMLUpdate, XMLUpdate>()
                .AddScoped<ISoapClient, SoapClient>()
                .AddScoped<IDynamicsLoginPage, DynamicsLoginPage>()
                .AddScoped<ICasesPage, CasesPage>()
                .AddScoped<ICommonStepDefiniation, CommonStepDefiniation>()
                .AddScoped<IBasePage, BasePage>()
                .AddScoped<IAttributesMappingPage, AttributesMappingPage>()
                .AddScoped<ITasksPage, TasksPage>()
                .AddScoped<IContactPage, ContactPage>()
                .AddScoped<ISearchPage, SearchPage>()
                .AddScoped<IUnderwriterAuthorityPage, UnderwriterAuthorityPage>()
                .AddScoped<IQueuesPage, QueuesPage>()
                .AddScoped<IMotorTotalSumPage, MotorTotalSumPage>()
                .AddScoped<ISLAstoppagePage, SLAstoppagePage>()
                .AddScoped<IMaintainContactSummaryPage, MaintainContactSummaryPage>()
                .AddScoped<ITaskTypePage, TaskTypePage>()
                .AddScoped<IActivitiesPage, ActivitiesPage>()
                .AddScoped<IAccountPage, AccountPage>()
                .AddScoped<IPoliciesPage, PoliciesPage>()
                .AddScoped<IPolicyHoldersPage, PolicyHoldersPage>()
                .AddScoped<IPlaywrightDriverInitializer, PlaywrightDriverInitializer>()
                .AddScoped<IContactChangesPage, ContactChangesPage>()
                .AddScoped<IChildCasePage, ChildCasePage>()
                .AddScoped<ISLATimesPage, SLATimesPage>()
                .AddScoped<ICustomerServiceHubPage, CustomerServiceHubPage>()
                .AddScoped<IEmailSender, EmailSender>()
                .AddScoped<IDashboardsPage, DashboardsPage>()
                .AddScoped<IDemandsPage, DemandsPage>()
                .AddScoped<ITaskApi, TaskApi>()
                .AddScoped<IPolicyApi, PolicyApi>();
            return services;
        }
    }
}
