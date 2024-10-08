using System;
using System.Xml.Linq;
using Microsoft.Playwright;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WorkflowSpecflowTests.Apis;
using WorkflowSpecflowTests.Config;
using WorkflowSpecflowTests.Email;
using WorkflowSpecflowTests.Pages;

namespace WorkflowSpecflowTests.StepDefinitions
{
    [Binding]
    public class LoginMerlinStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Users _user;
        private readonly ILoginPage _loginPage;
        private readonly IDashboardPage _dashboardPage;
        private readonly ILogoutPage _logoutPage;
        private readonly IEmailSender _emailSender;
        private readonly IXMLUpdate _xmlUpdate;
        private readonly ISoapClient _soapClient;
        private readonly IMaintainContactSummaryPage _maintainContactSummaryPage;
        private readonly IDynamicsLoginPage _dynamicsLoginPage;

        public LoginMerlinStepDefinitions(ScenarioContext scenarioContext, Users users, ILoginPage loginPage, IDashboardPage dashboardPage, ILogoutPage logoutPage, IEmailSender emailSender, IXMLUpdate xMLUpdate, ISoapClient soapClient, IMaintainContactSummaryPage maintainContactSummaryPage, IDynamicsLoginPage dynamicsLoginPage)
        {
            _scenarioContext = scenarioContext;
            _user = users;
            _loginPage = loginPage;
            _dashboardPage = dashboardPage;
            _logoutPage = logoutPage;
            _emailSender = emailSender;
            _xmlUpdate = xMLUpdate;
            _soapClient = soapClient;
            _maintainContactSummaryPage = maintainContactSummaryPage;
            _dynamicsLoginPage = dynamicsLoginPage;
        }
        [Given(@"User navigatges to Merlin application and enter user credentials")]
        public async Task GivenUserNavigatgesToMerlinApplicationAndEnterUserCredentials()
        {
            await _loginPage.enterMerlinCredentials(_user.Username, _user.Password);
            
            

        }

        [When(@"User clicks on login button")]
        public async Task WhenUserClicksOnLoginButton()
        {
           await _loginPage.clickLogin();
        }

        [When (@"User creates a new contact")]
        public async Task ThenUserLandsOnDashboardPage()
        {
            await _dashboardPage.createNewContact();
        }

        [Then(@"User logout")]
        public async Task ThenUserLogout()
        {
           await _logoutPage.applicationLogout();
            string from = "CEBuktest@hiscox.com";
            string to = "amitsharma.jaiprakash@hiscox.com";
            string subject = "Test Subject";
            string body = "This is a test email body";
            //string attachmentPath = "C:\\Users\\jaipraka\\source\\repos\\WorkflowApplicationTest\\WorkflowSpecflowTests\\Test.pdf";
           //await _emailSender.SendEmailWithAttachmentAsync(from, to, subject, body);
        }

        

        [Then(@"User Calls Merlin Apis To Create Policy")]
        public async Task ThenUserCallsMerlinApisToCreatePolicy()
        {
            
        }

        [When(@"User enters general details")]
        public async Task WhenUserEntersGeneralDetails()
        {
            await _maintainContactSummaryPage.EnterContactBasicDeatils();
            await _maintainContactSummaryPage.EnterAddressDeatils();
            //await _maintainContactSummaryPage.EnterPhoneDeatils(); 
            await _maintainContactSummaryPage.EnterEmailDeatils();
            await _maintainContactSummaryPage.EnterCommunicationPreferencesDeatils();

        }

        

        [Then(@"User clicks on Next button")]
        public async Task ThenUserClicksOnNextButton()
        {
            await _maintainContactSummaryPage.ClickNextButton();
        }


