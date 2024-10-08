using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WorkflowSpecflowTests.Config;
using WorkflowSpecflowTests.Pages;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.StepDefinitions
{
    [Binding]
    public class ContactCaseStepDefinition
    {
        
        private readonly ScenarioContext _scenarioContext;
        private readonly Users _user;
        private readonly IDynamicsLoginPage _dynamicsLoginPage;
        private readonly IContactPage _contactPage;
        private readonly ICommonStepDefiniation _commonStep;


        public ContactCaseStepDefinition(ScenarioContext scenarioContext, Users users, IDynamicsLoginPage dynamicsLoginPage, IContactPage contactPage, ICommonStepDefiniation commonStep)
        {
         
            _scenarioContext = scenarioContext;
            _user = users;
            _dynamicsLoginPage = dynamicsLoginPage;
            _contactPage = contactPage;
            _commonStep = commonStep;

        }
        [Given(@"User logged in to Dynamics application with '([^']*)' and '([^']*)' for Contacts")]
        public async Task GivenUserLoggedInDynamicsApplicationWithAndForContacts(string team, string role)
        {
            await _dynamicsLoginPage.EnterDynamincsCredentials(team, role);
            await _dynamicsLoginPage.ClickNext();
            
        }


        [Given(@"User validates The sitemap menu")]
        public async Task GivenUserValidatesTheSitemapMenu()
        {
            await _commonStep.ValidateSiteMap();
        }

        [Given(@"User Clicks on Contacts from Customers AreaGroup")]
        public async Task GivenUserClicksOnContactsFromCustomersAreaGroup()
        {
            await _contactPage.ClickContact();
        }

        [Given(@"User Clicks on New button")]
        public async Task GivenUserClicksOnNewButton()
        {
            await _contactPage.ClickNew();
        }


        [Then(@"User Enters '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public async Task ThenUserEnters(string contactId, string firstName, string surName, string email, string telephoneNumber, string broker, string brokerAddress, string brokerRegion, string brokerArea, string focusVsCore, string postCode)
        {
            await _contactPage.EnterContactDetails(contactId, firstName, surName, email, telephoneNumber, broker, brokerAddress, brokerRegion, brokerArea,focusVsCore,postCode);
        }

        [Then(@"User Enters Contact details as '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public async Task ThenUserEntersContactDetailsAs(string firstName, string surName, string email, string street, string houseNr)
        {
            await _contactPage.EnterFirstNameAsync(firstName);
            await _contactPage.EnterSurNameAsync(surName);
            await _contactPage.EnterEmailAsync(email);
            await _contactPage.EnterStreetAsync(street);
            await _contactPage.EnterHouseNumberAsync(houseNr);
        }
        [Then(@"Validate other fields are present for broker contact")]
        public async Task ThenValidateOtherFieldsArePresentForBrokerContact()
        {
            await _contactPage.ValidateContactFieldPresent();
        }


        [Then(@"Validate Post Code is Present")]
        public async Task ThenValidatePostCodeIsPresent()
        {
            await _contactPage.PostCodeReplacement();
        }

        [Then(@"User Clicks on Save")]
        public async Task ThenUserClicksOnSave()
        {
            await _contactPage.PressSave();
        }

        [Then(@"User Navigates to My Active Contacts dashboard")]
        public async Task ThenUserNavigatesToMyActiveContactsDashboard()
        {
            await _contactPage.ClickContact();
        }

        [Then(@"Validate the Contact By Clicking '([^']*)'")]
        public async Task ThenValidateTheContactAndDeleteIt(string firstName)
        {
            await _contactPage.ValidateAndDelete(firstName);
        }

        [Given(@"User Selects the Contact '([^']*)'")]
        public async Task GivenUserSelectsTheContact(string contactName)
        {
            await _contactPage.ClickNewlyCreatedContactAsync(contactName);
        }

        [Given(@"User filters contacts '([^']*)'")]
        public async Task GivenUserFiltersContacts(string contactName)
        {
            await _contactPage.ClickContactDropdownAsync();
            await _contactPage.ClickAllContactAsync();
            await _contactPage.FilterContact(contactName);
            await _contactPage.ClickFullNameAsync(contactName);
        }

        [Then(@"New Page will display queue details")]
        public async Task ThenNewPageWillDisplayQueueDetails()
        {
            
        }


        [Then(@"User Selects Related")]
        public async Task ThenUserSelectsRelated()
        {
            await _contactPage.ClickOnRelated();
        }

        [Then(@"Selects Activities")]
        public async Task ThenSelectsActivities()
        {
            await _contactPage.ClickOnRelatedActivities();
        }

        [Then(@"User Validates the Task '([^']*)'")]
        public async Task ThenUserValidatesTheTask(string DemandTask)
        {
            await _contactPage.TaskPresentInRelatedActivities(DemandTask);
        }

        [Then(@"Selects Cases")]
        public async Task ThenSelectsCases()
        {
            await _contactPage.ClickOnRelatedCases();
        }

        [Then(@"User Validates the Case '([^']*)'")]
        public async Task ThenUserValidatesTheCase(string CaseName)
        {
            await _contactPage.CasePresentInRelatedCases(CaseName);
        }





    }
}