Feature: Features

  From link http://demostore.gatling.io/swagger-ui/index.html there are 4 test cases with Products
  Test_case1: Get all products and validate they exist
  Test_case2: Get one random product and verify the price is a number
  Test_case3: Get all categories and validate at least one exists
  Test_case4: Get one category and verify the name is a string

  @Test_case1
  Scenario: Get product by ID
    Given A list of products all
    When Request to Get the products
    Then Expect at least one valid product

  @Test_case2
  Scenario: Get random product and verify the price is a number
    Given A list of products
    When Request to Get a random product
    Then Verify the price is a number

  @Test_case3
  Scenario: Get all categories and validate at least one exists
    Given A list of categories all
    When Request to Get all categories
    Then Expect at least one category to exist

  @Test_case4
  Scenario: Get a category and verify the name is a string
    Given A list of categories
    When Request to Get a category
    Then Verify the name is a string