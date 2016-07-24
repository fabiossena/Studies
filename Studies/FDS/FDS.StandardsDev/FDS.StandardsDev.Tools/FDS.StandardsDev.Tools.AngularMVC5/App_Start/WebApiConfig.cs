using System.Web.Http;
namespace WebApplication1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(config =>
            {
                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(
                               name: "DefaultApi",
                               routeTemplate: "api/{controller}/{action}/{id}",
                               defaults: new { id = RouteParameter.Optional }
                           );
            });
        }
    }
}