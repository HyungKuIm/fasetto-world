using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Server
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 구성 및 서비스

            //Web API 리턴값을 JSON형식으로만 함
            GlobalConfiguration.Configuration.Formatters
                .XmlFormatter.SupportedMediaTypes.Clear();

            // Web API 경로
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
