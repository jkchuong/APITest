using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using APIClient.PostcodeIOService;

namespace APIClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var restClient = new RestClient("https://api.postcodes.io/");
            var restRequest = new RestRequest();

            // configure request
            restRequest.Method = Method.GET;
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.Timeout = -1;

            // Set up the resource specification
            var postcode = "WS7 1LN";
            restRequest.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";

            // Call API
            var restResponse = restClient.Execute(restRequest);
            Console.WriteLine("Response content (string)");
            Console.WriteLine(restResponse.Content);
            JObject responseContent = JObject.Parse(restResponse.Content);
            Console.WriteLine(responseContent["result"]["parish"]);

            //// Same call copied from Postman
            //var client = new RestClient("https://api.postcodes.io/postcodes/EC2Y 5AS");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Cookie", "__cfduid=d3145d852b236e7b06a501f269ec270e01614164401");
            //IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);


            //var jsonResponse = JObject.Parse(restResponse.Content);
            //Console.WriteLine("\nResponse content as a JObject");
            //Console.WriteLine(jsonResponse);

            //var adminDistrict = jsonResponse["result"]["admin_district"];
            //Console.WriteLine($"Admin district {adminDistrict}");


            var client = new RestClient("https://api.postcodes.io/postcodes/");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "__cfduid=d3145d852b236e7b06a501f269ec270e01614164401");
            request.AddParameter("application/json", "{\r\n  \"postcodes\" : [\"OX49 5NU\", \"M32 0JG\", \"NE30 1DP\"]\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);


            //var singlePostCode = JsonConvert.DeserializeObject<SinglePostCodeResponse>(response.Content);
            var bulkPostCodes = JsonConvert.DeserializeObject<BulkPostcodeResponse>(response.Content);

            
        }
    }
}
