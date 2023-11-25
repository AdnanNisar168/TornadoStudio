using System;
using System.Collections.Generic;
using System.Linq;
//cors
using System.Web.Http;
using System.Web.Http.Cors;
//cors

namespace tornadoStudio
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Enable CORS globally for all controllers
            config.EnableCors();

            //Configure CORS to allow requests from specific origins
            //var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            //var cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);

            // Other Web API configuration settings
            // ...
        }
    }
}
