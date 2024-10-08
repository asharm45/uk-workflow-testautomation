using System.Reactive.Subjects;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface IQueuesPage
    {
        Task ClickAddToQueueAsync();
        Task ClickAllQueuesAsync();
        Task ClickApplyAsync();
        Task ClickCloseAsync();
        Task ClickContainsAsync();
        Task ClickDropDownAsync();
        Task ClickFilterByAsync();
        Task ClickFilterOperatorAsync();
        Task ClickManageAsync();
        Task ClickMore1Async();
        Task ClickMore2Async();
        Task ClickAddAsync();
        Task ClickOwnerAsync();
        Task ClickQueueItemsDetailsAsync();
        Task ClickQueuesAsync();
        Task ClickAllItemsAsync();
        Task EnterOwnerAsync(string owner);
        Task EnterQueueAsync(string queueName);
        Task<string> GetQueueAsync(string queueName);
        Task<string> GetQueueNameAsync();
        Task ClickTestUKSCAsync();
        Task SearchForSubjectAsync(string subject);
        Task ClickOnDashboardsAsync();
        Task PickWorkValidationAsync(string subject);
    }

    public class QueuesPage : IQueuesPage
    {
        private readonly IPage _page;
        private readonly IBasePage _basePage;
        private readonly ILogger<QueuesPage> _logger;
        public QueuesPage(IPlaywrightDriver driver, IBasePage basePage, ILogger<QueuesPage> logger)
        {
            _page = driver.Page.Result;
            _basePage = basePage;
            _logger = logger;
        }
        private ILocator CaseSearchField => _page.Locator("//input[@aria-label='Case Filter by keyword']");
        private ILocator PickWorkButton => _page.Locator("//span[text()='Pick Work']");
        private ILocator DashBoards => _page.Locator("//span[text()='Dashboards']");
        private ILocator AllItems => _page.Locator("//label[text()='All Items']");
        private ILocator Queues => _page.Locator("//span[text()='Queues']");
        private ILocator Manage => _page.Locator("(//span[text()='Manage'])[1]");
        private ILocator DropDown => _page.Locator("(//i[@data-icon-name='ChevronDown'])[1]");
        private ILocator DropDownBottom => _page.Locator("//div[@aria-label='Select a queue filter']");
        private ILocator Test_UKSC => _page.Locator("//li[text()='test_uksc_dynamics']");
        private ILocator AllQueues => _page.Locator("//label[text()='All Queues']");
        private ILocator Owner => _page.Locator("(//div[text()='Owner'])[1]");
        private ILocator FilterBy => _page.Locator("//span[text()='Filter by']");
        private ILocator FilterOperator => _page.Locator("(//div[@aria-label='Filter by operator']/span)[1]");
        private ILocator Contains => _page.Locator("//span[text()='Contains']");
        private ILocator Textbox => _page.Locator("//input[@aria-label='Filter by value']");
        private ILocator Apply => _page.Locator("//span[text()='Apply']");
        private ILocator More1 => _page.Locator("(//button[@data-id='OverflowButton']/span/span/span)[1]");
        private ILocator More2 => _page.Locator("(//button[@data-id='OverflowButton']/span/span/span)[2]");
        private ILocator AddToQueue => _page.Locator("//span[text()='Add to Queue']");
        private ILocator SearchQueue => _page.Locator("//input[@aria-label='Queue, Lookup']");
        private ILocator Add => _page.Locator("//button[text()='Add']");
        private ILocator QueueItemDetails => _page.Locator("//*[text()='Queue Item Details']");
        private ILocator Close => _page.Locator("//*[text()='Close']");
        private ILocator UKSCManualTriage => _page.Locator("//*[text()='UKSC- Manual Triage']");
        private ILocator SearchField => _page.Locator("//input[@aria-label='Queue Item Filter by keyword']");
        public async Task ClickQueuesAsync()
        {
            await _basePage.ClickElementAsync(Queues);
        }
        public async Task ClickManageAsync()
        {
            await _basePage.ClickElementAsync(Manage);
        }
        public async Task ClickDropDownAsync()
        {
            await _basePage.ClickElementAsync(DropDown);
        }
        public async Task ClickAllQueuesAsync()
        {
            await _basePage.ClickElementAsync(AllQueues);
        }
        public async Task ClickOwnerAsync()
        {
            await _basePage.ClickElementAsync(Owner);
        }
        public async Task ClickFilterByAsync()
        {
            await _basePage.ClickElementAsync(FilterBy);
        }
        public async Task ClickFilterOperatorAsync()
        {
            await _basePage.ClickElementAsync(FilterOperator);
        }
        public async Task ClickContainsAsync()
        {
            await _basePage.ClickElementAsync(Contains);
        }
        public async Task EnterOwnerAsync(string owner)
        {
            await _basePage.FillElementAsync(Textbox, owner);
        }
        public async Task ClickApplyAsync()
        {
            await _basePage.ClickElementAsync(Apply);
        }
        public async Task<string> GetQueueAsync(string queueName)
        {
            return await _page.Locator("//a[@aria-label='" + queueName + "']").TextContentAsync();
        }
        public async Task ClickMore1Async()
        {
            await _basePage.ClickElementAsync(More1);
        }
        public async Task ClickMore2Async()
        {
            await _basePage.ClickElementAsync(More2);
        }
        public async Task ClickAddAsync()
        {
            await _basePage.ClickElementAsync(Add);
        }
        public async Task ClickAddToQueueAsync()
        {
            await _basePage.ClickElementAsync(AddToQueue);
        }
        public async Task EnterQueueAsync(string queueName)
        {
            await _basePage.FillElementAsync(SearchQueue, queueName);
            await _basePage.ClickElementAsync(UKSCManualTriage);
        }
        public async Task ClickQueueItemsDetailsAsync()
        {
            await _basePage.ClickElementAsync(QueueItemDetails);
        }
        public async Task<string> GetQueueNameAsync()
        {
            return await UKSCManualTriage.TextContentAsync();
        }
        public async Task ClickCloseAsync()
        {
            await _basePage.ClickElementAsync(Close);
        }
        public async Task ClickAllItemsAsync()
        {
            await _basePage.ClickElementAsync(DropDown);
            await _basePage.ClickElementAsync(AllItems);
        }
        public async Task ClickTestUKSCAsync()
        {
            await _basePage.ClickElementAsync(DropDownBottom);
            await _basePage.ClickElementAsync(Test_UKSC);

        }
        public async Task SearchForSubjectAsync(string subject)
        {
            await _basePage.FillElementAsync(SearchField, subject);
            await _basePage.PressKeyAsync(SearchField, "Enter");
            //Test_UKSC_VALIDATION
            await _page.Locator("//span[text()='" + subject + "']//following::span[text()='test_uksc_dynamics']").First.IsVisibleAsync();
        }
        public async Task  ClickOnDashboardsAsync()
        {
            await _basePage.ClickElementAsync(DashBoards);
        }
        public async Task PickWorkValidationAsync(string subject)
        {
            var CaseCount = await _page.Locator("//div[@aria-label='Jump bar']//following::span").InnerTextAsync();

            var match = Regex.Match(CaseCount, @"of (\d+)");
            await _basePage.ClickElementAsync(PickWorkButton);
            Thread.Sleep(5000);
            await _page.Locator("//div[text()='Done']").IsVisibleAsync();
            await _page.Locator("//button[@title='Close']").ClickAsync();
            await _basePage.FillElementAsync(CaseSearchField, subject);
            await _basePage.PressKeyAsync(CaseSearchField, "Enter");
            Thread.Sleep(5000);
            if (await _page.Locator("//span[text()='"+subject+"']").IsVisibleAsync())
            {
                throw new Exception("Case is visible"+ subject +"after clicking pick work button");
            }


        }

    }

}
