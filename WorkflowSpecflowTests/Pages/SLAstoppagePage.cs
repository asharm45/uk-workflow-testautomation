using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface ISLAstoppagePage
    {
        Task<ILocator> IsFieldVisible(string name);
        Task IsElementPresentOnNewSLA();
        Task FillCaseNameInNewSLAPage(string caseName);
        Task SelectPendedDateFromCalendarInNewSLAPage(string StartDate);
        Task SelectUnPendedDateFromCalendarInNewSLAPage(string EndDate);
        Task ClickSaveButtonInNewSLAPage();
        Task SelectNewlyCreatedSLAStoppage(string newCase);
        Task ClickDeActivateButtonInSLAPage();
        Task ClickDeActivateButtonInConfirmPopup();
        Task ClickSLATimesInLeftMenu();
        Task SelectSLAOnPrimaryDemands(string primaryDemand);
        Task FillSLAdaysInSLAPage(string numberOfDays);




    }
    public class SLAstoppagePage : ISLAstoppagePage
    {
        private readonly IPage _page;
        private readonly IBrowserContext _browserContext;
        private readonly IBasePage _basePage;
        private readonly ILogger<SLAstoppagePage> _logger;
        public SLAstoppagePage(IPlaywrightDriver driver, IBasePage basePage, ILogger<SLAstoppagePage> logger)
        {
            _page = driver.Page.Result;
            _browserContext = driver.BrowserContext.Result;
            _basePage = basePage;
            _logger = logger;
        }

        private ILocator NewSLAstoppageTitle => _page.Locator("//*[@title='New SLA Stoppage']"); 
        private ILocator GeneralTab => _page.Locator("//*[@title='General']");
        private ILocator Case => _page.Locator("//*[@aria-label='Case, Lookup']");
        private ILocator pendedTimeCalenderIcon => _page.Locator("//input[@aria-label='Date of Pended Time']/parent::span//span");
        private ILocator unPendedTimeCalenderIcon => _page.Locator("//input[@aria-label='Date of Unpended Time']/parent::span//span");
        private ILocator SaveButton => _page.Locator("//span[text()='Save']");
        private ILocator DeActivateButton => _page.Locator("//span[text()='Deactivate']");
        private ILocator DeActivateButtonInConfirmPopup => _page.Locator("//button[text()='Deactivate']");
        private ILocator SLATimes => _page.Locator("//*[text()='SLA Times']");
        private ILocator SLADays => _page.Locator("//input[@aria-label='SLA Days']");


        public async Task<ILocator> IsFieldVisible(string fieldname)
        {
            await _page.Locator("//label[text()='" + fieldname + "']").ScrollIntoViewIfNeededAsync();
            return _page.Locator("//label[text()='" + fieldname + "']");
        }
        public async Task IsElementPresentOnNewSLA()
        {
            await _basePage.IsElementVisibleAsync(NewSLAstoppageTitle);
            await _basePage.IsElementVisibleAsync(GeneralTab);
        }
        public async Task FillCaseNameInNewSLAPage(string caseName)
        {
            await _basePage.FillElementAsync(Case, caseName);
            await _page.Locator("//span[text()='" + caseName + "']").First.ClickAsync();
            _logger.LogInformation($"Entered case name : {caseName}");
        }
        public async Task SelectPendedDateFromCalendarInNewSLAPage(string StartDate)
        {
            await _basePage.ClickElementAsync(pendedTimeCalenderIcon);
            string generatedDate = await _basePage.GetCalenderDateAsync(StartDate);
            await _basePage.ClickElementAsync(_page.Locator("//div[@aria-label='Calendar']//button[@aria-label='" + generatedDate + "']"));
            _logger.LogInformation($"Selected pended date from calender : {StartDate}");
        }
        public async Task SelectUnPendedDateFromCalendarInNewSLAPage(string EndDate)
        {
            await _basePage.ClickElementAsync(unPendedTimeCalenderIcon);
            string generatedDate = await _basePage.GetCalenderDateAsync(EndDate);
            await _basePage.ClickElementAsync(_page.Locator("//div[@aria-label='Calendar']//button[@aria-label='" + generatedDate + "']"));
            _logger.LogInformation($"Selected unpended date from calender : {EndDate}");
        }
        public async Task ClickSaveButtonInNewSLAPage()
        {
            await _basePage.ClickElementAsync(SaveButton);
            _logger.LogInformation($"Clicked on save button");
        }
        public async Task SelectNewlyCreatedSLAStoppage(string newCase)
        {
            await _basePage.ClickElementAsync(_page.Locator("//span[text()='" + newCase + "']//ancestor::div[@role='row']//label/div/i"));
            _logger.LogInformation($"Clicked on new case");
        }
        public async Task ClickDeActivateButtonInSLAPage()
        {
            await _basePage.ClickElementAsync(DeActivateButton);
            _logger.LogInformation($"Clicked on deactivate button");
        }
        public async Task ClickDeActivateButtonInConfirmPopup()
        {
            await _basePage.ClickElementAsync(DeActivateButtonInConfirmPopup);
            _logger.LogInformation($"Clicked on deactivate to confim the popup");
        }
        public async Task ClickSLATimesInLeftMenu()
        {
            await _basePage.ClickElementAsync(SLATimes);
        }
        public async Task SelectSLAOnPrimaryDemands(string primaryDemand)
        {
            await _basePage.ClickElementAsync(_page.Locator("//*[text()='"+ primaryDemand + "']/ancestor::div[@role='row']//div[2]//a//span"));
        }
        public async Task FillSLAdaysInSLAPage(string numberOfDays)
        {
            await _basePage.FillElementAsync(SLADays, numberOfDays);
        }

    }
}

