using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace CG.Common.Helper
{
    public class RestSharperHelper
    {
//        var client = new RestClient("http://example.com");
//// client.Authenticator = new HttpBasicAuthenticator(username, password);

//var request = new RestRequest("resource/{id}", Method.POST);
//request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
//request.AddUrlSegment("id", 123); // replaces matching token in request.Resource

//// easily add HTTP Headers
//request.AddHeader("header", "value");

//// add files to upload (works with compatible verbs)
//request.AddFile(path);

//// execute the request
//RestResponse response = client.Execute(request);
//var content = response.Content; // raw content as string
        //Hardcode
        public RestClient Client = new RestClient("http://cg.webapi/");

        //public static RestClient AuthenticatedClient = new RestClient("http://cg.webapi/");

        public string GetResponse(string url, 
            Method method = Method.GET, 
            Dictionary<string, string> headerDictionary = null, 
            Dictionary<string, string> parameters = null)
        {
            return MakeRequest(url, method, null, null);
        }

        private string MakeRequest(string url, Method method, 
            Dictionary<string, string> header, 
            Dictionary<string, string> parameters)
        {
            var request = new RestRequest(url, method);
            if (header != null)
            {
                foreach (var headerParameter in header)
                {
                    request.AddHeader(headerParameter.Key, headerParameter.Value);
                }
            }
            if (method == Method.POST)
            {
                if (header != null)
                {
                    foreach (var parameter in parameters)
                    {
                        request.AddHeader(parameter.Key, parameter.Value);
                    }
                }
            }

            IRestResponse response = Client.Execute(request);
            return response.Content;
        }
    }
}
