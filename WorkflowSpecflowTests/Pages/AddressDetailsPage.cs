using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface IAddressDetailsPage
    {
        Task EnterAddressDeatils();
        Task EnterContactBasicDeatils();
        Task EnterEmailDeatils();
        Task EnterPhoneDeatils();
        Task ClickNextButton();
        Task EnterCommunicationPreferencesDeatils();
    }

    public class AddressDetailsPage : IAddressDetailsPage
    {
        private readonly IPage _page;
        private readonly IBasePage _basePage;
        private readonly ILogger<AddressDetailsPage> _logger;

        public AddressDetailsPage(IPlaywrightDriver driver, IBasePage basePage, ILogger<AddressDetailsPage> logger)
        {
            _page = driver.Page.Result;
            _basePage = basePage;
            _logger = logger;
        }

        private ILocator AddreddDetailsTab => _page.Locator("//a[text()='Address details']");
        private ILocator AddNewAddress => _page.Locator("//a[@id='IDITForm@contactAddress|New']/i");

        //CV35QQ
        private ILocator PostcodeTextbox => _page.Locator("//input[@id=\"contactAddressVO@GB@addressVO@zipCode\"]");
        private ILocator AddressTypeDropdown => _page.Locator("//span[@id='select2-chosen-34']/following-sibling::span/b");

        private ILocator AddressType => _page.Locator("//di[text()='Billing address']");

        private ILocator SelectAddressDropdown => _page.Locator("//span[@id='select2-chosen-38']/following-sibling::span/b");
        private ILocator SelectAddress => _page.Locator("//ul[@role='listbox' and @id='select2-results-38']//li[2]/div");

        private ILocator FindButton => _page.Locator("#Find");
        private ILocator OkayAddressButton => _page.Locator("//*[@id=\"OKcontactAddressContainer\"]");

        //Phone number
        private ILocator AddNewPhoneNumber => _page.Locator("//a[@id='IDITForm@contactTelephone|New']/i");
        private ILocator SelectTelephoneDropdown => _page.Locator("//span[@id='select2-chosen-64']/following-sibling::span/b");
        private ILocator SelectHomeTelephone => _page.Locator("//div[text()='Home']");
        private ILocator SelectNumberPreferenceDropdown => _page.Locator("//span[@id='select2-chosen-66']/following-sibling::span/b");
        private ILocator SelectNumberPreference => _page.Locator("//div[text()='Secondary']");
        private ILocator TelephoneTextbox => _page.Locator("//*[@id=\"contactTelephoneVOtelephoneNumber\"]");
        private ILocator OkayContactButton => _page.Locator("//*[@id=\"OKcontactPhoneContainer\"]");

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

        }

        public async Task EnterAddressDeatils()
        {
            await _basePage.FillElementAsync(PostcodeTextbox, "AL13QQ");
            _logger.LogInformation("Entered postcode AL13QQ");
            await _basePage.ClickElementAsync(FindButton);
            _logger.LogInformation("Clicked find button");
            await _basePage.ClickElementAsync(SelectAddressDropdown);
            _logger.LogInformation("Clicked on address drop down");
            await _basePage.ClickElementAsync(SelectAddress);
            _logger.LogInformation("Address selected");
        }

        public async Task EnterPhoneDeatils()
        {

        }

        public async Task EnterEmailDeatils()
        {
            await _basePage.ClickElementAsync(SelectEmailTypeDropdown);
            _logger.LogInformation("Clicked emailType dropdown");
            await _basePage.ClickElementAsync(SelectEmailType);
            _logger.LogInformation("Email address selected");
            await _basePage.FillElementAsync(EmailTextbox, "Test@Hiscox.com");
            _logger.LogInformation("Entered email address Test@Hiscox.com");
        }

        public async Task EnterCommunicationPreferencesDeatils()
        {
            await _basePage.ClickElementAsync(SelectPreferredContactDropdown);
            _logger.LogInformation("Clicked Preferred Contact Dropdown");
            await _basePage.ClickElementAsync(SelectPreferredContact);
            _logger.LogInformation("Clicked Preferred Contact");
            await _basePage.ClickElementAsync(SelectDocumentDipatchPreferenceDropdown);
            _logger.LogInformation("Clicked Document Dipatch Preference Dropdown");
            await _basePage.ClickElementAsync(SelectDocumentDipatchPreference);
            _logger.LogInformation("Clicked Document Dipatch Preference");
        }

        public async Task ClickNextButton()
        {
            await _basePage.ClickElementAsync(NextButton);
            _logger.LogInformation("Clicked next button");
        }
    }
}
