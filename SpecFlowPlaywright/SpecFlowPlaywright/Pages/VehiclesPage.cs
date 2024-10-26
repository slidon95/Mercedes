using Microsoft.Playwright;

namespace SpecFlowPlaywright.Pages;

public class VehiclesPage
{
    private ILocator _filter;
    private ILocator _selectColor;
    private ILocator _color;
    private ILocator _sorting;
    private ILocator _firstVehicle;

    private readonly IPage _page;

    private string color_select;
    public VehiclesPage(IPage page)
    {
        _page = page;
        _filter = _page.Locator(".filter-toggle");
        _selectColor = _page.Locator("div.category-filter-row-headline >> text=Colour");
        _color =  _page.Locator($"a.dcp-filter-pill.dcp-filter-multi-select__pill >> text='{color_select}'");

        _sorting = _page.Locator("wb-select-control.dcp-cars-srp__sorting-dropdown > wb-select > select");
        _firstVehicle = _page.Locator("//div[@class='dcp-cars-srp-results__tile'][1]");
        
    }
    public async Task SelectFilter()
    {
        await Task.Delay(5000);
        await _filter.ClickAsync();

    }

    public async Task SelectColor(string color)
    {
        await _selectColor.ClickAsync();
        color_select = color;
        _color =  _page.Locator($"a.dcp-filter-pill.dcp-filter-multi-select__pill >> text='{color_select}'");
        await _color.ClickAsync();

    }
    public async Task SelectHightoLow()
    {
        await _sorting.SelectOptionAsync(new SelectOptionValue { Value = "price-desc-demo" });
    }

    public async Task SelectFirstVehicle()
    {
        await _firstVehicle.ClickAsync();


    }
}