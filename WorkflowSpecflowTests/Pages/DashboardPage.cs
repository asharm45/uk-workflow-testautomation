using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface IDashboardPage
    {
        Task createNewContact();
    }

    public class DashboardPage : IDashboardPage
    {
        private readonly IPage _page;
        private readonly IBasePage _basePage;
        private readonly ILogger<DashboardPage> _logger;
        public DashboardPage(IPlaywrightDriver driver, IBasePage basePage, ILogger<DashboardPage> logger)
        {
            _page = driver.Page.Result;
            _basePage = basePage;
            _logger = logger;
        }

        private ILocator NewBtn => _page.Locator("//*[@id=\"NewMainMenu\"]");
        private ILocator NewContactLink => _page.Locator("//*[@id=\"NewContactNewGenFromMenu_Link\"]");

        public async Task createNewContact()
        {
            await _basePage.ClickElementAsync(NewBtn);
            _logger.LogInformation($"Clicked on new button");
            await _basePage.ClickElementAsync(NewContactLink);
            _logger.LogInformation($"Clicked on new contact link");
        }
    }
}
