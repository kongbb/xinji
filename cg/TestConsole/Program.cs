using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CG.Common;
using CG.Logic.Dto.TestDtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = @"{""Id"":3,""Message"":""Hello Roger!""}";
            TestObject t = JsonConvert.DeserializeObject<TestObject>(jsonString);
            HttpRequestManager manager = new HttpRequestManager("http://cg.webapi/");
            string response = manager.GetResponse("api/TestApi/GetMessageById/1");
        }
    }
}
