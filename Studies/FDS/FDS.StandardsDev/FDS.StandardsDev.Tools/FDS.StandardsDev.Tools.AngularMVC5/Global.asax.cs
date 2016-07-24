using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication1;

namespace FDS.StandardsDev.Tools.AngularMVC5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);



            GlobalConfiguration.Configure(config =>
            {
                config.MapHttpAttributeRoutes();



                config.Routes.MapHttpRoute(
                               name: "DefaultHomeApi",
                               routeTemplate: "Home/api/{controller}/{action}/{id}",
                               defaults: new { id = RouteParameter.Optional }
                           );

                config.Routes.MapHttpRoute(
                               name: "DefaultApi",
                               routeTemplate: "api/{controller}/{action}/{id}",
                               defaults: new { id = RouteParameter.Optional }
                           );

                //config.Routes.MapHttpRoute(name: "DefaultApiAction", routeTemplate: "api/{controller}/{action}");

            });
            


        }
    }
}
