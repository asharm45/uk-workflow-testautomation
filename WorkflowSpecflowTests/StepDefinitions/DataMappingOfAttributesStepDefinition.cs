using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Pages;

namespace WorkflowSpecflowTests.StepDefinitions
{
    [Binding]
    public class DataMappingOfAttributesStepDefinition
    {
        private readonly IAttributesMappingPage _attributesMappingPage;
        private readonly ICasesPage _casesPage;

        public DataMappingOfAttributesStepDefinition(IAttributesMappingPage attributesMappingPage, ICasesPage casesPage)
        {
            _attributesMappingPage = attributesMappingPage;
            _casesPage = casesPage;
        }

        [When(@"User clicks on details tab")]
        public async Task WhenUserClicksOnDetailsTab()
        {
            await _casesPage.ClickOnDetailsTab();
        }


        [When(@"User selects phone as origin")]
        public async Task WhenUserSelectsPhoneAsOrigin()
        {
            await _attributesMappingPage.SelectOriginAsPhone();
        }

        [Then(@"User validates if phone ""([^""]*)"" as origin is selected")]
        public async Task ThenUserValidatesIfPhoneAsOriginIsSelected(string phone)
        {
            await Assertions.Expect(_attributesMappingPage.GetSelectedOrigin(phone)).ToBeVisibleAsync();
        }

        [When(@"User selects email as origin")]
        public async Task WhenUserSelectsEmailAsOrigin()
        {
            await _attributesMappingPage.SelectOriginAsEmail();
        }

        [Then(@"User validates if email ""([^""]*)"" as origin is selected")]
        public async Task ThenUserValidatesIfEmailAsOriginIsSelected(string email)
        {
            await Assertions.Expect(_attributesMappingPage.GetSelectedOrigin(email)).ToBeVisibleAsync();
        }
    }
}
