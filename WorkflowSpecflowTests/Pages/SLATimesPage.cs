using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface ISLATimesPage
    {
        Task ClickSLATimesAsync();
        Task EnterSLAAsync(int sla, string primaryDemand);
        Task ClickCustomerAdminServiceAsync();
        Task ClickCustomerServiceHubAsync();
    }

    public class SLATimesPage : ISLATimesPage
    {
        private readonly IPage _page;
        private readonly IBasePage _basePage;
        private readonly ILogger<SLATimesPage> _logger;
        public SLATimesPage(IPlaywrightDriver driver, IBasePage basePage, ILogger<SLATimesPage> logger)
        {
            _page = driver.Page.Result;
            _basePage = basePage;
            _logger = logger;
        }

        private ILocator SaveAndCloseButton => _page.Locator("//span[text()='Save & Close']");
        private ILocator SLATimes => _page.Locator("//span[text()='SLA Times']");
        private ILocator ErrorManagement => _page.Locator("(//a[@aria-label='Error Management'])[1]");
        private ILocator IWantInformation => _page.Locator("(//a[@aria-label='I want Information'])[1]");
        private ILocator IWantToCancel => _page.Locator("(//a[@aria-label='I want to Cancel'])[1]");
        private ILocator IWantToRevew => _page.Locator("(//a[@aria-label='I want to Renew'])[1]");
        private ILocator IWantToChange => _page.Locator("(//a[@aria-label='I want to Change'])[1]");
        private ILocator SLADays => _page.Locator("//input[@aria-label='SLA Days']");
        private ILocator CustomerAdminService => _page.Locator("//a[@aria-label='Customer Service admin center']");
        private ILocator CustomerServiceHub => _page.Locator("//a[@aria-label='Customer Service Hub']");
        public async Task ClickSLATimesAsync()
        {
            await _basePage.ClickElementAsync(SLATimes);
            _logger.LogInformation($"Clicked on SLA Times");
        }
        public async Task EnterSLAAsync(int sla, string primaryDemand)
        {
            switch (primaryDemand)
            {
                case "Error Management":
                    await _basePage.ClickElementAsync(ErrorManagement);
                    break;
                case "I want information":
                    await _basePage.ClickElementAsync(IWantInformation);
                    break;
                case "I want to change":
                    await _basePage.ClickElementAsync(IWantToChange);
                    break;
                case "I want to renew":
                    await _basePage.ClickElementAsync(IWantToRevew);
                    break;
                case "I want to cancel":
                    await _basePage.ClickElementAsync(IWantToCancel);
                    break;
                default:
                    _logger.LogInformation($"Invalid primry demand");
                    break;
            }
            await _basePage.FillElementAsync(SLADays, sla.ToString());
            await _basePage.ClickElementAsync(SaveAndCloseButton);
            _logger.LogInformation($"Updated {primaryDemand} SLA time : {sla}");
        }
        public async Task ClickCustomerAdminServiceAsync()
        {
            await _basePage.ClickElementAsync(CustomerAdminService);
        }
        public async Task ClickCustomerServiceHubAsync()
        {
            await _basePage.ClickElementAsync(CustomerServiceHub);
        }
    }
}
