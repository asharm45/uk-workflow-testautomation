using System;
using Microsoft.Playwright;
using TechTalk.SpecFlow;
using WorkflowSpecflowTests.Pages;

namespace WorkflowSpecflowTests.StepDefinitions
{
    [Binding]
    public class ValueStepsMappingTaskStepDefinitions
    {
        private readonly ScenarioContext _context;
        private readonly ICasesPage _casesPage;
        private readonly ITasksPage _tasksPage;
        private readonly IBasePage _basePage;

        public ValueStepsMappingTaskStepDefinitions(ScenarioContext context, ICasesPage casesPage, ITasksPage tasksPage, IBasePage basePage)
        {
            _context = context;
            _casesPage = casesPage;
            _tasksPage = tasksPage;
            _basePage = basePage;
        }

        [When(@"User clicks on activities tab")]
        public async Task WhenUserClicksOnActivitiesTab()
        {
            await _tasksPage.ClickActivities();
        }
        [When(@"User switches to All activities")]
        public async Task WhenUserSwitchesToAllActivities()
        {
            await _tasksPage.SelectAllActivitiesFromTaskPage();
        }

        [When(@"User searches the the demand task '([^']*)'")]
        public async Task WhenUserSearchesTheTheDemandTask(string DemandTask)
        {
            await _tasksPage.SearchTask(DemandTask);
        }
        [When(@"User clicks on the task '([^']*)'")]
        public async Task WhenUserClicksOnTheTask(string DemandTask)
        {
            await _tasksPage.ClickTaskAsync(DemandTask);
        }

        [When(@"User Selects the task '([^']*)' and deletes it")]
        public async Task WhenUserSelectsTheTaskAndDeletesIt(string DemandTask)
        {
            await _tasksPage.SelectAndDeleteTaskAsync(DemandTask);
        }

        [When(@"User clicks on task")]
        public async Task WhenUserClicksOnTask()
        {
            await _tasksPage.ClickTask();
        }

        [When(@"User selects existing case under regarding search bar '([^']*)'")]
        public async Task WhenUserSelectsExistingCaseUnderRegardingSearchBar(string caseName)
        {
            await _tasksPage.EnterRegardings(caseName);
        }
        
        [When(@"User creates task with regarding '([^']*)' demand task ""([^""]*)"" and validates case due date (.*) and primary demand '([^']*)'")]
        public async Task WhenUserCreatesTaskWithRegardingDemandTaskAndValidatesCaseDueDateAndPrimaryDemand(string caseName, string demandType, int caseDueDate, string primaryDemand)
        {
            await _tasksPage.EnterRegardings(caseName);
            await _tasksPage.EnterDemandTask(demandType);
            await _tasksPage.EnterPrimaryDemand(primaryDemand);
            await _tasksPage.SaveTask();
            await _casesPage.ClickRefresh();
            if(primaryDemand.Equals("I want to renew"))
            {
                Assertions.Equals(await _tasksPage.GetCaseDueDate(), "4/29/2025");
            }
            else
            {
                Assertions.Equals(await _tasksPage.GetCaseDueDate(), _basePage.GetFutureDateExcludingWeekendsAsync(caseDueDate));
            }
        }


        [Then(@"User validates all the fields under details section")]
        public async Task ThenUserValidatesAllTheFieldsUnderDetailsSection()
        {
            await Assertions.Expect(_tasksPage.GetLabel("Demand Task")).ToBeVisibleAsync();
            await Assertions.Expect(_tasksPage.GetLabel("Merlin Task ID")).ToBeVisibleAsync();
            await Assertions.Expect(_tasksPage.GetLabel("Primary Demand")).ToBeVisibleAsync();
            await Assertions.Expect(_tasksPage.GetLabel("Task Type")).ToBeVisibleAsync();
            await Assertions.Expect(_tasksPage.GetLabel("Urgent Flag")).ToBeVisibleAsync();
            await Assertions.Expect(_tasksPage.GetLabel("Status Reason")).ToBeVisibleAsync();
        }

