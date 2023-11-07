Feature: BBCWeathersearch
  As a user
  I want to search for weather in chorley on the BBC News website
  So that I can verify the weather results


 Scenario: Search for local weather in Chorley
    Given I am on the BBC News website
    When I navigate to the weather page    
    Then I should see the weather details for Chorley