using Microsoft.Playwright;
using WorkflowSpecflowTests.Pages;

namespace WorkflowSpecflowTests.StepDefinitions
{
    public interface ICommonStepDefiniation
    {
        Task ValidateSiteMap();
        Task ValidateCaseSummaryTabFields();
        Task ValidateCaseDetailsTabFields();
        Task ValidateAdminSiteMap();
        Task ValidateTaskTypeTabFields();
        Task ValidateActiveUnderwriterauthorities();
        Task ValidateCaseFields();
        Task ValidateNewSLAStoppagePage();
        Task ValidateEmailFromTimeLine();
    }

    public class CommonStepDefiniation : ICommonStepDefiniation
    {
        private readonly ICasesPage _casesPage;
        private readonly ITasksPage _tasksPage;
        private readonly IUnderwriterAuthorityPage _underwriterAuthorityPage;
        private readonly ISLAstoppagePage _slaStoppage;

        public CommonStepDefiniation(ICasesPage casesPage, ITasksPage tasksPage, IUnderwriterAuthorityPage underwriterAuthorityPage, ISLAstoppagePage SLAstoppagePage)
        {
            _casesPage = casesPage;
            _tasksPage = tasksPage;
            _underwriterAuthorityPage = underwriterAuthorityPage;
            _slaStoppage = SLAstoppagePage;
        }

