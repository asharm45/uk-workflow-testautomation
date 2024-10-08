using System;
using System.Threading.Channels;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WorkflowSpecflowTests.Pages;

namespace WorkflowSpecflowTests.StepDefinitions
{
    [Binding]
    public class PoliciesAndCasesStepDefinitions
    {
        private readonly IPoliciesPage _policiesPage;
        private readonly ICasesPage _casesPage;
        private readonly ITasksPage _tasksPage;
        private readonly IBasePage _basePage;
        private readonly IContactPage _contactPage;
        private readonly IPolicyHoldersPage _policyHoldersPage;

        public PoliciesAndCasesStepDefinitions(IPoliciesPage policiesPage, ICasesPage casesPage, ITasksPage tasksPage, IBasePage basePage, IContactPage contactPage, IPolicyHoldersPage policyHoldersPage)
        {
            _policiesPage = policiesPage;
            _casesPage = casesPage;
            _tasksPage = tasksPage;
            _basePage = basePage;
            _contactPage = contactPage;
            _policyHoldersPage = policyHoldersPage;
        }

        [When(@"User creates policy link it with case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer>  <Product> <PolicyReference> <CaseDueDate> sum insures <SumInsured> motor sum insured <MotorSumInsured> motor total sum insured <MotorTotalSumInsured> channel <Channel> policy start date <PolicyStartDate> policy end date <PolicyEndDate> policy inception date <PolicyInceptionDate> policy renweal date <PolicyRenewalDate> risk address <RiskAddress> excesses <Excesses> pas flag <PASFlag>")]
        public async Task WhenUserCreatesPolicyLinkItWithCase(Table table)
        {
            foreach (var row in table.Rows)
            {
                await _policiesPage.ClickPoliciesAsync();
                await _policiesPage.ClickNewAsync();
                await _policiesPage.EnterPolicyReferenceAsync(row["PolicyReference"].Replace("'",string.Empty));
                await _policiesPage.SelectChannelAsync(row["Channel"].Replace("'", string.Empty));
                await _policiesPage.PolicyStartDateAsync(row["PolicyStartDate"].Replace("'", string.Empty));
                await _policiesPage.PolicyEndDateAsync(row["PolicyEndDate"].Replace("'", string.Empty));
                await _policiesPage.EnterRiskAddressAsync(row["RiskAddress"].Replace("'", string.Empty));
                await _policiesPage.EnterExcessesAsync(row["Excesses"].Replace("'", string.Empty));
                await _policiesPage.SelectPASFlagAsync(row["PASFlag"].Replace("'", string.Empty));
                await _policiesPage.EnterSumInsuredAsync(row["SumInsured"].Replace("'", string.Empty));
                await _policiesPage.EnterMotorSumInsuredAsync(row["MotorSumInsured"].Replace("'", string.Empty));
                await _policiesPage.EnterMotorTotalInsuredAsync(row["MotorTotalSumInsured"].Replace("'", string.Empty));
                await _basePage.ClickSaveButton();

                await _casesPage.ClickOnCases();
                await _casesPage.AddNewCase();

                await _casesPage.EnterCaseNameAsync(row["CaseName"].Replace("'", string.Empty));
                await _casesPage.EnterPrimaryDemandAsync(row["PrimaryDemand"].Replace("'", string.Empty));
                await _casesPage.EnterDemandAsync(row["Demand"].Replace("'", string.Empty));
                await _casesPage.EnterSubDemandAsync(row["PrimaryDemand"].Replace("'", string.Empty), row["SubDemand"].Replace("'", string.Empty));
                await _casesPage.EnterCustomerAsync(row["Customer"].Replace("'", string.Empty));
                await _casesPage.EnterPolicyReferenceNumbereAsync(row["PolicyReference"].Replace("'", string.Empty));
                await _casesPage.EnterPolicyReferenceAsync(row["PolicyReference"].Replace("'", string.Empty));
                await _casesPage.EnterProductAsync(row["Product"].Replace("'", string.Empty));
                await _casesPage.EnterCaseDueDateAsync("Admin",row["CaseDueDate"].Replace("'", string.Empty));

                await _basePage.ClickSaveButton();
            }
        }

