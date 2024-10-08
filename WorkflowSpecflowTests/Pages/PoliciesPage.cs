using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface IPoliciesPage
    {
        Task ClickDeleteAsync();
        Task ClickPoliciesAsync();
        Task ClickSaveAndCloseAsync();
        Task ClickSaveAsync();
        Task ClickNewAsync();
        Task EnterMotorSumInsuredAsync(string motorSumInsured);
        Task EnterMotorTotalInsuredAsync(string motorTotalInsured);
        Task EnterPolicyReferenceAsync(string policyRef);
        Task EnterSumInsuredAsync(string sumInsured);
        Task EnterExcessesAsync(string excesses);
        Task EnterRiskAddressAsync(string riskAddress);
        Task PolicyEndDateAsync(string endDate);
        Task PolicyInceptionDateAsync(string inceptionDate);
        Task PolicyRenewalDateAsync(string renewalDate);
        Task PolicyStartDateAsync(string startDate);
        Task SelectChannelAsync(string channel);
        Task SelectPASFlagAsync(string pasFlag);
        Task ReadOnly();
        Task FilterPolicyAndClick(string policy);
        Task DateCalculation();        
    }

    public class PoliciesPage : IPoliciesPage
    {
        private readonly IPage _page;
        private readonly IBasePage _basePage;
        private readonly ILogger<PoliciesPage> _logger;
        public PoliciesPage(IPlaywrightDriver driver, IBasePage basePage, ILogger<PoliciesPage> logger)
        {
            _page = driver.Page.Result;
            _basePage = basePage;
            _logger = logger;
        }
        private ILocator PolicyReferenceSearch => _page.Locator("//div[text()='Policy Reference']/following::i[1]");
        private ILocator FilterBy => _page.Locator("//span[text()='Filter by']");

        private ILocator FilterByValueField => _page.Locator("//input[@aria-label='Filter by value']");
        private ILocator ApplyButton => _page.Locator("//span[text()='Apply']");

        private ILocator ReadOnlyField => _page.Locator("//span[@id='des-formReadOnlyNotification']");
        private ILocator Policies => _page.Locator("//span[text()='Policies']");
        private ILocator New => _page.Locator("//span[text()='New']");
        private ILocator Delete => _page.Locator("//span[text()='Delete']");
        private ILocator Save => _page.Locator("//span[text()='Save']");
        private ILocator SaveAndClose => _page.Locator("//span[text()='Save & Close']");
        private ILocator PoliciesRefLabel => _page.Locator("//label[text()='Policy Reference']");
        private ILocator ChannelLabel => _page.Locator("//label[text()='Channel']");
        private ILocator PolicyReferenceField => _page.Locator("//input[@aria-label='Policy Reference']");
        private ILocator SumInsuredField => _page.Locator("//input[@aria-label='Sum Insured']");
        private ILocator MotorSumInsuredField => _page.Locator("//input[@aria-label='Motor sum insured']");
        private ILocator MotorTotalInsuredField => _page.Locator("//input[@aria-label='Motor total sum insured (single address)']");
        private ILocator ChannelField => _page.Locator("//button[@aria-label='Channel']");
        private ILocator PolicyStartDate => _page.Locator("//input[@aria-label='Date of Policy Start Date']");
        private ILocator PolicyEndDate => _page.Locator("//input[@aria-label='Date of Policy End Date']");
        private ILocator PolicyInceptionDate => _page.Locator("//input[@aria-label='Date of Inception Date']");
        private ILocator PolicRenewalDate => _page.Locator("//input[@aria-label='Date of Policy Renewal Date']");
        private ILocator RiskAddress => _page.Locator("//textarea[@aria-label='Risk Address']");
        private ILocator Excesses => _page.Locator("//input[@aria-label='Excesses']");
        private ILocator PASFlag => _page.Locator("//button[@aria-label='PAS Flag']");

        public async Task ClickPoliciesAsync()
        {
            await _basePage.ClickElementAsync(Policies);
            _logger.LogInformation($"Clicked on policies");
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
            _logger.LogInformation($"Clicked on save&close");
        }
        public async Task EnterPolicyReferenceAsync(string policyRef)
        {
            await _basePage.FillElementAsync(PolicyReferenceField, policyRef);
            _logger.LogInformation($"Entered policies reference : {policyRef}");
        }
        public async Task EnterSumInsuredAsync(string sumInsured)
        {
            await PoliciesRefLabel.ClickAsync();
            _logger.LogInformation($"Clicked on policiesRef label");
            Thread.Sleep(2000);
            await ChannelLabel.ClickAsync();
            _logger.LogInformation($"Clicked on channel label");
            await _page.Mouse.WheelAsync(0, 600);
            await _basePage.FillElementAsync(SumInsuredField, sumInsured);
            _logger.LogInformation($"Entered sum insured : {sumInsured}");
        }
        public async Task EnterMotorSumInsuredAsync(string motorSumInsured)
        {
            await _page.Mouse.WheelAsync(0, 500);
            await _basePage.FillElementAsync(MotorSumInsuredField, motorSumInsured);
            _logger.LogInformation($"Entered motor sum insured : {motorSumInsured}");
        }
        public async Task EnterMotorTotalInsuredAsync(string motorTotalInsured)
        {
            await _page.Mouse.WheelAsync(0, 500);
            await _basePage.FillElementAsync(MotorTotalInsuredField, motorTotalInsured);
            _logger.LogInformation($"Entered motor total insured : {motorTotalInsured}");
        }
        public async Task SelectChannelAsync(string channel)
        {
            await _basePage.ClickElementAsync(ChannelField);
            await _page.Locator("//*[text()='" + channel + "']").First.ClickAsync();
            _logger.LogInformation($"Selected channel : {channel}");
        }
        public async Task PolicyStartDateAsync(string startDate)
        {
            await _page.Mouse.WheelAsync(0, 200);
            await _basePage.FillElementAsync(PolicyStartDate, startDate);
            _logger.LogInformation($"Entered policy start date : {startDate}");
        }
        public async Task PolicyEndDateAsync(string endDate)
        {
            await _page.Mouse.WheelAsync(0, 200);
            await _basePage.FillElementAsync(PolicyEndDate, endDate);
            _logger.LogInformation($"Entered policy ens date : {endDate}");
        }
        public async Task PolicyInceptionDateAsync(string inceptionDate)
        {
            await _page.Mouse.WheelAsync(0, 200);
            await _basePage.FillElementAsync(PolicyInceptionDate, inceptionDate);
            _logger.LogInformation($"Entered policy inception date : {inceptionDate}");
        }
        public async Task PolicyRenewalDateAsync(string renewalDate)
        {
            await _page.Mouse.WheelAsync(0, 200);
            await _basePage.FillElementAsync(PolicRenewalDate, renewalDate);
            _logger.LogInformation($"Entered policy renewal date : {renewalDate}");
        }
        public async Task EnterRiskAddressAsync(string riskAddress)
        {
            await _page.Mouse.WheelAsync(0, 200);
            await _basePage.FillElementAsync(RiskAddress, riskAddress);
            _logger.LogInformation($"Entered risk Address : {riskAddress}");
        }
        public async Task EnterExcessesAsync(string excesses)
        {
            await _page.Mouse.WheelAsync(0, 200);
            await _basePage.FillElementAsync(Excesses, excesses);
            _logger.LogInformation($"Entered excesses : {excesses}");
        }
        public async Task SelectPASFlagAsync(string pasFlag)
        {
            await _page.Mouse.WheelAsync(0, 200);
            await _basePage.ClickElementAsync(PASFlag);
            await _page.Locator("//*[text()='" + pasFlag + "']").First.ClickAsync();
            _logger.LogInformation($"Selected PAS flag : {pasFlag}");
        }
        public async Task ReadOnly()
        {
            await _basePage.IsElementVisibleAsync(ReadOnlyField);
        }
        public async Task FilterPolicyAndClick(string policy)
        {
            await _basePage.ClickElementAsync(PolicyReferenceSearch);
            await _basePage.ClickElementAsync(FilterBy);
            await _basePage.ClickElementAsync(FilterByValueField);
            await _basePage.FillElementAsync(FilterByValueField, policy);
            await _basePage.ClickElementAsync(ApplyButton);
            await _page.Locator("//span[text()='" + policy + "']").First.ClickAsync();

        }
        public async Task DateCalculation()
        {
            var dateText = await _page.Locator("//label[text()='Policy Renewal Date']/following::input[1]").InnerTextAsync();
            DateTime xpathDate = DateTime.Parse(dateText);
            DateTime systemTime = DateTime.Now.Date;
            int daysToRenewal = (xpathDate - systemTime).Days;

            var DaysToRenewalField = await _page.Locator("//label[text()='Days to Renewal']/following::input[1].").InnerTextAsync();
            int ParsedDays = int.Parse(DaysToRenewalField);
            Thread.Sleep(1500);
            if (daysToRenewal != ParsedDays)
            {
                throw new Exception("Renewal Days are wrong");
            } 

        }
    }
}
