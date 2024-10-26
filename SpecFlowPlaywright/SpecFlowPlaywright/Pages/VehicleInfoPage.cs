using Microsoft.Playwright;

namespace SpecFlowPlaywright.Pages;

public class VehicleInfoPage
{
    private ILocator _modelYear;
    private ILocator _vinNumber;
    private ILocator _button_speak;

    private readonly IPage _page;

    public VehicleInfoPage(IPage page)
    {
        _page = page;
        _modelYear =
            _page.Locator("li[data-test-id='dcp-vehicle-details-list-item-1'] .dcp-vehicle-details-list-item__value");
        _vinNumber =_page.Locator("li[data-test-id='dcp-vehicle-details-list-item-11'] .dcp-vehicle-details-list-item__value");
        _button_speak = _page.Locator("button[data-test-id='dcp-buy-box__contact-seller']");
        
    }
    
    public async Task SendInfoToFile()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\SaveInfo\VinNumber&ModelYear.txt");
        string writeModelAndVin = $"Model Year: {await _modelYear.InnerTextAsync()}\nVIN Number: {await _vinNumber.InnerTextAsync()}";
        await File.WriteAllTextAsync(filePath, writeModelAndVin);
    }

    public async Task ClickSpeakToExpert()
    {
        await _button_speak.ClickAsync();
    }
}