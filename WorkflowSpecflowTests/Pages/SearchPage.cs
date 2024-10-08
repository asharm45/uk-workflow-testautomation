using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface ISearchPage
    {
        Task ClickContacts();
        Task Search(string phoneNumber);
        Task<string> GetSearch(string search);
        Task ClickContactName();
        Task<string> GetHeader();
        Task ClickPoliciesTab();
        Task ClickPolicyRef();
        Task ClickBrokerName();
        Task ClickCasesTab();
        Task ClickCases();
        Task<string> GetCaseStatus();
        Task ClickServiceCases();
        Task SearchPrimaryDemand(string value);
        Task ClickFirstCase();
    }

    public class SearchPage : ISearchPage
    {
        private readonly IPage _page;
        private readonly IBasePage _basePage;
        private readonly ILogger<SearchPage> _logger;
        public SearchPage(IPlaywrightDriver driver, IBasePage basePage, ILogger<SearchPage> logger)
        {
            _page = driver.Page.Result;
            _basePage = basePage;
            _logger = logger;
        }
        private ILocator SearchIcon => _page.Locator("(//span[contains(@class,'symbolFont SearchButton-symbol')])[1]");
        private ILocator GlobalSearch => _page.Locator("#GlobalSearchBox");
        private ILocator Contacts => _page.Locator("//span[text()='Contacts' and starts-with(@class,'ms-Pivot-text')]");
        private ILocator ContactName => _page.Locator("(//div[@col-id='fullname']//button[@type='button'])[1]");
        private ILocator ContactHeader => _page.Locator("//h1[@data-id='header_title']");
        private ILocator PoliciesTab => _page.Locator("(//span[text()='Policies'])[2]");
        private ILocator PolicyRef => _page.Locator("//div[@col-id='ntt_name']//button[@type='button']");
        private ILocator BrokerName => _page.Locator("(//div[@col-id='fullname']//button[@type='button'])[1]");
        private ILocator CasesTab => _page.Locator("(//span[text()='Cases'])[2]");
        private ILocator Case => _page.Locator("(//div[@col-id='title']//button[@type='button'])[1]");
        private ILocator CaseStatus => _page.Locator("//div[text()='Status']//preceding-sibling::div/div");
        private ILocator Cases => _page.Locator("(//span[text()='Cases'])[1]");
        private ILocator Filter => _page.Locator("//input[@aria-label='Case Filter by keyword']");
        private ILocator FirstCase => _page.Locator("(//div[@col-id='title']//span[@role='presentation'])[1]");

        public async Task Search(string value)
        {
            //await _basePage.ClickElementAsync(SearchIcon);
            //_logger.LogInformation($"Clicked on search icon");
            await _basePage.FillElementAsync(GlobalSearch, value);
            _logger.LogInformation($"Entered global search value : {value}");
            await _page.Keyboard.PressAsync("Enter");
        }

        public async Task ClickContacts()
        {
            await _basePage.ClickElementAsync(Contacts);
            _logger.LogInformation($"Clicked on contacts");
        }

        public async Task ClickContactName()
        {
            await _basePage.ClickElementAsync(ContactName);
            _logger.LogInformation($"Clicked on contact name");
        }

        public async Task<string> GetSearch(string search)
        {
            return await _page.GetAttributeAsync("//div[starts-with(@title,'" + search + "')]/following-sibling::div//input", "value");
        }

        public async Task<string> GetHeader()
        {
            var str = await ContactHeader.TextContentAsync();
            return str.Split("-")[0];
        }
        public async Task ClickBrokerName()
        {
            await _basePage.ClickElementAsync(BrokerName);
            _logger.LogInformation($"Clicked on broker name");
        }
        public async Task ClickPoliciesTab()
        {
            await _basePage.ClickElementAsync(PoliciesTab);
            _logger.LogInformation($"Clicked on policies tab");
        }
        public async Task ClickPolicyRef()
        {
            await _basePage.ClickElementAsync(PolicyRef);
            _logger.LogInformation($"Clicked on policy ref");
        }
        public async Task ClickCasesTab()
        {
            await _basePage.ClickElementAsync(CasesTab);
            _logger.LogInformation($"Clicked on cases tab");
        }
        public async Task ClickCases()
        {
            await _basePage.ClickElementAsync(Case);
            _logger.LogInformation($"Clicked on case");
        }
        public async Task<string> GetCaseStatus()
        {
            return await CaseStatus.TextContentAsync();
        }
        public async Task ClickServiceCases()
        {
            await _basePage.ClickElementAsync(Cases);
            _logger.LogInformation($"Clicked on cases");
        }
        public async Task SearchPrimaryDemand(string value)
        {
            await _basePage.FillElementAsync(Filter, value);
            await _page.Keyboard.PressAsync("Enter");
            _logger.LogInformation($"Entered primary demand : {value}");
        }
        public async Task ClickFirstCase()
        {
            await _basePage.ClickElementAsync(FirstCase);
            _logger.LogInformation($"Clicked on first case");
        }
    }
}
