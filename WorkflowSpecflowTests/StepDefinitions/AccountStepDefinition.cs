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
    public class AccountStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Users _user;
        private readonly IDynamicsLoginPage _dynamicsLoginPage;
        private readonly ICasesPage _casesPage;
        private readonly IContactPage _contactPage;
        private readonly ICommonStepDefiniation _commonStep;
        private readonly IAccountPage _accountPage;

        public AccountStepDefinition(ScenarioContext scenarioContext, Users users, IDynamicsLoginPage dynamicsLoginPage, IContactPage contactPage, ICasesPage casesPage, ICommonStepDefiniation commonStep, IAccountPage accountPage)
        {
            _scenarioContext = scenarioContext;
            _user = users;
            _dynamicsLoginPage = dynamicsLoginPage;
            _casesPage = casesPage;
            _contactPage = contactPage;
            _commonStep = commonStep;
            _accountPage = accountPage;
        }

        [Given(@"User Clicks on Accounts Tab")]
        public async Task GivenUserClicksOnAccountsTab()
        {
            await _accountPage.ClickOnAccounts();
        }

        [Given(@"User Fills The Details '([^']*)'")]
        public async Task GivenUserFillsTheDetails(string AccountName)
        {
            await _accountPage.EnterTheAccountName(AccountName);
        }

        [Given(@"User selects the account '([^']*)' and Validates The Fields")]
        public async void GivenUserSelectsTheAccountAndValidatesTheFields(string AccountName)
        {
            await _accountPage.AccountFieldValidation(AccountName);
        }


        [Then(@"User Selects The Account '([^']*)'")]
        public async Task ThenUserSelectsTheAccount(string AccountName)
        {

            await _accountPage.SelectTheAccount(AccountName);
        }



    }
}
