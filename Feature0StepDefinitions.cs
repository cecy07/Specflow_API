using System;
using NUnit.Framework;
using System.Net;
using TechTalk.SpecFlow;
using RestSharp;

namespace Specflow_API
{
    [Binding]
    public class Feature0StepDefinitions
    {
        RestClient client = new RestClient("http://localhost:3000/");
        RestRequest request = new RestRequest("posts/{postid}", Method.Get);
        RestResponse response;

        [Given(@"I have a valid number (.*)")]
        public void GivenIHaveAValidNumber(int p0)
        {
            request.AddUrlSegment("postid", 1);
        }

        [When(@"I send Get request to server")]
        public void WhenISendGetRequestToServer()
        {
            response = client.Execute(request);
        }

        [Then(@"Expect a valid record response")]
        public void ThenExpectAValidRecordResponse()
        {
            Console.WriteLine(response.StatusCode.ToString());
            //Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
