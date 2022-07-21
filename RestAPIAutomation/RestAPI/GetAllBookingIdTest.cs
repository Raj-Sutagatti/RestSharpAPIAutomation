using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Net;
using Newtonsoft.Json.Linq;

namespace RestAPIAutomation.RestAPI
{
    [TestClass]
    public class BookingIdTest
    {
        static string clienturl;
        static RestClient client;


        [TestInitialize]
        public void init()
        {
            clienturl = "https://restful-booker.herokuapp.com";
            client = new RestClient(clienturl);

        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(HttpStatusCode.OK)]
        public void GetBookingIds(HttpStatusCode expectedStatusCode)
        {
            var request = new RestRequest("booking", Method.Get);
            var response = client.Execute(request);

            Console.Write(response.Content);
            Assert.AreEqual(expectedStatusCode, response.StatusCode);

        }


        [TestMethod]
        [DataTestMethod]
        [DataRow("admin", "password123", HttpStatusCode.OK)]
        public void CreateAuthenticationToken(string userName, string userPassword, HttpStatusCode expStatusCode)
        {
            var loginData = new JObject();

            loginData.Add("username", userName);
            loginData.Add("password", userPassword);

            Console.WriteLine(loginData);

            var createAuthRequest = new RestRequest("auth", Method.Post);

            //createAuthRequest.AddStringBody(loginData.ToString(), DataFormat.Json);
            createAuthRequest.AddJsonBody(loginData);
            var response = client.Execute(createAuthRequest);

            Console.WriteLine(response.Content);
            Assert.AreEqual(expStatusCode, response.StatusCode);


        }



        [TestMethod]
        [DataTestMethod]
        [DataRow("Krishna", "Kumar", 500, true, "2022-07-21", "2022-07-23", "lunch")]
        public void CreateNewBoooking(string firstName, string lastName, int price, bool depositPaid, string checkInDate, string checkOutDate, string additional)
        {
            var bookingData = new JObject();
            var bookingdate = new JObject();

            bookingdate.Add("checkin", checkInDate);
            bookingdate.Add("checkout", checkOutDate);

            bookingData.Add("firstname", firstName);
            bookingData.Add("lastname", lastName);
            bookingData.Add("totalprice", price);
            bookingData.Add("depositpaid", depositPaid);
            bookingData.Add("bookingdates", bookingdate);
            bookingData.Add("additionalneeds", additional);

            Console.WriteLine(bookingData);


            var postRequest = new RestRequest("booking", Method.Post);

            //postRequest.AddStringBody(bookingData.ToString(), DataFormat.Json);
            postRequest.AddJsonBody(bookingData);
            var response = client.Execute(postRequest);

            Console.WriteLine(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }




    }
}
