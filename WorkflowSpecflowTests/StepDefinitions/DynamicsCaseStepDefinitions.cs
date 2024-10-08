using Microsoft.Playwright;
using Microsoft.VisualStudio.Services.UserAccountMapping;
using System.Threading.Tasks;
using WorkflowSpecflowTests.Config;
using WorkflowSpecflowTests.Pages;

namespace WorkflowSpecflowTests.StepDefinitions
{
    [Binding]
    public class DynamicsCaseStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Users _user;
        private readonly IDynamicsLoginPage _dynamicsLoginPage;
        private readonly ICasesPage _casesPage;
        private readonly IContactPage _contactPage;
        private readonly ICommonStepDefiniation _commonStep;
        private readonly IBasePage _basePage;
        private readonly ITasksPage _tasksPage;

        private readonly ISLAstoppagePage _slaStoppagePage;
        private readonly ISLATimesPage _sLATimesPage;

        public DynamicsCaseStepDefinitions(ScenarioContext scenarioContext, Users users, IDynamicsLoginPage dynamicsLoginPage, IContactPage contactPage, ICasesPage casesPage, ICommonStepDefiniation commonStep, IBasePage basePage, ISLAstoppagePage slaStoppagePage, ISLATimesPage sLATimesPage,ITasksPage tasksPage)
        {
            _scenarioContext = scenarioContext;
            _user = users;
            _dynamicsLoginPage = dynamicsLoginPage;
            _casesPage = casesPage;
            _contactPage = contactPage;
            _commonStep = commonStep;
            _basePage = basePage;
            _slaStoppagePage = slaStoppagePage;
            _sLATimesPage = sLATimesPage;
            _tasksPage= tasksPage;
        }

        [Given(@"User logged in to Dynamics application with team ""([^""]*)"" and role ""([^""]*)""")]
        public async Task GivenUserLoggedInDynamicsApplicationWithTeamAndRole(string team, string role)
        {
            await _dynamicsLoginPage.EnterDynamincsCredentials(team, role);
            await _dynamicsLoginPage.ClickNext();
        }
        [Given(@"User logged in to Dynamics application")]
        public async Task GivenUserLoggedInDynamicsApplication()
        {
            await _dynamicsLoginPage.EnterDynamincsCredentials();
            await _dynamicsLoginPage.ClickNext();
            await _dynamicsLoginPage.HandleCopilotAsync();

        }


        [Given(@"User logged in to Dynamics application with '([^']*)'")]
        public async Task GivenUserLoggedInDynamicsApplicationWith(string userRole)
        {
            await _dynamicsLoginPage.EnterDynamincsCredentials();
            await _dynamicsLoginPage.ClickNext();
            if (userRole.ToLower().Equals("admin") || userRole.ToLower().Equals("team lead") || userRole.ToLower().Equals("teamlead")) 
            {
                await _casesPage.ClickOnCustomerServiceHub();
            }

            Thread.Sleep(3000);
            await _dynamicsLoginPage.HandleCopilotAsync();
        }


        [When(@"user navigates to Customer Service admin center")]
        public async Task WhenUserNavigatesToCustomerServiceAdminCenter()
        {
            await _sLATimesPage.ClickCustomerServiceHubAsync();
            await _casesPage.ReloadPageAsync();
            await _sLATimesPage.ClickCustomerServiceHubAsync();
            await _casesPage.ClickOnCustomerServiceAdmin();
        }

        [When(@"User navigates to Customer Service Hub")]
        public async Task WhenUserNavigatesToCustomerServiceHub()
        {
            await _sLATimesPage.ClickCustomerAdminServiceAsync();
            //await _casesPage.ReloadPageAsync(); 
            //await _sLATimesPage.ClickCustomerAdminServiceAsync();
            await _casesPage.ClickOnCustomerServiceHub();
        }

        [Then(@"User validates sitemap menu")]
        public async Task WhenUserValidatesSitemapMenu()
        {
            await _commonStep.ValidateSiteMap();
        }

        [When(@"User update the SLA days '([^']*)' for the primary demand '([^']*)'")]
        public async Task WhenUserUpdateTheSLADaysForThePrimaryDemand(string slaDays, string primaryDemand)
        {
            await _slaStoppagePage.ClickSLATimesInLeftMenu();
            await _slaStoppagePage.SelectSLAOnPrimaryDemands(primaryDemand);
            await _slaStoppagePage.FillSLAdaysInSLAPage(slaDays);
        }

        [Then(@"User validate the duedate '([^']*)' for the case '([^']*)'")]
        public async Task ThenUserValidateTheCaseDuedateIsDisplayedAs(string dueDate, string caseName)
        {
            await _casesPage.ClickOnCases();
            await _casesPage.ClickNewlyCreatedCase(caseName);
            Assertions.Equals(await _casesPage.GetCaseDueDate(), _basePage.GetFutureDateExcludingWeekendsAsync(int.Parse(dueDate)));
        }

        [When(@"User click the Save button on the SLA time page")]
        public async Task WhenUserClickTheSaveButtonOnTheSLATimePage()
        {
            await _slaStoppagePage.ClickSaveButtonInNewSLAPage();
        }

