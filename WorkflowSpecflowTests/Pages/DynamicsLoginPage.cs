using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface IDynamicsLoginPage
    {
        Task EnterDynamincsCredentials();
        Task ClickNext();
        Task EnterDynamincsCredentials(string team, string role);
        Task HandleCopilotAsync();

    }

    public class DynamicsLoginPage : IDynamicsLoginPage
    {
        private readonly IPage _page;
        private readonly IBasePage _basePage;
        private readonly ICasesPage _casesPage;
        private readonly ILogger<DynamicsLoginPage> _logger;

        public DynamicsLoginPage(IPlaywrightDriver driver, IBasePage basePage, ICasesPage casesPage, ILogger<DynamicsLoginPage> logger)
        {
            _page = driver.Page.Result;
            _basePage = basePage;
            _casesPage = casesPage;
            _logger = logger;
        }

        private ILocator EmailAddress => _page.Locator("//input[@type='email']");
        private ILocator NextButton => _page.Locator("//input[@type='submit']");
        private ILocator Copilot => _page.Locator("//button[@aria-label='Copilot']//div/div");
        private ILocator CloseCopilot => _page.Locator("//span[@data-automationid='splitbuttonprimary']/img");


        public async Task EnterDynamincsCredentials()
        {
            await _basePage.FillElementAsync(EmailAddress, "Svc_HiscoxUKWorkflowAuto4@hiscox.com");
            _logger.LogInformation("Entered email address");
        }

        public async Task EnterDynamincsCredentials(string team, string role)
        {
            

            switch (role)
            {
                case "Caseworker":
                    await _basePage.FillElementAsync(EmailAddress, "Svc_HiscoxUKWorkflowAuto4@hiscox.com");
                    _logger.LogInformation("Entered caseworker email address");
                    break;

                case "Admin":
                    await _basePage.FillElementAsync(EmailAddress, "amitsharma.jaiprakash@hiscox.com");
                    await _casesPage.ClickOnCustomerServiceAdmin();
                    _logger.LogInformation("Entered system admin email address");
                    break;
                case "Team Lead":
                    await _basePage.FillElementAsync(EmailAddress, "jeevanathan.chandran@hiscox.com");
                    await _casesPage.ClickOnCustomerServiceHub();
                    _logger.LogInformation("Entered team lead email address");
                    break;
                default:
                    _logger.LogInformation("Invalid credentials!");
                    break;
            }
        }

        public async Task ClickNext()
        {
            await _basePage.ClickElementAsync(NextButton);
            _logger.LogInformation("Clicked on next button");
            Thread.Sleep(10000);
            await _page.WaitForLoadStateAsync();
            
            if (await _page.Locator("//h2[text()='Copilot']").IsVisibleAsync())
            {
                await _page.Locator("//button[@aria-label='Copilot']//img").ClickAsync();
            }

        }

        public async Task HandleCopilotAsync()
        {
            try
            {
                await _page.WaitForSelectorAsync("//div[@id='filter-panel-host']");

                await _page.EvaluateAsync("document.body.style.zoom=0.75");

                await _page.WaitForSelectorAsync("//button[@aria-label='Copilot']//div/div");
                await _basePage.ClickElementAsync(CloseCopilot);

                //blue annoying pop up saying a copilot for you
                if (await _page.Locator("//p[text()='A Copilot for you!']//following::i[@data-icon-name='Cancel'][1]").IsVisibleAsync())
                {
                    await _page.Locator("//p[text()='A Copilot for you!']//following::i[@data-icon-name='Cancel'][1]").ClickAsync();
                }
                _logger.LogInformation("Closed copilot suggestion window");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex.Message}");
            }
            
        }
    }
}
