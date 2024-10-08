using Microsoft.Playwright;
using System;
using System.Drawing;
using TechTalk.SpecFlow;
using WorkflowSpecflowTests.Pages;
using static System.Net.Mime.MediaTypeNames;

namespace WorkflowSpecflowTests.StepDefinitions
{
    [Binding]
    public class ContactScreenChangesStepDefinitions
    {
        private readonly IContactChangesPage _contactChangesPage;
        private readonly ICasesPage _casesPage;
        private readonly IPage _page;

        public ContactScreenChangesStepDefinitions(IContactChangesPage contactChangesPage, ICasesPage casesPage, IPage page)
        {
            _contactChangesPage = contactChangesPage;
            _casesPage = casesPage;
            _page = page;

        }
        [Then(@"details tab in contact screen should be hidden")]
        public async Task ThenDetailsTabInContactScreenShouldBeHidden()
        {
            await _contactChangesPage.VerifyDetailsTabNotPresent();
            
        }

        [Then(@"Summary page should be displayed for the contact")]
        public async Task ThenSummaryPageShouldBeDisplayedForTheContact()
        {
            await Assertions.Expect(_contactChangesPage.CheckSummaryAsync()).ToBeVisibleAsync();
        }

        [Then(@"Summary page should have Correspondence address as Concatenation of '([^']*)' and '([^']*)'")]
        public async Task ThenSummaryPageShouldHaveCorrespondenceAddressAsConcatenationOfStreetAndHouseNr_(string Street, string HouseNr)
        {
            await _contactChangesPage.ClickSummaryAsync();
            
            string CorrespondenceAdr=await _page.GetAttributeAsync("//input[@aria-label='Subject']", "value");
            Assertions.Equals(Street+","+ HouseNr, CorrespondenceAdr);
           
        }

        [Then(@"'([^']*)' and '([^']*)' should be removed from the form")]
        public async Task ThenStreetAndHouseNrShouldBeRemovedFromTheForm(string Street, string HouseNr)
        {
            Assertions.Equals(await _casesPage.GetLabelCount(Street), 0);
            Assertions.Equals(await _casesPage.GetLabelCount(HouseNr), 0);
        }
    }
}