        [Given(@"User prepares request payload for CreateContact api")]
        public async Task GivenUserPreparesRequestPayloadForCreateContactApi()
        {

            string from = "amitsharma.jaiprakash@hiscox.com";
            string to = "Test_UKSC_Dynamics@hiscox.com";
            string subject = "Test Subject";
            string body = "This is a test email body";
            string attachmentPath = "C:\\Users\\jaipraka\\source\\repos\\WorkflowApplicationTest\\WorkflowSpecflowTests\\Test.pdf";
            await _emailSender.SendEmailWithAttachmentAsync(from, to, subject, body,attachmentPath);

            //Step1_Create Contact 
            string _timestamp = await _xmlUpdate.GetCurrentTimestamp();
            string _timestamp1 = await _xmlUpdate.GetTimestamp();
            //Update CreateContact request payload
            await _xmlUpdate.UpdateXMLFile("CreateContactService", "name", _timestamp, 0);
            await _xmlUpdate.UpdateXMLFile("CreateContactService", "effectiveDate", _timestamp1, 0);
            await _xmlUpdate.UpdateXMLFile("CreateContactService", "email", "workflow." + _timestamp + "@example.com", 0);
            await _xmlUpdate.UpdateXMLFile("CreateContactService", "correspondenceName", "Workflow " + _timestamp, 0);
            string CreateContactServiceUpdated = await _xmlUpdate.UpdateXMLFile("CreateContactService", "email", "workflow." + _timestamp + "@example.com", 1);

            await _soapClient.SetUrl("https://mansell-idit-web-northeurope.merlin.cloud.hiscox.com/idit-web/ws?methodName=CreateContact&serviceName=IDITServices");
            var CreateContactResponse = await _soapClient.PostCall(CreateContactServiceUpdated);
            //Get required fields from response
            var identifier = await _xmlUpdate.GetElementFromResponse(CreateContactResponse, "identifier", 0);




            //Update GetContactByIdService request payload
            string GetContactByIdUpdatedXml = await _xmlUpdate.UpdateXMLFile("GetContactByIdService", "identifier", identifier, 0);

            await _soapClient.SetUrl("https://mansell-idit-web-northeurope.merlin.cloud.hiscox.com/idit-web/ws?serviceName=IDITServices&methodName=GetContactByID");
            var GetContactByIdResponse = await _soapClient.PostCall(GetContactByIdUpdatedXml);

            //Get required fields from response
            /*var messageCorrelationId = await _xmlUpdate.GetElementFromResponse(GetContactByIdResponse, "messageCorrelationId", 0);
            var contactIVO = await _xmlUpdate.GetElementByAttribute(GetContactByIdResponse, "contactIVO", "id", 0);
            var externalContactNumber = await _xmlUpdate.GetElementFromResponse(GetContactByIdResponse, "externalContactNumber", 0);
            var contactAddress = await _xmlUpdate.GetElementByAttribute(GetContactByIdResponse, "contactAddress", "id", 0);
            var addressIVO = await _xmlUpdate.GetElementByAttribute(GetContactByIdResponse, "addressIVO", "id", 0);
            var contactTelephone = await _xmlUpdate.GetElementByAttribute(GetContactByIdResponse, "contactTelephone", "id", 0);
            var contactAffinityMembership = await _xmlUpdate.GetElementByAttribute(GetContactByIdResponse, "contactAffinityMembership", "id", 0);
            var membershipId = await _xmlUpdate.GetElementFromResponse(GetContactByIdResponse, "membershipId", 0);
            var contactAffinityMembership1 = await _xmlUpdate.GetElementByAttribute(GetContactByIdResponse, "contactAffinityMembership", "id", 1);
            var membershipId1 = await _xmlUpdate.GetElementFromResponse(GetContactByIdResponse, "membershipId", 1);
            var name = await _xmlUpdate.GetElementFromResponse(GetContactByIdResponse, "name", 0);
            var permissionHSCXIVO = await _xmlUpdate.GetElementByAttribute(GetContactByIdResponse, "permissionHSCXIVO", "id", 0);
            var contactRelationship = await _xmlUpdate.GetElementByAttribute(GetContactByIdResponse, "contactRelationship", "id", 0);
            var contactRole = await _xmlUpdate.GetElementByAttribute(GetContactByIdResponse, "contactRole", "id", 0);
            var effectiveDate = await _xmlUpdate.GetElementFromResponse(GetContactByIdResponse, "effectiveDate", 0);
            var personDrivingData = await _xmlUpdate.GetElementByAttribute(GetContactByIdResponse, "personDrivingData", "id", 0);
            var contactEmail = await _xmlUpdate.GetElementByAttribute(GetContactByIdResponse, "contactEmail", "id", 0);
            var email = await _xmlUpdate.GetElementFromResponse(GetContactByIdResponse, "email", 0);
            var correspondenceName = await _xmlUpdate.GetElementFromResponse(GetContactByIdResponse, "correspondenceName", 0);
            var preferredDeliveryAddressVO = await _xmlUpdate.GetElementByAttribute(GetContactByIdResponse, "preferredDeliveryAddressVO", "id", 0);
            var email1 = await _xmlUpdate.GetElementFromResponse(GetContactByIdResponse, "email", 1);*/



            //Update UpdateContact request payload
            await _xmlUpdate.UpdateElementByAttribute("UpdateContactService", "contactIVO", "id", await _xmlUpdate.GetElementByAttribute(GetContactByIdResponse, "contactIVO", "id", 0), 0);
            await _xmlUpdate.UpdateXMLFile("UpdateContactService", "externalContactNumber", identifier, 0);
            await _xmlUpdate.UpdateElementByAttribute("UpdateContactService", "contactAddress", "id", await _xmlUpdate.GetElementByAttribute(GetContactByIdResponse, "contactAddress", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("UpdateContactService", "addressIVO", "id", await _xmlUpdate.GetElementByAttribute(GetContactByIdResponse, "addressIVO", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("UpdateContactService", "contactTelephone", "id", await _xmlUpdate.GetElementByAttribute(GetContactByIdResponse, "contactTelephone", "id", 0), 0);
            await _xmlUpdate.UpdateXMLFile("UpdateContactService", "accountHolder", "workflow." + _timestamp1, 0);
            await _xmlUpdate.UpdateXMLFile("UpdateContactService", "branchName", "200000 Perform  Test sortcode Multi-Branch 9" + _timestamp, 0);
            await _xmlUpdate.UpdateXMLFile("UpdateContactService", "bankAccountExternalNumber", identifier, 0);
            await _xmlUpdate.UpdateElementByAttribute("UpdateContactService", "contactAffinityMembership", "id", await _xmlUpdate.GetElementByAttribute(GetContactByIdResponse, "contactAffinityMembership", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("UpdateContactService", "contactAffinityMembership", "id", await _xmlUpdate.GetElementByAttribute(GetContactByIdResponse, "contactAffinityMembership", "id", 1), 1);
            await _xmlUpdate.UpdateXMLFile("UpdateContactService", "membershipId", await _xmlUpdate.GetElementFromResponse(GetContactByIdResponse, "membershipId", 0), 0);
            await _xmlUpdate.UpdateXMLFile("UpdateContactService", "membershipId", await _xmlUpdate.GetElementFromResponse(GetContactByIdResponse, "membershipId", 1), 1);
            await _xmlUpdate.UpdateXMLFile("UpdateContactService", "name", await _xmlUpdate.GetElementFromResponse(GetContactByIdResponse, "name", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("UpdateContactService", "permissionHSCXIVO", "id", await _xmlUpdate.GetElementByAttribute(GetContactByIdResponse, "permissionHSCXIVO", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("UpdateContactService", "contactRelationship", "id", await _xmlUpdate.GetElementByAttribute(GetContactByIdResponse, "contactRelationship", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("UpdateContactService", "contactRole", "id", await _xmlUpdate.GetElementByAttribute(GetContactByIdResponse, "contactRole", "id", 0), 0);
            await _xmlUpdate.UpdateXMLFile("UpdateContactService", "effectiveDate", await _xmlUpdate.GetElementFromResponse(GetContactByIdResponse, "effectiveDate", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("UpdateContactService", "personDrivingData", "id", await _xmlUpdate.GetElementByAttribute(GetContactByIdResponse, "personDrivingData", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("UpdateContactService", "contactEmail", "id", await _xmlUpdate.GetElementByAttribute(GetContactByIdResponse, "contactEmail", "id", 0), 0);
            await _xmlUpdate.UpdateXMLFile("UpdateContactService", "email", await _xmlUpdate.GetElementFromResponse(GetContactByIdResponse, "email", 0), 0);
            await _xmlUpdate.UpdateXMLFile("UpdateContactService", "correspondenceName", await _xmlUpdate.GetElementFromResponse(GetContactByIdResponse, "correspondenceName", 0), 0);
            string UpdateContactServiceUpdatedXml = await _xmlUpdate.UpdateXMLFile("UpdateContactService", "email", await _xmlUpdate.GetElementFromResponse(GetContactByIdResponse, "email", 1), 1);



            await _soapClient.SetUrl("https://mansell-idit-web-northeurope.merlin.cloud.hiscox.com/idit-web/ws?serviceName=IDITServices&methodName=UpdateContact");
            var UpdateContactServiceResponse = await _soapClient.PostCall(UpdateContactServiceUpdatedXml);

            //Get required fields from response - we need to capture only identifier, which we have already captured from createContact reponse


            //Update - PartialSaveProposal request payload
            string _startDate = await _xmlUpdate.GetStartDate();
            string _endDate = await _xmlUpdate.GetEndDate();
            string _nextYear = await _xmlUpdate.GetNextYearDate();
            string _get45days = await _xmlUpdate.Get45Days();

            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalService", "policyProposalDate", _startDate, 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalService", "policyEndDate", _endDate, 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalService", "mainRenewalDate", _nextYear, 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalService", "endorsStartDate", _startDate, 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalService", "endDate", _endDate, 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalService", "startDate", _startDate, 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalService", "endDate", _endDate, 1);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalService", "startDate", _startDate, 1);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalService", "endDate", _endDate, 1);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalService", "startDate", _startDate, 1);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalService", "assetStartDate", _startDate, 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalService", "assetEndDate", _endDate, 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalService", "policyEndDate", _endDate, 1);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalService", "proposalDate", _startDate, 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalService", "proposalValidation", _get45days, 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalService", "policyStartDate", _startDate, 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalService", "contactExtNum", identifier, 0);
            string PartialSaveProposalServiceUpdatedXml = await _xmlUpdate.UpdateXMLFile("PartialSaveProposalService", "policyStartDate", _startDate, 1);

            await _soapClient.SetUrl("https://mansell-idit-web-northeurope.merlin.cloud.hiscox.com/idit-web/ws?serviceName=IDITServices&methodName=partialSaveProposal");
            var PartialSaveProposalServiceResponse = await _soapClient.PostCall(PartialSaveProposalServiceUpdatedXml);

            //Get required fields from response
            /*var policyHeaderIVO = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "policyHeaderIVO", "id", 0);
            var statusDate = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "statusDate", 0);
            var policyProposalDate = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "policyProposalDate", 0);
            var externalHeaderNumber = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "externalHeaderNumber", 0);
            var sales1Date = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "sales1Date", 0);
            var policyEndDate0 = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "policyEndDate", 0);
            var mainRenewalDate = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "mainRenewalDate", 0);
            var policyIVOs = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "policyIVOs", "id", 0);
            var statusDate1 = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "statusDate", 1);
            var endorsEndDate = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "endorsEndDate", 0);
            var endorsStartDate = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "endorsStartDate", 0);
            var policyQuestionnaireIVO0 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "policyQuestionnaireIVO", "id", 0);
            var policyQuestionnaireIVO1 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "policyQuestionnaireIVO", "id", 1);
            var questionnaireLineIVO0 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "questionnaireLineIVO", "id", 0);
            var questionnaireLineIVO1 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "questionnaireLineIVO", "id", 1);
            var questionnaireLineIVO2 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "questionnaireLineIVO", "id", 2);
            var questionnaireLineIVO3 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "questionnaireLineIVO", "id", 3);
            var questionnaireLineIVO4 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "questionnaireLineIVO", "id", 4);
            var questionnaireLineIVO5 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "questionnaireLineIVO", "id", 5);
            var policyQuestionnaireIVO2 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "policyQuestionnaireIVO", "id", 2);
            var policyLobIVOs = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "policyLobIVOs", "id", 0);
            var policyLobAssetIVOs = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "policyLobAssetIVOs", "id", 0);
            var coverIVOs0 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "coverIVOs", "id", 0);
            var externalNumber0 = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "externalNumber", 0);
            var endDate0 = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "endDate", 0);
            var startDate0 = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "startDate", 0);
            var coverCountryPremiumVOs0 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "coverCountryPremiumVOs", "id", 0);
            var priorActStartDate0 = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "priorActStartDate", 0);
            var excessComponentsVOs0 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "excessComponentsVOs", "id", 0);
            var excessComponentsVOs1 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "excessComponentsVOs", "id", 1);
            var coverIVOs1 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "coverIVOs", "id", 1);
            var externalNumber1 = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "externalNumber", 1);
            var endDate1 = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "endDate", 1);
            var startDate1 = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "startDate", 1);
            var coverCountryPremiumVOs1 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "coverCountryPremiumVOs", "id", 1);
            var priorActStartDate1 = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "priorActStartDate", 1);
            var excessComponentsVOs2 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "excessComponentsVOs", "id", 2);
            var excessComponentsVOs3 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "excessComponentsVOs", "id", 3);
            var coverIVOs2 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "coverIVOs", "id", 2);
            var endDate2 = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "endDate", 2);
            var startDate2 = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "startDate", 2);
            var priorActStartDate2 = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "priorActStartDate", 2);
            var excessComponentsVOs4 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "excessComponentsVOs", "id", 4);
            var excessComponentsVOs5 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "excessComponentsVOs", "id", 5);
            var assetIVO = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetIVO", "id", 3);
            var assetRiskVOs0 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 0);
            var assetRiskVOs1 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 1);
            var assetRiskVOs2 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 2);
            var assetRiskVOs3 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 3);
            var assetRiskVOs4 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 4);
            var assetRiskVOs5 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 5);
            var assetRiskVOs6 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 6);
            var assetRiskVOs7 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 7);
            var assetRiskVOs8 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 8);
            var assetRiskVOs9 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 9);
            var assetRiskVOs10 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 10);
            var assetRiskVOs11 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 11);
            var assetRiskVOs12 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 12);
            var assetRiskVOs13 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 13);
            var propertyTheftVO = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "propertyTheftVO", "id", 0);
            var postCodeRiskInfoHSCXVO = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "postCodeRiskInfoHSCXVO", "id", 0);
            var rateDate0 = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "rateDate", 0);
            var addressVO = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "addressVO", "id", 0);
            var assetStartDate = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "assetStartDate", 0);
            var originalLobAssetId = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "originalLobAssetId", 0);
            var assetEndDate = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "assetEndDate", 0);
            var rateDate1 = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "rateDate", 1);
            var policyEndDate1 = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "policyEndDate", 1);
            var proposalDate = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "proposalDate", 0);
            var proposalValidation = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "proposalValidation", 0);
            var policyYearlyPremium = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "policyYearlyPremium", "id", 0);
            var externalProposalNr = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "externalProposalNr", 0);
            var policyStartDate0 = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "policyStartDate", 0);
            var policyContactIVOs0 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "policyContactIVOs", "id", 0);
            var contactExtNum = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "contactExtNum", 0);
            var policyContactIVOs1 = await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "policyContactIVOs", "id", 1);
            var policyStartDate1 = await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "policyStartDate", 1);*/


            //Prepare request payload for PerformUWChecksService
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "policyHeaderIVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "policyHeaderIVO", "id", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "statusDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "statusDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "policyProposalDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "policyProposalDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "externalHeaderNumber", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "externalHeaderNumber", 0) , 0);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "sales1Date", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "sales1Date", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "policyEndDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "policyEndDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "mainRenewalDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "mainRenewalDate", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "policyIVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "policyIVOs", "id", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "statusDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "statusDate", 1), 0);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "endorsEndDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "endorsEndDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "endorsStartDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "endorsStartDate", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "policyQuestionnaireIVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "policyQuestionnaireIVO", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "policyQuestionnaireIVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "policyQuestionnaireIVO", "id", 1), 1);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "questionnaireLineIVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "questionnaireLineIVO", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "questionnaireLineIVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "questionnaireLineIVO", "id", 1), 1);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "questionnaireLineIVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "questionnaireLineIVO", "id", 2), 2);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "questionnaireLineIVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "questionnaireLineIVO", "id", 3), 3);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "questionnaireLineIVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "questionnaireLineIVO", "id", 4), 4);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "questionnaireLineIVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "questionnaireLineIVO", "id", 5), 5);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "policyQuestionnaireIVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "policyQuestionnaireIVO", "id", 2), 2);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "policyLobIVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "policyLobIVOs", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "policyLobAssetIVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "policyLobAssetIVOs", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "assetIVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetIVO", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 1), 1);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 2), 2);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 3), 3);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 4), 4);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 5), 5);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 6), 6);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 7), 7);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 8), 8);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 9), 9);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 10), 10);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 11), 11); 
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 12), 12);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "assetRiskVOs", "id", 13), 13);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "propertyTheftVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "propertyTheftVO", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "postCodeRiskInfoHSCXVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "postCodeRiskInfoHSCXVO", "id", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "rateDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "rateDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "rateDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "rateDate", 1), 1);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "addressVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "addressVO", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "coverIVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "coverIVOs", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "coverIVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "coverIVOs", "id", 1), 1);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "coverIVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "coverIVOs", "id", 2), 2);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "endDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "endDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "endDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "endDate", 1), 1);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "endDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "endDate", 2), 2);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "externalNumber", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "externalNumber", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "externalNumber", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "externalNumber", 1), 1);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "startDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "startDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "startDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "startDate", 1), 1);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "startDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "startDate", 2), 2);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "coverCountryPremiumVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "coverCountryPremiumVOs", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "coverCountryPremiumVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "coverCountryPremiumVOs", "id", 1), 1);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "priorActStartDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "priorActStartDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "priorActStartDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "priorActStartDate", 1), 1);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "priorActStartDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "priorActStartDate", 2), 2);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "excessComponentsVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "excessComponentsVOs", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "excessComponentsVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "excessComponentsVOs", "id", 1), 1);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "excessComponentsVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "excessComponentsVOs", "id", 2), 2);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "excessComponentsVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "excessComponentsVOs", "id", 3), 3);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "excessComponentsVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "excessComponentsVOs", "id", 4), 4);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "excessComponentsVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "excessComponentsVOs", "id", 5), 5);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "assetStartDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "assetStartDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "originalLobAssetId", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "originalLobAssetId", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "assetEndDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "assetEndDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "policyEndDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "policyEndDate", 1), 1);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "proposalDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "proposalDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "proposalValidation", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "proposalValidation", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "policyYearlyPremium", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "policyYearlyPremium", "id", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "externalProposalNr", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "externalProposalNr", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "policyStartDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "policyStartDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "policyStartDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "policyStartDate", 1), 1);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "policyContactIVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "policyContactIVOs", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PerformUWChecksService", "policyContactIVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposalServiceResponse, "policyContactIVOs", "id", 1), 1);
            string PerformUWChecksServiceRequest = await _xmlUpdate.UpdateXMLFile("PerformUWChecksService", "contactExtNum", await _xmlUpdate.GetElementFromResponse(PartialSaveProposalServiceResponse, "contactExtNum", 0), 0);

            await _soapClient.SetUrl("https://mansell-idit-web-northeurope.merlin.cloud.hiscox.com/idit-web/ws?serviceName=IDITServices&methodName=performUWChecks");
            var PerformUWChecksServiceResponse = await _soapClient.PostCall(PerformUWChecksServiceRequest);


            //capture PerformUWChecksService response
            /*var messageCorrelationId = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "messageCorrelationId", 0);
            var policyHeaderIVO = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "policyHeaderIVO", "id", 0);
            var statusDate0 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "statusDate", 0);
            var policyProposalDate = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "policyProposalDate", 0);
            var externalHeaderNumber = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "externalHeaderNumber", 0);
            var sales1Date = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "sales1Date", 0);
            var policyEndDate0 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "policyEndDate", 0);
            var mainRenewalDate = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "mainRenewalDate", 0);
            var policyIVOs = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "policyIVOs", "id", 0);
            var statusDate1 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "statusDate   ", 0);
            var endorsEndDate = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "policyEndDate", 0);
            var endorsStartDate = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "endorsStartDate", 0);
            var policyQuestionnaireIVO0 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "policyQuestionnaireIVO", "id", 0);
            var policyQuestionnaireIVO1 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "policyQuestionnaireIVO", "id", 1);
            var questionnaireLineIVO0 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "questionnaireLineIVO", "id", 0);
            var questionnaireLineIVO1 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "questionnaireLineIVO", "id", 1);
            var questionnaireLineIVO2 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "questionnaireLineIVO", "id", 2);
            var questionnaireLineIVO3 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "questionnaireLineIVO", "id", 3);
            var questionnaireLineIVO4 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "questionnaireLineIVO", "id", 4);
            var questionnaireLineIVO5 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "questionnaireLineIVO", "id", 5);
            var policyQuestionnaireIVO2 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "policyQuestionnaireIVO", "id", 2);
            var policyLobIVOs    = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "policyLobIVOs", "id", 0);
            var policyLobAssetIVOs = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "policyLobAssetIVOs", "id", 0);
            var coverIVOs0 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "coverIVOs", "id", 0);
            var coverIVOs1 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "coverIVOs", "id", 1);
            var coverIVOs2 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "coverIVOs", "id", 2);
            var externalNumber0 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "externalNumber", 0);
            var externalNumber1 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "externalNumber", 1);
            var externalNumber2 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "externalNumber", 2);
            var endDate0 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "endDate", 0);
            var endDate1 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "endDate", 1);
            var endDate2 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "endDate", 2);
            var startDate0 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "startDate", 0);
            var startDate1 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "startDate", 1);
            var startDate2 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "startDate", 2);
            var coverCountryPremiumVOs0 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "coverCountryPremiumVOs", "id", 0);
            var coverCountryPremiumVOs1 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "coverCountryPremiumVOs", "id", 1);
            var priorActStartDate0 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "priorActStartDate", 0);
            var priorActStartDate1 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "priorActStartDate", 1);
            var priorActStartDate2 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "priorActStartDate", 2);
            var excessComponentsVOs0 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "excessComponentsVOs", "id", 0);
            var excessComponentsVOs1 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "excessComponentsVOs", "id", 1);
            var excessComponentsVOs2 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "excessComponentsVOs", "id", 2);
            var excessComponentsVOs3 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "excessComponentsVOs", "id", 3);
            var excessComponentsVOs4 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "excessComponentsVOs", "id", 4);
            var excessComponentsVOs5 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "excessComponentsVOs", "id", 5);
            var assetIVO = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "assetIVO", 0);
            var assetRiskVOs0 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 0);
            var assetRiskVOs1 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 1);
            var assetRiskVOs2 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 2);
            var assetRiskVOs3 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 3);
            var assetRiskVOs4 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 4);
            var assetRiskVOs5 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 5);
            var assetRiskVOs6 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 6);
            var assetRiskVOs7 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 7);
            var assetRiskVOs8 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 8);
            var assetRiskVOs9 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 9);
            var assetRiskVOs10 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 10);
            var assetRiskVOs11 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 11);
            var assetRiskVOs12 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 12);
            var assetRiskVOs13 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 13);
            var propertyTheftVO = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "propertyTheftVO", "id", 0);
            var stayValueAmountVO = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "stayValueAmountVO", "id", 0);
            var transportValueAmountVO = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "transportValueAmountVO", "id", 0);
            var postCodeRiskInfoHSCXVO = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "postCodeRiskInfoHSCXVO", "id", 0);
            var rateDate0 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "rateDate", 0);
            var addressVO = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "addressVO", "id", 0);
            var assetStartDate = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "assetStartDate", 0);
            var policyItemUnderwritingAlertsIVO0 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "policyItemUnderwritingAlertsIVO", "id", 0);
            var insertDate0 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "insertDate", 0);
            var irregularityExceptionIVOs0 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "irregularityExceptionIVOs", "id", 0);
            var descOwner0 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "descOwner", 0);
            var policyItemUnderwritingAlertsIVO1 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "policyItemUnderwritingAlertsIVO", "id", 1);
            var insertDate1 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "insertDate", 1);
            var irregularityExceptionIVOs1 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "irregularityExceptionIVOs", "id", 1);
            var descOwner1 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "descOwner", 1);
            var originalLobAssetId = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "originalLobAssetId", 0);
            var assetEndDate = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "assetEndDate", 0);
            var wordingIVO = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "wordingIVO", "id", 0);
            var rateDate1 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "rateDate", 1);
            var policyEndDate1 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "policyEndDate", 1);
            var proposalDate = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "proposalDate", 0);
            var proposalValidation = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "proposalValidation", 0);
            var policyYearlyPremium = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "policyYearlyPremium", "id", 0);
            var externalProposalNr = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "externalProposalNr", 0);
            var policyStartDate0 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "policyStartDate", 0);
            var policyContactIVOs0 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "policyContactIVOs", "id", 0);
            var contactExtNum = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "contactExtNum", 0);
            var policyContactIVOs1 = await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "policyContactIVOs", "id", 1);
            var policyStartDate1 = await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "policyStartDate", 1);*/


            //PartialSaveProposalService request payload
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "policyHeaderIVO", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "policyHeaderIVO", "id", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "insertDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "insertDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "insertDate", _startDate, 1);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "insertDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "insertDate", 1), 2);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "insertDate", _startDate, 3);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "authorizedDate", _startDate, 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "authorizedDate", _startDate, 1);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "statusDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "statusDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "policyProposalDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "policyProposalDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "externalHeaderNumber", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "externalHeaderNumber", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "sales1Date", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "sales1Date", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "policyEndDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "policyEndDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "mainRenewalDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "mainRenewalDate", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "policyIVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "policyIVOs", "id", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "statusDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "statusDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "endorsEndDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "endorsEndDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "endorsStartDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "endorsStartDate", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "policyQuestionnaireIVO", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "policyQuestionnaireIVO", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "policyQuestionnaireIVO", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "policyQuestionnaireIVO", "id", 1), 1);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "questionnaireLineIVO", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "questionnaireLineIVO", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "questionnaireLineIVO", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "questionnaireLineIVO", "id", 1), 1);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "questionnaireLineIVO", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "questionnaireLineIVO", "id", 2), 2);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "questionnaireLineIVO", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "questionnaireLineIVO", "id", 3), 3);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "questionnaireLineIVO", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "questionnaireLineIVO", "id", 4), 4);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "questionnaireLineIVO", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "questionnaireLineIVO", "id", 5), 5);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "policyQuestionnaireIVO", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "policyQuestionnaireIVO", "id", 2), 2);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "policyLobIVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "policyLobIVOs", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "policyLobAssetIVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "policyLobAssetIVOs", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "assetIVO", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetIVO", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 1), 1);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 2), 2);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 3), 3);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 4), 4);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 5), 5);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 6), 6);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 7), 7);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 8), 8);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 9), 9);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 10), 10);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 11), 11);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 12), 12);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "assetRiskVOs", "id", 13), 13);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "propertyTheftVO", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "propertyTheftVO", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "postCodeRiskInfoHSCXVO", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "postCodeRiskInfoHSCXVO", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "stayValueAmountVO", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "stayValueAmountVO", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "transportValueAmountVO", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "transportValueAmountVO", "id", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "rateDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "rateDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "rateDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "rateDate", 1), 1);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "addressVO", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "addressVO", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "coverIVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "coverIVOs", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "coverIVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "coverIVOs", "id", 1), 1);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "coverIVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "coverIVOs", "id", 2), 2);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "endDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "endDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "endDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "endDate", 1), 1);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "endDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "endDate", 2), 2);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "externalNumber", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "externalNumber", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "externalNumber", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "externalNumber", 1), 1);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "externalNumber", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "externalNumber", 1), 2);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "startDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "startDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "startDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "startDate", 1), 1);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "startDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "startDate", 2), 2);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "coverCountryPremiumVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "coverCountryPremiumVOs", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "coverCountryPremiumVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "coverCountryPremiumVOs", "id", 1), 1);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "priorActStartDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "priorActStartDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "priorActStartDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "priorActStartDate", 1), 1);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "priorActStartDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "priorActStartDate", 2), 2);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "excessComponentsVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "excessComponentsVOs", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "excessComponentsVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "excessComponentsVOs", "id", 1), 1);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "excessComponentsVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "excessComponentsVOs", "id", 2), 2);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "excessComponentsVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "excessComponentsVOs", "id", 3), 3);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "excessComponentsVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "excessComponentsVOs", "id", 4), 4);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "excessComponentsVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "excessComponentsVOs", "id", 5), 5);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "assetStartDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "assetStartDate", 0), 0);



            ////////////
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "policyItemUnderwritingAlertsIVO", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "policyItemUnderwritingAlertsIVO", "id", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "policyItemUnderwritingAlertsIVO", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "policyItemUnderwritingAlertsIVO", "id", 1), 1);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "irregularityExceptionIVOs", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "irregularityExceptionIVOs", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "descOwner", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "descOwner", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "irregularityExceptionIVOs", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "irregularityExceptionIVOs", 1), 1);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "descOwner", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "descOwner", 1), 1);

            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "originalLobAssetId", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "originalLobAssetId", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "assetEndDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "assetEndDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "policyEndDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "policyEndDate", 1), 1);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "proposalDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "proposalDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "proposalValidation", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "proposalValidation", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "externalProposalNr", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "externalProposalNr", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "policyStartDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "policyStartDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "policyStartDate", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "policyStartDate", 1), 1);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "policyContactIVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "policyContactIVOs", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("PartialSaveProposalSer", "policyContactIVOs", "id", await _xmlUpdate.GetElementByAttribute(PerformUWChecksServiceResponse, "policyContactIVOs", "id", 1), 1);
            await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "contactExtNum", await _xmlUpdate.GetElementFromResponse(PerformUWChecksServiceResponse, "contactExtNum", 0), 0);
            string PartialSaveProposaSerRequest = await _xmlUpdate.UpdateXMLFile("PartialSaveProposalSer", "contactExtNum", "2", 1);

            await _soapClient.SetUrl("https://mansell-idit-web-northeurope.merlin.cloud.hiscox.com/idit-web/ws?serviceName=IDITServices&methodName=partialSaveProposal");
            var PartialSaveProposaService1Response = await _soapClient.PostCall(PartialSaveProposaSerRequest);



            //IssuePolicyServiceService request payload
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "policyHeaderIVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "policyHeaderIVO", "id", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "statusDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "statusDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "policyProposalDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "policyProposalDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "externalHeaderNumber", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "externalHeaderNumber", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "sales1Date", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "sales1Date", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "policyEndDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "policyEndDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "mainRenewalDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "mainRenewalDate", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "policyIVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "policyIVOs", "id", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "statusDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "statusDate", 1), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "endorsEndDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "endorsEndDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "endorsStartDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "endorsStartDate", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "policyQuestionnaireIVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "policyQuestionnaireIVO", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "policyQuestionnaireIVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "policyQuestionnaireIVO", "id", 1), 1);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "questionnaireLineIVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "questionnaireLineIVO", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "questionnaireLineIVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "questionnaireLineIVO", "id", 1), 1);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "questionnaireLineIVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "questionnaireLineIVO", "id", 2), 2);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "questionnaireLineIVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "questionnaireLineIVO", "id", 3), 3);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "questionnaireLineIVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "questionnaireLineIVO", "id", 4), 4);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "questionnaireLineIVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "questionnaireLineIVO", "id", 5), 5);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "policyQuestionnaireIVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "policyQuestionnaireIVO", "id", 2), 2);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "policyLobIVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "policyLobIVOs", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "policyLobAssetIVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "policyLobAssetIVOs", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "assetIVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "assetIVO", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "assetRiskVOs", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "assetRiskVOs", "id", 1), 1);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "assetRiskVOs", "id", 2), 2);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "assetRiskVOs", "id", 3), 3);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "assetRiskVOs", "id", 4), 4);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "assetRiskVOs", "id", 5), 5);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "assetRiskVOs", "id", 6), 6);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "assetRiskVOs", "id", 7), 7);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "assetRiskVOs", "id", 8), 8);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "assetRiskVOs", "id", 9), 9);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "assetRiskVOs", "id", 10), 10);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "assetRiskVOs", "id", 11), 11);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "assetRiskVOs", "id", 12), 12);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "assetRiskVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "assetRiskVOs", "id", 13), 13);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "propertyTheftVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "propertyTheftVO", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "postCodeRiskInfoHSCXVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "postCodeRiskInfoHSCXVO", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "stayValueAmountVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "stayValueAmountVO", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "postCodeRiskInfoHSCXVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "postCodeRiskInfoHSCXVO", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "transportValueAmountVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "transportValueAmountVO", "id", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "rateDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "rateDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "rateDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "rateDate", 1), 1);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "rateDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "rateDate", 2), 2);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "addressVO", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "addressVO", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "coverIVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "coverIVOs", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "coverIVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "coverIVOs", "id", 1), 1);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "coverIVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "coverIVOs", "id", 2), 2);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "endDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "endDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "endDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "endDate", 1), 1);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "endDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "endDate", 2), 2);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "externalNumber", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "externalNumber", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "externalNumber", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "externalNumber", 1), 1);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "startDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "startDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "startDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "startDate", 1), 1);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "startDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "startDate", 2), 2);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "coverCountryPremiumVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "coverCountryPremiumVOs", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "coverCountryPremiumVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "coverCountryPremiumVOs", "id", 1), 1);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "priorActStartDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "priorActStartDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "priorActStartDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "priorActStartDate", 1), 1);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "priorActStartDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "priorActStartDate", 2), 2);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "excessComponentsVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "excessComponentsVOs", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "excessComponentsVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "excessComponentsVOs", "id", 1), 1);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "excessComponentsVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "excessComponentsVOs", "id", 2), 2);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "excessComponentsVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "excessComponentsVOs", "id", 3), 3);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "excessComponentsVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "excessComponentsVOs", "id", 4), 4);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "excessComponentsVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "excessComponentsVOs", "id", 5), 5);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "assetStartDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "assetStartDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "policyItemUnderwritingAlertsIVO", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "policyItemUnderwritingAlertsIVO", "id", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "insertDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "insertDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "insertDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "insertDate", 1), 1);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "insertDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "insertDate", 2), 2);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "insertDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "insertDate", 3), 3);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "irregularityExceptionIVOs", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "irregularityExceptionIVOs", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "descOwner", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "descOwner", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "irregularityExceptionIVOs", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "irregularityExceptionIVOs", 1), 1);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "descOwner", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "descOwner", 1), 1);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "authorizedDate", _startDate, 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "authorizedDate", _startDate, 1);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "policyItemUnderwritingAlertsIVO", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "policyItemUnderwritingAlertsIVO", "id", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "originalLobAssetId", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "originalLobAssetId", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "assetEndDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "assetEndDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "policyEndDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "policyEndDate", 1), 1);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "proposalDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "proposalDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "proposalValidation", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "proposalValidation", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "policyYearlyPremium", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "policyYearlyPremium", "id", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "externalProposalNr", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "externalProposalNr", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "policyStartDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "policyStartDate", 0), 0);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "policyStartDate", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "policyStartDate", 1), 1);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "policyContactIVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "policyContactIVOs", "id", 0), 0);
            await _xmlUpdate.UpdateElementByAttribute("IssuePolicyServiceService", "policyContactIVOs", "id", await _xmlUpdate.GetElementByAttribute(PartialSaveProposaService1Response, "policyContactIVOs", "id", 1), 1);
            await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "contactExtNum", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "contactExtNum", 0), 0);
            string IssuePolicyServiceServiceRequest = await _xmlUpdate.UpdateXMLFile("IssuePolicyServiceService", "contactExtNum", await _xmlUpdate.GetElementFromResponse(PartialSaveProposaService1Response, "contactExtNum", 1), 1);

            await _soapClient.SetUrl("https://mansell-idit-web-northeurope.merlin.cloud.hiscox.com/idit-web/ws?serviceName=IDITServices&methodName=IssuePolicy");
            var IssuePolicyServiceServiceResponse = await _soapClient.PostCall(IssuePolicyServiceServiceRequest);

        }

        [When(@"User calls CreateContact using proper payload")]
        public async Task WhenUserCallsCreateContactUsingProperPayload()
        {

        }

        [Then(@"User gets valid response and saves the necessary fields values from the response")]
        public async Task ThenUserGetsValidResponseAndSavesTheNecessaryFieldsValuesFromTheResponse()
        {

        }

        [When(@"User prepares request payload for GetContactByID api and calls the service")]
        public async Task WhenUserPreparesRequestPayloadForGetContactByIDApiAndCallsTheService()
        {

        }
    }
}
