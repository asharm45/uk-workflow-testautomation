using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface IAccountPage
    {
        Task ClickOnAccounts();
        Task SelectTheAccount(string AccountName);
        Task EnterTheAccountName(string AccountName);
        Task AccountFieldValidation(string AccountName);

    }
    public class AccountPage : IAccountPage
    {
        private readonly IPage _page;
        private readonly IBrowserContext _browserContext;
        private readonly IBasePage _basePage;
        private readonly ILogger<AccountPage> _logger;

        public AccountPage(IPlaywrightDriver driver, IBasePage basePage, ILogger<AccountPage> logger)
        {
            _page = driver.Page.Result;
            _browserContext = driver.BrowserContext.Result;
            _basePage = basePage;
            _logger = logger;
        }
        private ILocator AccountInformation => _page.Locator("//h2[text()='ACCOUNT INFORMATION']");
        private ILocator AccountNameField => _page.Locator("//label[text()='Account Name']/following::input[1]");
        private ILocator PhoneField => _page.Locator("//label[text()='Phone']/following::input[1]");
        private ILocator FaxField => _page.Locator("//label[text()='Fax']/following::input[1]");
        private ILocator WebsiteField => _page.Locator("//label[text()='Website']/following::input[1]");
        private ILocator PrimaryContactField => _page.Locator("//label[text()='Primary Contact']/following::input[1]");
        private ILocator ParentAccountField => _page.Locator("//label[text()='Parent Account']/following::input[1]");
        private ILocator Address1S1Field => _page.Locator("//label[text()='Address 1: Street 1']/following::input[1]");
        private ILocator Address1S2Field => _page.Locator("//label[text()='Address 1: Street 2']/following::input[1]");
        private ILocator Address1S3Field => _page.Locator("//label[text()='Address 1: Street 3']/following::input[1]");
        private ILocator Address1CField => _page.Locator("//label[text()='Address 1: City']/following::input[1]");
        private ILocator Address1StateField => _page.Locator("//label[text()='Address 1: State/Province']/following::input[1]");
        private ILocator Address1ZIPField => _page.Locator("//label[text()='Address 1: ZIP/Postal Code']/following::input[1]");
        private ILocator Address1CountryField => _page.Locator("//label[text()='Address 1: Country/Region']/following::input[1]");

        private ILocator Accounts => _page.Locator("//span[text()='Accounts']");

        public async Task ClickOnAccounts()
        {
            await _basePage.ClickElementAsync(Accounts);
            _logger.LogInformation("Clicked on Accounts");
        }

        public async Task SelectTheAccount(string AccountName)
        {
            await _page.Locator("//span[starts-with(text(),'" + AccountName + "')]/preceding::input[1]").ScrollIntoViewIfNeededAsync();
            await _page.Locator("//span[starts-with(text(),'" + AccountName + "')]/preceding::input[1]").ClickAsync();
            _logger.LogInformation("Account name " + AccountName + " selected");
        }
        public async Task EnterTheAccountName(string AccountName)
        {
            //await _page.Locator("//span[starts-with(text(),'" + AccountName + "')]").ScrollIntoViewIfNeededAsync();
            //await _page.Locator("//span[starts-with(text(),'" + AccountName + "')]").ClickAsync();
            await _basePage.FillElementAsync(AccountNameField, AccountName);
            _logger.LogInformation("Entered account name " + AccountName);
        }
        public async Task AccountFieldValidation(string AccountName)
        {
            await _page.Locator("//span[starts-with(text(),'" + AccountName + "')]").ScrollIntoViewIfNeededAsync();
            await _page.Locator("//span[starts-with(text(),'" + AccountName + "')]").ClickAsync();
            _logger.LogInformation("Account name " + AccountName + " selected");
            //Field Validations scroll with AccountInformation
            await _basePage.IsElementVisibleAsync(AccountNameField);
            _logger.LogInformation("Account name field is visible");
            await _basePage.IsElementVisibleAsync(PhoneField);
            _logger.LogInformation("Phome field is visible");
            await _basePage.IsElementVisibleAsync(FaxField);
            _logger.LogInformation("Fax field is visible");
            await _basePage.IsElementVisibleAsync(WebsiteField);
            _logger.LogInformation("Website field is visible");
            await _basePage.IsElementVisibleAsync(PrimaryContactField);
            _logger.LogInformation("Primary contact field is visible");
            await _basePage.IsElementVisibleAsync(ParentAccountField);
            _logger.LogInformation("Parent account field is visible");

            await _basePage.ClickElementAsync(AccountInformation);
            _logger.LogInformation("Clciked on Account information");
            await _page.Mouse.WheelAsync(0, 50);
            Thread.Sleep(1000);
            await _page.Mouse.WheelAsync(0, 50);

            await _basePage.IsElementVisibleAsync(Address1S1Field);
            _logger.LogInformation("Address1 S1 field is visible");
            await _basePage.IsElementVisibleAsync(Address1S2Field);
            _logger.LogInformation("Address1 S2 field is visible");
            await _basePage.IsElementVisibleAsync(Address1S3Field);
            _logger.LogInformation("Address1 S3 field is visible");
            await _basePage.IsElementVisibleAsync(Address1CField);
            _logger.LogInformation("Address1 C field is visible");
            await _basePage.IsElementVisibleAsync(Address1StateField);
            _logger.LogInformation("Address1 state field is visible");
            await _basePage.IsElementVisibleAsync(Address1ZIPField);
            _logger.LogInformation("Address1 zip field is visible");
            await _basePage.IsElementVisibleAsync(Address1CountryField);
            _logger.LogInformation("Address1 country field is visible");

        }
    }
}