using Microsoft.Playwright;
using System.Reactive.Subjects;
using WorkflowSpecflowTests.Pages;

namespace WorkflowSpecflowTests.StepDefinitions
{
    [Binding]
    public class ChildCaseStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ICasesPage _casesPage;
        private readonly IChildCasePage _childCasePage;
        private readonly IBasePage _basePage;
        private readonly IActivitiesPage _activitiesPage;

        public ChildCaseStepDefinitions(ScenarioContext scenarioContext, ICasesPage casesPage, IChildCasePage childCasePage, IBasePage basePage, IActivitiesPage activitiesPage)
        {
            _scenarioContext = scenarioContext;
            _casesPage = casesPage;
            _childCasePage = childCasePage;
            _basePage = basePage;
            _activitiesPage = activitiesPage;
        }

        [Then(@"User clicks on Case Relationships tab and clicks on new case button to add a quick case")]
        public async Task ThenUserClicksOnCaseRelationshipsTabAndClicksOnNewCaseButtonToAddAQuickCase()
        {
            await _casesPage.ClickOnCaseRelationshipsTab();
            await _childCasePage.ClickChildCaseOptionAsync();
            await _childCasePage.ClickNewChildCaseAsync();
        }
        [Then(@"User validates the fields displayed for quick case '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public async Task ThenUserValidatesTheFieldsDisplayedForQuickCase(string parentCase, string caseName, string owner, string customer, string policyRefNumber, string policyRef, string primaryDemand, string demand, string subDemand, string product)
        {
            Assertions.Equals(await _childCasePage.GetParentCaseLabelAsync(), parentCase);
            Assertions.Equals(await _childCasePage.GetCaseNameLabelAsync(), caseName);
            Assertions.Equals(await _childCasePage.GetOwnerLabelAsync(), owner);
            Assertions.Equals(await _childCasePage.GetCustomerLabelAsync(), customer);
            Assertions.Equals(await _childCasePage.GePolicyReferenceNumberLabelAsync(), policyRefNumber);
            Assertions.Equals(await _childCasePage.GetPolicyReferenceLabelAsync(), policyRef);
            Assertions.Equals(await _childCasePage.GetPrimaryDemandLabelAsync(), primaryDemand);
            Assertions.Equals(await _childCasePage.GetDemandLabelAsync(), demand);
            Assertions.Equals(await _childCasePage.GetSubDemandLabelAsync(), subDemand);
            Assertions.Equals(await _childCasePage.GetProductLabelAsync(), product);
        }
        [Then(@"User validates the pre populated Parent Case '([^']*)' Case Name as Demand '([^']*)' Owner '([^']*)' Customer '([^']*)' Policy Reference Number '([^']*)' and Product '([^']*)'")]
        public async Task ThenUserValidatesThePrePopulatedParentCaseCaseNameAsDemandOwnerCustomerPolicyReferenceNumberAndProduct(string caseName, string demand, string owner, string customer, string policyRefNumber, string product)
        {
            Assertions.Equals(await _childCasePage.GetParentCaseAsync(), caseName);
            Assertions.Equals(await _childCasePage.GetCaseNameAsync(), demand);
            Assertions.Equals(await _childCasePage.GetOwnerAsync(), owner);
            Assertions.Equals(await _childCasePage.GetCustomerAsync(), customer);
            Assertions.Equals(await _childCasePage.GePolicyReferenceNumberAsync(), policyRefNumber);
            //Assertions.Equals(await _childCasePage.GetProductAsync(), product);
        }
        [Then(@"User clicks on cancel button")]
        public async Task ThenUserClicksOnCancelButton()
        {
            await _childCasePage.ClickCancelAsync();
        }

        [Then(@"User enters the mandatory fields primary demand <ChildPrimaryDemand> demand <ChildDemand> sub demand <ChildSubDemand> and validates SLA start date of child case (.*) also child case is shown in timeline.")]
        public async Task ThenUserEntersTheMandatoryFieldsPrimaryDemandChildPrimaryDemandDemandChildDemandSubDemandChildSubDemandAndValidatesSLAStartDateOfChildCaseAlsoChildCaseIsShownInTimeline(int numberOfDays, Table table)
        {
            foreach (var row in table.Rows)
            {
                await _casesPage.ClickOnCaseRelationshipsTab();
                await _childCasePage.ClickChildCaseOptionAsync();
                await _childCasePage.ClickNewChildCaseAsync();
                await _childCasePage.EnterPrimaryDemandAsync(row["ChildPrimaryDemand"].Replace("'", string.Empty));
                await _childCasePage.EnterDemandAsync(row["ChildDemand"].Replace("'", string.Empty));
                await _childCasePage.EnterSubDemandAsync(row["ChildPrimaryDemand"].Replace("'", string.Empty), row["ChildSubDemand"].Replace("'", string.Empty));

                await _childCasePage.ClickSaveAndCloseAsync();

                await _childCasePage.ClickActiveChildCaseAsync();

                await _childCasePage.ClickBackAsync();
                Thread.Sleep(6000);

                await _childCasePage.ClickActiveChildCaseAsync();
                if (row["ChildPrimaryDemand"].Replace("'", string.Empty).Equals("I want to renew"))
                {
                    Assertions.Equals(await _casesPage.GetCaseDueDate(), "11/07/2025");
                }
                else
                {
                    Assertions.Equals(await _casesPage.GetCaseDueDate(), _basePage.GetFutureDateExcludingWeekendsAsync(numberOfDays));
                }

                //await _casesPage.ClickCancelCase();
                //await _casesPage.ClickConfirmButton();
                //await _casesPage.ClickGoBackButton();
            }
        }

    }
}
