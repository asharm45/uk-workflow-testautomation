using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface ILogoutPage
    {
        Task applicationLogout();
        Task DynamicsLogout();
    }

    public class LogoutPage : ILogoutPage
    {
        private readonly IPage _page;
        private readonly IBasePage _basePage;
        private readonly ILogger<LogoutPage> _logger;
        public LogoutPage(IPlaywrightDriver playwrightDriver, IBasePage basePage, ILogger<LogoutPage> logger)
        {
            _page = playwrightDriver.Page.Result;
            _basePage = basePage;
            _logger = logger;
        }

        private ILocator UserDropDown => _page.Locator("//*[@id=\"personSubMenuUser\"]");
        private ILocator LogOff => _page.Locator("//*[@id=\"LogOff\"]");
        private ILocator LogoutOkBtn => _page.Locator("//*[@id=\"DialogOK\"]");

        private ILocator DynamicsProfileIcon => _page.Locator("#mectrl_headerPicture");
        private ILocator DynamicsSignout => _page.Locator("#mectrl_body_signOut");


        public async Task applicationLogout()
        {
            await _basePage.ClickElementAsync(UserDropDown);
            _logger.LogInformation($"Clicked on user dropdown");
            await _basePage.ClickElementAsync(LogOff);
            _logger.LogInformation($"Clicked on logoff button");
            await _basePage.ClickElementAsync(LogoutOkBtn);
            _logger.LogInformation($"Clicked on logout ok button");
        }

        public async Task DynamicsLogout()
        {
            await _basePage.ClickElementAsync(DynamicsProfileIcon);
            _logger.LogInformation($"Clicked on dynamics profile icon");
            await _basePage.ClickElementAsync(DynamicsSignout);
            _logger.LogInformation($"Clicked on dynamics sign-out");
        }
    }
}
