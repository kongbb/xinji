using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace CG.Common
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
            }
        }

        public string GetResponse(string url,
            Method method = Method.GET,
            Dictionary<string, string> headerDictionary = null,
            Dictionary<string, string> parameters = null)
        {
            return MakeRequest(url, method, null, null);
        }

        public T GetResponse<T>(string url,
            Method method = Method.GET,
            Dictionary<string, string> headerDictionary = null,
            Dictionary<string, string> parameters = null)
        {
            string json = MakeRequest(url, method, null, null);
            return JsonConvert.DeserializeObject<T>(json);
        }

        private string MakeRequest(string url, Method method,
            Dictionary<string, string> header,
            Dictionary<string, string> parameters)
        {
            var request = new RestRequest(url, method);
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
