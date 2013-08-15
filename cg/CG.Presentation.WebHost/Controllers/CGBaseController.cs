using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CG.Common;
using CG.Common.Utility;

namespace CG.Presentation.WebHost.Controllers
{
    public class CgBaseController : Controller
    {
        protected HttpRequestManager RequestManager { get; set; }

        public CgBaseController()
        {
            RequestManager = new HttpRequestManager("http://cg.api.com/");
        }
    }
}
