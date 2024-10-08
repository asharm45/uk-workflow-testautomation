using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface ICustomerServiceHubPage
    {
        Task switchToScheduling();
        Task clickResources();
        Task clickNewButton();
        Task createNewBookable(string ContactName);
        Task<bool> VerifyBookableCreated(string ContactName);
    }
    public class CustomerServiceHubPage : ICustomerServiceHubPage
    {
        private readonly IPage _page;
        private readonly IBasePage _basePage;
        private readonly ICasesPage _casePage;
        private readonly ILogger<CustomerServiceHubPage> _logger;
        public CustomerServiceHubPage(IPlaywrightDriver driver, ILogger<CustomerServiceHubPage> logger, IBasePage basePage, ICasesPage casePage)
        {
            _page = driver.Page.Result;
            _logger = logger;
            _basePage = basePage;
            _casePage = casePage;
        }

        //private ILocator AssetDropdown => _page.Locator("//*[@id='areaSwitcherId']");
        private ILocator AssetDropdown => _page.Locator("//span[text()='Service']");
        private ILocator Scheduling => _page.Locator("//*[text()='Scheduling']");
        private ILocator Resources => _page.Locator("//*[@id='sitemap-entity-nav_bookableresource']");
        private ILocator NewButton => _page.Locator("//button[@aria-label='New']");
        private ILocator ResourceType => _page.Locator("//button[@aria-label='Resource Type']");
        private ILocator UserLookup => _page.Locator("//input[@aria-label='User, Lookup']");
        private ILocator ContactLookup => _page.Locator("//input[@aria-label='Contact, Lookup']");
        private ILocator NewContact => _page.Locator("//button[@aria-label='New Contact']");
        private ILocator ClickContact => _page.Locator("//*[text()='Aut1 omation1']");
        private ILocator SelectContact => _page.Locator("//*[text()='Contact']");
        private ILocator ContactFirstName => _page.Locator("//input[@aria-label='First Name']");
        private ILocator ContactLastName => _page.Locator("//input[@aria-label='Last Name']");
        private ILocator ContactEmail => _page.Locator("//input[@aria-label='Email']");
        private ILocator Filter => _page.Locator("//input[@aria-label='Bookable Resource Filter by keyword']");
        private ILocator ContactStreet1 => _page.Locator("//input[@aria-label='Street 1']");
        private ILocator Save => _page.Locator("//button[@aria-label='Save (CTRL+S)']");


        public async Task switchToScheduling()
        {
            //await _page.ClickAsync(AssetDropdown);
            await _basePage.ClickElementAsync(AssetDropdown);
            _logger.LogInformation($"Clicked on Asset dropdown");
            await _basePage.ClickElementAsync(Scheduling);
            _logger.LogInformation($"Clicked on Scheduling");
        }

        public async Task clickResources()
        {
            await _basePage.ClickElementAsync(Resources);
            _logger.LogInformation($"Clicked on Resources");
            await _casePage.ClickOnSaveContinue();
        }

        public async Task clickNewButton()
        {
            //await _basePage.ClickElementAsync(NewButton);
            await _page.ClickAsync("//button[@aria-label='New']");
            _logger.LogInformation($"Clicked on New Button");
        }

        public async Task createNewBookable(string ContactName)
        {
            await _basePage.ClickElementAsync(ResourceType);
            _logger.LogInformation($"Clicked on Resource Type");
            await _basePage.ClickElementAsync(SelectContact);
            _logger.LogInformation($"Select Contact dropdown");
            await _basePage.ClickElementAsync(ContactLookup);
            _logger.LogInformation($"Clicked on Contact Lookup");
            await _basePage.FillElementAsync(ContactLookup, ContactName);
            await _basePage.ClickElementAsync(ClickContact);
            _logger.LogInformation($"Clicked on the Contact");
            await _basePage.ClickElementAsync(Save);
            _logger.LogInformation($"Clicked on Save");
        }

        public async Task<bool> VerifyBookableCreated(string ContactName)
        {
            await _basePage.FillElementAsync(Filter, ContactName);
            await _page.Keyboard.PressAsync("Enter");
            //await _page.Keyboard.PressAsync("Enter");
            _logger.LogInformation("Entered Bookable" + ContactName);

            return await _page.IsVisibleAsync("//a[@aria-label='"+ ContactName + "']");
        }
    }
    
}
