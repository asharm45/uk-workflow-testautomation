using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface ITasksPage
    {
        Task FilterCreatedTask(string taskName);
        Task ClickActivities();
        Task SelectAllActivitiesFromTaskPage();
        Task ClickTask();
        Task EnterDemandTask(string demandTask);
        Task EnterInstructions(string instructions);
        Task EnterPrimaryDemand(string primaryDemand);
        Task EnterPrimaryDemandNotOverwrite(string primaryDemand);
        Task EnterRegardings(string caseName);
        Task EnterTaskType(string taskType);
        ILocator GetLabel(string label);
        ILocator GetMerlinTaskId();
        ILocator GetValueStep();
        ILocator GetMerlinTaskIDReadonly();
        Task SaveTask();
        ILocator GetFirstTask();
        ILocator GetSecondTask();
        Task<string> GetMerlinTaskType(string merlinTaskType);
        Task<string> GetValueStep(string valueStep);
        Task<ILocator> IsFieldVisible(string name, int index);
        Task FilterTasksByOwnerName(string ownerName);
        Task validateTasksDisplayedWithOwnerName(string taskName, string ownerName);
        Task SelectNewlyCreatedTask(string taskName);
        Task ClickCancelTask();
        Task ClickCloseTaskButton();
        Task ClickSaveButtonAsync();
        Task<string> GetCaseDueDate();
        Task SearchTask(string DemandTask);
        Task ClickTaskAsync(string DemandTask);
        Task SelectAndDeleteTaskAsync(string DemandTask);
        Task<bool> GetLabelAsync(string subject);
        Task ClickRefreshAsync();
        Task ClickCancelRegardingsAsync();
    }

    public class TasksPage : ITasksPage
    {
        private readonly IPage _page;
        private readonly IBasePage _basePage;
        private readonly ILogger<TasksPage> _logger;
        public TasksPage(IPlaywrightDriver driver, IBasePage basePage, ILogger<TasksPage> logger)
        {
            _page = driver.Page.Result;
            _basePage = basePage;
            _logger = logger;
        }
        private ILocator SearchField => _page.Locator("//input[@aria-label='Activity Filter by keyword']");
        private ILocator SaveBtn => _page.Locator("//span[text()='Save']");
        private ILocator AcceptAllSuggestions => _page.Locator("//span[text()='Accept all suggestions']");
        private ILocator AISuggestion => _page.Locator("//button[@aria-label='Accept all suggestions']");
        private ILocator Activities => _page.Locator("//span[text()='Activities']");
        private ILocator MyActivities => _page.Locator("//span[text()='My Activities']");
        private ILocator AllActivities => _page.Locator("//label[text()='All Activities']");
        private ILocator Task => _page.Locator("//span[text()='Task']");
        private ILocator Regardings => _page.Locator("//input[@aria-label='Regarding, Lookup']");
        private ILocator DemandTask => _page.Locator("//input[@aria-label='Demand Task']");
        private ILocator MerlinTaskID => _page.Locator("(//input[@title='Select to enter data'])[3]");
        private ILocator PrimaryDemand => _page.Locator("//label[text()='Primary Demand']//parent::div//following-sibling::div//input");
        private ILocator MerlinTaskType => _page.Locator("//input[@aria-label='Merlin Task Type']");
        private ILocator ValueStep => _page.Locator("//ul[@title='Value Step']//div[2]/div");
        private ILocator MerlinTaskIDReadonly => _page.Locator("//input[@aria-label='Merlin Task ID' and @readonly]");
        private ILocator StatusReason => _page.Locator("//button[@aria-label='Status Reason']");
        private ILocator PrivateFlag => _page.Locator("//input[@aria-label='Urgent Flag']");
        private ILocator TaskDescription => _page.Locator("//textarea[@aria-label='Description']");
        private ILocator Instructions => _page.Locator("//textarea[@aria-label='Instructions']");
        private ILocator NormalPriority => _page.Locator("//div[text()='Normal']");
        private ILocator Status => _page.Locator("//div[text()='Open']");
        private ILocator TaskType => _page.Locator("//label[text()='Task Type']//following::input[1]");
        private ILocator ActivityDropdown => _page.Locator("//h1[@title='My Activities']//i[@data-icon-name='ChevronDown']");
        private ILocator AllTask => _page.Locator("//label[text()='All Tasks']");
        private ILocator Save => _page.Locator("//span[text()='Save']");
        private ILocator Refresh => _page.Locator("//span[text()='Refresh']");
        private ILocator MarkComplete => _page.Locator("//span[text()='Mark Complete']");
        private ILocator SaveAndClose => _page.Locator("//span[text()='Save & Close']");
        private ILocator FirstTask => _page.Locator("(//label[starts-with(@id,'timeline_record_title_text')])[1]");
        private ILocator SecondTask => _page.Locator("(//label[starts-with(@id,'timeline_record_title_text')])[2]");
        private ILocator TaskOwnerByDropdown => _page.Locator("//*[@data-testid='ownerid']//i");
        private ILocator TaskOwnerFilterByoption => _page.Locator("//*[text()='Filter by']");
        private ILocator TaskFilterByValueUsername => _page.Locator("//*[text()='Filter by value']/parent::div//input");
        private ILocator TaskApplyButton => _page.Locator("//span[text()='Apply']");
        private ILocator CancelTask => _page.Locator("//span[text()='Cancel']");
        private ILocator CloseTaskConfirmButton => _page.Locator("//button[@title='Close Task']");
        private ILocator ContinueAnyway => _page.Locator("//div[text='Continue anyway']");
        private ILocator CaseDueDate => _page.Locator("//div[text()='Case Due Date']//preceding-sibling::div/div");
        private ILocator DeleteBtn => _page.Locator("//span[text()='Delete']");
        private ILocator DeleteConfirmation => _page.Locator("//div[text()='Delete']");
        private ILocator Filter => _page.Locator("//input[@aria-label='Activity Filter by keyword']");
        private ILocator CancelRegardings => _page.Locator("//span[@data-id='regardingobjectid.fieldControl-LookupResultsDropdown_regardingobjectid_microsoftIcon_cancelButton']");
        public async Task ClickActivities()
        {                                    
            await _basePage.ClickElementAsync(Activities);
            _logger.LogInformation($"Clicked on Activities");
        }

        public async Task ClickRefreshAsync()
        {
            await _basePage.ClickElementAsync(Refresh);
            _logger.LogInformation($"Clicked on Refresh");
        }

        public async Task ClickCancelRegardingsAsync()
        {
            await _basePage.ClickElementAsync(CancelRegardings);
            _logger.LogInformation($"Clicked on Cancel Regardings");
        }

        public async Task SelectAllActivitiesFromTaskPage()
        {
            await _basePage.ClickElementAsync(MyActivities);
            _logger.LogInformation($"Clicked on MyActivities");
            await _basePage.ClickElementAsync(AllActivities);
            _logger.LogInformation($"Clicked on AllActivities");
        }

        public async Task ClickTask()
        {
            if (await ContinueAnyway.IsVisibleAsync())
            {
                await _basePage.ClickElementAsync(ContinueAnyway);
                _logger.LogInformation($"Clicked on continue anyway");
            }
            await _basePage.ClickElementAsync(Task);
            _logger.LogInformation($"Clicked on task");
            Thread.Sleep(2000);
        }

        public ILocator GetLabel(string label)
        {
            return _page.Locator("//label[text()='" + label + "']");
        }
        public async Task EnterRegardings(string caseName)
        {
            //await _page.Mouse.WheelAsync(0, 500);
            await _basePage.FillElementAsync(Regardings, caseName);
            await _page.Locator("//span[text()='" + caseName + "']").First.ClickAsync();
            _logger.LogInformation($"Entered case name : {caseName}");
            Thread.Sleep(2000);
            if (await AcceptAllSuggestions.IsVisibleAsync())
            {
                await _basePage.ClickElementAsync(AcceptAllSuggestions);
                _logger.LogInformation($"Clicked on AI Suggestion");
            }
        }

        public async Task EnterDemandTask(string demandTask)
        {
            await _page.WaitForLoadStateAsync();
            await DemandTask.HoverAsync();
            await _basePage.ClickElementAsync(DemandTask);
            if (await _page.Locator("//span[text()='Accept all suggestions']").IsVisibleAsync())
            {
                await _page.Locator("//span[text()='Accept all suggestions']").ClickAsync();
            }
            await _basePage.FillElementAsync(DemandTask, demandTask);
            Thread.Sleep(5000);
            _logger.LogInformation($"Entered demand task : {demandTask}");
        }

        public async Task EnterPrimaryDemand(string primaryDemand)
        {
            //await _page.Mouse.WheelAsync(0, 500);
            await _basePage.ClickElementAsync(PrimaryDemand);
            await _basePage.FillElementAsync(PrimaryDemand, primaryDemand);
            //await _page.Locator("//*[text()='" + primaryDemand + "']").FillAsync(primaryDemand);
            //await _page.Locator("//*[text()='" + primaryDemand + "']").First.ScrollIntoViewIfNeededAsync();
            await _page.Locator("//*[text()='"+ primaryDemand +"']").ClickAsync();
            Thread.Sleep(2000);
            _logger.LogInformation($"Entered primary demand : {primaryDemand}");
        }

        public async Task EnterPrimaryDemandNotOverwrite(string primaryDemand)
        {
            //await _page.Mouse.WheelAsync(0, 500);
            await _basePage.ClickElementAsync(PrimaryDemand);
            await _page.Locator("//*[text()='" + primaryDemand + "']").ClickAsync();
            Thread.Sleep(2000);
            _logger.LogInformation($"Entered primary demand : {primaryDemand}");
        }

        public async Task EnterTaskType(string taskType)
        {
            await _page.Mouse.WheelAsync(0, 500);
            //incase if task type already present
            if (await _page.Locator("//label[text()='Task Type']//following::button[1]").IsVisibleAsync())
            {
                await _page.Locator("//label[text()='Task Type']//following::button[1]").ClickAsync();
            }
            await _basePage.FillElementAsync(TaskType, taskType);
            await _page.Locator("(//span[text()='" + taskType + "'])[1]").First.ClickAsync();
            Thread.Sleep(2000);
            _logger.LogInformation($"Entered task type : {taskType}");
        }

        public ILocator GetMerlinTaskId()
        {
            return MerlinTaskID;
        }

        public ILocator GetValueStep()
        {
            return ValueStep;
        }

        public ILocator GetMerlinTaskIDReadonly()
        {
            return MerlinTaskIDReadonly;
        }

        public ILocator GetFirstTask()
        {
            _page.Mouse.WheelAsync(0, 500);
            FirstTask.WaitForAsync();
            FirstTask.ScrollIntoViewIfNeededAsync();
            return FirstTask;
        }
        public ILocator GetSecondTask()
        {
            _page.Mouse.WheelAsync(0, 500);
            SecondTask.WaitForAsync();
            SecondTask.ScrollIntoViewIfNeededAsync();
            return SecondTask;
        }

        public async Task EnterInstructions(string instructions)
        {
            await _page.Mouse.WheelAsync(0, 500);
            await _basePage.FillElementAsync(Instructions, instructions);
            _logger.LogInformation($"Entered instructions : {instructions}");

        }

        public async Task SaveTask()
        {
            await _basePage.ClickElementAsync(Save);
            _logger.LogInformation($"Clicked on save button");
        }


        public async Task<string> GetMerlinTaskType(string merlinTaskType)
        {
            await _page.Mouse.WheelAsync(0, 300);
            return await _page.Locator("//input[@value='" + merlinTaskType + "']").TextContentAsync();

        }

        public async Task<string> GetValueStep(string valueStep)
        {
            //await _page.Mouse.WheelAsync(0, 200);
            return await _page.Locator("//div[text()='" + valueStep + "']").TextContentAsync();

        }

        public async Task<ILocator> IsFieldVisible(string name, int index)
        {
            await _page.Locator("(//label[text()='" + name + "'])[" + index + "]").ScrollIntoViewIfNeededAsync();
            return _page.Locator("(//label[text()='" + name + "'])[" + index + "]");
        }

        public async Task FilterTasksByOwnerName(string ownerName)
        {
            await _basePage.ClickElementAsync(TaskOwnerByDropdown);
            _logger.LogInformation($"Clicked on task owner by dropdown");
            await _basePage.ClickElementAsync(TaskOwnerFilterByoption);
            _logger.LogInformation($"Clicked on task owner filter by option");
            await _basePage.FillElementAsync(TaskFilterByValueUsername, ownerName);
            await _page.Locator("//div[text()='" + ownerName + "']").First.ClickAsync();
            _logger.LogInformation($"Entered owner name : {ownerName}");
            await _basePage.ClickElementAsync(TaskApplyButton);
            _logger.LogInformation($"Clicked on apply button");
        }

        public async Task validateTasksDisplayedWithOwnerName(string taskName, string ownerName)
        {
            await _basePage.IsElementVisibleAsync(_page.Locator("//span[text()='" + taskName + "']//ancestor::div[@role='row']/div//i"));
        }

        public async Task SelectNewlyCreatedTask(string taskName)
        {
            await _page.Locator("//span[text()='" + taskName + "']//ancestor::div[@role='row']/div//i").ClickAsync();
            _logger.LogInformation($"Clicked on task name : {taskName}");
        }

        public async Task FilterCreatedTask(string taskName)
        {
            await _basePage.FillElementAsync(Filter, taskName);
            await _page.Keyboard.PressAsync("Enter");
            await _page.Keyboard.PressAsync("Enter");
            _logger.LogInformation("Entered email subject " + taskName);
            
        }

        public async Task ClickCancelTask()
        {
            await _basePage.ClickElementAsync(CancelTask);
            _logger.LogInformation($"Clicked cancel task");
        }
        public async Task ClickCloseTaskButton()
        {
            await _basePage.ClickElementAsync(CloseTaskConfirmButton);
            _logger.LogInformation($"Clicked confirm button");
        }
        public async Task<string> GetCaseDueDate()
        {
            return await CaseDueDate.TextContentAsync();
        }
        public async Task ClickSaveButtonAsync()
        {
            await _basePage.ClickElementAsync(SaveBtn);
        }
        public async Task SearchTask(string DemandTask)
        {
            await _basePage.FillElementAsync(SearchField, DemandTask);
            await _basePage.PressKeyAsync(SearchField, "Enter");
        }
        public async Task ClickTaskAsync(string DemandTask)
        {
            await _page.Locator("//span[text()='" + DemandTask + "']").ClickAsync();
        }
        public async Task SelectAndDeleteTaskAsync(string DemandTask)
        {
            await _page.Locator("//span[text()='" + DemandTask + "']//preceding::i[1]").ClickAsync();
            await _basePage.ClickElementAsync(DeleteBtn);
            await _basePage.ClickElementAsync(DeleteConfirmation);
            Thread.Sleep(8000);
            if (await _page.Locator("//span[text()='" + DemandTask + "']").IsVisibleAsync())
            {
                throw new Exception("Element is still visible");
            }
        }

        public async Task<bool> GetLabelAsync(string subject)
        {
            return await _page.Locator("//*[text()='" + subject + "']").IsVisibleAsync();
        }
    }

}
