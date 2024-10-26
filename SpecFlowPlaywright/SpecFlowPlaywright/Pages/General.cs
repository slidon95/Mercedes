using Microsoft.Playwright;

namespace SpecFlowPlaywright.Pages;

public class General
{
    private readonly IPage _page;
    private ILocator _acceptCookies;
    
    public General(IPage page)
    {
        _page = page;
        _acceptCookies = _page.Locator("wb7-button[data-test='handle-accept-all-button']").Nth(0); // First button

    }
    public async Task GoToPageAsync(string url)
    {
        await _page.GotoAsync(url); 
    }
        
    public async Task ClickAcceptCookiesAsync()
    {
        // Wait for the accept cookies button to be visible before clicking it
        await _acceptCookies.WaitForAsync(new LocatorWaitForOptions
        {
            State = WaitForSelectorState.Visible,
            Timeout = 500000 

        });
        await _acceptCookies.ClickAsync();
    }
}