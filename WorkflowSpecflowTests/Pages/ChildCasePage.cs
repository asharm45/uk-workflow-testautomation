using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface IChildCasePage
    {
        Task ClickBackAsync();
        Task ClickCancelAsync();
        Task ClickChildCaseOptionAsync();
        Task ClickNewChildCaseAsync();
        Task ClickSaveAndCloseAsync();
        Task EnterDemandAsync(string demand);
        Task EnterPrimaryDemandAsync(string primaryDemand);
        Task EnterSubDemandAsync(string primaryDemand, string subDemand);
        Task<string> GePolicyReferenceNumberAsync();
        Task<string> GePolicyReferenceNumberLabelAsync();
        Task<string> GetCaseNameAsync();
        Task<string> GetCaseNameLabelAsync();
        Task<string> GetCustomerAsync();
        Task<string> GetCustomerLabelAsync();
        Task<string> GetDemandLabelAsync();
        Task<string> GetOwnerAsync();
        Task<string> GetOwnerLabelAsync();
        Task<string> GetParentCaseAsync();
        Task<string> GetParentCaseLabelAsync();
        Task<string> GetPolicyReferenceAsync();
        Task<string> GetPolicyReferenceLabelAsync();
        Task<string> GetPrimaryDemandLabelAsync();
        Task<string> GetProductAsync();
        Task<string> GetProductLabelAsync();
        Task<string> GetSubDemandLabelAsync();
        Task ClickActiveChildCaseAsync();
    }

    public class ChildCasePage : IChildCasePage
    {
        private readonly IPage _page;
        private readonly IBasePage _basePage;
        private readonly ILogger<ChildCasePage> _logger;
        public ChildCasePage(IPlaywrightDriver driver, IBasePage basePage, ILogger<ChildCasePage> logger)
        {
            _page = driver.Page.Result;
            _basePage = basePage;
            _logger = logger;
        }
        private ILocator Back => _page.Locator("//button[@title='Go back']/span");
        private ILocator ChildCase => _page.Locator("//h3[text()='Child Cases']//following::div//button[@title='More commands for Case']//span[starts-with(@class,'symbolFont')]");
        private ILocator AddChildCase => _page.Locator("//*[text()='New Case']");
        private ILocator ParentCaseLabel => _page.Locator("//label[text()='Parent Case']");
        private ILocator CaseNameLabel => _page.Locator("(//label[text()='Case Name'])[2]");
        private ILocator OwnerLabel => _page.Locator("//label[text()='Owner']");
        private ILocator CustomerLabel => _page.Locator("(//label[text()='Customer'])[2]");
        private ILocator PolicyReferenceNumberLabel => _page.Locator("(//label[text()='Policy Reference Number'])[2]");
        private ILocator PolicyReferenceLabel => _page.Locator("(//label[text()='Policy Reference'])[2]");
        private ILocator PrimaryDemandLabel => _page.Locator("(//label[text()='Primary Demand'])[2]");
        private ILocator DemandLabel => _page.Locator("(//label[text()='Demand'])[2]");
        private ILocator SubDemandLabel => _page.Locator("(//label[text()='Sub Demand'])[2]");
        private ILocator ProductLabel => _page.Locator("(//label[text()='Product'])[2]");
        private ILocator ParentCaseFieldValue => _page.Locator("//div[@data-id='parentcaseid.fieldControl-LookupResultsDropdown_parentcaseid_selected_tag_text']");
        private ILocator CaseNameFieldValue => _page.Locator("(//input[@aria-label='Case Name'])[2]"); //title
        private ILocator OwnerFieldValue => _page.Locator("//div[@data-id='ownerid.fieldControl-LookupResultsDropdown_ownerid_selected_tag_text']");
        private ILocator CustomeFieldValue => _page.Locator("(//div[@data-id='customerid.fieldControl-LookupResultsDropdown_customerid_selected_tag_text'])[2]");
        private ILocator PolicyReferenceNumberFieldValue => _page.Locator("(//input[@aria-label='Policy Reference Number'])[2]");
        private ILocator PolicyReferencFieldValue => _page.Locator("(//div[@data-id='ntt_lookup_policy.fieldControl-LookupResultsDropdown_ntt_lookup_policy_selected_tag_text'])[2]");
        private ILocator ProductFieldValue => _page.Locator("//div[@title='Property']");
        private ILocator PrimaryDemandFieldValue => _page.Locator("(//div[@id='divTreeView']/input)[2]");
        private ILocator DemandFieldValue => _page.Locator("//input[@data-id='ntt_lookup_demand.fieldControl-LookupResultsDropdown_ntt_lookup_demand_textInputBox_with_filter_new']");
        private ILocator SubDemandFieldValue => _page.Locator("//input[@data-id='ntt_lookup_subdemand.fieldControl-LookupResultsDropdown_ntt_lookup_subdemand_textInputBox_with_filter_new']");
        private ILocator SaveAndClose => _page.Locator("//button[@aria-label='Save and Close']");
        private ILocator Cancel => _page.Locator("//button[@data-id='quickCreateCancelBtn']");
        private ILocator ActiveChildCase => _page.Locator("//button[@type='button']//span[text()='Active']");
        public async Task ClickActiveChildCaseAsync()
        {
            await _basePage.ClickElementAsync(ActiveChildCase);
            _logger.LogInformation($"Clicked active child case");
        }
        public async Task ClickBackAsync()
        {
            await _basePage.ClickElementAsync(Back);
            _logger.LogInformation($"Clicked on back button");
        }
        public async Task ClickChildCaseOptionAsync()
        {
            await _basePage.ClickElementAsync(ChildCase);
            _logger.LogInformation($"Clicked three dots to add a child case");
        }
        public async Task ClickNewChildCaseAsync()
        {
            await _basePage.ClickElementAsync(AddChildCase);
            _logger.LogInformation($"Clicked on new case button");
        }
        public async Task<string> GetParentCaseLabelAsync()
        {
            return await ParentCaseLabel.TextContentAsync();
        }
        public async Task<string> GetCaseNameLabelAsync()
        {
            return await CaseNameLabel.TextContentAsync();
        }
        public async Task<string> GetOwnerLabelAsync()
        {
            return await OwnerLabel.TextContentAsync();
        }
        public async Task<string> GetCustomerLabelAsync()
        {
            return await CustomerLabel.TextContentAsync();
        }
        public async Task<string> GePolicyReferenceNumberLabelAsync()
        {
            return await PolicyReferenceNumberLabel.TextContentAsync();
        }
        public async Task<string> GetPolicyReferenceLabelAsync()
        {
            return await PolicyReferenceLabel.TextContentAsync();

        }
        public async Task<string> GetPrimaryDemandLabelAsync()
        {
            return await PrimaryDemandLabel.TextContentAsync();
        }
        public async Task<string> GetSubDemandLabelAsync()
        {
            await _basePage.PressKeyAsync(SubDemandLabel, "PageDown");
            return await SubDemandLabel.TextContentAsync();
        }
        public async Task<string> GetDemandLabelAsync()
        {
            return await DemandLabel.TextContentAsync();
        }
        public async Task<string> GetProductLabelAsync()
        {
            await _basePage.PressKeyAsync(ProductLabel, "PageDown");
            return await ProductLabel.TextContentAsync();
        }

        public async Task<string> GetParentCaseAsync()
        {
            return await ParentCaseFieldValue.TextContentAsync();
        }
        public async Task<string> GetCaseNameAsync()
        {
            return await CaseNameFieldValue.GetAttributeAsync("title");
        }
        public async Task<string> GetOwnerAsync()
        {
            return await OwnerFieldValue.TextContentAsync();
        }
        public async Task<string> GetCustomerAsync()
        {
            return await CustomeFieldValue.TextContentAsync();
        }
        public async Task<string> GePolicyReferenceNumberAsync()
        {
            return await PolicyReferenceNumberFieldValue.GetAttributeAsync("title");
        }
        public async Task<string> GetPolicyReferenceAsync()
        {
            return await PolicyReferencFieldValue.TextContentAsync();
        }
        public async Task<string> GetProductAsync()
        {
            return await ProductFieldValue.TextContentAsync();
        }
        public async Task EnterPrimaryDemandAsync(string primaryDemand)
        {
            Thread.Sleep(1000);
            await _basePage.FillElementAsync(PrimaryDemandFieldValue, primaryDemand);
            await _page.Locator("//div[@title='" + primaryDemand + "']/div/div").First.ScrollIntoViewIfNeededAsync();
            await _page.Locator("//div[@title='" + primaryDemand + "']/div/div").First.ClickAsync();
            _logger.LogInformation($"Entered primary demand field : {primaryDemand}");
        }
        public async Task EnterDemandAsync(string demand)
        {
            Thread.Sleep(1000);
            await _basePage.FillElementAsync(DemandFieldValue, demand);
            await _page.Locator("//span[text()='" + demand + "']").First.ScrollIntoViewIfNeededAsync();
            await _page.Locator("//span[text()='" + demand + "']").First.ClickAsync();
            _logger.LogInformation($"Entere demand field : {demand}");
        }
        public async Task EnterSubDemandAsync(string primaryDemand, string subDemand)
        {
            Thread.Sleep(1000);
            if (!primaryDemand.Equals("Error Management"))
            {
                await _basePage.FillElementAsync(SubDemandFieldValue, subDemand);
                await _page.Locator("//span[text()='" + subDemand + "']").First.ScrollIntoViewIfNeededAsync();
                await _page.Locator("//span[text()='" + subDemand + "']").First.ClickAsync();
                _logger.LogInformation($"Entered sub demand field : {subDemand}");
            }
        }
        public async Task ClickSaveAndCloseAsync()
        {
            await _basePage.ClickElementAsync(SaveAndClose);
            _logger.LogInformation($"Clicked close&save button");
        }
        public async Task ClickCancelAsync()
        {
            await _basePage.ClickElementAsync(Cancel);
            _logger.LogInformation($"Clicked cancel button");
        }
    }
}
