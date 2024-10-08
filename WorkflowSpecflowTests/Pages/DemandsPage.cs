using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface IDemandsPage
    {
        Task ClickDeleteAsync();
        Task ClickDemandsAsync();
        Task ClickNewAsync();
        Task ClickRefreshAsync();
        Task ClickSaveAndCloseAsync();
        Task ClickSaveAsync();
        Task<string> GetLabelAsync(string label);
        Task<bool> GetDemandLabelAsync(string label);
    }

    public class DemandsPage : IDemandsPage
    {
        private readonly IPage _page;
        private readonly IBasePage _basePage;

        public DemandsPage(IPlaywrightDriver driver, IBasePage basePage)
        {
            _page = driver.Page.Result;
            _basePage = basePage;
        }
        private ILocator Demands => _page.Locator("//span[text()='Demands']");
        private ILocator New => _page.Locator("//span[text()='New']");
        private ILocator Delete => _page.Locator("//span[text()='Delete']");
        private ILocator Refresh => _page.Locator("//span[text()='Refresh']");
        private ILocator Save => _page.Locator("//span[text()='Save']");
        private ILocator SaveAndClose => _page.Locator("//span[text()='Save & Close']");

        public async Task ClickDemandsAsync()
        {
            await _basePage.ClickElementAsync(Demands);
        }
        public async Task ClickNewAsync()
        {
            await _basePage.ClickElementAsync(New);
        }
        public async Task ClickSaveAndCloseAsync()
        {
            await _basePage.ClickElementAsync(SaveAndClose);
        }
        public async Task ClickDeleteAsync()
        {
            await _basePage.ClickElementAsync(Delete);
        }
        public async Task ClickRefreshAsync()
        {
            await _basePage.ClickElementAsync(Refresh);
        }
        public async Task ClickSaveAsync()
        {
            await _basePage.ClickElementAsync(Save);
        }
        public async Task<string> GetLabelAsync(string label)
        {
            return await _page.Locator("//label[text()='" + label + "']").TextContentAsync();
        }
        public async Task<bool> GetDemandLabelAsync(string label)
        {
            return await _page.Locator("//*[text()='" + label + "']").IsVisibleAsync();
        }
    }
}
