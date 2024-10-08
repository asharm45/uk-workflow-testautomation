using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WorkflowSpecflowTests.Config;
using WorkflowSpecflowTests.Pages;

namespace WorkflowSpecflowTests.StepDefinitions
{
    [Binding]
    public class QueuesStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IQueuesPage _queuesPage;

        public QueuesStepDefinition(ScenarioContext scenarioContext, IQueuesPage queuesPage)
        {
            _scenarioContext = scenarioContext;
            _queuesPage = queuesPage;
        }

        [Then(@"User clicks on queue")]
        public async Task ThenUserClicksOnQueue()
        {
            await _queuesPage.ClickQueuesAsync();
        }
        [Then(@"user selects all items and clicks test_uksc")]
        public async Task ThenUserSelectsAllItemsAndClicksTest_Uksc()
        {
            await _queuesPage.ClickAllItemsAsync();
            await _queuesPage.ClickTestUKSCAsync();
        }
        [Then(@"User searches the email by subject '([^']*)' and validate present in TEST_UKSC queue")]
        public async Task ThenUserSearchesTheEmailBySubjectAndValidatePresentInTEST_UKSCQueue(string subject)
        {
            await _queuesPage.SearchForSubjectAsync(subject);
        }
        [Then(@"User clicks on Dashboards")]
        public async Task ThenUserClicksOnDashboards()
        {
            await _queuesPage.ClickOnDashboardsAsync();
        }
        [Then(@"Validates case is not present after clicking on pick work button '([^']*)'")]
        public async Task ThenValidatesCaseIsNotPresentAfterClickingOnPickWorkButton(string subject)
        {
            await _queuesPage.PickWorkValidationAsync(subject);
        }





        [Then(@"User validates all the queues visible on the screen")]
        public async Task ThenUserValidatesAllTheQueuesVisibleOnTheScreen(Table table)
        {
            await _queuesPage.ClickManageAsync();
            await _queuesPage.ClickDropDownAsync();
            await _queuesPage.ClickAllQueuesAsync();
            await _queuesPage.ClickOwnerAsync();
            await _queuesPage.ClickFilterByAsync();
            await _queuesPage.ClickFilterOperatorAsync();
            await _queuesPage.ClickContainsAsync();
            await _queuesPage.EnterOwnerAsync("# Svc_HiscoxUKWorkflowNTT2");
            await _queuesPage.ClickApplyAsync();
            foreach(var row in table.Rows)
            {
                Assertions.Equals(await _queuesPage.GetQueueAsync(row["QueueName"].Replace("'", string.Empty)), row["QueueName"].Replace("'", string.Empty));
            }
        }

        [Then(@"User puts case in UKSC- Manual Triage queue")]
        public async Task ThenUserPutsCaseInUKSC_ManualTriageQueue()
        {
            await _queuesPage.ClickMore1Async();
            await _queuesPage.ClickAddToQueueAsync();
            await _queuesPage.EnterQueueAsync("UKSC- Manual Triage");
            await _queuesPage.ClickAddAsync();
        }

        [Then(@"User validates queue details popup for case")]
        public async Task ThenUserValidatesQueueDetailsPopupForCase()
        {
            await _queuesPage.ClickMore1Async();
            await _queuesPage.ClickQueueItemsDetailsAsync();
            Assertions.Equals(await _queuesPage.GetQueueNameAsync(), "UKSC- Manual Triage");
            await _queuesPage.ClickMore2Async();
            await _queuesPage.ClickCloseAsync();
        }

        [When(@"User puts task in UKSC- Manual Triage queue")]
        public async Task WhenUserPutsTaskInUKSC_ManualTriageQueue()
        {
            await _queuesPage.ClickMore1Async();
            await _queuesPage.ClickAddToQueueAsync();
            await _queuesPage.EnterQueueAsync("UKSC- Manual Triage");
            await _queuesPage.ClickAddAsync();
        }

        [When(@"User validates queue details popup for task")]
        public async Task WhenUserValidatesQueueDetailsPopupForTask()
        {
            await _queuesPage.ClickMore1Async();
            await _queuesPage.ClickQueueItemsDetailsAsync();
            Assertions.Equals(await _queuesPage.GetQueueNameAsync(), "UKSC- Manual Triage");
            await _queuesPage.ClickMore2Async();
            await _queuesPage.ClickCloseAsync();
        }

    }
}
