using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface IActivitiesPage
    {
        Task ClickActivitiesAsync();
        Task ClickAllEmailAsync();
        Task ClickAllEmailFilterAsync();
        Task ClickMyActivitesAsync();
        Task ClickSearchDropdownAsync();
        Task FilterEmailAsync(string subject);
        Task FilterQueueEmailAsync(string subject);
        Task<string> GetBodyAsync();
        Task<string> GetSubjectAsync();
        Task<string> GetRegardingTextAsync();
        Task SearchAllEmailAsync(string searchOption);
        Task SelectNewlySentEmailAsync();
        Task ClickDeleteAsync();
        Task ClickConfirmDeleteAsync();
        Task ClickEmailAsync();
        Task ClickSendAsync();
        Task EnterEmailDetails(string from, string to, string subject, string body, string attachment, string attachmentPath);
        Task EnterEmailDetails(string from, string to, string cc, string subject, string body, string attachment, string attachmentPath);
        Task EnterEmailDetails(string from, string to, string cc, string bcc, string subject, string body, string attachment, string attachmentPath);
        Task ClickMySentEmailsAsync();
        Task<string> GetRegardingsAsync();
        Task ClickRegardingsAsync();
        Task CheckCaseStatusNew();
        Task ClearToAsync();
        Task ClickRefreshAsync();
        Task ClickMofidicationOnAsync();
        Task ClickNewerToOlderAsync();
        Task ClickOnRegardingAndValidate();
        Task GotoUKSCTriageQueuesFilter();
        Task<bool> verifyEmailWithSubject(String subject);
        Task ClickNewRegardingsAsync();
        Task<string> GetTimelineSubject();
        Task<string> GetTimelineDescription();
        Task ClickFilterByAsync();
        Task ClickDatePickerAsync();
        Task ClickCurrentDateAsync();
        Task ClickApplyAsync();
        Task<int> GetMailCountAsync(string subject);
    }

    public class ActivitiesPage : IActivitiesPage
    {
        private readonly IPage _page;
        private readonly IBasePage _basePage;
        private readonly ILogger<ActivitiesPage> _logger;

        public ActivitiesPage(IPlaywrightDriver driver, IBasePage basePage, ILogger<ActivitiesPage> logger)
        {
            _page = driver.Page.Result;
            _basePage = basePage;
            _logger = logger;
        }
        private ILocator CaseStatusNew => _page.Locator("//div[text()='Case Status']//preceding::div[text()='New']");
        private ILocator RegardingField => _page.Locator("//label[text()='Regarding']/following::ul/li/div/div[1]");
        private ILocator MyActivites => _page.Locator("//span[text()='My Activities']");
        private ILocator Activities => _page.Locator("//span[text()='Activities']");
        private ILocator Queues => _page.Locator("//span[text()='Queues']");
        private ILocator SearchDropdown => _page.Locator(".ms-Button-menuIcon");
        private ILocator AllItems => _page.Locator("//label[text()='All Items']");
        private ILocator selectQueueFilter => _page.Locator("//div[@aria-label='Select a queue filter']");
        private ILocator UKSCManualTriage => _page.Locator("//*[text()='UKSC- Manual Triage']");
        private ILocator SearchView => _page.Locator("//input[@aria-label='Search views']");
        private ILocator AllEmail => _page.Locator("//label[text()='All Emails']");
        private ILocator Filter => _page.Locator("//input[@placeholder='Filter by keyword']");
        private ILocator QueueFilter => _page.Locator("//input[@aria-label='Queue Item Filter by keyword']");
        private ILocator EmailSubject => _page.Locator("(//div[@col-id='subject']//span)[1]");
        private ILocator Regardings => _page.Locator("(//div[@col-id='regardingobjectid']//span)[1]");
        private ILocator More => _page.Locator("//button[@data-id='OverflowButton']");
        private ILocator Delete => _page.Locator("//span[text()='Delete']");
        private ILocator ConfirmDelete => _page.Locator("//div[text()='Delete']");
        private ILocator Email => _page.Locator("//span[text()='Email']");
        private ILocator To => _page.Locator("//input[@aria-label='To, Multiple Selection Lookup']");
        private ILocator Cc => _page.Locator("//input[@aria-label='Cc, Multiple Selection Lookup']");
        private ILocator Bcc => _page.Locator("//input[@aria-label='Bcc, Multiple Selection Lookup']");
        private ILocator Subject => _page.Locator("//input[@aria-label='Subject']");
        private ILocator Body => _page.Locator("//div[@role='textbox']");
        private ILocator Send => _page.Locator("//span[text()='Send']");
        private ILocator MySentEmails => _page.Locator("//label[text()='My Sent Emails']");
        private ILocator Regarding => _page.Locator("//div[@data-id='regardingobjectid.fieldControl-LookupResultsDropdown_regardingobjectid_selected_tag_text']");
        private ILocator RegardingLookup => _page.Locator("//input[@aria-label='Regarding, Lookup']");
        private ILocator ClearTo => _page.Locator(".Cancel-symbol");
        private ILocator From => _page.Locator("//input[@aria-label='From, Lookup']");
        private ILocator Refresh => _page.Locator("//span[text()='Refresh']");
        private ILocator MofidicationOn => _page.Locator("//div[@data-testid='modifiedon']");
        private ILocator NewerToOlder => _page.Locator("//span[text()='Newer to older']");
        private ILocator AllEmails => _page.Locator("(//i[@data-icon-name='CheckMark'])[2]");
        private ILocator TimelineDescription => _page.Locator("//div[starts-with(@id,'timeline_field_description')]/div");
        private ILocator TimelineSubject => _page.Locator("//div[starts-with(@id,'timeline_field_subjec')]/label");
        private ILocator FilterBy => _page.Locator("//span[text()='Filter by']");
        private ILocator DatePicker => _page.Locator("//input[starts-with(@id,'DatePicker')]");
        private ILocator CurrentDate => _page.Locator("//td[@aria-selected='true']");
        private ILocator Apply => _page.Locator("//span[text()='Apply']");

        public async Task ClickFilterByAsync()
        {
            await _basePage.ClickElementAsync(FilterBy);
            _logger.LogInformation("Clicked on FilterBy");
        }
        public async Task ClickDatePickerAsync()
        {
            await _basePage.ClickElementAsync(DatePicker);
            _logger.LogInformation("Clicked on DatePicker");
        }
        public async Task ClickCurrentDateAsync()
        {
            await _basePage.ClickElementAsync(CurrentDate);
            _logger.LogInformation("Clicked on CurrentDate");
        }
        public async Task ClickApplyAsync()
        {
            await _basePage.ClickElementAsync(Apply);
            _logger.LogInformation("Clicked on Apply");
        }
        public async Task ClickRefreshAsync()
        {
            await _basePage.ClickElementAsync(Refresh);
            _logger.LogInformation("Clicked on Refresh");
        }
        public async Task<int> GetMailCountAsync(string subject)
        {
            await _page.Mouse.WheelAsync(0, 150);
            return await _page.Locator("//span[text()='"+subject+"']").CountAsync();
        }
        public async Task ClickMofidicationOnAsync()
        {
            await AllEmails.ClickAsync();
            _logger.LogInformation("Clicked on All Emails");
            await _page.Mouse.WheelAsync(150, 0);
            await _basePage.ClickElementAsync(MofidicationOn);
            _logger.LogInformation("Clicked on MOdificationOn");
        }
        public async Task ClickNewerToOlderAsync()
        {
            await _basePage.ClickElementAsync(NewerToOlder);
            _logger.LogInformation("Clicked on Newer to Older");
            await _page.Mouse.WheelAsync(-150, 0);
        }
        public async Task ClickActivitiesAsync()
        {
            await _basePage.ClickElementAsync(Activities);
            _logger.LogInformation("Clicked on Activities");
        }
        public async Task ClickSearchDropdownAsync()
        {
            await _basePage.ClickElementAsync(SearchDropdown);
            _logger.LogInformation("Clicked on Search dropdown");
        }
        public async Task SearchAllEmailAsync(string searchOption)
        {
            Thread.Sleep(3000);
            await _basePage.FillElementAsync(SearchView, searchOption);
            _logger.LogInformation("Entered " + searchOption);
        }
        public async Task ClickMyActivitesAsync()
        {
            await _basePage.ClickElementAsync(MyActivites);
            _logger.LogInformation("Clicked on MyActivites");
        }
        public async Task ClickAllEmailAsync()
        {
            await _basePage.ClickElementAsync(AllEmail);
            _logger.LogInformation("Clicked on All Emails");
        }

        public async Task ClickAllEmailFilterAsync()
        {
            await _basePage.ClickElementAsync(AllEmail);
            _logger.LogInformation("Clicked on All Emails Filter");
        }

        public async Task GotoUKSCTriageQueuesFilter()
        {
            await _basePage.ClickElementAsync(Queues);
            await _basePage.ClickElementAsync(SearchDropdown);
            await _basePage.ClickElementAsync(AllItems);
            await _basePage.ClickElementAsync(selectQueueFilter);
            await _page.ClickAsync("//*[text()='UKSC- Manual Triage']");
            //await _basePage.ClickElementAsync(UKSCManualTriage);
            _logger.LogInformation("Filtered UKSC Manual Triage");
        }

        public async Task<bool> verifyEmailWithSubject(string subject)
        {
            return await _page.IsVisibleAsync("//span[text()='" + subject + "']");
        }
        public async Task FilterEmailAsync(string subject)
        {
            await _basePage.FillElementAsync(Filter, subject);
            await _page.Keyboard.PressAsync("Enter");
            await _page.Keyboard.PressAsync("Enter");
            await _page.Keyboard.PressAsync("Enter");
            _logger.LogInformation("Entered email subject " + subject);
        }

        public async Task FilterQueueEmailAsync(string subject)
        {
            await _basePage.FillElementAsync(QueueFilter, subject);
            await _page.Keyboard.PressAsync("Enter");
            await _page.Keyboard.PressAsync("Enter");
            _logger.LogInformation("Entered email subject " + subject);
        }
        public async Task SelectNewlySentEmailAsync()
        {
            await _basePage.ClickElementAsync(EmailSubject);
            _logger.LogInformation("Clicked newly sent email");
        }
        public async Task<string> GetSubjectAsync()
        {
            return await _page.GetAttributeAsync("//input[@aria-label='Subject']", "value");
        }
        public async Task<string> GetBodyAsync()
        {
            return await Body.TextContentAsync();
        }

        public async Task<string> GetRegardingTextAsync()
        {
            return await _page.GetAttributeAsync("//input[@aria-label='Regarding, Lookup']", "value");
        }
        public async Task ClickDeleteAsync()
        {
            await _basePage.ClickElementAsync(More);
            _logger.LogInformation("Clicked More");
            await _basePage.ClickElementAsync(Delete);
            _logger.LogInformation("Clicked Delete");
        }
        public async Task ClickConfirmDeleteAsync()
        {
            await _basePage.ClickElementAsync(ConfirmDelete);
            _logger.LogInformation("Clicked Confirm Delete");
        }
        public async Task ClickEmailAsync()
        {
            await _basePage.ClickElementAsync(Email);
            _logger.LogInformation("Clicked Email");
        }
        public async Task ClearToAsync()
        {
            await _basePage.ClickElementAsync(ClearTo);
            _logger.LogInformation("Clicked ClearTo");
        }
        public async Task EnterEmailDetails(string from, string to, string subject, string body, string attachment, string attachmentPath)
        {
            await _basePage.FillElementAsync(From, from);
            await _page.Locator("//span[text()='" + from + "']").First.ClickAsync();
            _logger.LogInformation("Entered from " + from);
            await _basePage.FillElementAsync(To, to);
            await _page.Locator("//span[text()='" + to + "']").First.ClickAsync();
            _logger.LogInformation("Entered to " + to);
            await _basePage.FillElementAsync(Subject, subject);
            await _basePage.FillElementAsync(Body, body);
            if (attachment.Equals("Yes"))
            {
                
            }
        }

        public async Task EnterEmailDetails(string from, string to, string cc, string subject, string body, string attachment, string attachmentPath)
        {
            await _basePage.FillElementAsync(From, from);
            await _page.Locator("//span[text()='" + from + "']").First.ClickAsync();
            _logger.LogInformation("Entered from " + from);
            await _basePage.FillElementAsync(To, to);
            await _page.Locator("//span[text()='" + to + "']").First.ClickAsync();
            _logger.LogInformation("Entered to " + to);
            await _basePage.FillElementAsync(Cc, cc);
            await _page.Locator("//span[text()='" + cc + "']").First.ClickAsync();
            _logger.LogInformation("Entered cc " + cc);
            await _basePage.FillElementAsync(Subject, subject);
            await _basePage.FillElementAsync(Body, body);
            if (attachment.Equals("Yes"))
            {

            }
        }

        public async Task EnterEmailDetails(string from, string to, string cc, string bcc, string subject, string body, string attachment, string attachmentPath)
        {
            await _basePage.FillElementAsync(From, from);
            await _page.Locator("//span[text()='" + from + "']").First.ClickAsync();
            _logger.LogInformation("Entered from " + from);
            await _basePage.FillElementAsync(To, to);
            await _page.Locator("//span[text()='" + to + "']").First.ClickAsync();
            _logger.LogInformation("Entered to " + to);
            await _basePage.FillElementAsync(Cc, cc);
            await _page.Locator("//span[text()='" + cc + "']").First.ClickAsync();
            _logger.LogInformation("Entered cc " + cc);
            await _basePage.FillElementAsync(Bcc, bcc);
            await _page.Locator("//span[text()='" + bcc + "']").First.ClickAsync();
            _logger.LogInformation("Entered bcc " + bcc);
            await _basePage.FillElementAsync(Subject, subject);
            await _basePage.FillElementAsync(Body, body);
            _logger.LogInformation("Entered email body " + body);
            if (attachment.Equals("Yes"))
            {

            }
        }
        public async Task ClickSendAsync()
        {
            await _basePage.ClickElementAsync(Send);
            _logger.LogInformation("Clicked Send button");
        }
        public async Task ClickMySentEmailsAsync()
        {
            await _basePage.ClickElementAsync(MySentEmails);
            _logger.LogInformation("Clicked my sent email");
        }
        public async Task ClickRegardingsAsync()
        {
            await _basePage.ClickElementAsync(Regarding);
            _logger.LogInformation("Clicked regardings");
        }
        public async Task<string> GetRegardingsAsync()
        {
            return await Regarding.TextContentAsync();
        }
        public async Task ClickOnRegardingAndValidate()
        {
            await _basePage.IsElementVisibleAsync(RegardingField);            
            await _basePage.ClickElementAsync(RegardingField);
        }
        public async Task ClickNewRegardingsAsync()
        {
            await _basePage.ClickElementAsync(Regardings);
        }
        public async Task<string> GetTimelineSubject()
        {
            return await TimelineSubject.TextContentAsync();
        }
        public async Task<string> GetTimelineDescription()
        {
            return await TimelineDescription.TextContentAsync();
        }
        public async Task CheckCaseStatusNew()
        {
            await _basePage.IsElementVisibleAsync(CaseStatusNew);
        }
    }
}