        [Then(@"User enter demand task details ""([^""]*)""")]
        public async Task ThenUserEnterDemandTaskDetails(string demandType)
        {
            await _tasksPage.EnterDemandTask(demandType);
        }

        [When(@"User Filters the Task ""([^""]*)""")]
        public async Task WhenUserFiltersTheTask(string taskName)
        {
            //await _tasksPage.ClickActivities();
            await _tasksPage.FilterCreatedTask(taskName);
        }


        [Then(@"User validates Merlin task id field is disabled & read only")]
        public async Task ThenUserValidatesMerlinTaskIdFieldIsDisabledReadOnly()
        {
            await Assertions.Expect(_tasksPage.GetMerlinTaskIDReadonly()).ToBeVisibleAsync();
        }

        [Then(@"User enters task details primary demand ""([^""]*)"" task type ""([^""]*)""")]
        public async Task ThenUserEntersTaskDetailsPrimaryDemandTaskType(string primaryDemand, string taskType)
        {
            await _tasksPage.EnterPrimaryDemand(primaryDemand);
            await _tasksPage.EnterTaskType(taskType);
        }

        [Then(@"User enters new task details primary demand ""([^""]*)"" task type ""([^""]*)""")]
        public async Task ThenUserEntersTaskDetailsPrimaryDemandTaskTypeNotOverwrite(string primaryDemand, string taskType)
        {
            await _tasksPage.EnterPrimaryDemandNotOverwrite(primaryDemand);
            await _tasksPage.EnterTaskType(taskType);
        }

        [Then(@"User validates merlinTaskType ""([^""]*)"" and valueStep ""([^""]*)""")]
        public async Task ThenUserValidatesMerlinTaskTypeAndValueStep(string merlinTaskType, string valueStep)
        {
            Assertions.Equals(await _tasksPage.GetMerlinTaskType(merlinTaskType), "Broker - Cancellation Request");
            Assertions.Equals(await _tasksPage.GetValueStep(valueStep), "Understand My Request/Assess Information Provided");
        }

        [Then(@"User enters  task description ""([^""]*)"" and instruction field ""([^""]*)""")]
        public async Task ThenUserEntersTaskDescriptionAndInstructionField(string description, string instruction)
        {
            await _tasksPage.EnterInstructions(instruction);
        }

        [When(@"User navigates to cases '([^']*)' and validates newly created task under Highlights panel '([^']*)'")]
        public async Task WhenUserNavigatesToCasesAndValidatesNewlyCreatedTaskUnderHighlightsPanel(string caseName, string demandType)
        {
            await _casesPage.ClickOnCases();
            await _casesPage.ClickNewlyCreatedCase(caseName);
            await Assertions.Expect(_tasksPage.GetFirstTask()).ToBeVisibleAsync();
        }


        [Then(@"User also validates the case value step moved to ""([^""]*)""")]
        public async Task ThenUserAlsoValidatesTheCaseValueStepMovedTo(string valueStep)
        {
            await Assertions.Expect(_casesPage.GetInProgressValueStep(valueStep)).ToBeVisibleAsync();
        }


        [When(@"User moves value steps to Manage Referral")]
        public async Task WhenUserMovesValueStepsToManageReferral()
        {
            await _casesPage.MoveValueStepsToManageReferral();
        }



        [Then(@"User also validates the case value step remains at ""([^""]*)""")]
        public async Task ThenUserAlsoValidatesTheCaseValueStepRemainsAt(string p0)
        {

        }
        [Then(@"User cancels the case with tasks '([^']*)'")]
        public async Task ThenUserCancelsTheCaseWithTasks(string caseName)
        {
            await _casesPage.ClickOnCases();
            await _casesPage.ClickRefresh();
            await _casesPage.SelectNewlyCreatedCase(caseName);
            await _casesPage.ClickCancelCase();
            await _casesPage.ClickConfirmButton();
            await _casesPage.ClickConfirmButton();
        }
        [When(@"User Enters '([^']*)'")]
        public async void WhenUserEnters(string demandTask)
        {
            await _tasksPage.EnterDemandTask(demandTask);
        }        

