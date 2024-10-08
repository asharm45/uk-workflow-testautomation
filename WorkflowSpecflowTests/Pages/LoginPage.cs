using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface ILoginPage
    {
        Task enterMerlinCredentials(string _username, string _password);
        Task clickLogin();
    }

    public class LoginPage : ILoginPage
    {
        private readonly IPage _page;
        private readonly IBasePage _basePage;
        private readonly ILogger<LoginPage> _logger;
        public LoginPage(IPlaywrightDriver driver, IBasePage basePage, ILogger<LoginPage> logger)
        {
            _page = driver.Page.Result;
            _basePage = basePage;
            _logger = logger;
        }

        private ILocator Username => _page.Locator("//*[@id=\"UserName\"]");
        private ILocator Password => _page.Locator("//*[@id=\"Password\"]");
        private ILocator LoginButton => _page.Locator("//*[@id=\"Login\"]");

        public async Task enterMerlinCredentials(string _username, string _password)
        {
            await _basePage.FillElementAsync(Username, _username);
            _logger.LogInformation($"Entered username : {_username}");
            await _basePage.FillElementAsync(Password, _password);
            _logger.LogInformation($"Entered password");

            //await _basePage.FillElementAsync(Username, _username);
            //await _basePage.FillElementAsync(Password, _password);

            await _basePage.FillElementAsync(Username, "DvappTest511");
            await _basePage.FillElementAsync(Password, "1111");
        }

        public async Task clickLogin()
        {
            await _basePage.ClickElementAsync(LoginButton);
            _logger.LogInformation($"Clicked on login button");
        }
    }
}
