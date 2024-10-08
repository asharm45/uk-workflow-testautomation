using System;
using Microsoft.Playwright;
using Newtonsoft.Json.Serialization;
using TechTalk.SpecFlow;
using WorkflowSpecflowTests.Pages;

namespace WorkflowSpecflowTests.StepDefinitions
{
    [Binding]
    public class MarkDemandFailureStepDefinitions
    {
        private readonly ICasesPage _casesPage;

        public MarkDemandFailureStepDefinitions(ICasesPage casesPage)
        {
            _casesPage = casesPage;
        }

        [Then(@"User checks newly created case ""([^""]*)""")]
        public async Task ThenUserChecksNewlyCreatedCase(string caseName)
        {
            await _casesPage.ClickOnCases();
            await _casesPage.ClickRefresh();
            await _casesPage.SelectNewlyCreatedCase(caseName);
        }


        [Then(@"User resolve the case with Resolution Type ""([^""]*)"" Resolution ""([^""]*)""")]
        public async Task ThenUserResolveTheCaseWithResolutionTypeResolution(string resolutionType, string resolution)
        {
            await _casesPage.ClickResolveCaseButton();
            await _casesPage.SelectResolutionTypeFromResolveCasePopup(resolutionType);
            await _casesPage.EnterResolutionReason(resolution);
            await _casesPage.ClickResolveButtonInResolveCasePopup();
        }

        [Then(@"User validates resolved case ""([^""]*)"" is read only")]
        public async Task ThenUserValidatesCaseIsReadOnly(string caseName)
        {
            await _casesPage.ClickOnCases();
            await _casesPage.ClickMyActiveCases();
            await _casesPage.SearchGivenView("My Resolved Cases");
            await _casesPage.ClickMyResolvedCases();
            await _casesPage.FilterCase(caseName);
            await _casesPage.ClickNewlyCreatedCase(caseName);
            Assertions.Equals(await _casesPage.GetReadOnlyLocator().TextContentAsync(), "Read-only  This record’s status: Resolved");
        }

        [Then(@"User validates the demand type ""([^""]*)""")]
        public async Task ThenUserValidatesTheDemandType(string demandType)
        {
            await _casesPage.ClickExpand();
            Assertions.Equals(await _casesPage.GetDemandType(), demandType);

        }

        [Then(@"User Clicks Delete button and deletes the Case")]
        public async void ThenUserClicksDeleteButtonAndDeletesTheCase()
        {
            await _casesPage.DeleteCase();
        }

        [Then(@"User validate the case status as resolved")]
        public async Task ThenUserValidateTheCaseStatusAsResolved()
        {
            Assertions.Equals(await _casesPage.GetCaseStatus(), "Resolved");
        }

        [Then(@"User validates fields are non editable")]
        public async Task ThenUserValidatesFieldsAreNonEditable()
        {
            await Assertions.Expect(_casesPage.GetReadonlyFields("Case Name")).ToBeVisibleAsync();
            await Assertions.Expect(_casesPage.GetReadonlyFields("Case Number")).ToBeVisibleAsync();
            await Assertions.Expect(_casesPage.GetReadonlyFields("Primary Demand")).ToBeVisibleAsync();
            await Assertions.Expect(_casesPage.GetReadonlyFields("Policy Reference Number")).ToBeVisibleAsync();
        }

    }
}
