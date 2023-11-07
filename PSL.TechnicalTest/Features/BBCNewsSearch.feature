Feature: BBC News Search
  As a user
  I want to search for articles relating to Chorley on the BBC News website
  So that I can verify the search results


Scenario: Verify top five search results for articles relating to Chorley
    Given I am on the BBC News website
    When I perform a search for articles relating to Chorley
    Then I should see at least five search results
    And the top five results should contain 'Chorley' in the title

