using Demoblaze.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Demoblaze.Request
{
    public class Rest
    {
        public static RestClient restClient;
        public static RestRequest restRequest;
        public static RestResponse response;
        public static int statuscode;
        public static string bodyResponse;
        public static void PostRequest(string jsonString, string url)
        {
            restClient = new RestClient(url);
            restRequest = new RestRequest(url, Method.Post);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddBody(jsonString);
            response = restClient.Execute(restRequest);
            bodyResponse = response.Content.ToString();
            statuscode = (int)response.StatusCode;
        }
    }
}
