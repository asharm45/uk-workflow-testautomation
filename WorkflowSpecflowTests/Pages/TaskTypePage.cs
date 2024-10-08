using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface ITaskTypePage
    {
        Task ClickDelete();
        Task ClickNew();
        Task ClickRefresh();
        Task ClickTaskType();
        Task ClickSave();
        Task ClickSaveAndClose();
        Task ClickBack();
        Task<ILocator> IsFieldVisible(string name);
        Task EnterPrimaryDeamnd(string primaryDemand);
        Task EnterTaskType(string taskType);
        Task EnterMerlinTaskType(string merlinTaskType);
        Task SelectAvailableForManualSelection(string selectType);
        Task EnterValueStep(string valueStep);
        Task SelectNewlyCreatedTask(string taskType);
        Task ClickDeleteBtn();
        Task SearchTaskType(string taskType);
        Task SelectNewlyCreatedTaskType();
        Task<string> GetSaveLabel();
    }

    public class TaskTypePage : ITaskTypePage
    {
        private readonly IPage _page;
        private readonly IBasePage _basePage;
        private readonly ILogger<TaskTypePage> _logger;
        public TaskTypePage(IPlaywrightDriver driver, IBasePage basePage, ILogger<TaskTypePage> logger)
        {
            _page = driver.Page.Result;
            _basePage = basePage;
            _logger = logger;
        }
        private ILocator TaskType => _page.Locator("//span[text()='Task Types']");
        private ILocator New => _page.Locator("//span[text()='New']");
        private ILocator Delete => _page.Locator("//span[text()='Delete']");
        private ILocator Refresh => _page.Locator("//span[text()='Refresh']");
        private ILocator Save => _page.Locator("//span[text()='Save']");
        private ILocator SaveAndClose => _page.Locator("//span[text()='Save & Close']");
        private ILocator ConfirmDelete => _page.Locator("//button[@title='Delete']/div");
        private ILocator BackBtn => _page.Locator("//button[@title='Go back']/span");
        private ILocator PrimaryDemandField => _page.Locator("//input[@aria-label='Look for subject']");
        private ILocator TaskTypeField => _page.Locator("//input[@aria-label='Task Type']");
        private ILocator MerlinTaskTypeField => _page.Locator("//input[@aria-label='Merlin Task Type']");
        private ILocator AvailableForManualSelectionField => _page.Locator("//button[@aria-label='Available for Manual Selection']");
        private ILocator AvailableForManualSelectionYes => _page.Locator("(//*[text()='Yes'])[1]");
        private ILocator AvailableForManualSelectionNo => _page.Locator("(//*[text()='No'])[1]");
        private ILocator ValueStepField => _page.Locator("//input[starts-with(@aria-label,'Value Step')]");
        private ILocator Search => _page.Locator("//input[@aria-label='Task Type Filter by keyword']");
        private ILocator SelectTaskTypes => _page.Locator("(//i[starts-with(@class,'ms-Checkbox-checkmark')])[1]");
        private ILocator SaveLabel => _page.Locator("//h1[@data-id='header_title']");

        public async Task ClickTaskType()
        {
            await _basePage.ClickElementAsync(TaskType);
            _logger.LogInformation($"Clicked TaskType button");
        }
        public async Task ClickNew()
        {
            await _basePage.ClickElementAsync(New);
            _logger.LogInformation($"Clicked New button");
        }
        public async Task ClickDelete()
        {
            await _page.WaitForSelectorAsync("//span[text()='Delete']");
            await _basePage.ClickElementAsync(Delete);
            _logger.LogInformation($"Clicked Delete button");
        }
        public async Task ClickRefresh()
        {
            await _basePage.ClickElementAsync(Refresh);
            _logger.LogInformation($"Clicked refresh button");
        }
        public async Task ClickSave()
        {
            await _basePage.ClickElementAsync(Save);
            _logger.LogInformation($"Clicked save button");
        }
        public async Task ClickBack()
        {
            await _basePage.ClickElementAsync(BackBtn);
            _logger.LogInformation($"Clicked back button");
        }
        public async Task ClickSaveAndClose()
        {
            await _basePage.ClickElementAsync(SaveAndClose);
            _logger.LogInformation($"Clicked save&close button");
        }
        public async Task ClickDeleteBtn()
        {
            await _basePage.ClickElementAsync(ConfirmDelete);
            _logger.LogInformation($"Clicked confirm delete button");
        }

        public async Task SelectNewlyCreatedTaskType()
        {
            await _basePage.ClickElementAsync(SelectTaskTypes);
            _logger.LogInformation($"Clicked select task tyep button");
        }

        public async Task EnterPrimaryDeamnd(string primaryDemand)
        {
            await _basePage.ClickElementAsync(PrimaryDemandField);
            await _page.Locator("//div[@title='" + primaryDemand + "']/div/div").First.ScrollIntoViewIfNeededAsync();
            await _page.Locator("//div[@title='" + primaryDemand + "']/div/div").First.ClickAsync();
            _logger.LogInformation($"Selected primary demand : {primaryDemand}");
        }
        public async Task EnterTaskType(string taskType)
        {
            await _basePage.FillElementAsync(TaskTypeField, taskType);
            _logger.LogInformation($"Entered task type : {taskType}");
        }
        public async Task EnterMerlinTaskType(string merlinTaskType)
        {
            await _basePage.FillElementAsync(MerlinTaskTypeField, merlinTaskType);
            _logger.LogInformation($"Entered merlin task type : {merlinTaskType}");
        }
        public async Task SelectAvailableForManualSelection(string selectType)
        {
            if (selectType.Equals("Yes"))
            {
                await _basePage.ClickElementAsync(AvailableForManualSelectionField);
                _logger.LogInformation($"Clicked available for manual selection");
                await _basePage.ClickElementAsync(AvailableForManualSelectionYes);
                _logger.LogInformation($"Selected available for manual selection Yes");
            }
            else
            {

                await _basePage.ClickElementAsync(AvailableForManualSelectionField);
                _logger.LogInformation($"Clicked available for manual selection");
                await _basePage.ClickElementAsync(AvailableForManualSelectionNo);
                _logger.LogInformation($"Selected available for manual selection No");
            }
        }
        public async Task EnterValueStep(string valueStep)
        {

            await _basePage.FillElementAsync(ValueStepField, valueStep);
            await _page.Locator("//span[text()='" + valueStep + "']").First.ClickAsync();
            _logger.LogInformation($"Entered value step : {valueStep}");
        }

        public async Task<ILocator> IsFieldVisible(string name)
        {
            await _page.Locator("//span[text()='" + name + "']").ScrollIntoViewIfNeededAsync();
            return _page.Locator("//span[text()='" + name + "']");
        }

        public async Task SelectNewlyCreatedTask(string taskType)
        {
            await _page.Locator("//span[text()='" + taskType + "']//ancestor::div[@col-id='ntt_name']//preceding-sibling::div[@col-id='__row_status']//i").ClickAsync();
            _logger.LogInformation($"Selected newly created task type : {taskType}");
        }

        public async Task SearchTaskType(string taskType)
        {
            await _basePage.FillElementAsync(Search, taskType);
            await _page.Keyboard.PressAsync("Enter");
            _logger.LogInformation($"Entered task type : {taskType}");
        }
        public async Task<string> GetSaveLabel()
        {
            return await SaveLabel.TextContentAsync();
        }
    }
}
