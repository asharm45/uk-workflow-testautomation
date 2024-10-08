using Microsoft.Playwright;
using WorkflowSpecflowTests.Config;

namespace WorkflowSpecflowTests.Driver
{
    public class PlaywrightDriverInitializer : IPlaywrightDriverInitializer
    {
        public const float DEFAULT_TIMEOUT = 30f;
        public async Task<IBrowser> GetChromeDriverAsync(TestSettings settings)
        {
            var options = GetBrowserLaunchOptions(settings.Args, settings.Timeout, settings.Headless, settings.SlowMo);
            options.Channel = "chrome";
            return await GetBrowserAsync(DriverType.Chromium, options);
        }

        public async Task<IBrowser> GetFirefoxDriverAsync(TestSettings settings)
        {
            var options = GetBrowserLaunchOptions(settings.Args, settings.Timeout, settings.Headless, settings.SlowMo);
            options.Channel = "firefox";
            return await GetBrowserAsync(DriverType.Firefox, options);
        }

        public async Task<IBrowser> GetWebkitDriverAsync(TestSettings settings)
        {
            var options = GetBrowserLaunchOptions(settings.Args, settings.Timeout, settings.Headless, settings.SlowMo);
            options.Channel = "";
            return await GetBrowserAsync(DriverType.Webkit, options);
        }

        public async Task<IBrowser> GetChromiumDriverAsync(TestSettings settings)
        {
            var options = GetBrowserLaunchOptions(settings.Args, settings.Timeout, settings.Headless, settings.SlowMo);
            options.Channel = "chromium";
            return await GetBrowserAsync(DriverType.Chromium, options);
        }

        public async Task<IBrowser> GetEdgeDriverAsync(TestSettings settings)
        {
            var options = GetBrowserLaunchOptions(settings.Args, settings.Timeout, settings.Headless, settings.SlowMo);
            options.Channel = "msedge";
            return await GetBrowserAsync(DriverType.Chromium, options);
        }




        private async Task<IBrowser> GetBrowserAsync(DriverType driverType, BrowserTypeLaunchOptions options)
        {
            var playwright = await Playwright.CreateAsync();
            return await playwright[driverType.ToString().ToLower()].LaunchAsync(options);
        }

        private BrowserTypeLaunchOptions GetBrowserLaunchOptions(string[]? args, float? timeout = DEFAULT_TIMEOUT, bool? headless = true, float? slowmo = null)
        {
            return new BrowserTypeLaunchOptions
            {
                Args = args,
                Timeout = ToMilliseconds(timeout),
                Headless = headless,
                SlowMo = slowmo
               
            };
        }

        private static float? ToMilliseconds(float? seconds)
        {
            return seconds * 1000;
        }

    }
}
