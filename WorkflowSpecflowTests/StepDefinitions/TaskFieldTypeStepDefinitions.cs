using System;
using Microsoft.Playwright;
using TechTalk.SpecFlow;
using WorkflowSpecflowTests.Pages;
using xRetry;

namespace WorkflowSpecflowTests.StepDefinitions
{
    [Binding]
    public class TaskFieldTypeStepDefinitions
    {
        private readonly ITaskTypePage _taskTypePage;
        private readonly IBasePage _basePage;
        private readonly ICommonStepDefiniation _commonStep;
        private readonly ICasesPage _casesPage;
        private readonly IDynamicsLoginPage _dynamicsLoginPage;

        public TaskFieldTypeStepDefinitions(ITaskTypePage taskTypePage, IBasePage basePage, ICommonStepDefiniation commonStep, ICasesPage casesPage, IDynamicsLoginPage dynamicsLoginPage)
        {
            _taskTypePage = taskTypePage;
            _basePage = basePage;
            _commonStep = commonStep;
            _casesPage = casesPage;
            _dynamicsLoginPage = dynamicsLoginPage;
        }

        [When(@"User selects customer admin hub from Dynamics Home page")]
        public async Task WhenUserSelectsCustomerAdminHubFromDHomePage()
        {
            await _casesPage.ClickOnCustomerServiceAdmin();
        }

        [When(@"User selects customer service hub from Dynamics Home page")]
        public async Task WhenUserSelectsCustomerServiceHubFromDynamicsHomePage()
        {
            await _casesPage.ClickOnCustomerServiceHub();
            Thread.Sleep(3000);
            await _dynamicsLoginPage.HandleCopilotAsync();
        }


        [When(@"User selects task type from Sitemap menu")]
        public async Task WhenUserSelectsTaskTypeFromSitemapMenu()
        {
            await _commonStep.ValidateAdminSiteMap();
            await _taskTypePage.ClickTaskType();
        }

        [Then(@"User clicks on new button and validates all fields")]
        public async Task ThenUserClicksOnNewButtonAndValidatesAllFields()
        {
            await _taskTypePage.ClickNew();
            await _commonStep.ValidateTaskTypeTabFields();
        }

        [Then(@"User validates error messages")]
        public async Task ThenUserValidatesErrorMessages()
        {
            await _taskTypePage.ClickSave();
            await Assertions.Expect(await _taskTypePage.IsFieldVisible("Primary Demand: Required fields must be filled in.")).ToBeVisibleAsync();
            await Assertions.Expect(await _taskTypePage.IsFieldVisible("Task Type: Required fields must be filled in.")).ToBeVisibleAsync();
            await Assertions.Expect(await _taskTypePage.IsFieldVisible("Merlin Task Type: Required fields must be filled in.")).ToBeVisibleAsync();
        }

        [Then(@"User fills all the details in the page primary demand '([^']*)' task type '([^']*)' merlin task type '([^']*)' manual selection '([^']*)' value step '([^']*)'")]
        public async Task ThenUserFillsAllTheDetailsInThePagePrimaryDemandTaskTypeMerlinTaskTypeManualSelectionValueStep(string primaryDemand, string taskType, string merlinTaskType, string availableForManualSelection, string valueStep)
        {
            await _taskTypePage.ClickBack();
            await _taskTypePage.ClickNew();
            await _taskTypePage.EnterPrimaryDeamnd(primaryDemand);
            await _taskTypePage.EnterTaskType(taskType);
            await _taskTypePage.EnterMerlinTaskType(merlinTaskType);
            await _taskTypePage.SelectAvailableForManualSelection(availableForManualSelection);
            await _taskTypePage.EnterValueStep(valueStep);
        }


        [Then(@"User finishes task type creation & validate all fields in view mode")]
        public async Task ThenUserFinishesTaskTypeCreationValidateAllFieldsInViewMode()
        {
            await _taskTypePage.ClickSaveAndClose();

        }

        [Then(@"User deletes the task type '([^']*)'")]
        public async Task ThenUserDeletesTheTaskType(string taskType)
        {
            await _taskTypePage.SearchTaskType(taskType);
            await _taskTypePage.SelectNewlyCreatedTaskType();
            await _taskTypePage.ClickDelete();
            await _taskTypePage.ClickDeleteBtn();
        }

        
        [Then(@"User clicks on New")]
        public async Task ThenUserClicksOnNew()
        {
            await _taskTypePage.ClickNew();
        }


        [Then(@"User clicks task type")]
        public async Task ThenUserClicksTaskType()
        {
            await _taskTypePage.ClickTaskType();        
        }

        [Then(@"User validates Task type & merlin task type fields having (.*) characters as per data catalogue")]
        public async Task ThenUserValidatesTaskTypeMerlinTaskTypeFieldsHavingCharactersAsPerDataCatalogue(int p0, Table table)
        {
            foreach (var row in table.Rows)
            {
                await _taskTypePage.EnterPrimaryDeamnd(row["PrimaryDemand"].Replace("'", string.Empty));
                await _taskTypePage.EnterTaskType(row["TaskType"].Replace("'", string.Empty));
                await _taskTypePage.EnterMerlinTaskType(row["MerlinType"].Replace("'", string.Empty));
                await _taskTypePage.SelectAvailableForManualSelection(row["AvailableForManualSelection"].Replace("'", string.Empty));
                await _taskTypePage.EnterValueStep(row["ValueStep"].Replace("'", string.Empty));

                await _taskTypePage.ClickSave();
                Assertions.Equals(await _taskTypePage.GetSaveLabel(), row["TaskType"].Replace("'", string.Empty) + "- Saved");
                await _taskTypePage.ClickDelete();
                await _taskTypePage.ClickDeleteBtn();
            }
           

        }

        [Then(@"User validates all fields & save the task type")]
        public async Task ThenUserValidatesAllFieldsSaveTheTaskType(Table table)
        {
            await _commonStep.ValidateTaskTypeTabFields();
            foreach (var row in table.Rows)
            {
                await _taskTypePage.EnterPrimaryDeamnd(row["PrimaryDemand"].Replace("'", string.Empty));
                await _taskTypePage.EnterTaskType(row["TaskType"].Replace("'", string.Empty));
                await _taskTypePage.EnterMerlinTaskType(row["MerlinType"].Replace("'", string.Empty));
                await _taskTypePage.SelectAvailableForManualSelection(row["AvailableForManualSelection"].Replace("'", string.Empty));
                await _taskTypePage.EnterValueStep(row["ValueStep"].Replace("'", string.Empty));

                await _taskTypePage.ClickSave();
                Assertions.Equals(await _taskTypePage.GetSaveLabel(), row["TaskType"].Replace("'", string.Empty) + "- Saved");
                await _taskTypePage.ClickDelete();
                await _taskTypePage.ClickDeleteBtn();
            }
        }

    }
}
