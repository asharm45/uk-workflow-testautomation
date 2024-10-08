using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface IDashboardsPage
    {
        Task ClickClosePickWorkAsync();
        Task ClickDashboardsAsync();
        Task ClickPickWorkAsync();
        Task ClickDashboardsDropdownAsync();
        Task<int> GetDashboardAsync(string subject);
    }

    public class DashboardsPage : IDashboardsPage
    {
        private readonly IBasePage _basePage;
        private readonly IPage _page;
        private readonly ILogger<DashboardsPage> _logger;

        public DashboardsPage(IPlaywrightDriver driver, IBasePage basePage, ILogger<DashboardsPage> logger)
        {
            _page = driver.Page.Result;
            _basePage = basePage;
            _logger = logger;
        }
        private ILocator Dashboards => _page.Locator("//span[text()='Dashboards']");
        private ILocator PickWork => _page.Locator("//span[text()='Pick Work']");
        private ILocator ClosePickWork => _page.Locator(".symbolFont.Cancel-symbol");
        private ILocator DashboardsDropdown => _page.Locator("//span[starts-with(@id,'Dashboard_Selector')]//following-sibling::span/span");

        public async Task ClickDashboardsAsync()
        {
            await _basePage.ClickElementAsync(Dashboards);
            _logger.LogInformation($"Clicked on dashboards");
        }
        public async Task ClickPickWorkAsync()
        {
            await _basePage.ClickElementAsync(PickWork);
            _logger.LogInformation($"Clicked on pick work");
        }
        public async Task ClickClosePickWorkAsync()
        {
            await _basePage.ClickElementAsync(ClosePickWork);
            _logger.LogInformation($"Closed pick work popup");
        }
        public async Task ClickDashboardsDropdownAsync()
        {
            await _basePage.ClickElementAsync(DashboardsDropdown);
            _logger.LogInformation($"Clicked on Dashboards Dropdown");
        }
        public async Task<int> GetDashboardAsync(string subject)
        {
            return await _page.Locator("//*[text()='" + subject + "']").CountAsync();
        }
    }
}
