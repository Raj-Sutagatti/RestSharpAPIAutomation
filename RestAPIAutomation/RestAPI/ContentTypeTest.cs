using RestSharp;
using System;
using System.IO;
using System.Net;
using System.Collections;

namespace RestAPIAutomation.RestAPI
{
    [TestClass]
    public class ContentTypeTest
    {
        RestClient client = null;
        string clientUrl = null;

        [TestInitialize]
        public void initialise()
        {
            clientUrl = "http://api.zippopotam.us";
            client = new RestClient(clientUrl);
        }


        [TestMethod]
        public void GetStatusCode()
        {
            Console.WriteLine("Hello World");

            //Sets the BaseUrl property for requests made by this client instance
            RestRequest request = new RestRequest("nl/3825", Method.Get);

            var response = client.Execute(request);
            Console.Write("Response is:", response.Content.ToString());


            Assert.AreEqual("application/json", response.ContentType);
        }

    }
}