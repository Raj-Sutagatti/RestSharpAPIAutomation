using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace RestAPIAutomation.RestAPI
{
    [TestClass]
    public class StatusCodeDataDrivenTest
    {
        RestClient client;
        string clientUrl;
        RestRequest request;
        RestResponse response;

        [TestInitialize]
        public void initialise()
        {
            clientUrl = "http://api.zippopotam.us";
            client = new RestClient(clientUrl);
        }


        [DataTestMethod]
        [DataRow("CH", "1000", HttpStatusCode.OK)]
        [DataRow("IN", "110001", HttpStatusCode.OK)]
        [DataRow("FR", "01001", HttpStatusCode.OK)]
        public void StatusCodeTest(string countryCode, string zipCode, HttpStatusCode expectedHTTPStatusCode)
        {
            request = new RestRequest($"{countryCode}/{zipCode}", Method.Get);
            response = client.Execute(request);

            Console.Write("Response Content:" + response.Content);
            Console.Write("Response Status is:" + response.StatusCode);
            Assert.AreEqual(expectedHTTPStatusCode, response.StatusCode);

        }



    }
}
