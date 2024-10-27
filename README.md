## First Exercise 

The Task 1 you can find on a PDF attached to the repository.

# Second Exercise 

The project was developed in **C#** using **SpecFlow** for BDD and **Playwright** for UI tests. The structure follows a modular organization, divided into several folders to ensure scalability and maintainability

## Project Structure

The project is organized into the following folders: 

**Config:** this contains all the configuration settings. An instance is Config.cs, which contains constant strings representing URLs and keys for the values that are held in the ScenarioContext.

**Drivers:** this contains the Driver.cs class, which instantiates and maintains the browser instance used throughout the tests; either Chrome or Firefox.

**Hooks:** this contains Hooks.cs, which has methods to be executed before and after each scenario. This includes browser setup, navigating to the base URL, and acceptance of cookies.

 **Pages (Page Objects)** - The `Pages` folder contains classes representing the Page Object Model - POM pattern. Those classes define and encapsulate page-specific logic and locators so one can easily manipulate web elements in a structured way.

- **General.cs**:
- Manages the general actions on the page, such as accepting cookies.
- Methods:
- `GoToPageAsync(string url)`: Goes to a particular URL.
- `ClickAcceptCookiesAsync()`: Clicks "Accept Cookies" if visible.

- **PopUpLocationPage.cs**:
- Handles the interaction within the location pop-up.
- Methods:
- `SelectState(string state)`: Selects a state.
- `WritePostalCode(string postalCode)`: Fills in the postal code.
- `WhatPurpose(string purpose)`: Chooses the purpose of Private/Business.
- `ClickContinue()`: Continues to the next step.

- **PopUpContactDetail.cs**:
- Performs the operations associated with contact details input.
- Methods:
- `WriteFirstName()`, `WriteLastName()`, `WriteEmail(string email)`, `WritePhoneNumber()`, `WritePostalCode()`: Fills contact information fields.
- `FillContactDetail(string email)`: Fills in the contact details form.
- `ClickProceed()`: Clicks the Proceed button.
- `VisibleErrorMessage()`: Checks for an error message if the form validation fails.

- **VehiclesPage.cs**:
- Manages the vehicle filtering and selection actions.
- Methods:
- `SelectFilter()`: Opens the filter options.
- `SelectColor(string color)`: To select any particular color to apply to the filter.
- `SelectHightoLow()`: To sort vehicles in descending order of their prices.
- `SelectFirstVehicle()`: To select the first vehicle of that sorted list.

- **VehicleInfoPage.cs**:
- Handles the details of the vehicle and what actions are to be performed on them.
- Methods:
- `SendInfoToFile()`: Saves model year and VIN number to a file.
- `ClickSpeakToExpert()`: Clicks the "Speak to an Expert" button.

**Steps:** This is the step definition class for SpecFlow feature scenarios, found in the FormValidationSteps.cs file.

**Features** - on features we have a scenario describing the flow of contact form validation on the Mercedes-Benz vehicle website. 

- Feature: Mercedes-Benz Contact Form Validation
- Tags: @firefox or @chrome, just tags that decide which browser to use to run the test, based on configuration in SpecFlow regarding the scenario.

```
Feature: Mercedes-Benz Contact Form Validation

    @firefox
    Scenario Outline: Submit contact form with invalid data
         When the user selects their location with the following details <State>, <Postal Code> and <Purpose>
         And the user clicks the filter button
         And the user is on Demonstrator tab and select the <Color>
         And the user select the most expensive car in the filtered results
         And the user saves in the file the VIN number and Model Year
         And the user clicks on the Speak to an expert
         And  the user fills the Contact Details form with an invalid <Email> and dont click on the checkbox
         And  the user clicks Proceed
         Then the user should see an error message indicating an invalid email format and should also remember to check the checkboxes
         
         Examples:
           | State    | Postal Code | Purpose  | Color                 | Email |
           | Tasmania | 7005        | Business | Cosmos Black metallic |  sara@.com     |
```

**Evidence**

- Chrome
[mercedes_Chrome.zip](https://github.com/user-attachments/files/17535521/mercedes_Chrome.zip)

- Firefox

  [mercedes_firefox.zip](https://github.com/user-attachments/files/17535519/mercedes_firefox.zip)


## Setting Up the Development Environment

### Requirements

- .NET SDK
- Rider or Visual Studio
- Playwright
- SpecFlow

### Setup Steps for **Rider**

1. **Install .NET SDK**:
   - Download and install the .NET SDK: [Download .NET SDK](https://dotnet.microsoft.com/download).
   
2. **Install Rider**:
   - Download and install JetBrains Rider: [Download Rider](https://www.jetbrains.com/rider/download/).

3. **Install SpecFlow and Playwright**:
   - Run the following command in the terminal to add SpecFlow and Playwright:
     ```bash
     dotnet add package SpecFlow
     dotnet add package Microsoft.Playwright
     dotnet build
     ```
   - Install the Playwright browsers with:
     ```bash
     playwright install
     ```

4. **Run the Project**:
   - Execute the tests directly in Rider by clicking on the **Run** button.

### Setup Steps for **Visual Studio**

1. **Install .NET SDK**:
   - Download and install the .NET SDK: [Download .NET SDK](https://dotnet.microsoft.com/download).

2. **Install Visual Studio**:
   - Download and install Visual Studio: [Download Visual Studio](https://visualstudio.microsoft.com/).

3. **Install SpecFlow and Playwright**:
   - Open the **Package Manager Console** and run:
     ```bash
     Install-Package SpecFlow
     Install-Package Microsoft.Playwright
     dotnet build
     ```
   - Install the Playwright browsers:
     ```bash
     playwright install
     ```

4. **Run the Project**:
   - Execute the tests by clicking on the **Run** button in Visual Studio.
