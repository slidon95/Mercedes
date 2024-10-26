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

  