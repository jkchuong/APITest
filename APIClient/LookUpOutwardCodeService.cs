using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace APIClient
{
    public class LookUpOutwardCodeService
    {
        #region Properties
        // Restsharp object which handles communication with the API
        public RestClient Client;

        // a Newtonsoft object representing the json response
        public JObject ResponseContent { get; set; }
        public OutwardResponse ResponseObject { get; set; }

        // the Postcode used in thsi API request
        public string OutwardCodeSelected { get; set; }
        #endregion

        public LookUpOutwardCodeService()
        {
            Client = new RestClient { BaseUrl = new Uri(AppConfigReader.BaseUrl)};
        }

        /// <summary>
        /// Defines and makes the APi request, and stores the response
        /// </summary>
        /// <param name="outwardCode"></param>
        public void MakeRequest(string outwardCode)
        {
            // set up the request
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            OutwardCodeSelected = outwardCode;

            // define the request resource path, changing to lowercase and removing white space
            request.Resource = $"outcodes/{outwardCode.ToLower()}";

            // make request
            IRestResponse response = Client.Execute(request);

            // parse Json into response content
            ResponseContent = JObject.Parse(response.Content);

            // parse Json into object tree
            ResponseObject = JsonConvert.DeserializeObject<OutwardResponse>(response.Content);
        }
    }
}
