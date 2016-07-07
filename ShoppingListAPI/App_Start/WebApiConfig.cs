using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ShoppingListAPI
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

            config.Routes.MapHttpRoute(
               name: "Post",
               routeTemplate: "api/{controller}/Post/{name}/{quantity}",
               defaults: new { controller = "Item", action = "Post" }
           );

            config.Routes.MapHttpRoute(
                name: "Put",
                routeTemplate: "api/{controller}/Put/{name}/{quantity}",
                defaults: new { controller = "Item", action = "Put" }
            );

            config.Routes.MapHttpRoute(
                name: "Delete",
                routeTemplate: "api/{controller}/Delete/{name}",
                defaults: new { controller = "Item", action = "Delete" }
            );

            config.Routes.MapHttpRoute(
                name: "Get",
                routeTemplate: "api/{controller}/Get/{name}",
                defaults: new { controller = "Item", action = "Get" }
            );

            config.Routes.MapHttpRoute(
                name: "GetList",
                routeTemplate: "api/{controller}/GetList",
                defaults: new { controller = "Item", action = "GetList" }
            );
        }
    }
}
