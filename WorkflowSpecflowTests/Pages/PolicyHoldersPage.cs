using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface IPolicyHoldersPage
    {
        Task ClickDeleteAsync();
        Task ClickNewAsync();
        Task ClickPolicyHolderAsync();
        Task ClickSaveAndCloseAsync();
        Task ClickSaveAsync();
        Task EnterContactAsync(string firtName, string surName);
        Task EnterPolicyAsync(string policy);
        Task SelectPolicyHolderAsync(string policyHolder);
        Task SelectPrimaryPolicyHolderAsync(string primaryPolicyHolder);
        Task ValidateNewPolicyHolderAsync();
        Task CreatedOnSort();
        Task SelectTheFirstPolicy();
        Task SelectContactAndPolicyRole(string contact, string policyContactRole);
        Task PolicyHolderAndPrimaryAsYes();
    }

    public class PolicyHoldersPage : IPolicyHoldersPage
    {
        private readonly IPage _page;
        private readonly IBasePage _basePage;
        private readonly ILogger<PolicyHoldersPage> _logger;
        public PolicyHoldersPage(IPlaywrightDriver driver, IBasePage basePage, ILogger<PolicyHoldersPage> logger)
        {
            _page = driver.Page.Result;
            _basePage = basePage;
            _logger = logger;
        }
        private ILocator PolicyHolders => _page.Locator("//span[text()='Policy Holders']");
        private ILocator New => _page.Locator("//span[text()='New']");
        private ILocator Delete => _page.Locator("//span[text()='Delete']");
        private ILocator Save => _page.Locator("//span[text()='Save']");
        private ILocator SaveAndClose => _page.Locator("//span[text()='Save & Close']");
        private ILocator Policy => _page.Locator("//input[@aria-label='Policy, Lookup']");
        private ILocator Contact => _page.Locator("//input[@aria-label='Contact, Lookup']");
        private ILocator PolicyContactRole => _page.Locator("//label[text()='Policy Contact Role']//following::input[1]");
        private ILocator PolicyHolder => _page.Locator("//button[@aria-label='Policy Holder']");
        private ILocator PrimaryPolicyHolder => _page.Locator("//button[@aria-label='Primary Policy Holder ']");
        private ILocator EditColumns => _page.Locator("//span[text()='Edit columns']");
        private ILocator AddColumns => _page.Locator("//span[text()='Add columns']");
        private ILocator CreatedOnFieldSelection => _page.Locator("//label[text()='Created On']");
        private ILocator Close => _page.Locator("//span[text()='Close']");
        private ILocator Apply => _page.Locator("//span[text()='Apply']");
        private ILocator CreatedOn => _page.Locator("(//div[text()='Created On'])[1]");
        private ILocator NewerToOlder => _page.Locator("//span[text()='Newer to older']");
        public async Task ClickPolicyHolderAsync()
        {
            await _basePage.ClickElementAsync(PolicyHolders);
            _logger.LogInformation($"Clicked on policy holder");
        }
        public async Task ClickNewAsync()
        {
            await _basePage.ClickElementAsync(New);
            _logger.LogInformation($"Clicked on new button");
        }
        public async Task ClickDeleteAsync()
        {
            await _basePage.ClickElementAsync(Delete);
            _logger.LogInformation($"Clicked on delete button");
        }
        public async Task ClickSaveAsync()
        {
            await _basePage.ClickElementAsync(Save);
            _logger.LogInformation($"Clicked on save button");
        }
        public async Task ClickSaveAndCloseAsync()
        {
            await _basePage.ClickElementAsync(SaveAndClose);
            _logger.LogInformation($"Clicked on save&close button");
        }
        public async Task EnterPolicyAsync(string policy)
        {
            await _basePage.FillElementAsync(Policy, policy);
            await _page.Locator("//span[text()='" + policy + "']").First.ClickAsync();
            _logger.LogInformation($"Entered policy number : {policy}");
        }
        public async Task EnterContactAsync(string firtName, string surName)
        {
            var contact = firtName + " " + surName;
            await _basePage.FillElementAsync(Contact, contact);
            await _page.Locator("//span[text()='" + contact + "']").First.ClickAsync();
            _logger.LogInformation($"Entered contact : {contact}");
        }
        public async Task SelectPolicyHolderAsync(string policyHolder)
        {
            await _basePage.ClickElementAsync(PolicyHolder);
            await _page.Locator("//*[text()='" + policyHolder + "']").First.ClickAsync();
            _logger.LogInformation($"Entered policy holder : {policyHolder}");
        }
        public async Task SelectPrimaryPolicyHolderAsync(string primaryPolicyHolder)
        {
            await _basePage.ClickElementAsync(PrimaryPolicyHolder);
            await _page.Locator("//*[text()='" + primaryPolicyHolder + "']").First.ClickAsync();
            _logger.LogInformation($"Entered primary Policy Holder : {primaryPolicyHolder}");
        }
        public async Task ValidateNewPolicyHolderAsync()
        {
            await _basePage.IsElementVisibleAsync(Policy);
            await _basePage.IsElementVisibleAsync(Contact);
            await _basePage.IsElementVisibleAsync(PolicyContactRole);
            await _basePage.IsElementVisibleAsync(PolicyHolder);
            await _basePage.IsElementVisibleAsync(PrimaryPolicyHolder);
        }
        public async Task CreatedOnSort()
        {
            await _basePage.ClickElementAsync(EditColumns);
            await _basePage.ClickElementAsync(AddColumns);
            await _basePage.ClickElementAsync(CreatedOnFieldSelection);
            await _basePage.ClickElementAsync(Close);
            await _basePage.ClickElementAsync(Apply);
            await _basePage.ClickElementAsync(CreatedOn);
            await _basePage.ClickElementAsync(NewerToOlder);
        }
        public async Task SelectTheFirstPolicy()
        {
            await _page.Locator("//span[@aria-label='Go to record']").First.ClickAsync();
        }
        public async Task SelectContactAndPolicyRole(string contact, string policyContactRole)
        {
            await _basePage.ClickElementAsync(Contact);
            await _basePage.FillElementAsync(Contact, contact);
            await _page.Locator("//span[text()='" + contact + "']").First.ClickAsync();

            await _basePage.ClickElementAsync(PolicyContactRole);
            await _basePage.FillElementAsync(PolicyContactRole, policyContactRole);
            await _page.Locator("//span[text()='" + policyContactRole + "']").First.ClickAsync();

        }
        public async Task PolicyHolderAndPrimaryAsYes()
        {
            await _basePage.ClickElementAsync(PolicyHolder);
            await _page.Locator("//div[text()='Yes']").ClickAsync();

            await _basePage.ClickElementAsync(PrimaryPolicyHolder);
            await _page.Locator("//div[text()='Yes']").ClickAsync();
        }

    }
}