        [When(@"User creates policy link it with case and task <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer>  <Product> <PolicyReference> <CaseDueDate> sum insures <SumInsured> motor sum insured <MotorSumInsured> motor total sum insured <MotorTotalSumInsured> channel <Channel> policy start date <PolicyStartDate> policy end date <PolicyEndDate> policy inception date <PolicyInceptionDate> policy renweal date <PolicyRenewalDate> risk address <RiskAddress> excesses <Excesses> pas flag <PASFlag> and demand task <DemandTask> primary demand of task <TaskPrimaryDemand>")]
        public async Task WhenUserCreatesPolicyLinkItWithCaseAndTask(Table table)
        {
            foreach (var row in table.Rows)
            {
                await _policiesPage.ClickPoliciesAsync();
                await _policiesPage.ClickNewAsync();
                await _policiesPage.EnterPolicyReferenceAsync(row["PolicyReference"].Replace("'", string.Empty));
                await _policiesPage.SelectChannelAsync(row["Channel"].Replace("'", string.Empty));
                await _policiesPage.PolicyStartDateAsync(row["PolicyStartDate"].Replace("'", string.Empty));
                await _policiesPage.PolicyEndDateAsync(row["PolicyEndDate"].Replace("'", string.Empty));
                await _policiesPage.EnterRiskAddressAsync(row["RiskAddress"].Replace("'", string.Empty));
                await _policiesPage.EnterExcessesAsync(row["Excesses"].Replace("'", string.Empty));
                await _policiesPage.SelectPASFlagAsync(row["PASFlag"].Replace("'", string.Empty));
                await _policiesPage.EnterSumInsuredAsync(row["SumInsured"].Replace("'", string.Empty));
                await _policiesPage.EnterMotorSumInsuredAsync(row["MotorSumInsured"].Replace("'", string.Empty));
                await _policiesPage.EnterMotorTotalInsuredAsync(row["MotorTotalSumInsured"].Replace("'", string.Empty));
                await _basePage.ClickSaveButton();

                await _casesPage.ClickOnCases();
                await _casesPage.AddNewCase();

                await _casesPage.EnterCaseNameAsync(row["CaseName"].Replace("'", string.Empty));
                await _casesPage.EnterPrimaryDemandAsync(row["PrimaryDemand"].Replace("'", string.Empty));
                await _casesPage.EnterDemandAsync(row["Demand"].Replace("'", string.Empty));
                await _casesPage.EnterSubDemandAsync(row["PrimaryDemand"].Replace("'", string.Empty), row["SubDemand"].Replace("'", string.Empty));
                await _casesPage.EnterCustomerAsync(row["Customer"].Replace("'", string.Empty));
                await _casesPage.EnterPolicyReferenceNumbereAsync(row["PolicyReference"].Replace("'", string.Empty));
                await _casesPage.EnterPolicyReferenceAsync(row["PolicyReference"].Replace("'", string.Empty));
                await _casesPage.EnterProductAsync(row["Product"].Replace("'", string.Empty));
                await _casesPage.EnterCaseDueDateAsync("Admin", row["CaseDueDate"].Replace("'", string.Empty));

                await _basePage.ClickSaveButton();

                await _tasksPage.ClickActivities();
                await _tasksPage.ClickTask();
                await _tasksPage.EnterRegardings(row["CaseName"].Replace("'", string.Empty));
                await _tasksPage.EnterDemandTask(row["DemandTask"].Replace("'", string.Empty));
                await _tasksPage.EnterPrimaryDemand(row["TaskPrimaryDemand"].Replace("'", string.Empty));

                await _tasksPage.SaveTask();
            }
        }

        [When(@"User creates policy and contact and link it with policy holder with policy reference <PolicyReference> sum insures <SumInsured> motor sum insured <MotorSumInsured> motor total sum insured <MotorTotalSumInsured> channel <Channel> policy start date <PolicyStartDate> policy end date <PolicyEndDate> policy inception date <PolicyInceptionDate> policy renweal date <PolicyRenewalDate> risk address <RiskAddress> excesses <Excesses> pas flag <PASFlag>")]
        public async Task CreatePolicies(Table table)
        {
            foreach (var row in table.Rows)
            {
                await _policiesPage.ClickPoliciesAsync();
                await _policiesPage.ClickNewAsync();
                await _policiesPage.EnterPolicyReferenceAsync(row["PolicyReference"].Replace("'", string.Empty));
                await _policiesPage.SelectChannelAsync(row["Channel"].Replace("'", string.Empty));
                await _policiesPage.PolicyStartDateAsync(row["PolicyStartDate"].Replace("'", string.Empty));
                await _policiesPage.PolicyEndDateAsync(row["PolicyEndDate"].Replace("'", string.Empty));
                await _policiesPage.EnterRiskAddressAsync(row["RiskAddress"].Replace("'", string.Empty));
                await _policiesPage.EnterExcessesAsync(row["Excesses"].Replace("'", string.Empty));
                await _policiesPage.SelectPASFlagAsync(row["PASFlag"].Replace("'", string.Empty));
                await _policiesPage.EnterSumInsuredAsync(row["SumInsured"].Replace("'", string.Empty));
                await _policiesPage.EnterMotorSumInsuredAsync(row["MotorSumInsured"].Replace("'", string.Empty));
                await _policiesPage.EnterMotorTotalInsuredAsync(row["MotorTotalSumInsured"].Replace("'", string.Empty));
                await _basePage.ClickSaveButton();

            }
        }

