using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace CG.Common.Utility
{
    public class HttpRequestManager
    {
        public RestClient Client { get; set; }

        public RestClient AuthenticatedClient { get; set; }

        public HttpRequestManager(string domainUrl, bool needAuthentication = false)
        {
            if (needAuthentication)
            {

            }
            else
            {
                Client = new RestClient(domainUrl);
                Client.Authenticator = new HttpBasicAuthenticator("ys-kos-d02\\webtest", "nomads?12");
            }
        }

        public string Get(string url,
            Dictionary<string, string> headerDictionary = null,
            Dictionary<string, string> parameters = null)
        {
            return MakeRequest(url, Method.GET, null, null, null);
        }

        public T Get<T>(string url,
            Dictionary<string, string> headerDictionary = null,
            Dictionary<string, string> parameters = null)
        {
            string json = MakeRequest(url, Method.GET, null, null, null);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public string Post(string url,
            string jsonString,
            Dictionary<string, string> headerDictionary = null,
            Dictionary<string, string> parameters = null)
        {
            return MakeRequest(url, Method.POST, headerDictionary, parameters, jsonString);
        }

        public T Post<T>(string url,
            Object json,
            Dictionary<string, string> headerDictionary = null,
            Dictionary<string, string> parameters = null)
        {
            string jsonResponse = MakeRequest(url, Method.POST, headerDictionary, parameters, JsonConvert.SerializeObject(json));
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }

        private string MakeRequest(string url, Method method,
            Dictionary<string, string> header,
            Dictionary<string, string> parameters, string jsonString)
        {
            var request = new RestRequest(url, method);
            if (!string.IsNullOrWhiteSpace(jsonString))
            {
                request.AddParameter("application/json; charset=utf-8", jsonString,
                    ParameterType.RequestBody);
            }
            
            request.RequestFormat = DataFormat.Json;
            //Client.Authenticator = new SimpleAuthenticator("username", "foo", "password", "bar");

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
