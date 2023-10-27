using System.Web.Http;
using System.Web.Http.Cors;

namespace ivnet.club.services.api.Startup
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var corsAttr = new EnableCorsAttribute("http://localhost:5173, http://ivnet.co.uk", "*", "*");
            config.EnableCors(corsAttr);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Add(new BrowserJsonFormatter());
        }
    }
}
