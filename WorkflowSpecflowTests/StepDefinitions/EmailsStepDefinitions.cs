using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Diagnostics;
using System.Net.Mail;
using System.Reactive.Subjects;
using TechTalk.SpecFlow;
using WorkflowSpecflowTests.Email;
using WorkflowSpecflowTests.Pages;
using static Microsoft.VisualStudio.Services.Graph.GraphResourceIds;

namespace WorkflowSpecflowTests.StepDefinitions
{
    [Binding]
    public class EmailsStepDefinitions
    {
        private readonly IActivitiesPage _activitiesPage;
        private readonly IEmailSender _emailSender;
        private readonly ICasesPage _casesPage;
        private readonly IBasePage _basePage;
        private readonly IChildCasePage _childCasePage;
        private readonly ScenarioContext _scenarioContext;

        public EmailsStepDefinitions(ScenarioContext scenarioContext, IActivitiesPage activitiesPage, IEmailSender emailSender, ICasesPage casesPage, IBasePage basePage, IChildCasePage childCasePage)
        {
            _scenarioContext = scenarioContext;
            _activitiesPage = activitiesPage;
            _emailSender = emailSender;
            _casesPage = casesPage;
            _basePage = basePage;
            _childCasePage = childCasePage;
        }

        [Given(@"User sends email to UKSC mailbox")]
        public async Task GivenUserSendsEmailToUKSCMailbox(Table table)
        {
            var subjects = new List<string>();
            var bodies = new List<string>();

            foreach (var row in table.Rows)
            {
                subjects.Add(row["subject"].Replace("'", string.Empty));
                bodies.Add(row["body"].Replace("'", string.Empty));
                string from = "amitsharma.jaiprakash@hiscox.com";
                string to = "Test_UKSC_Dynamics@hiscox.com";
                if (row["attachment"].Replace("'", string.Empty).Equals("Yes"))
                {
                    string attachmentPath = "C:\\Users\\jaipraka\\source\\repos\\uk-workflow-testautomation\\WorkflowSpecflowTests\\Attachments\\Test.xlsx";
                    await _emailSender.SendEmailWithAttachmentAsync(from, to, row["subject"].Replace("'", string.Empty), row["body"].Replace("'", string.Empty), attachmentPath);
                }
                else
                {
                    await _emailSender.SendEmailWithoutAttachmentAsync(from, to, row["subject"].Replace("'", string.Empty), row["body"].Replace("'", string.Empty));
                }
            }
            _scenarioContext["Subjects"] = subjects;
            _scenarioContext["Bodies"] = bodies;


        }

        [Given(@"User sends email to UKSC mailbox with subject '([^']*)' body '([^']*)' and attachment if any '([^']*)'")]
        public async Task GivenUserSendsEmailToUKSCMailboxWithSubjectBodyAndAttachmentIfAny(string subject, string body, string attachment)
        {
            string from = "amitsharma.jaiprakash@hiscox.com";
            string to = "Test_UKSC_Dynamics@hiscox.com";
            if (attachment.Equals("Yes"))
            {
                string attachmentPath = "C:\\Users\\jaipraka\\source\\repos\\uk-workflow-testautomation\\WorkflowSpecflowTests\\Attachments\\Test.xlsx";
                await _emailSender.SendEmailWithAttachmentAsync(from, to, subject, body, attachmentPath);
            }
            else
            {
                await _emailSender.SendEmailWithoutAttachmentAsync(from, to, subject, body);
            }
        }

        [Given(@"User sends email to UKSC mailbox with sender '([^']*)' to '([^']*)' subject '([^']*)' body '([^']*)' and attachment '([^']*)'")]
        public async Task GivenUserSendsEmailToUKSCMailboxWithSenderToSubjectBodyAndAttachment(string from, string to, string subject, string body, string attachment)
        {
            if (attachment.Equals("Yes"))
            {
                string attachmentPath = "C:\\Users\\jaipraka\\source\\repos\\uk-workflow-testautomation\\WorkflowSpecflowTests\\Attachments\\Test.xlsx";
                await _emailSender.SendEmailWithAttachmentAsync(from, to, subject, body, attachmentPath);
            }
            else
            {
                await _emailSender.SendEmailWithoutAttachmentAsync(from, to, subject, body);
            }
        }


