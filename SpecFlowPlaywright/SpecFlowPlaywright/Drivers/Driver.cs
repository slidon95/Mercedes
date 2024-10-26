using Microsoft.Playwright;

namespace SpecFlowPlaywright.Drivers
{
    public class Driver : IAsyncDisposable
    {
        private IBrowser? _browser;
        private IPage? _page;

        // Constructor remains parameterless
        public Driver() { }

        // Factory method to initialize the browser
        public static async Task<Driver> CreateAsync(string browserType)
        {
            var driver = new Driver();
            await driver.InitializeAsync(browserType);
            return driver;
        }

        private async Task InitializeAsync(string browserType)
        {
            // Playwright
            var playwright = await Playwright.CreateAsync();

            // Launch the specified browser
            _browser = browserType switch
            {
                "Chrome" => await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }),
                "Firefox" => await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }),
                _ => throw new ArgumentException($"Unsupported browser type: {browserType}")
            };

            // Create a new page
            _page = await _browser.NewPageAsync();
        }

        public async Task<IPage> GetPageAsync()
        {
            if (_page == null)
            {
                throw new InvalidOperationException("Browser not initialized.");
            }
            return _page; // Return the page instance
        }

        public async ValueTask DisposeAsync()
        {
            if (_browser != null)
            {
                await _browser.CloseAsync(); 
            }
        }
    }
}