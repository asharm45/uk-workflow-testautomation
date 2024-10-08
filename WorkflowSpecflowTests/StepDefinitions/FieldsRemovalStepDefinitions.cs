using System;
using Microsoft.Playwright;
using TechTalk.SpecFlow;
using WorkflowSpecflowTests.Pages;

namespace WorkflowSpecflowTests.StepDefinitions
{
    [Binding]
    public class FieldsRemovalStepDefinitions
    {
        private readonly ICasesPage _casesPage;
        private readonly IContactPage _contactPage;
        private readonly ILogoutPage _logoutPage;
        private readonly IBasePage _basePage;
        private readonly IUnderwriterAuthorityPage _underwriterAuthority;

        public FieldsRemovalStepDefinitions(ICasesPage casesPage, IContactPage contactPage, ILogoutPage logoutPage, IBasePage basePage, IUnderwriterAuthorityPage  underwriterAuthority)
        {
            _casesPage = casesPage;
            _contactPage = contactPage;
            _logoutPage = logoutPage;
            _basePage = basePage;
            _underwriterAuthority = underwriterAuthority;
        }

        [Then(@"User clicks on summary tab")]
        public async Task ThenUserClicksOnSummaryTab()
        {
            await _casesPage.ClickOnSummaryTab();
        }

        [Then(@"User validates if fields Days OOS ""([^""]*)"" Effective Date of Change ""([^""]*)"" Urgent flag ""([^""]*)"" are not displayed")]
        public async Task ThenUserValidatesIfFieldsDaysOOSEffectiveDateOfChangeUrgentFlagAreNotDisplayed(string daysOOS, string effectiveDateOfChange, string urgentFlag)
        {
            Assertions.Equals(await _casesPage.GetLabelCount(daysOOS), 0);
            Assertions.Equals(await _casesPage.GetLabelCount(effectiveDateOfChange), 0);
            Assertions.Equals(await _casesPage.GetLabelCount(urgentFlag), 0);
        }

        [When(@"User clicks on contact and clicks on new")]
        public async Task WhenUserClicksOnContactAndClicksOnNew()
        {
            await _contactPage.ClickContact();
            await _contactPage.ClickNew();
        }

        [When(@"User clicks on contact")]
        public async Task WhenUserClicksOnContact()
        {
            await _contactPage.ClickContact();
        }

        [Then(@"User selects the existing contact with firstName '([^']*)' and lastName '([^']*)'")]
        public async Task ThenUserSelectsTheExistingContactWithFirstNameAndLastName(string firstName, string lastName)
        {
            await _contactPage.FilterContact(firstName + " " + lastName);
            await _contactPage.ClickNewlyCreatedContactAsync(firstName + " " + lastName);
        }


        [Then(@"User validates sub agent ""([^""]*)"" field is not displayed")]
        public async Task ThenUserValidatesSubAgentFieldIsNotDisplayed(string subAgent)
        {
            Assertions.Equals(await _casesPage.GetLabelCount(subAgent), 0);
        }

        [When(@"User navigates to Customer Service admin center")]
        public async Task WhenUserNavigatesToCustomerServiceAdminCenter()
        {
            await _casesPage.ClickOnCustomerServiceAdmin();
        }

        [When(@"User navigates to Customer Service hub")]
        public async Task WhenUserNavigatesToCustomerServiceHub()
        {
            await _casesPage.ClickOnCustomerServiceHub();
        }


        [Then(@"User clicks on Underwriter Authorities")]
        public async Task ThenUserClicksOnUnderwriterAuthorities()
        {
            await _underwriterAuthority.ClickUnderwriterAuthoritiesAsync();
            await _underwriterAuthority.ClickNewAsync();
        }

        [Then(@"User validates Underwriter Authority ""([^""]*)"" field is not displayed")]
        public async Task ThenUserValidatesUnderwriterAuthorityFieldIsNotDisplayed(string underwriterAuthority)
        {
            Assertions.Equals(await _casesPage.GetLabelCount(underwriterAuthority), 0);
        }

        [Then(@"User creates new Underwriter Authorities with agent '([^']*)' Property only '([^']*)' Motor only single vehicle '([^']*)' Motor total accumulation '([^']*)'")]
        public async Task ThenUserCreatesNewUnderwriterAuthoritiesWithAgentPropertyOnlyMotorOnlySingleVehicleMotorTotalAccumulation(string agent, string propertyOnly, string motorOnly, string motorTotal)
        {
            await _underwriterAuthority.EnterAgentAsync(agent);
            await _underwriterAuthority.EnterPropertyOnlyAsync(propertyOnly);
            await _underwriterAuthority.EnterMotorOnlyAsync(motorOnly);
            await _underwriterAuthority.EnterMotorTotalAsync(motorTotal);
            await _underwriterAuthority.ClickSaveAndCloseAsync();
        }

        [Then(@"User selects new Underwriter Authorities with agent '([^']*)'")]
        public async Task ThenUserSelectsNewUnderwriterAuthoritiesWithAgent(string agent)
        {
            await _underwriterAuthority.ClickNewlyCreateUWAuthoritiesAsync(agent);
        }

        [Then(@"User deactivates the Underwriter Authority")]
        public async Task ThenUserDeactivatesTheUnderwriterAuthority()
        {
            await _underwriterAuthority.ClickDeactiveAsync();
            await _underwriterAuthority.ClickDeactiveConfirmAsync();
        }


        [Then(@"User clicks on sign out")]
        public async Task ThenUserClicksOnSignOut()
        {
            await _logoutPage.DynamicsLogout();
        }

        [When(@"User fills in mandatory fields firstName '([^']*)' and lastName '([^']*)' and saves the contact")]
        public async Task WhenUserFillsInMandatoryFieldsFirstNameAndLastNameAndSavesTheContact(string testFirstName, string testLastName)
        {
            await _contactPage.EnterFirstNameAsync(testFirstName);
            await _contactPage.EnterSurNameAsync(testLastName);
            await _contactPage.ClickSaveAndCloseAsync();
        }

    }
}
