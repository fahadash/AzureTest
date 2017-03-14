using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TestMvcService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Init()
        {
           
        }
        protected void Application_Start()
        {
           // throw new ApplicationException("Test exception");

            string path = Environment.GetEnvironmentVariable("PATH");
            string binDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Bin");
            if (!path.EndsWith(";"))
            {
                path = path + ";";
            }

            path = path + binDir;

            Environment.SetEnvironmentVariable("PATH", path);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
