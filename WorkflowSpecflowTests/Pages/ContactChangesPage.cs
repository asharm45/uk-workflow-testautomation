using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface IContactChangesPage
    {
        Task VerifyDetailsTabNotPresent();
        Task ClickSummaryAsync();
        ILocator CheckSummaryAsync();
    }

    public class ContactChangesPage : IContactChangesPage
    {
        private readonly IPage _page;
        private readonly IBasePage _basePage;
        private readonly ILogger<ContactChangesPage> _logger;
        public ContactChangesPage(IPlaywrightDriver driver, IBasePage basePage, ILogger<ContactChangesPage> logger)
        {
            _page = driver.Page.Result;
            _basePage = basePage;
            _logger = logger;
        }

        private ILocator Summary => _page.Locator("//*[@title='Summary']");
        private ILocator Details => _page.Locator("//*[@title='Details']");

        public async Task VerifyDetailsTabNotPresent()
        {
            await _basePage.ClickElementAsync(Summary);
            _logger.LogInformation($"Clicked on summay button");
            var count = await Details.CountAsync();
            if (count > 0)
            {
                throw new Exception("Details Tab Present");
            }
        }

        public ILocator CheckSummaryAsync()
        {
            return Summary;
        }

        public async Task ClickSummaryAsync()
        {
            await Summary.ClickAsync();
            _logger.LogInformation($"Clicked on summay button");
        }
    }
}
