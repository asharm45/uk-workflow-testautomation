using Microsoft.Playwright;
using WorkflowSpecflowTests.Config;
using WorkflowSpecflowTests.Pages;

namespace WorkflowSpecflowTests.StepDefinitions
{
    [Binding]
    public class UnderAuthStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Users _user;
        private readonly IDynamicsLoginPage _dynamicsLoginPage;
        private readonly ICommonStepDefiniation _commonStep;
        private readonly IUnderwriterAuthorityPage _underwriterAuthorityPage;
        private readonly ITaskTypePage _taskTypePage;
        private readonly IDemandsPage _demandsPage;

        public UnderAuthStepDefinition(ScenarioContext scenarioContext, Users users, IDynamicsLoginPage dynamicsLoginPage, ICommonStepDefiniation commonStep, IUnderwriterAuthorityPage underwriterAuthorityPage, ITaskTypePage taskTypePage, IDemandsPage demandsPage)
        {
            _scenarioContext = scenarioContext;
            _user = users;
            _dynamicsLoginPage = dynamicsLoginPage;
            _commonStep = commonStep;
            _underwriterAuthorityPage = underwriterAuthorityPage;
            _taskTypePage = taskTypePage;
            _demandsPage = demandsPage;
        }

        
        [Then(@"User clicks on save and close button")]
        public async Task ThenUserClicksOnSaveAndCloseButton()
        {
            await _underwriterAuthorityPage.ClickSaveAndCloseAsync();
        }


        [Then(@"User Validates below filters are present")]
        public async Task ThenUserValidatesBelowFiltersArePresent()
        {
            await _commonStep.ValidateActiveUnderwriterauthorities();
        }

        [When(@"User Clicks On Underwriter Authority")]
        public async Task WhenUserClicksOnUnderwriterAuthority()
        {
            await _underwriterAuthorityPage.ClickUnderwriterAuthoritiesAsync();
        }


        [Then(@"User clicks on new button")]
        public async Task ThenUserClicksOnNewButton()
        {
            await _underwriterAuthorityPage.ClickNewAsync();
        }

        [Then(@"User Click on New Bookable Resource")]
        public async Task ThenUserClickOnNewBookableResource()
        {
            await _underwriterAuthorityPage.ClickOnNewBookableResourceAsync();
        }
        
