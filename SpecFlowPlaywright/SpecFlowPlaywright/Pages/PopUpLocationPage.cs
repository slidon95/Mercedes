using Microsoft.Playwright;

namespace SpecFlowPlaywright.Pages;

public class PopUpLocationPage
{
    private ILocator _state;
    private ILocator _postalCode;
    private ILocator _privateButton;
    private ILocator _businessButton;
    private ILocator _continueButton;

    private readonly IPage _page;
    

    public PopUpLocationPage(IPage page)
    {
        _page = page;
        _state = _page.Locator("wb-select-control.dcp-header-location-modal-dropdown.hydrated select");
        _postalCode = _page.Locator("wb-input.hydrated input[type='number'][aria-labelledby='postal-code-hint']");
        _privateButton = _page.Locator("input[name='registration-type'][value='P']");
        _businessButton = _page.Locator("input[name='registration-type'][value='B']");
        _continueButton = _page.Locator("button[data-test-id='state-selected-modal__close']");

    }
    public async Task SelectState(string state)
    {
        await _state.SelectOptionAsync(new[] { state });
    }

    public async Task WritePostalCode(string postalCode,int delayMilliseconds = 100)
    {
        foreach (char c in postalCode)
        {
            await _postalCode.TypeAsync(c.ToString());
            await Task.Delay(delayMilliseconds); 
        }

    }
    
    public async Task WhatPurpose(string purpose)
    {
        var purposeButton = purpose.Equals("Business", StringComparison.OrdinalIgnoreCase)
            ? _businessButton 
            : _privateButton;

        await purposeButton.ClickAsync(new LocatorClickOptions { Force = true });

    }
    public async Task ClickContinue()
    {
        
        await _continueButton.ClickAsync();

    }
}