        public async Task ValidateSiteMap()
        {
            Assertions.Equals(await _casesPage.GetSitemapMenu("Go to home page").TextContentAsync(), "Home");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Recent items").TextContentAsync(), "Recent");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Pinned items").TextContentAsync(), "Pinned");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Dashboards").TextContentAsync(), "Dashboards");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Activities").TextContentAsync(), "Activities");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Accounts").TextContentAsync(), "Accounts");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Contacts").TextContentAsync(), "Contacts");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Social Profiles").TextContentAsync(), "Social Profiles");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Cases").TextContentAsync(), "Cases");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Queues").TextContentAsync(), "Queues");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Policies").TextContentAsync(), "Policies");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Policy Holders").TextContentAsync(), "Policy Holders");
            Assertions.Equals(await _casesPage.GetSitemapMenu("SLA Stoppages").TextContentAsync(), "SLA Stoppages");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Knowledge Articles").TextContentAsync(), "Knowledge Articles");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Knowledge Search").TextContentAsync(), "Knowledge Search");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Customer Assets").TextContentAsync(), "Customer Assets");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Email templates").TextContentAsync(), "Email templates");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Email signatures").TextContentAsync(), "Email signatures");
        }

        public async Task ValidateAdminSiteMap()
        {

            Assertions.Equals(await _casesPage.GetSitemapMenu("Get started", "Home").TextContentAsync(), "Home");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Get started", "Search admin settings").TextContentAsync(), "Search admin settings");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Get started", "Guided channel setups").TextContentAsync(), "Guided channel setups");

            Assertions.Equals(await _casesPage.GetSitemapMenu("Customer support", "Overview").TextContentAsync(), "Overview");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Customer support", "User management").TextContentAsync(), "User management");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Customer support", "Channels").TextContentAsync(), "Channels");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Customer support", "Queues").TextContentAsync(), "Queues");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Customer support", "Routing").TextContentAsync(), "Routing");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Customer support", "Case settings").TextContentAsync(), "Case settings");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Customer support", "Customer settings").TextContentAsync(), "Customer settings");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Customer support", "Task Types").TextContentAsync(), "Task Types");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Customer support", "Underwriter Authorities").TextContentAsync(), "Underwriter Authorities");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Customer support", "Demands").TextContentAsync(), "Demands");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Customer support", "Products").TextContentAsync(), "Products");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Customer support", "SLA Times").TextContentAsync(), "SLA Times");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Customer support", "Reinfer Labels Mapping").TextContentAsync(), "Reinfer Labels Mapping");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Customer support", "Predictions thresholds").TextContentAsync(), "Predictions thresholds");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Customer support", "Overview").TextContentAsync(), "Overview");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Customer support", "User management").TextContentAsync(), "User management");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Customer support", "Channels").TextContentAsync(), "Channels");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Customer support", "Queues").TextContentAsync(), "Queues");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Customer support", "Routing").TextContentAsync(), "Routing");

            Assertions.Equals(await _casesPage.GetSitemapMenu("Agent experience", "Overview").TextContentAsync(), "Overview");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Agent experience", "Workspaces").TextContentAsync(), "Workspaces");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Agent experience", "Productivity").TextContentAsync(), "Productivity");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Agent experience", "Knowledge").TextContentAsync(), "Knowledge");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Agent experience", "Collaboration").TextContentAsync(), "Collaboration");


            Assertions.Equals(await _casesPage.GetSitemapMenu("Operations", "Overview").TextContentAsync(), "Overview");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Operations", "Insights").TextContentAsync(), "Insights");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Operations", "Calendar").TextContentAsync(), "Calendar");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Operations", "Service terms").TextContentAsync(), "Service terms");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Operations", "Service scheduling").TextContentAsync(), "Service scheduling");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Operations", "Miscellaneous").TextContentAsync(), "Miscellaneous");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Operations", "Cases").TextContentAsync(), "Cases");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Operations", "IoT Alerts").TextContentAsync(), "IoT Alerts");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Operations", "Leads").TextContentAsync(), "Leads");
            Assertions.Equals(await _casesPage.GetSitemapMenu("Operations", "Opportunities").TextContentAsync(), "Opportunities");


        }

        public async Task ValidateCaseSummaryTabFields()
        {
            await Assertions.Expect(await _casesPage.IsFieldVisible("Case Name", 1)).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Case Number", 1)).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Primary Demand", 1)).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Demand", 1)).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Sub Demand", 1)).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Customer", 1)).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Product", 1)).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Policy Reference Number", 1)).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Policy Reference", 1)).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Case Due Date", 1)).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Start Handling Date", 1)).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Description", 1)).ToBeVisibleAsync();
        }

        public async Task ValidateCaseFields()
        {
            await Assertions.Expect(await _casesPage.IsFieldVisible("Priority", 1)).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Created On", 1)).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Status", 1)).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Case Status", 1)).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Demand Type", 1)).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Owner", 1)).ToBeVisibleAsync();
        }

        public async Task ValidateCaseDetailsTabFields()
        {
            await Assertions.Expect(await _casesPage.IsFieldVisible("Case Name", 2)).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Primary Demand", 2)).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Customer", 2)).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("ID")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Origin")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Contact")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Address Line")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Town/City")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("UK PostCode")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Agency Code")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Hiscox APC Policy Number")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Building works")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("New BAH")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Registration Plate")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Security Device")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("New Payment Method")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Current Commission Percentage")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("New Commission Percentage")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Driver Name")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("New Name")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Mileage")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Parent Case")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Is Escalated")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Escalated On")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Follow Up By")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("First Response Sent")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("First Response By")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Resolve By")).ToBeVisibleAsync();
        }

        public async Task ValidateTaskTypeTabFields()
        {
            await Assertions.Expect(await _tasksPage.IsFieldVisible("Primary Demand", 1)).ToBeVisibleAsync();
            await Assertions.Expect(await _tasksPage.IsFieldVisible("Task Type", 1)).ToBeVisibleAsync();
            await Assertions.Expect(await _tasksPage.IsFieldVisible("Merlin Task Type", 1)).ToBeVisibleAsync();
            await Assertions.Expect(await _tasksPage.IsFieldVisible("Available for Manual Selection", 1)).ToBeVisibleAsync();
            await Assertions.Expect(await _tasksPage.IsFieldVisible("Value Step", 1)).ToBeVisibleAsync();

        }
        public async Task ValidateActiveUnderwriterauthorities()
        {
            await Assertions.Expect(await _underwriterAuthorityPage.IsFieldVisible("Agent")).ToBeVisibleAsync();
            await Assertions.Expect(await _underwriterAuthorityPage.IsFieldVisible("Property only")).ToBeVisibleAsync();
            await Assertions.Expect(await _underwriterAuthorityPage.IsFieldVisible("Motor only single vehicle")).ToBeVisibleAsync();
            await Assertions.Expect(await _underwriterAuthorityPage.IsFieldVisible("Motor total accumulation")).ToBeVisibleAsync();
            await Assertions.Expect(await _underwriterAuthorityPage.IsFieldVisible("Created On")).ToBeVisibleAsync();
        }

        public async Task ValidateNewSLAStoppagePage()
        {
            await Assertions.Expect(await _slaStoppage.IsFieldVisible("Case")).ToBeVisibleAsync();
            await Assertions.Expect(await _slaStoppage.IsFieldVisible("Pended Time")).ToBeVisibleAsync();
            await Assertions.Expect(await _slaStoppage.IsFieldVisible("Unpended Time")).ToBeVisibleAsync();
        }

        public async Task ValidateEmailFromTimeLine()
        {
            await Assertions.Expect(await _casesPage.IsFieldVisible("From")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("To")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Cc")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Bcc")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Subject")).ToBeVisibleAsync();
            await Assertions.Expect(await _casesPage.IsFieldVisible("Regarding")).ToBeVisibleAsync();
        }


    }
}