        [When(@"User creates contact and contact with first name <FirstName> sur name <SurName>")]
        public async Task CreateContacts(Table table)
        {
            foreach (var row in table.Rows)
            {
                await _contactPage.ClickContact();
                await _contactPage.ClickNew();
                await _contactPage.EnterFirstNameAsync(row["FirstName"].Replace("'", string.Empty));
                await _contactPage.EnterSurNameAsync(row["SurName"].Replace("'", string.Empty));
                await _contactPage.ClickSaveAsync();

            }
        }
        [Then(@"User creates policy holder with policy <PolicyReference> contact first name <FirstName> sur name <SurName> and policy holder <PolicyHolder> primary policy holder <PrimaryPolicyHolder>")]
        public async Task CreatePolicyHolder(Table table)
        {
            foreach (var row in table.Rows)
            {
                await _policyHoldersPage.ClickPolicyHolderAsync();
                await _policyHoldersPage.ClickNewAsync();
                await _policyHoldersPage.EnterPolicyAsync(row["PolicyReference"].Replace("'", string.Empty));
                await _policyHoldersPage.EnterContactAsync(row["FirstName"].Replace("'", string.Empty), row["SurName"].Replace("'", string.Empty));
                await _policyHoldersPage.SelectPolicyHolderAsync(row["PolicyHolder"].Replace("'", string.Empty));
                await _policyHoldersPage.SelectPrimaryPolicyHolderAsync(row["PrimaryPolicyHolder"].Replace("'", string.Empty));
                await _policyHoldersPage.ClickSaveAsync();

            }
        }
        [Then(@"User Clicks on Policies '([^']*)'")]
        public async Task ThenUserClicksOnPolicies(string policy)
        {
            await _policiesPage.ClickPoliciesAsync();
            await _policiesPage.FilterPolicyAndClick(policy);

        }

        [Then(@"User Validates the user policy renewal date")]
        public async Task ThenUserValidatesTheUserPolicyRenewalDate()
        {
            await _policiesPage.DateCalculation();
        }
        [When(@"User searches the policy from search bar and clicks on it '([^']*)'")]
        public async Task WhenUserSearchesThePolicyFromSearchBarAndClicksOnIt(string policy)
        {
            await _policiesPage.FilterPolicyAndClick(policy);
        }


        [Then(@"Check Whether it's read-only")]
        public async Task ThenCheckWhetherItsRead_Only()
        {
            await _policiesPage.ReadOnly();
        }
        [Given(@"User Clicks on Policy Holders from Service AreaGroup")]
        public async Task GivenUserClicksOnPolicyHoldersFromServiceAreaGroup()
        {
            await _policyHoldersPage.ClickPolicyHolderAsync();
        }
        [Then(@"User Validates new policy holder page")]
        public async Task ThenUserValidatesNewPolicyHolderPage()
        {
            await _policyHoldersPage.ValidateNewPolicyHolderAsync();
        }
        [Then(@"User Enter the Policy '([^']*)'")]
        public async Task ThenUserEnterThePolicy(string policy)
        {
            await _policyHoldersPage.EnterPolicyAsync(policy);
        }
        [Then(@"User selects the contact '([^']*)' and policy contact role '([^']*)'")]
        public async Task ThenUserSelectsTheContactAndPolicyContactRole(string contact, string policyContactRole)
        {
            await _policyHoldersPage.SelectContactAndPolicyRole(contact, policyContactRole);
        }

        [Then(@"User selects policy holder and primary policy holder")]
        public async Task ThenUserSelectsPolicyHolderAndPrimaryPolicyHolder()
        {
            await _policyHoldersPage.PolicyHolderAndPrimaryAsYes();
        }

        [Then(@"User Clicks on Save button")]
        public async Task ThenUserClicksOnSaveButton()
        {
            await _policyHoldersPage.ClickSaveAsync();
        }
        [Then(@"User Clicks On Created On and sorts by newer to older")]
        public async Task ThenUserClicksOnCreatedOnAndSortsByNewerToOlder()
        {
            await _policyHoldersPage.CreatedOnSort();
        }
        [Then(@"User selects the policy Holder and Validates")]
        public async Task ThenUserSelectsThePolicyHolder()
        {
            await _policyHoldersPage.SelectTheFirstPolicy();
        }







    }
}
