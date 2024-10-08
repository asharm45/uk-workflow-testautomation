using Microsoft.Playwright;
using System;
using System.Net.Mail;
using TechTalk.SpecFlow;
using WorkflowSpecflowTests.Pages;

namespace WorkflowSpecflowTests.StepDefinitions
{
    [Binding]
    public class AttributeSearchCapabilityStepDefinitions
    {
        private readonly ISearchPage _searchPage;

        public AttributeSearchCapabilityStepDefinitions(ISearchPage searchPage)
        {
            _searchPage = searchPage;
        }

        [Then(@"User searches by postCode '([^']*)' and validates the results")]
        public async Task ThenUserSearchesByPostCodeAndValidatesTheResults(string postCode)
        {
            await _searchPage.Search(postCode);
            await _searchPage.ClickContacts();
            await _searchPage.ClickContactName();
            Assertions.Equals(_searchPage.GetSearch("Post Code"), postCode);
        }

        [Then(@"User searches by phoneNumber '([^']*)' and validates the results")]
        public async Task ThenUserSearchesByPhoneNumberAndValidatesTheResults(string phoneNumber)
        {
            await _searchPage.Search(phoneNumber);
            await _searchPage.ClickContacts();
            await _searchPage.ClickContactName();
            Assertions.Equals(_searchPage.GetSearch("Telephone Number"), phoneNumber);
        }

        [Then(@"User searches by emailAddress '([^']*)' and validates the results")]
        public async Task ThenUserSearchesByEmailAddressAndValidatesTheResults(string emailAddress)
        {
            await _searchPage.Search(emailAddress);
            await _searchPage.ClickContacts();
            await _searchPage.ClickContactName();
            Assertions.Equals(_searchPage.GetSearch("Email"), emailAddress);
        }

        [Then(@"User searches by contactName '([^']*)' and validates the results")]
        public async Task ThenUserSearchesByContactNameAndValidatesTheResults(string contactName)
        {
            await _searchPage.Search(contactName);
            await _searchPage.ClickContacts();
            await _searchPage.ClickContactName();
            Assertions.Equals(await _searchPage.GetHeader(), contactName);
        }

        [Then(@"User searches by policyRef '([^']*)' and validates the results")]
        public async Task ThenUserSearchesByPolicyRefAndValidatesTheResults(string policyRef)
        {
            await _searchPage.Search(policyRef);
            await _searchPage.ClickPoliciesTab();
            await _searchPage.ClickPolicyRef();
            Assertions.Equals(await _searchPage.GetHeader(), policyRef);
        }

        [Then(@"User searches by brokerName '([^']*)' and validates the results")]
        public async Task ThenUserSearchesByBrokerNameAndValidatesTheResults(string brokerName)
        {
            await _searchPage.Search(brokerName);
            await _searchPage.ClickContacts();
            await _searchPage.ClickBrokerName();
            Assertions.Equals(await _searchPage.GetHeader(), brokerName);
        }

        [Then(@"User searches by caseNumber '([^']*)' and validates the results")]
        public async Task ThenUserSearchesByCaseNumberAndValidatesTheResults(string caseNumber)
        {
            await _searchPage.Search(caseNumber);
            await _searchPage.ClickCasesTab();
            await _searchPage.ClickCases();
            Assertions.Equals(_searchPage.GetSearch("Case Number"), caseNumber);
        }

        [Then(@"User searches by resolvedStatus '([^']*)' and validates the results")]
        public async Task ThenUserSearchesByResolvedStatusAndValidatesTheResults(string resolved)
        {
            await _searchPage.Search(resolved);
            await _searchPage.ClickCasesTab();
            await _searchPage.ClickCases();
            Assertions.Equals(await _searchPage.GetCaseStatus(), resolved);
        }

        [Then(@"User searches by openStatus '([^']*)' and validates the results")]
        public async Task ThenUserSearchesByOpenStatusAndValidatesTheResults(string open)
        {
            await _searchPage.Search(open);
            await _searchPage.ClickCasesTab();
            await _searchPage.ClickCases();
            Assertions.Equals(await _searchPage.GetCaseStatus(), open);
        }

        [Then(@"User searches by activeStatus '([^']*)' and validates the results")]
        public async Task ThenUserSearchesByActiveStatusAndValidatesTheResults(string active)
        {
            await _searchPage.Search(active);
            await _searchPage.ClickCasesTab();
            await _searchPage.ClickCases();
            Assertions.Equals(await _searchPage.GetCaseStatus(), active);
        }

        [Then(@"User searches by primaryDemand '([^']*)' and validates the results")]
        public async Task ThenUserSearchesByPrimaryDemandAndValidatesTheResults(string primaryDemand)
        {
            await _searchPage.ClickServiceCases();
            await _searchPage.SearchPrimaryDemand(primaryDemand);
            await _searchPage.ClickFirstCase();
            Assertions.Equals(_searchPage.GetSearch("Primary Demand"), primaryDemand);
        }

    }
}
