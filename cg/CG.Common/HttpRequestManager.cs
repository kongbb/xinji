using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace CG.Common
{
    public class HttpRequestManager
    {
        public RestClient Client { get; set; }

        public RestClient AuthenticatedClient { get; set; }
    }
}