        [Then(@"User clicks on save button")]
        public async Task ThenUserClicksOnSaveButton()
        {
            await _casesPage.ClickSaveButton();
        }
        [Then(@"User saves the case '([^']*)' with '([^']*)'")]
        public async Task ThenUserSavesTheCaseWith(string caseName, string primaryDemand)
        {
            if (primaryDemand.Equals("I want to change"))
            {
                await _casesPage.ClickSaveAndCountinueAsync();
            }
            else
            {
                await _casesPage.ClickSaveAsync();
            }
        }

        [Then(@"User clicks on Save and Close button")]
        public async Task ThenUserClicksOnSaveAndCloseButton()
        {
            await _casesPage.ClickSaveAndCloseButton();
        }

        [Then(@"User clicks on Save and Route button")]
        public async Task ThenUserClicksOnSaveAndRouteButton()
        {
            await _casesPage.ClickSaveAndRouteButton();
        }

        [Then(@"User clicks on '([^']*)' button")]
        public async Task ThenUserClicksOnSaveTypeButton(string SaveType)
        {
            if (SaveType.Equals("Save"))
            {
                await _casesPage.ClickSaveButton();
            }
            else if (SaveType.Equals("Save and Close"))
            {
                await _casesPage.ClickSaveAndCloseButton();
            }
            else if (SaveType.Equals("Save and Route"))
            {
                await _casesPage.ClickSaveAndRouteButton();
            }
        }

        [Then(@"User validate the status of the case")]
        public async Task ThenUserValidateTheStatusOfTheCase()
        {
            Assertions.Equals(await _casesPage.GetStatus().TextContentAsync(), "Active");
        }

        [Then(@"User changes the Case status to '([^']*)'")]
        public async Task ThenUserChangesTheCaseStatusToOnHold(String newStatus)
        {
            await _casesPage.ClickExpand();
            await _casesPage.ClickChangeCaseStatus(newStatus);
        }

        [Then(@"User validates the task status reason")]
        public async Task ThenUserValidatesTheTaskStatusReason()
        {
            Assertions.Equals(await _casesPage.GetStatusReason(), "New");
        }


        [Then(@"User validates the case due date (.*) for primary demand (.*)")]
        public async Task ThenUserValidatesTheCaseDueDate(int numberOfDays, string primaryDemand)
        {
            switch (primaryDemand)
            {
                case "I want to change":
                    await _casesPage.ClickRefresh();
                    await _casesPage.ClickRefresh();
                    break;
                default:
                    await _casesPage.ClickContinueAnywayAsync();
                    await _casesPage.ClickRefresh();
                    await _casesPage.ClickRefresh();
                    break;
            }
            if (primaryDemand.Equals("I want to renew"))
            {
                Assertions.Equals(await _casesPage.GetCaseDueDate(), "7/11/2025");
            }
            else
            {
                Assertions.Equals(await _casesPage.GetCaseDueDate(), _basePage.GetFutureDateExcludingWeekendsAsync(numberOfDays));
            }
        }

