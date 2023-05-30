using System;
using RestSharp;
using TechTalk.SpecFlow;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Net;

namespace Specflow_API
{
    [Binding]
    public class FeaturesStepDefinitions
    {
        RestClient client = new RestClient("http://demostore.gatling.io/");
        RestRequest request;
        RestResponse response;
        int? firstProduct = 0;
        int? firstCategory = 0;

        [Given(@"A list of products all")]
        public void GivenAListOfProductsAll()
        {
            // Get all products available
            request = new RestRequest("api/product", Method.Get);
            response = client.Execute(request);
            var jsonArray = JArray.Parse(response.Content);

            // Get the first product's ID from the array
            firstProduct = jsonArray[0]["id"].Value<int>();
            Console.WriteLine(firstProduct);
            Assert.That(jsonArray, Is.Not.Empty);
        }

        [When(@"Request to Get the products")]
        public void WhenRequestToGetTheProductsIsSent()
        {
            request = new RestRequest("api/product", Method.Get);
            response = client.Execute(request);
        }

        [Then(@"Expect at least one valid product")]
        public void ThenExpectAtLeastOneValidProduct()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var jsonArray = JArray.Parse(response.Content);
            Assert.That(jsonArray, Is.Not.Empty);
        }

        [Given(@"A list of products")]
        public void GivenAListOfProducts()
        {
            // Get all products available
            request = new RestRequest("api/product", Method.Get);
            response = client.Execute(request);
            var jsonArray = JArray.Parse(response.Content);

            // Get a random product's ID from the array
            Random random = new Random();
            int randomIndex = random.Next(0, jsonArray.Count);
            firstProduct = jsonArray[randomIndex]["id"].Value<int>();
            Console.WriteLine(firstProduct);
            Assert.That(jsonArray, Is.Not.Empty);
        }

        [When(@"Request to Get a random product")]
        public void WhenRequestToGetARandomProductIsSent()
        {
            int productId = firstProduct.Value;
            request = new RestRequest("api/product/{id}", Method.Get);
            request.AddUrlSegment("id", productId.ToString());
            response = client.Execute(request);
        }

        [Then(@"Verify the price is a number")]
        public void ThenVerifyThePriceIsANumber()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var jsonObject = JObject.Parse(response.Content);
            Console.WriteLine(response.Content);
            string priceString = jsonObject["price"].Value<string>();
            bool isNumber = decimal.TryParse(priceString, out decimal price);
            Assert.That(isNumber, Is.True, "The price is not a valid number.");
        }

        [Given(@"A list of categories all")]
        public void GivenAListOfCategoriesAll()
        {
            // Get all categories available
            request = new RestRequest("api/category", Method.Get);
            response = client.Execute(request);
            var jsonArray = JArray.Parse(response.Content);

            // Get the first category's ID from the array
            firstCategory = jsonArray[0]["id"].Value<int>();
            Console.WriteLine(firstCategory);
            Assert.That(jsonArray, Is.Not.Empty);
        }

        [When(@"Request to Get all categories")]
        public void WhenRequestToGetAllCategoriesIsSent()
        {
            request = new RestRequest("api/category", Method.Get);
            response = client.Execute(request);
        }

        [Then(@"Expect at least one category to exist")]
        public void ThenExpectAtLeastOneCategoryToExist()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var jsonArray = JArray.Parse(response.Content);
            Assert.That(jsonArray, Is.Not.Empty);
        }

        [Given(@"A list of categories")]
        public void GivenAListOfCategories()
        {
            // Get all categories available
            request = new RestRequest("api/category", Method.Get);
            response = client.Execute(request);
            var jsonArray = JArray.Parse(response.Content);

            // Get a category's ID from the array
            firstCategory = jsonArray[0]["id"].Value<int>();
            Console.WriteLine(firstCategory);
            Assert.That(jsonArray, Is.Not.Empty);
        }

        [When(@"Request to Get a category")]
        public void WhenRequestToGetACategoryIsSent()
        {
            int categoryId = firstCategory.Value;
            request = new RestRequest("api/category/{id}", Method.Get);
            request.AddUrlSegment("id", categoryId.ToString());
            response = client.Execute(request);
        }

        [Then(@"Verify the name is a string")]
        public void ThenVerifyTheNameIsAString()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var jsonObject = JObject.Parse(response.Content);
            Assert.That(jsonObject["name"].Type, Is.EqualTo(JTokenType.String));
        }
    }
}
