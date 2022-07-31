using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestAPIAutomation.RestAPI.APIMethods;
using System.Net;
using Newtonsoft.Json.Linq;

namespace RestAPIAutomation.RestAPI
{
    [TestClass]
    public class BookingTest
    {
        APIMethod bookingAPI;

        [TestInitialize]
        public void init()
        {
            APIMethod bookingAPI = new APIMethod("https://restful-booker.herokuapp.com");
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(HttpStatusCode.OK)]
        [DataRow("booking")]
        public void GetBookingIds(HttpStatusCode expectedStatusCode, string requestParam)
        {
            var response = bookingAPI.GetMethod(requestParam);
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
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

            var response = bookingAPI.PostMethod(bookingData, "booking");

            //postRequest.AddStringBody(bookingData.ToString(), DataFormat.Json);
            Console.WriteLine(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }




    }
}
