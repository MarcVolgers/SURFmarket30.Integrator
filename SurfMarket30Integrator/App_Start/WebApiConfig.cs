using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SURF.SurfMarket30.Integrator
{
    /// <summary>
    /// The api configuration
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Register the config
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi2",
            //    routeTemplate: "api/{controller}/{action}"
            //);
        }
    }
}
