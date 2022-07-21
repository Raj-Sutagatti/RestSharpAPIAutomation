using RestSharp;
using System;
using System.IO;
using System.Net;
using System.Collections;


namespace RestAPIAutomation.RestAPI
{
    [TestClass]
    public class StatusCodeTest
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
            RestRequest request = new RestRequest("DE/01067", Method.Get);

            var response = client.Execute(request);
            RestResponse resp = client.Get(request);

            Console.Write("", response.Content);
            Console.Write("", resp.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void GetNotFoundStatusCode()
        {
            RestRequest request = new RestRequest("AU/02100", Method.Get);
            //request.AddParameter("", "");

            var resp = client.Get(request);
            Assert.AreEqual(HttpStatusCode.NotFound, resp.StatusCode);

        }


    }
}