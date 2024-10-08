using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface IAttributesMappingPage
    {
        ILocator GetSelectedOrigin(string origin);
        Task SelectOriginAsEmail();
        Task SelectOriginAsPhone();
    }

    public class AttributesMappingPage : IAttributesMappingPage
    {
        private readonly IBasePage _basePage;
        private readonly IPage _page;
        private readonly ILogger<AttributesMappingPage> _logger;

        public AttributesMappingPage(IPlaywrightDriver driver, IBasePage basePage, ILogger<AttributesMappingPage> logger)
        {
            _page = driver.Page.Result;
            _basePage = basePage;
            _logger = logger;
        }

        private ILocator OriginDropdown => _page.Locator("(//div[starts-with(@title,'Origin')]//following-sibling::div//button)[1]");
        private ILocator SelectEmail => _page.Locator("(//*[text()='Email'])[2]");
        private ILocator SelectPhone => _page.Locator("//*[text()='Phone']");


        public async Task SelectOriginAsPhone()
        {
            await _page.Mouse.WheelAsync(0, 500);
            await _basePage.ClickElementAsync(OriginDropdown);
            _logger.LogInformation("Clicked Origin dropdown");
            await _basePage.ClickElementAsync(SelectPhone);
            _logger.LogInformation("Phone selected");
        }

        public async Task SelectOriginAsEmail()
        {
            await _page.Mouse.WheelAsync(0, 500);
            await _basePage.ClickElementAsync(OriginDropdown);
            _logger.LogInformation("Clicked Origin dropdown");
            await _basePage.ClickElementAsync(SelectEmail);
            _logger.LogInformation("Email selected");
        }

        public ILocator GetSelectedOrigin(string origin)
        {
            _page.Mouse.WheelAsync(0, 500);
            return _page.Locator("//button[@title='" + origin + "']");
        }

    }
}