        [Given(@"User sends an email to UKSC mailbox")]
        public async Task GivenUserSendsAnEmailToUKSCMailbox(Table table)
        {
            foreach (var row in table.Rows)
            {

                if (row["attachment"].Replace("'", string.Empty).Equals("Yes"))
                {
                    string attachmentPath = "" + _basePage.GetRootDir() + "\\Attachments\\Work-33-Files\\" + row["FileName"] + ""; //$"/XML/{fileName}.xml"
                    //string attachmentPath = _basePage.GetRootDir() + "\\Attachments\\Test.xlsx"; //$"/XML/{fileName}.xml"
                    await _emailSender.SendEmailWithAttachmentAsync(row["sender"].Replace("'", string.Empty), row["to"].Replace("'", string.Empty), row["subject"].Replace("'", string.Empty), row["body"].Replace("'", string.Empty), attachmentPath);
                }
                else
                {
                    await _emailSender.SendEmailWithoutAttachmentAsync(row["sender"].Replace("'", string.Empty), row["to"].Replace("'", string.Empty), row["subject"].Replace("'", string.Empty), row["body"].Replace("'", string.Empty));
                }
            }
        }



        [Then(@"User enters the mandatory fields primary demand <ChildPrimaryDemand> demand <ChildDemand> sub demand <ChildSubDemand> and validates SLA start date of child case <numberOfDays> also child case is shown in timeline")]
        public async Task ThenUserEntersTheMandatoryFieldsPrimaryDemandChildPrimaryDemandDemandChildDemandSubDemandChildSubDemandAndValidatesSLAStartDateOfChildCaseNumberOfDaysAlsoChildCaseIsShownInTimeline(Table table)
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
                if (row["PrimaryDemand"].Replace("'", string.Empty).Equals("I want to renew"))
                {
                    Assertions.Equals(await _casesPage.GetCaseDueDate(), "11/07/2025");
                }
                else
                {
                    Assertions.Equals(await _casesPage.GetCaseDueDate(), _basePage.GetFutureDateExcludingWeekendsAsync(int.Parse(row["numberOfDays"].Replace("'", string.Empty))));
                }

