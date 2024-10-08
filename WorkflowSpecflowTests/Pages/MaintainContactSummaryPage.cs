using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface IMaintainContactSummaryPage
    {
        Task EnterAddressDeatils();
        Task EnterContactBasicDeatils();
        Task EnterEmailDeatils();
        Task EnterPhoneDetails();
        Task ClickNextButton();
        Task EnterCommunicationPreferencesDeatils();
    }

    public class MaintainContactSummaryPage : IMaintainContactSummaryPage
    {
        private readonly IPage _page;
        private readonly IBasePage _basePage;
        private readonly ILogger<MaintainContactSummaryPage> _logger;
        public MaintainContactSummaryPage(IPlaywrightDriver driver, IBasePage basePage, ILogger<MaintainContactSummaryPage> logger)
        {
            _page = driver.Page.Result;
            _basePage = basePage;
            _logger = logger;
        }

        private ILocator SelectIndividualDropdown => _page.Locator("//span[@id='select2-chosen-1']/following-sibling::span/b");
        private ILocator SelectIndividual => _page.Locator("//div[text()='Individual']");

        private ILocator SurnameTextbox => _page.Locator("#LastName");
        private ILocator FirstnameTextbox => _page.Locator("#FirstName");

        private ILocator SelectCountryDropdown => _page.Locator("//span[@id='select2-chosen-1']/following-sibling::span/b");
        //AL13QQ
        private ILocator PostcodeTextbox => _page.Locator("//input[@id=\"IDITForm@primaryAddressForDisplay@GB@addressVO@zipCode\"]");
        private ILocator FindButton => _page.Locator("#Find");
        private ILocator SelectAddressDropdown => _page.Locator("//span[@id='select2-chosen-8']/following-sibling::span/b");
        private ILocator SelectAddress => _page.Locator("//ul[@role='listbox' and @id='select2-results-8']//li[2]/div");
        //01234567890
        private ILocator SelectTelephoneDropdown => _page.Locator("//span[@id='select2-chosen-9']/following-sibling::span/b");
        private ILocator SelectTelephone => _page.Locator("//div[text()='Mobile']");
        private ILocator TelephoneTextbox => _page.Locator("//*[@id=\"IDITForm@primaryTelephoneForDisplaytelephoneNumber\"]");
        private ILocator SelectNumberPreferenceDropdown => _page.Locator("//span[@id='select2-chosen-11']/following-sibling::span/b");
        private ILocator SelectNumberPreference => _page.Locator("//div[text()='Primary']");
        //Test@Hiscox.com
        private ILocator SelectEmailTypeDropdown => _page.Locator("//span[@id='select2-chosen-12']/following-sibling::span/b");
        private ILocator SelectEmailType => _page.Locator("//div[text()='Work']");
        private ILocator EmailTextbox => _page.Locator("//*[@id=\"IDITForm@primaryEmailForDisplay@email\"]");
        private ILocator SelectPreferredContactDropdown => _page.Locator("//span[@id='select2-chosen-13']/following-sibling::span/b");

        private ILocator SelectPreferredContact => _page.Locator("//div[text()='Phone']");

        private ILocator SelectDocumentDipatchPreferenceDropdown => _page.Locator("//span[@id='select2-chosen-14']/following-sibling::span/b");

        private ILocator SelectDocumentDipatchPreference => _page.Locator("//div[text()='Email']");

        private ILocator NextButton => _page.Locator("//*[@id=\"Next\"]");

        public async Task EnterContactBasicDeatils()
        {
            await _basePage.ClickElementAsync(SelectIndividualDropdown);
            _logger.LogInformation($"Clicked Individual dropdown");
            await _basePage.ClickElementAsync(SelectIndividual);
            _logger.LogInformation($"Selected Individual");
            await _basePage.FillElementAsync(SurnameTextbox, "Workflow");
            _logger.LogInformation($"Entered Surname : Workflow");
            await _basePage.FillElementAsync(FirstnameTextbox, "Test");
            _logger.LogInformation($"Entered Firstname : Test");
        }

        public async Task EnterAddressDeatils()
        {
            await _basePage.FillElementAsync(PostcodeTextbox, "AL13QQ");
            _logger.LogInformation($"Entered post code : AL13QQ");
            await _basePage.ClickElementAsync(FindButton);
            _logger.LogInformation($"Clicked find button");
            await _basePage.ClickElementAsync(SelectAddressDropdown);
            _logger.LogInformation($"Clicked Address dropdown");
            await _basePage.ClickElementAsync(SelectAddress);
            _logger.LogInformation($"Selected address");
        }

        public async Task EnterPhoneDetails()
        {
            await _basePage.ClickElementAsync(SelectTelephoneDropdown);
            _logger.LogInformation($"Clicked telephone dropdown");
            await _basePage.ClickElementAsync(SelectTelephone);
            _logger.LogInformation($"Selected telephone");
            await _basePage.ClickElementAsync(SelectNumberPreferenceDropdown);
            _logger.LogInformation($"Clicked Number Preference dropdown");
            await _basePage.ClickElementAsync(SelectNumberPreference);
            _logger.LogInformation($"Selected Number Preference");
            await _basePage.FillElementAsync(TelephoneTextbox, "01234567890");
            _logger.LogInformation($"Entered phone number : 01234567890");
        }

        public async Task EnterEmailDeatils()
        {
            await _basePage.ClickElementAsync(SelectEmailTypeDropdown);
            _logger.LogInformation($"Clicked Email type dropdown");
            await _basePage.ClickElementAsync(SelectEmailType);
            _logger.LogInformation($"Selected email type");
            await _basePage.FillElementAsync(EmailTextbox, "Test@Hiscox.com");
            _logger.LogInformation($"Entered email address : Test@Hiscox.com");
        }

        public async Task EnterCommunicationPreferencesDeatils()
        {
            await _basePage.ClickElementAsync(SelectPreferredContactDropdown);
            _logger.LogInformation($"Clicked Preferred Contact dropdown");
            await _basePage.ClickElementAsync(SelectPreferredContact);
            _logger.LogInformation($"Selected Preferred Contact");
            await _basePage.ClickElementAsync(SelectDocumentDipatchPreferenceDropdown);
            _logger.LogInformation($"Clicked Document Dipatch Preference dropdown");
            await _basePage.ClickElementAsync(SelectDocumentDipatchPreference);
            _logger.LogInformation($"Selected Document Dipatch Preference");

        }

        public async Task ClickNextButton()
        {
            await _basePage.ClickElementAsync(NextButton);
            _logger.LogInformation($"Clicked on next button");
        }

    }
}