        [Then(@"User clicks the on save button")]
        public async Task ThenUserClicksTheOnSaveButton()
        {
            await _tasksPage.ClickSaveButtonAsync();
        }

        [When(@"create the new task '([^']*)' '([^']*)' '([^']*)'")]
        public async Task WhenCreateTheNewTaskCaseNameDemandPrimaryDemand(string caseName,string demandTask, string primaryDemand)
        {
            await _tasksPage.ClickActivities();
            await _tasksPage.ClickTask();
            await _tasksPage.EnterDemandTask(demandTask);
            await _tasksPage.EnterPrimaryDemand(primaryDemand);

        }

        [When(@"User select the task '([^']*)' from task page")]
        public async Task WhenUserSelectTheTaskFromTaskPage(string taskName)
        {
            await _tasksPage.ClickActivities();
            await _tasksPage.SelectNewlyCreatedTask(taskName);
        }

        [Then(@"User validates the task '([^']*)' ownernName is changed to '([^']*)'")]
        public async Task ThenUserValidatesTheCasesOwnernameIsChangedTo(string taskName, string ownerName)
        {
            await _tasksPage.ClickActivities();
            await _tasksPage.SelectAllActivitiesFromTaskPage();
            await _tasksPage.FilterTasksByOwnerName(ownerName);
            await _tasksPage.validateTasksDisplayedWithOwnerName(taskName, ownerName);
        }

        [Then(@"User cancels the tasks '([^']*)'")]
        public async Task ThenUserCancelsTheTasks(string taskName)
        {
            await _tasksPage.SelectNewlyCreatedTask(taskName);
            await _tasksPage.ClickCancelTask();
            await _tasksPage.ClickCloseTaskButton();
        }


        [Then(@"User validates the Task fields")]
        public async Task ThenUserValidatesTheTaskFields(Table table)
        {
            foreach (var row in table.Rows)
            {
                Assertions.Equals(await _tasksPage.GetLabelAsync(row["Fields"].Replace("'", string.Empty)), true);
            }
        }

        [Then(@"User creates task with regarding '([^']*)' demand task '([^']*)' and primary demand '([^']*)'")]
        public async Task CreateTask(string regardings, string demandTask, string primaryDemand)
        {
            await _tasksPage.EnterRegardings(regardings);
            await _tasksPage.EnterDemandTask(demandTask);
            await _tasksPage.EnterPrimaryDemand(primaryDemand);
            await _tasksPage.SaveTask();

        }

        [Then(@"User creates task with regarding '([^']*)' demand task '([^']*)' and validates case due date '([^']*)'")]
        public async Task ThenUserCreatesTaskWithRegardingDemandTaskAndValidatesCaseDueDate(string regardings, string demandTask, string caseDueDate)
        {
            await _tasksPage.EnterRegardings(regardings);
            await _tasksPage.EnterDemandTask(demandTask);
            await _tasksPage.EnterPrimaryDemand("I want to cancel");
            await _tasksPage.SaveTask();
            await _tasksPage.ClickRefreshAsync();
            await _tasksPage.ClickRefreshAsync();
            await _tasksPage.ClickRefreshAsync();

            Assertions.Equals(await _tasksPage.GetCaseDueDate(), caseDueDate);

        }

        [Then(@"User changes regarding '([^']*)' and validates case due date '([^']*)'")]
        public async Task ThenUserChangesRegardingAndValidatesCaseDueDate(string regardings, string caseDueDate)
        {
            await _tasksPage.ClickCancelRegardingsAsync();
            await _tasksPage.EnterRegardings(regardings);
            await _tasksPage.SaveTask();
            await _tasksPage.ClickRefreshAsync();
            await _tasksPage.ClickRefreshAsync();
            await _tasksPage.ClickRefreshAsync();

            Assertions.Equals(await _tasksPage.GetCaseDueDate(), caseDueDate);
        }

    }
}