                await _casesPage.ClickCancelCase();
                await _casesPage.ClickConfirmButton();
                await _casesPage.ClickGoBackButton();
            }
        }


        [Then(@"User clicks on Activities")]
        public async Task ThenUserClicksOnActivities()
        {
            await _activitiesPage.ClickActivitiesAsync();
        }
        [Then(@"User Selects All Emails")]
        public async Task ThenUserSelectsAllEmails()
        {
            await _activitiesPage.ClickAllEmailAsync();
        }


        [Then(@"User searches the email by subject and clicks on the email")]
        public async Task ThenUserSearchesTheEmailBySubjectAndClicksOnTheEmail()
        {


            await _activitiesPage.ClickSearchDropdownAsync();
            await _activitiesPage.SearchAllEmailAsync("All Emails");
            await _activitiesPage.ClickAllEmailAsync();
            await _activitiesPage.FilterEmailAsync("subject");
            await _activitiesPage.ClickMofidicationOnAsync();
            await _activitiesPage.ClickNewerToOlderAsync();
            await _activitiesPage.SelectNewlySentEmailAsync();
        }

        [Then(@"User searches the email by subject '([^']*)' and clicks on the email")]
        public async Task ThenUserSearchesTheEmailBySubjectAndClicksOnTheEmail(string subject)
        {
            await _activitiesPage.ClickSearchDropdownAsync();
            await _activitiesPage.SearchAllEmailAsync("All Emails");
            await _activitiesPage.ClickAllEmailFilterAsync();
            await _activitiesPage.FilterEmailAsync(subject);
            await _activitiesPage.ClickMofidicationOnAsync();
            await _activitiesPage.ClickNewerToOlderAsync();
            await _activitiesPage.SelectNewlySentEmailAsync();
        }

        [Then(@"User searches the email by subject '([^']*)'")]
        public async Task ThenUserSearchesTheEmailBySubject(string subject)
        {
            await _activitiesPage.ClickSearchDropdownAsync();
            await _activitiesPage.SearchAllEmailAsync("All Emails");
            await _activitiesPage.ClickAllEmailFilterAsync();
            await _activitiesPage.FilterEmailAsync(subject);
        }

        [Then(@"User filter the mail with current date")]
        public async Task ThenUserFilterTheMailWithCurrentDate()
        {
            await _activitiesPage.ClickMofidicationOnAsync();
            await _activitiesPage.ClickFilterByAsync();
            await _activitiesPage.ClickDatePickerAsync();
            await _activitiesPage.ClickCurrentDateAsync();
            await _activitiesPage.ClickApplyAsync();
        }

        [Then(@"User validates the mail count of '([^']*)'")]
        public async Task ThenUserValidatesTheMailCount(string subject)
        {
            Assertions.Equals(await _activitiesPage.GetMailCountAsync(subject), 1);
        }


        [Then(@"Validate the request '([^']*)' is in UKSC Manual Triage Bucket")]
        public async Task ThenValidateTheRequestIsInUKSCManualTriageBucket(string subject)
        {
            await _activitiesPage.GotoUKSCTriageQueuesFilter();
            await _activitiesPage.FilterQueueEmailAsync(subject);
            //Assert.Equal(_activitiesPage.verifyEmailWithSubject(subject), true);
            Assertions.Equals(_activitiesPage.verifyEmailWithSubject(subject), true);
        }


        [Then(@"Validate that case number is not created")]
        public async void ThenValidateThatCaseNumberIsNotCreated()
        {
            Assertions.Equals(await _activitiesPage.GetRegardingTextAsync(), "---");
        }


        [Then(@"User validates the email content like subject '([^']*)' body '([^']*)'")]
        public async Task ThenUserValidatesTheEmailContentLikeSubjectBody(string subject, string body)
        {
            Assertions.Equals(await _activitiesPage.GetSubjectAsync(), subject);
            Assertions.Equals(await _activitiesPage.GetBodyAsync(), body);
        }
        [Then(@"User Validates The Regarding has Casename")]
        public async Task ThenUserValidatesTheRegardingHasCasename()
        {
            await _activitiesPage.ClickOnRegardingAndValidate();
        }



        [Then(@"User validates the email content like subject and body")]
        public async Task ThenUserValidatesTheEmailContentLikeSubjectBody()
        {
            await _activitiesPage.ClickRefreshAsync();
            //Assertions.Equals(await _activitiesPage.GetSubjectAsync(), subject);
            //Assertions.Equals(await _activitiesPage.GetBodyAsync(), body);
        }
        [Then(@"User Deletes the email")]
        public async Task ThenUserDeletesTheEmail()
        {
            await _activitiesPage.ClickDeleteAsync();
            await _activitiesPage.ClickConfirmDeleteAsync();
        }
        [Then(@"User clicks on Emails")]
        public async Task ThenUserClicksOnEmails()
        {
            await _activitiesPage.ClickEmailAsync();
        }

        [Then(@"User enters from '([^']*)' to '([^']*)' subject '([^']*)' body '([^']*)' and attach files '([^']*)' with file path '([^']*)'")]
        public async Task ThenUserEntersFromToSubjectBodyAndAttachFilesWithFilePath(string from, string to, string subject, string body, string attachment, string attachmentPath)
        {
            await _activitiesPage.ClearToAsync();
            await _activitiesPage.EnterEmailDetails(from, to, subject, body, attachment, attachmentPath);
        }

        [Then(@"User clicks on send button")]
        public async Task ThenUserClicksOnSendButton()
        {
            await _activitiesPage.ClickSendAsync();
        }

        [Then(@"User validates if email '([^']*)' has sent successfully")]
        public async Task ThenUserValidatesIfEmailHasSentSuccessfully(string subject)
        {
            await _activitiesPage.ClickSearchDropdownAsync();
            await _activitiesPage.SearchAllEmailAsync("My Sent Emails");
            await _activitiesPage.ClickMySentEmailsAsync();
            await _activitiesPage.FilterEmailAsync(subject);
            //await _activitiesPage.SelectNewlySentEmailAsync();
        }
        [Then(@"User validates if regarding field is updated with case name and click on the case link")]
        public async Task ThenUserValidatesIfRegardingFieldIsUpdatedWithCaseNameAndClickOnTheCaseLink()
        {
            //Assertions.Equals(await _activitiesPage.GetRegardingsAsync(), caseName);
            await _activitiesPage.ClickRegardingsAsync();
        }
        [Then(@"User checks case status is set to new")]
        public async Task ThenUserChecksCaseStatusIsSetToNew()
        {
            await _activitiesPage.CheckCaseStatusNew();
        }

        [Then(@"User validates if regarding field is updated with case name '([^']*)' and click on the case link")]
        public async Task ThenUserValidatesIfRegardingFieldIsUpdatedWithCaseNameAndClickOnTheCaseLink(string caseName)
        {
            Assertions.Equals(await _activitiesPage.GetRegardingsAsync(), caseName);
            await _activitiesPage.ClickRegardingsAsync();
        }


        [Then(@"User validates case name '([^']*)' primary demand '([^']*)' demand '([^']*)' policy reference '([^']*)' case due date (.*) reinfer label '([^']*)' and RPA flag '([^']*)'")]
        public async Task ThenUserValidatesCaseNamePrimaryDemandDemandPolicyReferenceCaseDueDateReinferLabelAndRPAFlag(string caseName, string primaryDemand, string demand, string policyRef, int caseDueDate, string reinferLabel, string rpaFlag)
        {
            Assertions.Equals(await _casesPage.GetCaseNameAsync(), caseName);
            Assertions.Equals(await _casesPage.GetPrimaryDemandAsync(), primaryDemand);
            Assertions.Equals(await _casesPage.GetDemandAsync(), demand);
            Assertions.Equals(await _casesPage.GetPolicyReferenceNumberAsync(), policyRef);
            if (primaryDemand.Equals("I want to renew"))
            {
                Assertions.Equals(await _casesPage.GetCaseDueDate(), "4/29/2025");

            }
            else
            {
                Assertions.Equals(await _casesPage.GetCaseDueDate(), _basePage.GetFutureDateExcludingWeekendsAsync(caseDueDate));

            }
            await _casesPage.ClickOnDetailsTab();
            Assertions.Equals(await _casesPage.GetReInferLabelAsync(), reinferLabel);
            Assertions.Equals(await _casesPage.GetRPAFlagAsync(), rpaFlag);
        }
        [Then(@"user cancel the case")]
        public async Task ThenUserCancelTheCase()
        {
            await _casesPage.ClickCancelCase();
            await _casesPage.ClickConfirmButton();
        }


        [Then(@"User clicks on back button")]
        public async Task ThenUserClicksOnBackButton()
        {
            await _casesPage.ClickGoBackButton();
        }

        [When(@"User creates child case and validates SLA")]
        public async Task CreateChildCase(Table table)
        {
            var subjects = (List<string>)_scenarioContext["Subjects"];
            var bodies = (List<string>)_scenarioContext["Bodies"];

            for (int i = 0; i < subjects.Count; i++)
            {
                await _activitiesPage.ClickActivitiesAsync();

                await _activitiesPage.ClickSearchDropdownAsync();
                await _activitiesPage.SearchAllEmailAsync("All Emails");
                await _activitiesPage.ClickAllEmailAsync();
                await _activitiesPage.FilterEmailAsync(subjects[i]);
                await _activitiesPage.ClickMofidicationOnAsync();
                await _activitiesPage.ClickNewerToOlderAsync();
                await _activitiesPage.SelectNewlySentEmailAsync();

                await _activitiesPage.ClickRefreshAsync();
                Assertions.Equals(await _activitiesPage.GetSubjectAsync(), subjects[i]);
                Assertions.Equals(await _activitiesPage.GetBodyAsync(), bodies[i]);

                Assertions.Equals(await _activitiesPage.GetRegardingsAsync(), subjects[i]);
                await _activitiesPage.ClickRegardingsAsync();

                foreach (var row in table.Rows)
                {
                    await _casesPage.ClickOnCaseRelationshipsTab();
                    await _childCasePage.ClickChildCaseOptionAsync();
                    await _childCasePage.ClickNewChildCaseAsync();
                    await _childCasePage.EnterPrimaryDemandAsync(row["PrimaryDemand"].Replace("'", string.Empty));
                    await _childCasePage.EnterDemandAsync(row["Demand"].Replace("'", string.Empty));
                    await _childCasePage.EnterSubDemandAsync(row["PrimaryDemand"].Replace("'", string.Empty), row["SubDemand"].Replace("'", string.Empty));

                    await _childCasePage.ClickSaveAndCloseAsync();

                    await _childCasePage.ClickActiveChildCaseAsync();

                    await _childCasePage.ClickBackAsync();
                    Thread.Sleep(6000);

                    await _childCasePage.ClickActiveChildCaseAsync();
                    if (row["PrimaryDemand"].Replace("'", string.Empty).Equals("I want to renew"))
                    {
                        Assertions.Equals(await _casesPage.GetCaseDueDate(), "11/07/2025");
                    }
                    else
                    {
                        Assertions.Equals(await _casesPage.GetCaseDueDate(), _basePage.GetFutureDateExcludingWeekendsAsync(int.Parse(row["numberOfDays"].Replace("'", string.Empty))));
                    }

                    await _casesPage.ClickCancelCase();
                    await _casesPage.ClickConfirmButton();
                    await _casesPage.ClickGoBackButton();
                }
            }
        }

        [Then(@"User changes the owner to '([^']*)' and clicks on Dashboard")]
        public async Task ThenUserChangesTheOwnerToAndClicksOnDashboard(string owner)
        {
            await _casesPage.ClickExpand();
            await _casesPage.RemoveOwnerAsync();
            await _casesPage.SelectOwnerAsync(owner);
            await _casesPage.ClickSaveAsync();
        }



        [Then(@"User search and validates the email content with the below")]
        public async Task ThenUserValidatesIfEmailAppearsInTheTimelineSubjectBody(Table table)
        {

            foreach (var row in table.Rows)
            {
                await _activitiesPage.ClickActivitiesAsync();

                await _activitiesPage.ClickSearchDropdownAsync();
                await _activitiesPage.SearchAllEmailAsync("All Emails");
                await _activitiesPage.ClickAllEmailAsync();
                await _activitiesPage.FilterEmailAsync(row["subject"].Replace("'", string.Empty));
                await _activitiesPage.ClickMofidicationOnAsync();
                await _activitiesPage.ClickNewerToOlderAsync();
                await _activitiesPage.SelectNewlySentEmailAsync();

                await _activitiesPage.ClickRefreshAsync();
                Assertions.Equals(await _activitiesPage.GetSubjectAsync(), row["subject"].Replace("'", string.Empty));
                Assertions.Equals(await _activitiesPage.GetBodyAsync(), row["body"].Replace("'", string.Empty));
                // Assertions.Equals(await _activitiesPage.GetAttachmentAsync(), row["FileName"].Replace("'", string.Empty));

            }
        }

        [Then(@"User validates if email appears in the timeline subject '([^']*)' body '([^']*)'")]
        public async Task ThenUserValidatesIfEmailAppearsInTheTimelineSubjectBody(string subject, string body)
        {
            Assertions.Equals(await _activitiesPage.GetTimelineSubject(), subject);
            Assertions.Equals(await _activitiesPage.GetTimelineDescription(), body);
        }

    }
}
