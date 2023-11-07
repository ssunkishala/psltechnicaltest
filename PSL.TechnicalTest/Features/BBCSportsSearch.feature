Feature: BBCSportsSearch
  As a user
  I want to search for sports on the BBC website
  So that I can verify the sports details


 Scenario: Search for sports details on sports page
    Given I am on the BBC News website
    When I navigate to the the sports page
    Then I should see the sports details