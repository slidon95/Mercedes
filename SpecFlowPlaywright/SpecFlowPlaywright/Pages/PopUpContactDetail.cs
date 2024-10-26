
using Microsoft.Playwright;

namespace SpecFlowPlaywright.Pages;

public class PopUpContactDetail

{
    private readonly IPage _page;
    private ILocator _firstName;
    private ILocator _lastName;
    private ILocator _email;
    private ILocator _postalCode;
    private ILocator _phoneNumber;
    private ILocator _buttonProceed;
    private ILocator _errorMessage;



    public PopUpContactDetail(IPage page)
    {
        _page = page;
        _firstName= _page.Locator("div[data-test-id='rfq-contact__first-name'] label:has-text('First Name') + input[type='text']");
        _lastName= _page.Locator("div[data-test-id='rfq-contact__last-name'] label:has-text('Last Name') + input[type='text']");
        _email= _page.Locator("div[data-test-id='rfq-contact__email'] label:has-text('E-Mail') + input[type='text']");
        _postalCode= _page.Locator("div[data-test-id='rfq-contact__postal-code'] label:has-text('Postal Code') + input[type='text']");
        _phoneNumber = _page.Locator("div[data-test-id='rfq-contact__phone'] label:has-text('Phone') + input[type='text']");
        _buttonProceed = _page.Locator("button[data-test-id='dcp-rfq-contact-button-container__button-next']");
        _errorMessage =_page.Locator("div.dcp-error-message");

    }
    
    public async Task WriteFirstName()
    {
        await _firstName.FillAsync("Sara");
    }
    public async Task WriteLastName()
    {
        await _lastName.FillAsync("Lidon");
    }
    public async Task WriteEmail(string email)
    {
        await _email.FillAsync(email);
    }
    public async Task WritePhoneNumber()
    {
        await _phoneNumber.FillAsync("0441234567");
    }
    public async Task WritePostalCode()
    {
        await _postalCode.FillAsync("7005");
    }


    public async Task FillContactDetail(string email)
    {
        await WriteFirstName();
        await WriteLastName();
        await WritePhoneNumber();
        await WritePostalCode();
        await WritePhoneNumber();
        await WriteEmail(email);

    }
    public async Task ClickProceed()
    {
        await _buttonProceed.ClickAsync();
    }
    public async Task VisibleErrorMessage()
    {
        await _errorMessage.IsVisibleAsync();
    }
}