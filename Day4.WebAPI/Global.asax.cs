using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Day4.WebAPI.App_Start;

namespace Day4.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DIConfig.Configure();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
