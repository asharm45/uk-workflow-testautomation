using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using WorkflowSpecflowTests.Config;
using WorkflowSpecflowTests.Pages;

namespace WorkflowSpecflowTests.StepDefinitions
{
    [Binding]
    public class CSHubScheduling
    {
        private readonly ICustomerServiceHubPage _customerServiceHubPage;

        public CSHubScheduling(ICustomerServiceHubPage customerServiceHubPage)
        {
            _customerServiceHubPage = customerServiceHubPage;
        }

        [When(@"The user clicks on Customer Assets dropdown and selects scheduling")]
        public async void WhenTheUserClicksOnCustomerAssetsDropdownAndSelectsScheduling()
        {
            await _customerServiceHubPage.switchToScheduling();
        }

        [When(@"The user clicks on Resources")]
        public async void WhenTheUserClicksOnResources()
        {
            await _customerServiceHubPage.clickResources();
        }

        [When(@"The user creates a new Bookable Resource with Contact '([^']*)'")]
        public async void WhenTheUserCreatesANewBookableResource(string ContactName)
        {
            await _customerServiceHubPage.clickNewButton();
            await _customerServiceHubPage.createNewBookable(ContactName);
            await _customerServiceHubPage.clickResources();
        }

        [When(@"The user verifies if new Bookable '([^']*)' is created")]
        public async void WhenTheUserVerifiesIfNewBookableIsCreated(string ContactName)
        {
            Assertions.Equals(_customerServiceHubPage.VerifyBookableCreated(ContactName), true);
        }



    }


}
