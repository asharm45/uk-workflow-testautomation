using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface IBasePage
    {
        Task ClickElementAsync(ILocator locator);
        Task FillElementAsync(ILocator locator, string value);
        Task IsElementVisibleAsync(ILocator locator);
        Task ClickRefreshButton();
        Task ClickSaveButton();
        Task ClickContactButton();
        Task ClickNewButton();
        Task ClickTaskButton();
        Task ClickAppLink();
        Task ClickCustomerServiceAdminCenter();
        Task ClickCustomerServiceHub();
        Task ClickCasesButton();
        Task<string> GetFutureDateExcludingWeekendsAsync(int daysToAdd);
        Task<string> GetCalenderDateAsync(String Date);
        Task PressKeyAsync(ILocator locator, string key);
        Task<string> GetRootDir();
    }

    public class BasePage : IBasePage
    {
        private readonly IPage _page;
        private readonly ILogger<BasePage> _logger;

        public BasePage(IPlaywrightDriver driver, ILogger<BasePage> logger)
        {
            _page = driver.Page.Result;
            _logger = logger;
        }

        private ILocator AppLink => _page.Locator("//span[@data-id='appBreadCrumbText']");
        private ILocator CustomerServiceAdminCenter => _page.Locator("//div[@title='Customer Service admin center']");
        private ILocator CustomerServiceHub => _page.Locator("//div[@title='//div[@title='Customer Service Hub']']");
        private ILocator SaveBtn => _page.Locator("//span[text()='Save']");
        private ILocator Contact => _page.Locator("//span[text()='Contacts']");
        private ILocator NewBtn => _page.Locator("//span[text()='New']");
        private ILocator TaskBtn => _page.Locator("//span[text()='Task']");
        private ILocator RefreshBtn => _page.Locator("//span[text()='Refresh']");
        private ILocator Cases => _page.Locator("//span[text()='Cases']");

        public async Task ClickCasesButton()
        {
            await Cases.ClickAsync();
            _logger.LogInformation("Clicked cases");
        }
        public async Task ClickSaveButton()
        {
            await SaveBtn.ClickAsync();
            _logger.LogInformation("Clicked save button");
        }
        public async Task ClickContactButton()
        {
            await Contact.ClickAsync();
            _logger.LogInformation("Clicked contact button");
        }
        public async Task ClickNewButton()
        {
            await NewBtn.ClickAsync();
            _logger.LogInformation("Clicked next button");
        }
        public async Task ClickTaskButton()
        {
            await TaskBtn.ClickAsync();
            _logger.LogInformation("Clicked task button");
        }
        public async Task ClickRefreshButton()
        {
            await RefreshBtn.ClickAsync();
            _logger.LogInformation("Clicked refresh button");
        }
        public async Task ClickAppLink()
        {
            await AppLink.ClickAsync();
            _logger.LogInformation("Clicked app link");
        }
        public async Task ClickCustomerServiceAdminCenter()
        {
            await CustomerServiceAdminCenter.ClickAsync();
            _logger.LogInformation("Clicked customer service admin center");
        }
        public async Task ClickCustomerServiceHub()
        {
            await CustomerServiceHub.ClickAsync();
            _logger.LogInformation("Clicked customer service hub");
        }
        public async Task ClickElementAsync(ILocator locator)
        {
            try
            {
                _logger.LogInformation($"Clicking element with locator : '{locator}'");
                await _page.WaitForLoadStateAsync();
                await locator.WaitForAsync();
                await locator.ScrollIntoViewIfNeededAsync();
                await locator.ClickAsync();
                _logger.LogInformation($"Clicked element with locator : '{locator}'");
            }
            catch (Exception e)
            {
                _logger.LogError($"Error clicking element with locator '{locator}'" + e.Message);
                Assert.Fail($"Error clicking element with locator '{locator}'" + e.Message);
            }
        }

        public async Task FillElementAsync(ILocator locator, string value)
        {
            try
            {
                _logger.LogInformation($"Entering value '{value}' element with locator : '{locator}'");
                //await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
                await _page.WaitForLoadStateAsync();
                await locator.WaitForAsync();
                await locator.ScrollIntoViewIfNeededAsync();
                await locator.FillAsync(value);
                _logger.LogInformation($"Entered value '{value}' element with locator : '{locator}'");
            }
            catch (Exception e)
            {
                _logger.LogError($"Error entering value with locator '{locator}'" + e.Message);
                Assert.Fail($"Error entering value with locator '{locator}'" + e.Message);
            }
        }
        public async Task IsElementVisibleAsync(ILocator locator)
        {
            try
            {
                _logger.LogInformation($"Checking Visibility of element with locator: '{locator}'");
                await _page.WaitForLoadStateAsync();
                await locator.WaitForAsync();
                await locator.ScrollIntoViewIfNeededAsync();
                await locator.IsVisibleAsync();
                _logger.LogInformation("Element is visible on the page");

            }
            catch (Exception e)
            {
                _logger.LogError($"Error checking element visibility : {locator}" + e.Message);

            }
        }
        public async Task PressKeyAsync(ILocator locator, string key)
        {
            await _page.WaitForLoadStateAsync();
            if (locator != null)
            {
                await locator.PressAsync(key);
            }
            else
            {
                throw new Exception("Locator is null");
            }

        }

        public async Task<string> GetFutureDateExcludingWeekendsAsync(int daysToAdd)
        {
            DateTime currentDate = DateTime.Now;
            int addedDays = 0;

            while (addedDays < (daysToAdd - 1))
            {
                currentDate = currentDate.AddDays(1);
                if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    addedDays++;
                }
            }

            return currentDate.ToString("dd/MM/yyyy");
        }


        public async Task<string> GetCalenderDateAsync(String Date)
        {
            DateTime currentDate = DateTime.Now;
            int addedDays = 0;

            if (Date.Equals("Today"))
            {
                currentDate = DateTime.Now;

            }
            else if (Date.Equals("Tomorrow"))
            {
                currentDate = currentDate.AddDays(1);

            }
            else if (Date.Contains("+"))
            {
                string[] addDates = Date.Split("+");
                currentDate = currentDate.AddDays(int.Parse(addDates[1]));
            }
            Console.WriteLine("Generated Date : " + currentDate.ToString("dd, MMMM, yyyy"));
            return currentDate.ToString("dd, MMMM, yyyy");
        }

        public async Task<string> GetRootDir()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            int binIndex = currentDirectory.IndexOf("bin");
            if (binIndex != -1)
            {
                return currentDirectory.Substring(0, binIndex - 1);

            }
            return null;
        }
    }
}
