using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;


namespace WorkflowSpecflowTests.Pages
{
    public interface IMotorTotalSumPage
    {
        Task ClickCustomerServiceHub();

        Task ClickOnPolicies();

        Task ClickOnNewButton();

        Task EnterPolicyDetails(string polref, string channel, string startdate, string enddate, string annualpremium, string coversheld, string riskaddr, string excesses, string motorsuminsured);

        Task EnterManually();

    }

    public class MotorTotalSumPage : IMotorTotalSumPage
    {
        private readonly IPage _page;
        private readonly IBasePage _basePage;
        private readonly ILogger<MotorTotalSumPage> _logger;
        public MotorTotalSumPage(IPlaywrightDriver driver, IBasePage basePage, ILogger<MotorTotalSumPage> logger)
        {
            _page = driver.Page.Result;
            _basePage = basePage;
            _logger = logger;
        }

        private ILocator AcceptAllSuggestions => _page.Locator("//span[text()='Accept all suggestions']");
        private ILocator CustomerServiceHub => _page.Locator("//div[@title='Customer Service Hub']");
        private ILocator Policies => _page.Locator("//span[text()='Policies']");
        private ILocator NewBtn => _page.Locator("//span[text()='New']");
        private ILocator  policyref=> _page.Locator("//input[@aria-label='Policy Reference']");
        private ILocator  selectOpt=> _page.Locator("//label[text()='Channel']/following::button[1]");
        private ILocator  direct=> _page.Locator("//div[text()='Direct']");
        private ILocator startDate => _page.Locator("//input[@aria-label='Date of Policy Start Date']");
        private ILocator endDate => _page.Locator("//input[@aria-label='Date of Policy End Date']");
        private ILocator  annualPremium=> _page.Locator("//input[@aria-label='Annual Premium']");
        private ILocator  coversHeld=> _page.Locator("//textarea[@aria-label='Covers Held']");
        private ILocator  riskAddress=> _page.Locator("//textarea[@aria-label='Risk Address']");
        private ILocator  Excesses=> _page.Locator("//input[@aria-label='Excesses']");
        private ILocator  motorSumInsured=> _page.Locator("//input[@aria-label='Motor sum insured']");
        private ILocator  motorTotalSumInsured=> _page.Locator("//input[@aria-label='Motor total sum insured (single address)']");
        private ILocator  saveBtn=> _page.Locator("//span[text()='Save']");

        private string MotoralTotalSum= "46000000";

        

        public async Task ClickCustomerServiceHub()
        {
            await _basePage.ClickElementAsync(CustomerServiceHub);
            _logger.LogInformation($"Clicked on customer service hub");
        }
        public async Task ClickOnPolicies()
        {
            await _basePage.ClickElementAsync(Policies);
            _logger.LogInformation($"Clicked on policies");
        }
        public async Task ClickOnNewButton()
        {
            await _basePage.ClickElementAsync(NewBtn);
            _logger.LogInformation($"Clicked on next button");
        }
        public async Task EnterPolicyDetails(string polref, string channel, string startdate, string enddate, string annualpremium, string coversheld, string riskaddr, string excesses, string motorsuminsured)
        {
            await _basePage.FillElementAsync(policyref, polref);
            _logger.LogInformation($"Entered policy ref :{polref}");
            if (await AcceptAllSuggestions.IsVisibleAsync())
            {
                await _basePage.ClickElementAsync(AcceptAllSuggestions);
                _logger.LogInformation($"Clicked on AI Suggestion");
            }
            await _basePage.ClickElementAsync(selectOpt);
            _logger.LogInformation($"Clicked on selectOpt");
            Thread.Sleep(2000);
            await _basePage.ClickElementAsync(direct);
            _logger.LogInformation($"Clicked direct");
            await _basePage.FillElementAsync(startDate, startdate);
            _logger.LogInformation($"Entered start date :{startdate}");
            await _basePage.FillElementAsync(endDate, enddate);
            _logger.LogInformation($"Entered end date :{endDate}");
            await _basePage.FillElementAsync(annualPremium, annualpremium);
            _logger.LogInformation($"Enteredannual premium :{annualPremium}");
            await _basePage.FillElementAsync(coversHeld, coversheld);
            _logger.LogInformation($"Entered cover held :{coversheld}");
            await _basePage.FillElementAsync(riskAddress, riskaddr);
            _logger.LogInformation($"Entered risk address :{riskaddr}");
            await _basePage.FillElementAsync(Excesses, excesses);
            _logger.LogInformation($"Entered excessess :{excesses}");
            await _basePage.FillElementAsync(motorSumInsured, motorsuminsured);
            _logger.LogInformation($"Entered motor toal sum :{MotoralTotalSum}");
        }

        public async Task EnterManually()
        {
            await _basePage.FillElementAsync(motorTotalSumInsured,MotoralTotalSum);
            _logger.LogInformation($"Entered motor toal sum :{MotoralTotalSum}");
        }
    }
}
