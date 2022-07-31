using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace RestAPIAutomation.RestAPI.APIMethods
{
    public class APIMethod
    {
        static string clienturl;
        static RestClient client;

        public APIMethod(string clientUrl)
        {
            clienturl = clientUrl;
            client = new RestClient(clienturl);
        }

        public RestResponse GetMethod(string requestParams)
        {
            var request = new RestRequest(requestParams, Method.Get);
            var response = client.Execute(request);
            return response;
        }

        public RestResponse PostMethod(JObject jsonBody, string postParams)
        {
            var request = new RestRequest(postParams, Method.Post);
            request.AddJsonBody(jsonBody);
            var response = client.Execute(request);
            return response;
        }
         
        public RestResponse CreateAuthorisation(JObject jsonBody, string authParams)
        {
            var request = new RestRequest(authParams, Method.Post);
            request.AddJsonBody(jsonBody);
            var response = client.Execute(request);
            return response;
        }

        public RestResponse PutMethod(JsonParameter jsonBody, string putParams)
        {
            var request = new RestRequest(putParams, Method.Put);
            request.AddJsonBody(jsonBody);
            var response = client.Execute(request);
            return response;
        }

        public RestResponse PatchMethod(JsonParameter jsonBody, string patchParams)
        {
            var request = new RestRequest(patchParams, Method.Patch);
            request.AddJsonBody(jsonBody);
            var response = client.Execute(request);
            return response;

        }

        public void DeleteMethod(params string[] postParams)
        {

        }
    }
}
