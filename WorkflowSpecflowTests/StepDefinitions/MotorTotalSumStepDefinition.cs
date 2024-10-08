using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowSpecflowTests.Config;
using WorkflowSpecflowTests.Pages;

namespace WorkflowSpecflowTests.StepDefinitions
{
    [Binding]
    public class MotorTotalSumStepDefinitions
    {
        private readonly ScenarioContext _context;
        private readonly IDynamicsLoginPage _dynamicsLoginPage;
        private readonly IMotorTotalSumPage _motorTotalSumPage;
        private readonly IContactPage _contactPage;
        private readonly ICommonStepDefiniation _commonStep;

        public MotorTotalSumStepDefinitions(ScenarioContext context, IDynamicsLoginPage dynamicsLoginPage, IContactPage contactPage, IMotorTotalSumPage motorTotalSumPage, ICommonStepDefiniation commonStep)
        {
            _context = context;
            _dynamicsLoginPage = dynamicsLoginPage;
            _motorTotalSumPage = motorTotalSumPage;
            _contactPage = contactPage;
            _commonStep = commonStep;
        }

        [Given(@"User selects Customer Service Hub")]
        public async Task GivenUserSelectsCustomerServiceHub()
        {
            await _motorTotalSumPage.ClickCustomerServiceHub();
        }

        [Given(@"User validates sitemap menu")]
        public async Task GivenUserValidatesSitemapMenu()
        {
            await _commonStep.ValidateSiteMap();
        }

        [Given(@"User Clicks on Policies from Service AreaGroup")]
        public async Task GivenUserClicksOnPoliciesFromServiceAreaGroup()
        {
            await _motorTotalSumPage.ClickOnPolicies();
        }

        [Given(@"User Clicks on \+New button")]
        public async Task GivenUserClicksOnNewButton()
        {
            await _motorTotalSumPage.ClickOnNewButton();

        }
        


        [Then(@"User Enters  '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public async Task ThenUserEnters(string polref, string channel, string startdate, string enddate, string annualpremium, string coversheld, string riskaddr, string excesses, string motorsuminsured)
        {
            await _motorTotalSumPage.EnterPolicyDetails(polref, channel, startdate, enddate, annualpremium, coversheld, riskaddr, excesses, motorsuminsured);
        }

        [Then(@"Enter the total motor sum Insured Manually")]
        public async Task ThenEnterTheTotalMotorSumInsuredManually()
        {
            await _motorTotalSumPage.EnterManually();
        }


    }
}
