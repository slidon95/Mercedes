using System;
using Microsoft.Playwright;
using NUnit.Framework;
using SpecFlowPlaywright.Configuration;
using SpecFlowPlaywright.Drivers;
using SpecFlowPlaywright.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowPlaywright.Hooks
{
    [Binding]
    public class Hooks
    {
        private Driver _driver;
        private IPage _page;
        private readonly ScenarioContext _scenarioContext;
        private General _general;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            string browserType;
            // Check if the scenario has the Chrome tag
            if (_scenarioContext.ScenarioInfo.Tags.Contains("chrome"))
            {
                browserType = "Chrome";
            }
            // If not Firefox
            else 
            {
                browserType = "Firefox";
            }
            // Initialize the Driver with the specified browser using the static factory method
            _driver = await Driver.CreateAsync(browserType); // Use the factory method
            _page = await _driver.GetPageAsync(); // Await the async method

            // Store the driver and page in ScenarioContext for access in step definitions
            _scenarioContext[Config.ScenarioContextDriver] = _driver;
            _scenarioContext[Config.ScenarioContextPage] = _page;
            _general = new General(_page);
            await _general.GoToPageAsync(Config.Url); // Await the async method
            await Task.Delay(2000); // Wait for 2 seconds
            await _general.ClickAcceptCookiesAsync(); // Await the async method
        }


        [AfterScenario]
        public async Task AfterScenario()
        {
            await _driver.DisposeAsync(); // Await the DisposeAsync method
        }


    }
}