        [Then(@"creates new bookable resource '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public async Task ThenCreatesNewBookableResource(string ResourceType, string User, string Name, string TimeZone)
        {
            await _underwriterAuthorityPage.CreateNewBookableResourceAsync(ResourceType, User, Name, TimeZone);
        }


        [Then(@"User creates New UA '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public async Task ThenUserCreatesNewUA(string agent, string property, string vehicle, string accumulation)
        {
            await _underwriterAuthorityPage.EnterAgentAsync(agent);
            await _underwriterAuthorityPage.EnterPropertyOnlyAsync(property);
            await _underwriterAuthorityPage.EnterMotorOnlyAsync(vehicle);
            await _underwriterAuthorityPage.EnterMotorTotalAsync(accumulation);
            
        }

        [Then(@"User validate UA is saved and created successfully with '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public async Task ThenUserValidateUAIsSavedAndCreatedSuccessfullyWith(string agent, string property, string vehicle, string accumulation)
        {
            await _underwriterAuthorityPage.ClickCreatedOnAsync();
            await _underwriterAuthorityPage.ClickNewerToOlderAsync();
            Assertions.Equals(await _underwriterAuthorityPage.GetProprtyOnlyAsync(), property);
            Assertions.Equals(await _underwriterAuthorityPage.GetMotorOnlyAsync(), vehicle);
            Assertions.Equals(await _underwriterAuthorityPage.GetMotorTotalAsync(), accumulation);
        }

        [Then(@"User deletes the UA '([^']*)'")]
        public async Task ThenUserDeletesTheUA(string agent)
        {
            await _underwriterAuthorityPage.ClickNewlyCreateUWAuthoritiesAsync(agent);
            await _underwriterAuthorityPage.ClickDeleteAsync();
            await _underwriterAuthorityPage.ClickConfirmDelete();
        }

        [Then(@"User clicks on save")]
        public async Task ThenUserClicksOnSave()
        {
            await _underwriterAuthorityPage.ClickSaveAsync();
        }

        [Then(@"User deletes the UA")]
        public async Task ThenUserDeletesTheUA()
        {
            await _underwriterAuthorityPage.ClickDeleteAsync();
            await _underwriterAuthorityPage.ClickConfirmDelete();
        }


        [Then(@"User clears filter")]
        public async Task ThenUserClearsFilter()
        {
            await _underwriterAuthorityPage.ClickClearFilterAsync();
        }
        [Then(@"User clears  keyboard filter")]
        public async Task ThenUserClearsKeyboardFilter()
        {
            await _underwriterAuthorityPage.ClickClearKeyboadFilterAsync();
        }


        [Then(@"User selects the newly created UA with '([^']*)' and updated the '([^']*)' '([^']*)' '([^']*)'")]
        public async Task ThenUserSelectsTheNewlyCreatedUAWithAndUpdatedThe(string agent, string newProperty, string newVehicle, string newAccumulation)
        {
            await _underwriterAuthorityPage.ClickNewlyCreateUWAuthoritiesAsync(agent);
            await _underwriterAuthorityPage.EnterPropertyOnlyAsync(newProperty);
            await _underwriterAuthorityPage.EnterMotorOnlyAsync(newVehicle);
            await _underwriterAuthorityPage.EnterMotorTotalAsync(newAccumulation);
            await _underwriterAuthorityPage.ClickSaveAndCloseAsync();
        }

        [Then(@"User selects the newly created UA with '([^']*)'")]
        public async Task ThenUserSelectsTheNewlyCreatedUA(string agent)
        {
            await _underwriterAuthorityPage.ClickNewlyCreateUWAuthoritiesAsync(agent);
        }

        [Then(@"User selects the newly created UA with '([^']*)' and updated the '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public async Task ThenUserSelectsTheNewlyCreatedUAWithAndUpdatedThe(string agent, string newAgent, string newProperty, string newVehicle, string newAccumulation)
        {
            await _underwriterAuthorityPage.ClickNewlyCreateUWAuthoritiesAsync(agent);
            await _underwriterAuthorityPage.RemoveAgentAsync();
            await _underwriterAuthorityPage.EnterAgentAsync(newAgent);
            await _underwriterAuthorityPage.EnterPropertyOnlyAsync(newProperty);
            await _underwriterAuthorityPage.EnterMotorOnlyAsync(newVehicle);
            await _underwriterAuthorityPage.EnterMotorTotalAsync(newAccumulation);
            await _underwriterAuthorityPage.ClickSaveAndCloseAsync();
        }

        [Then(@"User validates if UA is updated successfully with '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public async Task ThenUserValidatesIfUAIsUpdatedSuccessfullyWith(string agent, string newProperty, string newVehicle, string newAccumulation)
        {
            await _underwriterAuthorityPage.ClickCreatedOnAsync();
            await _underwriterAuthorityPage.ClickNewerToOlderAsync();
            Assertions.Equals(await _underwriterAuthorityPage.GetAgentNameAsync(), agent);
            Assertions.Equals(await _underwriterAuthorityPage.GetProprtyOnlyAsync(), newProperty);
            Assertions.Equals(await _underwriterAuthorityPage.GetMotorOnlyAsync(), newVehicle);
            Assertions.Equals(await _underwriterAuthorityPage.GetMotorTotalAsync(), newAccumulation);
        }

        [Then(@"User validates all the fields visible '([^']*)' '([^']*)' '([^']*)' and '([^']*)'")]
        public async Task ThenUserValidatesAllTheFieldsVisibleAnd(string agent, string propertyOnly, string motorOnly, string motorTotal)
        {
            Assertions.Equals(await _underwriterAuthorityPage.GetLabel(agent), "Agent");
            Assertions.Equals(await _underwriterAuthorityPage.GetLabel(propertyOnly), "Property only");
            Assertions.Equals(await _underwriterAuthorityPage.GetLabel(motorOnly), "Motor only single vehicle");
            Assertions.Equals(await _underwriterAuthorityPage.GetLabel(motorTotal), "Motor total accumulation");
        }


        [Then(@"User validates error messages on UA screen")]
        public async Task ThenUserValidatesErrorMessagesOnUAScreen()
        {
            await _underwriterAuthorityPage.ClickSaveAsync();
            await Assertions.Expect(await _taskTypePage.IsFieldVisible("Agent: Required fields must be filled in.")).ToBeVisibleAsync();
        }

        [Then(@"User clicks on share and manage access")]
        public async Task ThenUserClicksOnShareAndManageAccess()
        {
            await _underwriterAuthorityPage.ClickShareAsync();
            await _underwriterAuthorityPage.ClickManageAccessAsync();
        }

        [Then(@"User share it with '([^']*)' and grants the permission and click on share button")]
        public async Task ThenUserShareItWithAndGrantsThePermissionAndClickOnShareButton(string shareWith)
        {
            await _underwriterAuthorityPage.ClickAddUserOrTeamAsync(shareWith);
            await _underwriterAuthorityPage.SelectUserAsync();
            await _underwriterAuthorityPage.ClickReadPermissionAsync();
            await _underwriterAuthorityPage.ClickShareBtnAsync();
            Assertions.Equals(await _underwriterAuthorityPage.GetMessageAsync(), "Your changes have been saved");
            await _underwriterAuthorityPage.ClickCloseAsync();
        }

        [Then(@"User clicks on assign button")]
        public async Task ThenUserClicksOnAssignButton()
        {
            await _underwriterAuthorityPage.ClickAssignAsync();
        }

        [Then(@"User assign it to '([^']*)' and clicks on assign button")]
        public async Task ThenUserAssignItToAndClicksOnAssignButton(string userOrTeam)
        {
            await _underwriterAuthorityPage.SelectAssignToAsync("User or team");
            await _underwriterAuthorityPage.SelectUserOrTeamAsync(userOrTeam);
            await _underwriterAuthorityPage.ClickAssignBtnAsync();
        }

        [Then(@"User clicks on Demands")]
        public async Task ThenUserClicksOnDemands()
        {
            await _demandsPage.ClickDemandsAsync();
        }

        [Then(@"User clicks on New demand")]
        public async Task ThenUserClicksOnNewDemand()
        {
            await _demandsPage.ClickNewAsync();
        }

        [Then(@"User validates the Demands fields")]
        public async Task ThenUserValidatesTheDemandsFields(Table table)
        {
            foreach (var row in table.Rows)
            {
                Assertions.Equals(await _demandsPage.GetDemandLabelAsync(row["Fields"].Replace("'", string.Empty)), true);
            }
        }

    }
}
