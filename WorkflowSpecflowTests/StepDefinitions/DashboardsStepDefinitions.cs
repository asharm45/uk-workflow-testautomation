using Microsoft.Playwright;
using WorkflowSpecflowTests.Pages;

namespace WorkflowSpecflowTests.StepDefinitions
{
    [Binding]
    public class DashboardsStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IDashboardsPage _dashboardsPage;

        public DashboardsStepDefinitions(ScenarioContext scenarioContext, IDashboardsPage dashboardsPage)
        {
            _scenarioContext = scenarioContext;
            _dashboardsPage = dashboardsPage;
        }

        [When(@"User clicks on Dashboard")]
        public async Task WhenUserClicksOnDashboard()
        {
            await _dashboardsPage.ClickDashboardsAsync();
        }

        [Then(@"User validates dynamics dashboards are NOT visible")]
        public async Task ThenUserValidatesDynamicsDashboardsAreNOTVisible(Table table)
        {
            await _dashboardsPage.ClickDashboardsDropdownAsync();
            foreach (var row in table.Rows)
            {
                Assertions.Equals(await _dashboardsPage.GetDashboardAsync(row["Dashboards"].Replace("'", string.Empty)), 0);
            }
        }
    }

}
