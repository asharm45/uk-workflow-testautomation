using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface IContactPage
    {
        Task CasePresentInRelatedCases(string CaseName);
        Task ClickContact();
        Task ClickContactTypeDropdown();
        Task ClickDeactivateAsync();
        Task ClickDelete();
        Task ClickDetailsTab();
        Task ClickGeneralInformationAsync();
        Task ClickNew();
        Task ClickNewlyCreatedContactAsync(string contactName);
        Task ClickOnRelated();
        Task ClickOnRelatedActivities();
        Task ClickOnRelatedCases();
        Task ClickRefresh();
        Task ClickSaveAndCloseAsync();
        Task ClickSaveAsync();
        Task ClickSummaryTab();
        Task ConfirmDeactivateAsync();
        Task EnterBrokerAreaAsync(string brokerArea);
        Task EnterBrokerAsync(string broker);
        Task EnterBrokerRegionAsync(string brokerRegion);
        Task EnterContactDetails(string contactId, string firstName, string surName, string email, string telephoneNumber, string broker, string brokerAddress, string brokerRegion, string brokerArea, string focusVsCore, string postCode);
        Task EnterContactIDAsync(string contactId);
        Task EnterEmailAsync(string email);
        Task EnterFirstNameAsync(string firstName);
        Task EnterPostCodeAsync(string postCode);
        Task EnterSurNameAsync(string surName);
        Task EnterTelephoneNumberAsync(string telephoneNumber);
        Task FilterContact(string contactName);
        Task PostCodeReplacement();
        Task PressSave();
        Task SelectNewlyCreatedContactAsync(string contactName);
        Task TaskPresentInRelatedActivities(string DemandTask);
        Task ValidateAndDelete(string firstName);
        Task EnterStreetAsync(string street);
        Task EnterHouseNumberAsync(string houseNr);
        Task ValidateContactFieldPresent();
        Task ClickFullNameAsync(string contact);
        Task ClickContactDropdownAsync();
        Task ClickAllContactAsync();
    }

    public class ContactPage : IContactPage
    {
        private readonly IPage _page;
        private readonly IBrowserContext _browserContext;
        private readonly IBasePage _basePage;
        private readonly ILogger<ContactPage> _logger;
        public ContactPage(IPlaywrightDriver driver, IBasePage basePage, ILogger<ContactPage> logger)
        {
            _page = driver.Page.Result;
            _browserContext = driver.BrowserContext.Result;
            _basePage = basePage;
            _logger = logger;
        }

        private ILocator RelatedCases => _page.Locator("//div[text()='Related - Service']//following-sibling::div[@role='menuitem'][@aria-label='Cases']");
        private ILocator RelatedActivites => _page.Locator("//div[@role='menuitem'][@aria-label='Activities']");
        private ILocator Related => _page.Locator("//div[text()='Related']/span");
        private ILocator DuplicateRecordsFound => _page.Locator("//h1[@aria-label='Duplicate records found']");
        private ILocator CloseBtn => _page.Locator("//button[@title='Close']");
        private ILocator SaveBtn => _page.Locator("//span[text()='Save']");
        private ILocator Contact => _page.Locator("//span[text()='Contacts']");
        private ILocator New => _page.Locator("//span[text()='New']");
        private ILocator Save => _page.Locator("//span[text()='Save']");
        private ILocator SaveAndClose => _page.Locator("//span[text()='Save & Close']");
        private ILocator Delete => _page.Locator("//span[text()='Delete']");
        private ILocator Refresh => _page.Locator("//span[text()='Refresh']");
        private ILocator SummaryTab => _page.Locator("//li[text()='Summary']");
        private ILocator DetailsTab => _page.Locator("//li[text()='Details']");
        private ILocator Deactivate => _page.Locator("//span[text()='Deactivate']");
        private ILocator ConfirmDeactivate => _page.Locator("//button[@title='Deactivate']");
        private ILocator ContactTypeDropdown => _page.Locator("//button[@aria-label='Contact Type']");
        private ILocator ContactIDField => _page.Locator("//label[text()='Contact ID']/following::input[1]");
        private ILocator FirstNameField => _page.Locator("//label[text()='First Name']/following::input[1]");
        private ILocator SurNameField => _page.Locator("//label[text()='Surname']/following::input[1]");
        private ILocator EmailField => _page.Locator("//label[text()='Email']/following::input[1]");
        private ILocator StreetField => _page.Locator("//input[@aria-label='Street']");
        private ILocator HouseNrField => _page.Locator("//input[@aria-label='House Nr']");
        private ILocator PostCodeField => _page.Locator("//label[text()='Post Code']/following::input[1]");
        private ILocator TelephoneNumberField => _page.Locator("//label[text()='Telephone Number']/following::input[1]");
        private ILocator BrokerField => _page.Locator("//label[text()='Broker']/following::input[1]");
        private ILocator BrokerAreaField => _page.Locator("//label[text()='Broker Area']/following::input[1]");
        private ILocator BrokerRegionField => _page.Locator("//label[text()='Broker Region']/following::input[1]");
        private ILocator FocusVsCoreField => _page.Locator("//label[text()='Focus vs Core']/following::button[1]");
        private ILocator CoreOption => _page.Locator("//div[text()='Core']");
        private ILocator IgnoreAndSaveBtn => _page.Locator("//button[text()='Ignore and save']");
        private ILocator GeneralInformation => _page.Locator("//h2[@title='GENERAL INFORMATION']");
        private ILocator FirstName => _page.Locator("//input[@aria-label='First Name']");
        private ILocator LastName => _page.Locator("//input[@aria-label='Surname']");
        private ILocator Filter => _page.Locator("//input[@placeholder='Filter by keyword']");
        private ILocator ContactType => _page.Locator("//label[text()='Contact Type']//following::button[1]");
        private ILocator CorrespondenceAddressField => _page.Locator("//label[text()='Correspondence Address']//following::input[1]");
        private ILocator BrokerageField => _page.Locator("//label[text()='Brokerage']//following::input[1]");
        private ILocator MasterBrokerField => _page.Locator("//label[text()='Master Broker']//following::input[1]");
        private ILocator HUNumberField => _page.Locator("//label[text()='HU Number']//following::input[1]");
        private ILocator BrokerSegmentationField => _page.Locator("//label[text()='Broker Segmentation']//following::input[1]");
        private ILocator ClientField => _page.Locator("//label[text()='Client']//following::input[1]");
        private ILocator AcceptSuggestionsBtn => _page.Locator("//button[@aria-label='Accept all suggestions']");
        private ILocator Dropdown => _page.Locator("//span[@data-automationid='splitbuttonprimary']//i[@data-icon-name='ChevronDown']");
        private ILocator AllContacts => _page.Locator("//label[text()='All Contacts']");


        public async Task ClickContact()
        {
            await _basePage.ClickElementAsync(Contact);
            _logger.LogInformation($"Clicked on contact button");
        }
        public async Task ClickNew()
        {
            if (await _page.Locator("//button[@aria-label='Copilot']//img").IsVisibleAsync())
            {
                await _page.Locator("//button[@aria-label='Copilot']//img").ClickAsync();
            }
            await _basePage.ClickElementAsync(New);
            _logger.LogInformation($"Clicked on new button");
        }
        public async Task ClickDelete()
        {
            await _basePage.ClickElementAsync(Delete);
            _logger.LogInformation($"Clicked on delete button");
        }
        public async Task ClickRefresh()
        {
            await _basePage.ClickElementAsync(Refresh);
            _logger.LogInformation($"Clicked on refresh button");
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
        public async Task ClickSummaryTab()
        {
            await _basePage.ClickElementAsync(SummaryTab);
            _logger.LogInformation($"Clicked on summay tab button");
        }
        public async Task ClickDetailsTab()
        {
            await _basePage.ClickElementAsync(DetailsTab);
            _logger.LogInformation($"Clicked on details tab button");
        }
        public async Task ClickContactTypeDropdown()
        {
            await _basePage.ClickElementAsync(ContactTypeDropdown);
            _logger.LogInformation($"Clicked on contact type dropdown");
        }
        public async Task EnterContactDetails(string contactId, string firstName, string surName, string email, string telephoneNumber, string broker, string brokerAddress, string brokerRegion, string brokerArea, string focusVsCore, string postCode)
        {
            await _basePage.FillElementAsync(ContactIDField, contactId);
            _logger.LogInformation($"Entered contact id : {contactId}");
            Thread.Sleep(500);
            if (await AcceptSuggestionsBtn.IsVisibleAsync())
            {
                await _basePage.ClickElementAsync(AcceptSuggestionsBtn);
            }
            await _basePage.FillElementAsync(FirstNameField, firstName);
            _logger.LogInformation($"Entered first name : {firstName}");
            Thread.Sleep(500);
            await _basePage.FillElementAsync(SurNameField, surName);
            _logger.LogInformation($"Entered surName : {surName}");
            Thread.Sleep(500);
            if (await AcceptSuggestionsBtn.IsVisibleAsync())
            {
                await _basePage.ClickElementAsync(AcceptSuggestionsBtn);
            }
            await _basePage.FillElementAsync(EmailField, email);
            _logger.LogInformation($"Entered email id : {email}");
            await _page.Mouse.WheelAsync(0, 50);
            await _basePage.ClickElementAsync(GeneralInformation);
            _logger.LogInformation($"Clicked general information");
            await _basePage.PressKeyAsync(GeneralInformation, "End");
            await _basePage.FillElementAsync(TelephoneNumberField, telephoneNumber);
            _logger.LogInformation($"Entered telephone number : {telephoneNumber}");
            await _page.Locator("//label[text()='Broker']/following::input[1]").ScrollIntoViewIfNeededAsync();
            await _page.Locator("//label[text()='Broker']/following::input[1]").FillAsync(broker);
            _logger.LogInformation($"Entered broker : {broker}");
            //await _basePage.FillElementAsync(BrokerField, broker);
            await _page.Mouse.WheelAsync(0, -200);
            await _basePage.FillElementAsync(BrokerRegionField, brokerRegion);
            _logger.LogInformation($"Entered broker region : {brokerRegion}");
            await _basePage.FillElementAsync(BrokerAreaField, brokerArea);
            _logger.LogInformation($"Entered broker area : {brokerArea}");
            await _basePage.FillElementAsync(PostCodeField, postCode);
            _logger.LogInformation($"Entered post code : {postCode}");
        }
        public async Task EnterContactIDAsync(string contactId)
        {
            if (await AcceptSuggestionsBtn.IsVisibleAsync())
            {
                await _basePage.ClickElementAsync(AcceptSuggestionsBtn);
            }
            await _basePage.FillElementAsync(ContactIDField, contactId);
            _logger.LogInformation($"Entered contact id : {contactId}");
            Thread.Sleep(500);
        }
        public async Task EnterFirstNameAsync(string firstName)
        {
            await _basePage.FillElementAsync(FirstName, firstName);
            _logger.LogInformation($"Entered first name : {firstName}");
            Thread.Sleep(500);
        }
        public async Task EnterSurNameAsync(string surName)
        {
            await _basePage.FillElementAsync(SurNameField, surName);
            _logger.LogInformation($"Entered sur name : {surName}");
            Thread.Sleep(500);
        }
        public async Task EnterEmailAsync(string email)
        {
            await _basePage.FillElementAsync(EmailField, email);
            _logger.LogInformation($"Entered email : {email}");
        }
        public async Task ClickGeneralInformationAsync()
        {
            await _page.Mouse.WheelAsync(0, 50);
            await _basePage.ClickElementAsync(GeneralInformation);
            await _basePage.PressKeyAsync(GeneralInformation, "End");
            _logger.LogInformation($"Clicked general information");
        }
        public async Task EnterTelephoneNumberAsync(string telephoneNumber)
        {
            await _basePage.FillElementAsync(TelephoneNumberField, telephoneNumber);
            _logger.LogInformation($"Entered telephone number : {telephoneNumber}");
        }
        public async Task EnterBrokerAsync(string broker)
        {
            await _page.Locator("//label[text()='Broker']/following::input[1]").ScrollIntoViewIfNeededAsync();
            await _page.Locator("//label[text()='Broker']/following::input[1]").FillAsync(broker);
            _logger.LogInformation($"Entered broker : {broker}");
        }
        public async Task EnterBrokerRegionAsync(string brokerRegion)
        {
            await _page.Mouse.WheelAsync(0, -200);
            await _basePage.FillElementAsync(BrokerRegionField, brokerRegion);
            _logger.LogInformation($"Entered broker region : {brokerRegion}");
        }
        public async Task EnterBrokerAreaAsync(string brokerArea)
        {
            await _basePage.FillElementAsync(BrokerAreaField, brokerArea);
            _logger.LogInformation($"Entered broker are : {brokerArea}");
        }
        public async Task EnterPostCodeAsync(string postCode)
        {
            await _basePage.FillElementAsync(PostCodeField, postCode);
            _logger.LogInformation($"Entered post code : {postCode}");
        }
        public async Task EnterStreetAsync(string street)
        {
            await _basePage.FillElementAsync(StreetField, street);
            _logger.LogInformation($"Entered street : {street}");
        }
        public async Task EnterHouseNumberAsync(string houseNr)
        {
            await _basePage.FillElementAsync(HouseNrField, houseNr);
            _logger.LogInformation($"Entered house number : {houseNr}");
        }
        public async Task PostCodeReplacement()
        {
            await _basePage.IsElementVisibleAsync(PostCodeField);
        }
        public async Task PressSave()
        {
            await _basePage.ClickElementAsync(SaveBtn);
            _logger.LogInformation($"Clicked save button");
            Thread.Sleep(5000);
            if (await DuplicateRecordsFound.IsVisibleAsync())
            {
                await _basePage.ClickElementAsync(DuplicateRecordsFound);
                _logger.LogInformation($"Clciked duplicate records");
                await _basePage.PressKeyAsync(DuplicateRecordsFound, "End");
            }
            if (await IgnoreAndSaveBtn.IsVisibleAsync())
            {
                await _basePage.ClickElementAsync(IgnoreAndSaveBtn);
                _logger.LogInformation($"Clicked ignore and save button");
                Thread.Sleep(2000);
            }
            else
            {
                await _basePage.ClickElementAsync(CloseBtn);
                _logger.LogInformation($"Cliced close button");
            }

        }
        public async Task ValidateAndDelete(string firstName)
        {
            await _page.Locator("//span[starts-with(text(),'" + firstName + "')]").First.IsVisibleAsync();
            await _page.Locator("//span[starts-with(text(),'" + firstName + "')]").First.ClickAsync();
            //Delete function not available for caseWorker
        }

        public async Task ClickDeactivateAsync()
        {
            await _basePage.ClickElementAsync(Deactivate);
            _logger.LogInformation($"Clicked deactivate button");
        }
        public async Task FilterContact(string contactName)
        {
            await _basePage.FillElementAsync(Filter, contactName);
            await _page.Keyboard.PressAsync("Enter");
            _logger.LogInformation($"Entered contact name : {contactName}");
        }
        public async Task ConfirmDeactivateAsync()
        {
            await _basePage.ClickElementAsync(ConfirmDeactivate);
            _logger.LogInformation($"Clicked confirm deactivate");
        }
        public async Task ClickNewlyCreatedContactAsync(string contactName)
        {
            await _page.Locator("//span[text()='" + contactName + "']").First.ClickAsync();
            _logger.LogInformation($"Contact name selected : {contactName}");
        }
        public async Task SelectNewlyCreatedContactAsync(string contactName)
        {
            await _page.Locator("//span[text()='" + contactName + "']//ancestor::div[@col-id='fullname']//preceding-sibling::div//i").ClickAsync();
            _logger.LogInformation($"Newly created contact name selected : {contactName}");
        }
        public async Task ClickOnRelated()
        {
            await _basePage.ClickElementAsync(Related);
            _logger.LogInformation($"Clickedon related");
        }
        public async Task ClickOnRelatedActivities()
        {
            await _basePage.ClickElementAsync(RelatedActivites);
            _logger.LogInformation($"Clicked on related activities");
        }
        public async Task ClickOnRelatedCases()
        {
            await _basePage.PressKeyAsync(Related, "End");
            await _basePage.ClickElementAsync(RelatedCases);
            _logger.LogInformation($"Clicked on related cases");
        }
        public async Task TaskPresentInRelatedActivities(string DemandTask)
        {
            await _page.Mouse.WheelAsync(0, 50);
            await _page.Locator("//span[text()='" + DemandTask + "']").First.IsVisibleAsync();
        }
        public async Task CasePresentInRelatedCases(string CaseName)
        {
            await _page.Mouse.WheelAsync(0, 50);
            await _page.Locator("//span[text()='" + CaseName + "']").First.IsVisibleAsync();
        }
        public async Task ValidateContactFieldPresent()
        {
            await _basePage.IsElementVisibleAsync(ContactType);
            await _basePage.IsElementVisibleAsync(ContactIDField);
            await _basePage.IsElementVisibleAsync(FirstNameField);
            await _basePage.IsElementVisibleAsync(SurNameField);
            await _basePage.IsElementVisibleAsync(EmailField);
            await _basePage.IsElementVisibleAsync(CorrespondenceAddressField);
            await _basePage.IsElementVisibleAsync(PostCodeField);
            await _basePage.IsElementVisibleAsync(TelephoneNumberField);
            await _basePage.IsElementVisibleAsync(BrokerageField);
            await _basePage.IsElementVisibleAsync(BrokerRegionField);
            await _basePage.IsElementVisibleAsync(BrokerAreaField);
            await _basePage.IsElementVisibleAsync(MasterBrokerField);
            await _basePage.IsElementVisibleAsync(HUNumberField);
            await _basePage.IsElementVisibleAsync(BrokerSegmentationField);
            await _basePage.IsElementVisibleAsync(FocusVsCoreField);
            await _basePage.IsElementVisibleAsync(ClientField);
            await _basePage.IsElementVisibleAsync(BrokerField);
        }

        public async Task ClickFullNameAsync(string contact)
        {
            await _page.Locator("(//span[text()='" + contact + "'])[1]").ClickAsync();
            _logger.LogInformation($"Clicked on given contact {contact}");
        }
        public async Task ClickContactDropdownAsync()
        {
            await _basePage.ClickElementAsync(Dropdown);
            _logger.LogInformation($"Clicked on contact dropdown");
        }
        public async Task ClickAllContactAsync()
        {
            await _basePage.ClickElementAsync(AllContacts);
            _logger.LogInformation($"Clicked on all contact");
        }
        
    }
}
