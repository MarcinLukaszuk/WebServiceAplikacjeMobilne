using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebServiceAplikacjeMobilne
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {  // Konfiguracja i usługi składnika Web API
            var cors = new EnableCorsAttribute("http://localhost:50086", "*", "*");
            config.EnableCors(cors);
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            // Trasy składnika Web API
            config.MapHttpAttributeRoutes();

            

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