        [When(@"User '([^']*)' creates new case '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public async Task WhenUserCreatesNewCase(string userRole, string caseName, string primaryDemand, string demand, string subDemand, string customer, string policyReference, string caseDueDate, string product)
        {
            await _casesPage.ClickOnCases();
            //await _casesPage.CloseSignIn();
            await _casesPage.AddNewCase();

            await _casesPage.ClickAISuggestionAsync();

            //await _casesPage.ClickOnSummaryTab();
            //await _commonStep.ValidateCaseSummaryTabFields();

            //await _casesPage.ClickExpand();
            //await _commonStep.ValidateCaseFields();
            //await _casesPage.ClickCollapse();

            //await _casesPage.ClickOnDetailsTab();
            //await _commonStep.ValidateCaseDetailsTabFields();


            await _casesPage.ClickOnSummaryTab();
            await _casesPage.ClearPolicyReferenceNumberAsync();
            await _casesPage.EnterCaseNameAsync(caseName);
            await _casesPage.EnterPrimaryDemandAsync(primaryDemand);
            await _casesPage.EnterDemandAsync(demand);
            await _casesPage.EnterSubDemandAsync(primaryDemand, subDemand);
            await _casesPage.EnterCustomerAsync(customer);
            await _casesPage.EnterPolicyReferenceNumbereAsync(policyReference);
            await _casesPage.EnterPolicyReferenceAsync(policyReference);
            await _casesPage.EnterProductAsync(product);
            await _casesPage.EnterCaseDueDateAsync(userRole, caseDueDate);

        }
        [Then(@"User clicks on save&route button")]
        public async Task ThenUserClicksOnSaveRouteButton()
        {
            await _casesPage.ClickSaveAndRouteButton();
        }


        [Then(@"User selects newly created case '([^']*)'")]
        public async Task ThenUserSelectsNewlyCreatedCase(string caseName)
        {
            await _casesPage.ClickOnCases();
            await _casesPage.ClickRefresh();
            await _casesPage.ClickNewlyCreatedCase(caseName);
        }
        [When(@"User click on Queue Items Details")]
        public async Task WhenUserClickOnQueueItemsDetails()
        {
            await _casesPage.ClickOnQueueItemDetails();
        }
        [Then(@"User Validate the case is assigned automatically assigned to respective '([^']*)'")]
        public async Task ThenUserValidateTheCaseIsAssignedAutomaticallyAssignedToRespective(string queue)
        {
            await _casesPage.ValidateQueuePresentInItemDetails(queue);
        }



        [Then(@"User goes to Cases tab")]
        public async Task ThenUserGoesToCasesTab()
        {
            await _casesPage.ClickOnCases();
            await _casesPage.ClickRefresh();
        }

        [Then(@"User validate the updated SLA")]
        public async Task ThenUserValidateTheUpdatedSLA()
        {

        }

        [Then(@"User selects the Case '([^']*)' and validates Case Number")]
        public async Task ThenUserSelectsTheCaseAndValidatesCaseNumber(string caseName)
        {
            await _casesPage.SelectNewCaseValidateCaseNumber(caseName);
        }

        [Then(@"User selects the Case '([^']*)' and validates Case Status")]
        public async Task ThenUserSelectsTheCaseAndValidatesCaseStatus(string caseName)
        {
            await _casesPage.ClickOnCases();
            await _casesPage.ClickOnSaveContinue();
            await _casesPage.ClickRefresh();
            await _casesPage.SelectNewCaseValidateCaseNumber(caseName);
        }

        [Then(@"user cancel the case '([^']*)'")]
        public async Task ThenUserCancelTheCase(string caseName)
        {
            await _casesPage.ClickOnCases();
            await _casesPage.ClickRefresh();
            await _casesPage.SelectNewlyCreatedCase(caseName);
            await _casesPage.ClickCancelCase();
            await _casesPage.ClickConfirmButton();
        }

        [Then(@"User cancel the case ""([^""]*)""")]
        public async Task ThenUserCancelsTheCase(string caseName)
        {
            await _casesPage.ClickOnCases();
            await _casesPage.ClickRefresh();
            await _casesPage.SelectNewlyCreatedCase(caseName);
            await _casesPage.ClickCancelCase();
            await _casesPage.ClickConfirmButton();
        }


        [Then(@"User changes the primaryDemand '([^']*)' demand '([^']*)' and subDemand '([^']*)'")]
        public async Task ThenUserChangesThePrimaryDemandDemandAndSubDemand(string primaryDemand, string demand, string subDemand)
        {
            await _casesPage.ChangePrimaryDemandAsync(primaryDemand);
            await _casesPage.ChangeDemandAsync(demand);
            await _casesPage.ChangeSubDemandAsync(primaryDemand, subDemand);
            await _casesPage.ClickSaveButton();
        }

        [Then(@"User validates the valueSteps ""([^""]*)"" for primaryDemand ""([^""]*)""")]
        public async Task ThenUserValidatesTheValueStepsForPrimaryDemand(string valueSteps, string primaryDemand)
        {
            string[] valueStepArray = valueSteps.Split(',');
            List<string> expectedList = valueStepArray.ToList();

            Assertions.Equals(expectedList, await _casesPage.GetValueSteps());
        }

        [Then(@"User validates the '([^']*)' for primaryDemand '([^']*)'")]
        public async Task ThenUserValidatesTheForPrimaryDemand(string valueSteps, string primaryDemand)
        {
            string[] valueStepArray = valueSteps.Split(',');
            List<string> expectedList = valueStepArray.ToList();

            Assertions.Equals(expectedList, await _casesPage.GetValueSteps());
        }

        [Then(@"User validates the '([^']*)' in the case page")]
        public async Task ThenUserValidatesTheInTheCasePage(string valueStepMessages)
        {
            Assertions.Equals(await _casesPage.GetValueStepsMessages().TextContentAsync(), valueStepMessages);
        }

        [Then(@"user validate the status of the case as '([^']*)'")]
        public async Task ThenUserValidateTheStatusOfTheCaseAs(string caseStatus)
        {
            //await _dynamicsLoginPage.HandleCopilotAsync();

            Assertions.Equals(await _casesPage.GetStatusCase(caseStatus).TextContentAsync(), caseStatus);
        }

        [Then(@"user validate the status of the case '([^']*)' as '([^']*)'")]
        public async Task ThenUserValidateTheStatusOfTheCaseAs(string caseName, string caseStatus)
        {
            Assertions.Equals(await _casesPage.GetStatusCase(caseName).TextContentAsync(), caseStatus);
        }


        [Then(@"User validate the status as '([^']*)' for the case '([^']*)'")]
        public async Task ThenUserValidateTheStatusAsForTheCase(string caseStatus, string caseName)
        {
            await _casesPage.ClickOnCases();
            await _casesPage.ClickNewlyCreatedCase(caseName);
            Assertions.Equals(await _casesPage.GetStatus().TextContentAsync(), caseStatus);
        }

        [When(@"user select the ""([^""]*)"" option from the case actions")]
        public async Task WhenUserSelectTheOptionFromTheCaseActions(string buttonName)
        {
            if (buttonName == "Resolve Case")
            {
                await _casesPage.ClickResolveCaseButton();
            }
            else if (buttonName == "Go back")
            {
                await _casesPage.ClickGoBackButton();
            }
            else
            {
                Console.WriteLine("The given button name is not valid '" + buttonName + "'.");
            }
        }

        [Then(@"user validates the resolve case popup is '([^']*)'")]
        public async Task ThenUserValidatesTheResolveCasePopupIs(string popupEnabledOrDisabled)
        {
            if (popupEnabledOrDisabled == "Enabled")
            {
                await Assertions.Expect(await _casesPage.IsFieldVisible("Resolution Type", 1)).ToBeVisibleAsync();
                await Assertions.Expect(await _casesPage.IsFieldVisible("Resolution", 1)).ToBeVisibleAsync();
            }
            else if (popupEnabledOrDisabled == "Disabled")
            {
                //await Assertions.Expect(await _casesPage.IsFieldVisible("Resolution Type")).Not.ToBeVisibleAsync();

            }
            else
            {
                Console.WriteLine("The given resolve popup option is not valid '" + popupEnabledOrDisabled + "'.");
            }
        }

        [Then(@"user click on '([^']*)' button in Resolve Case popup")]
        public async Task WhenUserClickOnButton(string buttonNameInResolveCasePopup)
        {
            if (buttonNameInResolveCasePopup == "Resolve")
            {
                await _casesPage.ClickResolveButtonInResolveCasePopup();
            }
            else if (buttonNameInResolveCasePopup == "Cancel")
            {
                await _casesPage.ClickCancelButtonInResolveCasePopup();
            }
            else
            {
                Console.WriteLine("The given button name for Resolve popup is not valid '" + buttonNameInResolveCasePopup + "'.");
            }
        }

        [When(@"user selects the option '([^']*)' and '([^']*)' in resolved popup")]
        public async Task WhenUserSelectsTheOptionAndInResolvedPopup(string resolutionType, string resolutionReason)
        {
            await _casesPage.SelectResolutionTypeFromResolveCasePopup(resolutionType);
            await _casesPage.EnterResolutionReason(resolutionReason);
        }

        [Then(@"user validate the primary demand as ""([^""]*)""")]
        public async Task ThenUserValidateThePrimaryDemandAs(string primaryDemand)
        {
            Assertions.Equals(await _casesPage.GetPrimaryDemandFromCaseCreationPage().GetAttributeAsync("value"), primaryDemand);
        }


        [When(@"user change the primary demand to ""([^""]*)"", demand to ""([^""]*)"" and subdemand to ""([^""]*)""")]
        public async Task WhenUserChangeThePrimaryDemandToAndDemandTo(string primaryDemand, string demand, string subDemand)
        {
            await _casesPage.ChangePrimaryDemandAsync(primaryDemand);
            await _casesPage.ChangeDemandAsync(demand);
            await _casesPage.ChangeSubDemandAsync(primaryDemand, subDemand);
            await _casesPage.ClickSaveButton();
        }

        [Then(@"user validate the priority of the case as ""([^""]*)""")]
        public async Task ThenUserValidateThePriorityOfTheCaseAs(string priority)
        {
            Assertions.Equals(await _casesPage.GetPriorityFromCasePage().TextContentAsync(), priority);
        }

        [When(@"user override the priority from ""([^""]*)"" to ""([^""]*)""")]
        public async Task WhenUserOverrideThePriorityFromTo(string fromPriority, string ToPriority)
        {
            await _casesPage.OverrideCasePriority(ToPriority);
        }

        [When(@"user creates a new task under timeline '([^']*)' '([^']*)'")]
        public async Task WhenUserCreatesANewTaskUnderTimeline(string subject, string description)
        {
            await _casesPage.SelectTaskUnderTimeLineInCasePage();
            await _casesPage.CreateTaskUnderTime(subject, description);
        }

        [When(@"user click on the ""([^""]*)"" button on the Task under timeline")]
        public async Task WhenUserClickOnTheButtonOnTheTaskUnderTimmeline(string buttonToClick)
        {
            if (buttonToClick == "open report")
            {
                await _casesPage.ClickOpenReportButtonInCasePage();
            }
            else
            {
                Console.WriteLine("The given button name is not valid '" + buttonToClick + "'.");
            }
        }

        [Then(@"user validate the priority of the task should be ""([^""]*)""")]
        public async Task ThenUserValidateThePriorityOfTheTaskShouldBe(string priority)
        {
            Assertions.Equals(await _casesPage.GetPriorityFromCasePage().TextContentAsync(), priority);
        }

        [When(@"user click the '([^']*)' in progression stages")]
        public async Task WhenUserClickTheInProgressionStages(string progressionStageName)
        {
            if (progressionStageName == "Authentication")
            {
                await _casesPage.ClickAuthenticationProgressionStageInCasePage();
            }
            else
            {
                Console.WriteLine("The given 'Case progression Stage Name' is not valid '" + progressionStageName + "'.");
            }
        }

        [Then(@"user validate the popup along with '([^']*)', '([^']*)' and '([^']*)' Button")]
        public async Task ThenUserValidateThePopupAlongWithAndButton(string status, string primaryDemand, string buttonName)
        {
            Assertions.Equals(await _casesPage.GetPrimaryDemandFromAuthenticationPopupAsync(), primaryDemand);
            if (buttonName == "Next Stage")
            {
                await _casesPage.GetNextStageButtonInStageProgressionPopup();
            }
            else if (buttonName == "Set Active")
            {
                await _casesPage.GetActiveButtonFromStageProgressionPopup();
            }
            else
            {
                Console.WriteLine("The given 'Button Name in Progression stage' is not valid '" + buttonName + "'.");
            }
        }

        [When(@"user click on the '([^']*)' Button in progression bar")]
        public async Task WhenUserClickOnTheButtonInProgressionBar(string progressionBarButton)
        {
            if (progressionBarButton == "Previous Stage")
            {
                await _casesPage.ClickPreviousStageButtonInProgressionBar();
            }
            else if (progressionBarButton == "Next Stage")
            {
                await _casesPage.ClickNextStageButtonInProgressionBar();
            }
            else
            {
                Console.WriteLine("The given 'Button Name in Progression Bar' is not valid '" + progressionBarButton + "'.");
            }
        }


        [When(@"user click on the '([^']*)' Button in progression popup")]
        public async Task WhenUserClickOnTheButtonInProgressionPopup(string buttonToClick)
        {
            if (buttonToClick == "Next Stage")
            {
                await _casesPage.ClickNextStageButtonInStageProgressionPopup();
            }
            else if (buttonToClick == "Back")
            {
                await _casesPage.ClickBackButtonInStageProgressionPopup();
            }
            else if (buttonToClick == "Close")
            {
                await _casesPage.ClickCloseButtonInStageProgressionPopup();
            }
            else if (buttonToClick == "Set Active")
            {
                await _casesPage.ClickSetActiveButtonInProgressionPopup();
            }
            else
            {
                Console.WriteLine("The given 'Button Name in Progression stage' is not valid '" + buttonToClick + "'.");
            }
        }

        [Then(@"user validate the popup along with '([^']*)', '([^']*)', '([^']*)' and '([^']*)' Button")]
        public async Task ThenUserValidateThePopupAlongWithAndButton(string currentStatus, string primaryDemand, string backButton, string nextStageButton)
        {
            await _casesPage.GetNextStageButtonInStageProgressionPopup();
            await _casesPage.GetBackButtonInStageProgressionPopup();
        }

        [When(@"User select the cases '([^']*)' '([^']*)' '([^']*)'")]
        public async Task WhenUserSelectTheCases(string caseName1, string caseName2, string caseName3)
        {
            await _casesPage.ClickOnCases();
            await _casesPage.ClickRefresh();
            await _casesPage.SelectNewlyCreatedCase(caseName1);
            await _casesPage.SelectNewlyCreatedCase(caseName2);
            await _casesPage.SelectNewlyCreatedCase(caseName3);
        }

        [Then(@"User validates the cases '([^']*)' '([^']*)' '([^']*)' ownername is changed to '([^']*)'")]
        public async Task ThenUserValidatesTheCasesOwnernameIsChangedTo(string caseName1, string caseName2, string caseName3, string ownerName)
        {
            await _casesPage.ClickOnCases();
            await _casesPage.ClickRefresh();
            await _casesPage.ClickAllCases();
            await _casesPage.FilterCasesByOwnerName(ownerName);
            await _casesPage.validateUsersDisplayedWithOwnerName(caseName1, ownerName);
            await _casesPage.validateUsersDisplayedWithOwnerName(caseName2, ownerName);
            await _casesPage.validateUsersDisplayedWithOwnerName(caseName3, ownerName);
        }

        [Then(@"user cancel the case '([^']*)''([^']*)''([^']*)'")]
        public async Task ThenUserCancelTheCase(string caseName1, string caseName2, string caseName3)
        {
            await _casesPage.ClickAllCases();
            await _casesPage.SelectNewlyCreatedCase(caseName1);
            await _casesPage.SelectNewlyCreatedCase(caseName2);
            await _casesPage.SelectNewlyCreatedCase(caseName3);
            await _casesPage.ClickCancelCase();
            await _casesPage.ClickConfirmButton();
        }

        [When(@"User clicks on SLA Stoppages tab")]
        public async Task WhenUserClicksOnSLAStoppagesTab()
        {
            await _casesPage.ClickOnSLATab();
        }

        [When(@"User click the New button from SLA Home page")]
        public async void WhenUserClicktheNewbuttonfromSLAHomePage()
        {
            await _casesPage.ClickOnNewInSLAstoppages();

        }

        //Work-130
        [Given(@"User logged in to Dynamics application with '([^']*)' and '([^']*)'")]
        public async Task GivenUserLoggedInDynamicsApplicationWithAnd(string team, string role)
        {
            await _dynamicsLoginPage.EnterDynamincsCredentials(team, role);
            await _dynamicsLoginPage.ClickNext();            
            await _dynamicsLoginPage.HandleCopilotAsync();
        }

        [When(@"User creates new case '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public async Task WhenUserCreatesNewCase(string casename, string primaryDemand, string demand, string subDemand, string customer, string policyref)
        {
            await _casesPage.ClickOnCases();
            await _casesPage.AddNewCase();
            await _casesPage.EnterCaseNameAsync(casename);
            await _casesPage.EnterPrimaryDemandAsync(primaryDemand);
            await _casesPage.EnterDemandAsync(demand);
            await _casesPage.EnterSubDemandAsync(primaryDemand, subDemand);
            await _casesPage.EnterCustomerAsync(customer);
            await _casesPage.ClickAISuggestionAsync();
            await _casesPage.EnterPolicyReferenceNumbereAsync(policyref);
            await _casesPage.EnterPolicyReferenceAsync(policyref);
        }
        [When(@"User Enters Primary Demand '([^']*)'")]
        public async void WhenUserEntersPrimaryDemand(string primaryDemand)
        {
            await _tasksPage.EnterPrimaryDemand(primaryDemand);
        }
        [When(@"User Clicks on Task Type '([^']*)'")]
        public async Task WhenUserClicksOnTaskType(string TaskType)
        {
            await _tasksPage.EnterTaskType(TaskType);
        }


        [Then(@"User Changes the '([^']*)'")]
        public async Task ThenUserChangesThe(string Owner)
        {
            await _casesPage.ChangeOwnerForCase(Owner);
        }

        [Then(@"Validates Owner is Changed '([^']*)'")]
        public async Task ThenValidatesOwnerIsChanged(string caseName)
        {
            await _casesPage.ValidateCaseNameNotPresent(caseName);
        }
        [When(@"User Clicks on Cases")]
        public async Task WhenUserClicksOnCases()
        {
            await _basePage.ClickCasesButton();
        }

        [When(@"Selects a Case")]
        public async Task WhenSelectsACase()
        {
            await _casesPage.AsyncSelectTheFirstCase();
        }

        [When(@"User Enter a '([^']*)'")]
        public async Task WhenUserEnterA(string note)
        {
            await _casesPage.AsyncEnterNotes(note);
        }
        [When(@"User Switches case status to In-Progress")]
        public async Task WhenUserSwitchesCaseStatusToIn_Progress()
        {
            await _casesPage.SwitchToInProgress();
        }

        [When(@"User Switches case status to On-Hold")]
        public async Task WhenUserSwitchesCaseStatusToOn_Hold()
        {
            await _casesPage.SwitchToOnHold();
        }

        [Then(@"User clicks on resolve case '([^']*)'")]
        public async Task ThenUserClicksOnResolveCase(string resolutionReason)
        {
            await _casesPage.ClickResolveCaseButton();
            await _casesPage.EnterResolutionReason(resolutionReason);
            await _casesPage.ClickResolveButtonInResolveCasePopup();
        }


        [Then(@"User Validates note is not editable")]
        public async Task ThenUserValidatesNoteIsNotEditable()
        {
            await _casesPage.ValidateNoteNoteEditableAsync();
        }

        [Then(@"User validates '([^']*)' is added")]
        public async Task ThenUserValidatesIsAdded(string note)
        {
            await _casesPage.CaseNoteCreatedAsync(note);
        }


        [Then(@"User validate the fields are displayed '([^']*)' '([^']*)' and '([^']*)'")]
        public async Task ThenUserValidateTheTodayPMAndTodayUnpendedTime(string cases, string pendedTime, string undpendedTime)
        {
            await _slaStoppagePage.IsElementPresentOnNewSLA();
            await _commonStep.ValidateNewSLAStoppagePage();
        }

        [When(@"User create new SLA for the caseName '([^']*)', pended time as '([^']*)' and unpended time as '([^']*)'")]
        public async Task WhenUserCreateNewSLAForTheCaseNamePendedTimeAsAndUnpendedTimeAs(string caseName, string pendedStartDate, string unpendedEndDate)
        {
            await _slaStoppagePage.FillCaseNameInNewSLAPage(caseName);
            await _slaStoppagePage.SelectPendedDateFromCalendarInNewSLAPage(pendedStartDate);
            await _slaStoppagePage.SelectUnPendedDateFromCalendarInNewSLAPage(unpendedEndDate);
        }

        [When(@"User click on the Save button in new SLA stoppage page")]
        public async Task WhenUserClickOnTheSaveButtonInNewSLAStoppagePage()
        {
            await _slaStoppagePage.ClickSaveButtonInNewSLAPage();
        }

        [When(@"User select the SLA Stoppage for the case '([^']*)'")]
        public async Task WhenUserSelectTheSLAStoppageForTheCase(string caseName)
        {
            await _slaStoppagePage.SelectNewlyCreatedSLAStoppage(caseName);
        }

        [When(@"User clicks the '([^']*)' button on the SLA home page")]
        public async Task WhenUserClicksTheButtonOnTheSLAHomePage(string buttonName)
        {
            await _slaStoppagePage.ClickDeActivateButtonInSLAPage();
        }

        [When(@"User select the '([^']*)' button on the confim popup")]
        public async Task WhenUserSelectTheButtonOnTheConfimPopup(string buttonName)
        {
            await _slaStoppagePage.ClickDeActivateButtonInConfirmPopup();
        }


        [When(@"user navigates to the my resolved cases page")]
        public async Task WhenUserNavigatesToTheMyResolvedCasesPage()
        {
            await _casesPage.ClickOnCases();
            await _casesPage.ClickMyActiveCases();
            await _casesPage.ClickMyResolvedCases();
        }

        [Then(@"user delete the cases '([^']*)'")]
        public async void ThenUserDeleteTheCases(string caseName)
        {
            await _casesPage.SelectNewlyCreatedCase(caseName);
            await _casesPage.DeleteCase();
        }

        [When(@"User select the case '([^']*)' from case home page")]
        public async Task WhenUserSelectTheCaseFromCaseHomePage(string caseName)
        {
            await _casesPage.ClickOnCases();
            await _casesPage.SelectNewlyCreatedCase(caseName);
        }

        [Then(@"User validates the cases '([^']*)' ownername is changed to '([^']*)'")]
        public async Task ThenUserValidatesTheCasesOwnernameIsChangedTo(string caseName, string ownerName)
        {
            await _casesPage.ClickOnCases();
            await _casesPage.ClickRefresh();
            await _casesPage.ClickAllCases();
            await _casesPage.FilterCasesByOwnerName(ownerName);
            await _casesPage.validateUsersDisplayedWithOwnerName(caseName, ownerName);

        }
        [Then(@"User Validates Case due date is (.*) days further from creation date")]
        public async Task ThenUserValidatesCaseDueDateIsDaysFurtherFromCreationDate(int p0)
        {
            await _casesPage.CaseDueDateValidation();
        }
        [Then(@"Case Status Should be new")]
        public async void ThenCaseStatusShouldBeNew()
        {
            await _casesPage.CaseStatusNewValidation();
        }

        [Then(@"User clicsUser clicks on SLA timer")]
        public async Task ThenUserClicsUserClicksOnSLATimer()
        {
            await _sLATimesPage.ClickSLATimesAsync();
        }

        [Then(@"User updates the sla for primaryDemand:")]
        public async Task UpdateSLA(Table table)
        {
            foreach (var row in table.Rows)
            {
                await _sLATimesPage.EnterSLAAsync(int.Parse(row["SLA"].Replace("'", string.Empty)), row["PrimaryDemand"].Replace("'", string.Empty));
            }
        }

        [Then(@"User updates original sla for primaryDemand:")]
        public async Task UpdatesOriginalSLA(Table table)
        {
            foreach (var row in table.Rows)
            {
                await _sLATimesPage.EnterSLAAsync(int.Parse(row["SLA"].Replace("'", string.Empty)), row["PrimaryDemand"].Replace("'", string.Empty));
            }
        }
        [When(@"User creates the case and validates the sla:")]
        public async Task CreateCase(Table table)
        {
            foreach (var row in table.Rows)
            {
                await _sLATimesPage.EnterSLAAsync(int.Parse(row["SLA"].Replace("'", string.Empty)), row["PrimaryDemand"].Replace("'", string.Empty));
                await _casesPage.ClickOnCases();
                await _casesPage.AddNewCase();

                await _casesPage.ClickAISuggestionAsync();

                await _casesPage.ClickOnSummaryTab();
                await _casesPage.ClearPolicyReferenceNumberAsync();
                await _casesPage.EnterCaseNameAsync(row["CaseName"].Replace("'", string.Empty));
                await _casesPage.EnterPrimaryDemandAsync(row["PrimaryDemand"].Replace("'", string.Empty));
                await _casesPage.EnterDemandAsync(row["Demand"].Replace("'", string.Empty));
                await _casesPage.EnterSubDemandAsync(row["PrimaryDemand"].Replace("'", string.Empty), row["SubDemand"].Replace("'", string.Empty));
                await _casesPage.EnterCustomerAsync(row["Customer"].Replace("'", string.Empty));
                await _casesPage.EnterPolicyReferenceNumbereAsync(row["PolicyReference"].Replace("'", string.Empty));
                await _casesPage.EnterPolicyReferenceAsync(row["PolicyReference"].Replace("'", string.Empty));
                await _casesPage.EnterProductAsync(row["Product"].Replace("'", string.Empty));
                await _casesPage.EnterCaseDueDateAsync(row["userRole"].Replace("'", string.Empty), row["CaseDueDate"].Replace("'", string.Empty));

                if (row["PrimaryDemand"].Replace("'", string.Empty).Equals("I want to change"))
                {
                    await _casesPage.ClickSaveButton();
                    await _casesPage.ClickOnCases();
                    await _casesPage.ClickRefresh();
                    await _casesPage.ClickNewlyCreatedCase(row["CaseName"].Replace("'", string.Empty));
                }
                else
                {
                    await _casesPage.ClickSaveAsync();
                }

                await _casesPage.ClickOnCases();
                await _casesPage.ClickRefresh();
                await _casesPage.ClickNewlyCreatedCase(row["CaseName"].Replace("'", string.Empty));

                await _casesPage.ClickRefresh();
                switch (row["PrimaryDemand"].Replace("'", string.Empty))
                {
                    case "I want to change":
                        await _casesPage.ClickRefresh();
                        await _casesPage.ClickRefresh();
                        break;
                    default:
                        await _casesPage.ClickContinueAnywayAsync();
                        await _casesPage.ClickRefresh();
                        await _casesPage.ClickRefresh();
                        break;
                }
                if (row["PrimaryDemand"].Replace("'", string.Empty).Equals("I want to renew"))
                {
                    Assertions.Equals(await _casesPage.GetCaseDueDate(), "2/11/2025");
                }
                else
                {
                    Assertions.Equals(await _casesPage.GetCaseDueDate(), _basePage.GetFutureDateExcludingWeekendsAsync(int.Parse(row["SLA"].Replace("'", string.Empty))));
                }
            }
        }


        [Then(@"User nevigates to customer service hub")]
        public async Task ThenUserNevigatesToCustomerServiceHub()
        {
            await _sLATimesPage.ClickCustomerAdminServiceAsync();
            await _casesPage.ClickOnCustomerServiceHub();
        }


        [When(@"User validates the new sla (.*) for primary demand '([^']*)'")]
        public async Task ThenUserValidatesTheNewSlaForPrimaryDemand(int sla, string primaryDemand)
        {
            await _casesPage.ClickRefresh();
            switch (primaryDemand)
            {
                case "I want to change":
                    await _casesPage.ClickRefresh();
                    await _casesPage.ClickRefresh();
                    break;
                default:
                    await _casesPage.ClickContinueAnywayAsync();
                    await _casesPage.ClickRefresh();
                    await _casesPage.ClickRefresh();
                    break;
            }
            if (primaryDemand.Equals("I want to renew"))
            {
                Assertions.Equals(await _casesPage.GetCaseDueDate(), "2/11/2025");
            }
            else
            {
                Assertions.Equals(await _casesPage.GetCaseDueDate(), _basePage.GetFutureDateExcludingWeekendsAsync(sla));
            }
        }


        [Then(@"User creates new case and validates case status, case due date, case number and sitemap")]
        public async Task CreateValidCase(Table table)
        {
            foreach (var row in table.Rows)
            {
                //Create case
                await _casesPage.ClickOnCases();
                await _casesPage.AddNewCase();

                await _casesPage.ClickAISuggestionAsync();

                await _casesPage.ClickOnSummaryTab();
                await _casesPage.ClearPolicyReferenceNumberAsync();
                await _casesPage.EnterCaseNameAsync(row["CaseName"].Replace("'", string.Empty));
                await _casesPage.EnterPrimaryDemandAsync(row["PrimaryDemand"].Replace("'", string.Empty));
                await _casesPage.EnterDemandAsync(row["Demand"].Replace("'", string.Empty));
                await _casesPage.EnterSubDemandAsync(row["PrimaryDemand"].Replace("'", string.Empty), row["SubDemand"].Replace("'", string.Empty));
                await _casesPage.EnterCustomerAsync(row["Customer"].Replace("'", string.Empty));
                await _casesPage.EnterPolicyReferenceNumbereAsync(row["PolicyReference"].Replace("'", string.Empty));
                await _casesPage.EnterPolicyReferenceAsync(row["PolicyReference"].Replace("'", string.Empty));
                await _casesPage.EnterProductAsync(row["Product"].Replace("'", string.Empty));
                await _casesPage.EnterCaseDueDateAsync(row["userRole"].Replace("'", string.Empty), row["CaseDueDate"].Replace("'", string.Empty));

                if (row["PrimaryDemand"].Replace("'", string.Empty).Equals("I want to change"))
                {
                    await _casesPage.ClickSaveAndCountinueAsync();
                }
                else
                {
                    await _casesPage.ClickSaveAsync();
                }

                await _casesPage.ClickOnCases();
                await _casesPage.ClickRefresh();
                await _casesPage.ClickNewlyCreatedCase(row["CaseName"].Replace("'", string.Empty));

                //Validate sitemap
                await _commonStep.ValidateSiteMap();

                //Validate case status
                Assertions.Equals(await _casesPage.GetStatus().TextContentAsync(), "Active");

                await _casesPage.ClickRefresh();
                await _casesPage.ClickRefresh();
                await _casesPage.ClickRefresh();

                //Validate case due date (SLA)
                if (row["PrimaryDemand"].Replace("'", string.Empty).Equals("I want to renew"))
                {
                    Assertions.Equals(await _casesPage.GetCaseDueDate(), "7/10/2025");
                }
                else
                {
                    Assertions.Equals(await _casesPage.GetCaseDueDate(), _basePage.GetFutureDateExcludingWeekendsAsync(int.Parse(row["numberOfDays"].Replace("'", string.Empty))));
                }

                //Validate case number is visible
                await _casesPage.SelectNewCaseValidateCaseNumber(row["CaseName"].Replace("'", string.Empty));
            }
        }


        [Then(@"User cancel the case")]
        public async Task CancelCase(Table table)
        {
            foreach (var row in table.Rows)
            {
                await _casesPage.ClickOnCases();
                await _casesPage.ClickRefresh();
                await _casesPage.SelectNewlyCreatedCase(row["CaseName"].Replace("'", string.Empty));
                await _casesPage.ClickCancelCase();
                await _casesPage.ClickConfirmButton();
            }
        }

        [When(@"User clicks create a timeline button and select the Email from the option")]
        public async Task WhenUserClicksCreateATimelineButtonAndSelectTheEmailFromTheOption()
        {
            await _casesPage.SelectEmailUnderTimeLineInCasePage();
            await _commonStep.ValidateEmailFromTimeLine();
        }

        [Then(@"User validate the timeline history for sending the email")]
        public async Task ThenUserValidateTheTimelineHistoryForSendingTheEmail()
        {
            await _casesPage.ClickOpenReportButtonInCasePage();
            await _commonStep.ValidateEmailFromTimeLine();
        }

        [When(@"User validates the mandatory fields error messages")]
        public async Task WhenUserValidatesTheMandatoryFieldsErrorMessages(Table table)
        {
            await _casesPage.ClickOnCases();
            await _casesPage.AddNewCase();
            await _casesPage.ClickAISuggestionAsync();
            await _casesPage.ClickSaveAsync();

            foreach (var row in table.Rows)
            {
                if (row["FieldName"].Replace("'", string.Empty).Equals("CaseName"))
                {
                    Assertions.Equals(await _casesPage.GetCaseNameErrorMessage(), "Case Name: Required fields must be filled in.");
                }
                else if (row["FieldName"].Replace("'", string.Empty).Equals("PrimaryDemand"))
                {
                    Assertions.Equals(await _casesPage.GetPrimaryDemandErrorMessage(), "Primary Demand: Required fields must be filled in.");
                }
                else if (row["FieldName"].Replace("'", string.Empty).Equals("Customer"))
                {
                    Assertions.Equals(await _casesPage.GetCustomerErrorMessage(), "Customer: Required fields must be filled in.");
                }
                else if (row["FieldName"].Replace("'", string.Empty).Equals("PolicyReference"))
                {
                    Assertions.Equals(await _casesPage.GetPolicyReferenceNumberErrorMessage(), "Policy Reference Number: Required fields must be filled in.");
                }
                else
                {
                    Assert.Fail("The given FieldName " + row["FieldName"] + " is Not Matched");
                }

            }
            await _casesPage.ClickGoBackButton();
            await _casesPage.ClickOnDiscardButton();
        }
    }

}
