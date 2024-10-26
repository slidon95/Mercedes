using Microsoft.Playwright;
using SpecFlowPlaywright.Pages;

namespace SpecFlowPlaywright.Steps;

[Binding]
public sealed class FormValidationSteps
{
    private readonly ScenarioContext _scenarioContext;
    private readonly PopUpLocationPage _locationPage;
    private readonly VehiclesPage _vehiclesPage;
    private readonly VehicleInfoPage _vehicleInfoPage;
    private readonly PopUpContactDetail _popUpContactDetail;



    public FormValidationSteps(ScenarioContext scenarioContext)
    {
        var page = scenarioContext[Configuration.Config.ScenarioContextPage] as IPage; // Retrieve the IPage instance from ScenarioContext
        _locationPage = new PopUpLocationPage(page);
        _vehiclesPage = new VehiclesPage(page);
        _vehicleInfoPage = new VehicleInfoPage(page);
        _popUpContactDetail = new PopUpContactDetail(page);

    }

    [When(@"the user selects their location with the following details (.*), (.*) and (.*)")]
    public async Task WhenTheUserSelectsTheirLocationWithTheFollowingDetailsAnd(string state, string postalCode, string purpose)
    {
        await _locationPage.SelectState(state);
        await _locationPage.WritePostalCode(postalCode);
        await _locationPage.WhatPurpose(purpose);
        await _locationPage.ClickContinue();    
    }

    [When(@"the user clicks the filter button")]
    public async Task WhenTheUserClicksTheFilterButton()
    {
        await _vehiclesPage.SelectFilter();
    }
    [When(@"the user is on Demonstrator tab and select the (.*)")]
    public async Task WhenTheUserIsOnDemonstratorTabAndSelectTheBlack(string color)
    {
        await _vehiclesPage.SelectColor(color);
    }

    [When(@"the user select the most expensive car in the filtered results")]
    public async Task WhenTheUserSelectTheMostExpensiveCarInTheFilteredResults()
    {
        await _vehiclesPage.SelectHightoLow();
        await _vehiclesPage.SelectFirstVehicle();
    }

    
    [When(@"the user saves in the file the VIN number and Model Year")]
    public async Task WhenTheUserSavesInTheFileTheVinNumberAndModelYear()
    {
        await _vehicleInfoPage.SendInfoToFile();
    }

    [When(@"the user clicks on the Speak to an expert")]
    public async Task  WhenTheUserClicksOnTheSpeakToAnExpert()
    {
        await _vehicleInfoPage.ClickSpeakToExpert();
    }

    [When(@"the user fills the Contact Details form with an invalid (.*)")]
    public  async Task WhenTheUserFillsTheContactDetailsFormWithAnInvalidSaraCom(string email)
    {
        await _popUpContactDetail.FillContactDetail(email);
    }

    [When(@"the user clicks Proceed")]
    public async Task WhenTheUserClicksProceed()
    {
        await _popUpContactDetail.ClickProceed();
    }

    [Then(@"the user should see an error message indicating an invalid email format and should also remember to check the checkboxes")]
    public async Task ThenTheUserShouldSeeAnErrorMessageIndicatingAnInvalidEmailFormatAndShouldAlsoRememberToCheckTheCheckboxes()
    {
        await _popUpContactDetail.VisibleErrorMessage();
    }
}