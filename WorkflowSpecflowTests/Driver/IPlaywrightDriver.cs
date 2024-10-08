using Microsoft.Playwright;

namespace WorkflowSpecflowTests.Driver
{
    public interface IPlaywrightDriver
    {
        Task<IBrowser> Browser { get; }
        Task<IBrowserContext> BrowserContext { get; }
        Task<IPage> Page { get; }
        Task<string> TakeScreenshotAsBase64Async();
    }
}