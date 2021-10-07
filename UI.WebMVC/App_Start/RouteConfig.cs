using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UI.WebMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Inscripciones",
                url: "usuario/inscripciones/{id}",
                defaults: new { controller = "Usuario", action = "Inscripciones", id = "" }
            );


            routes.MapRoute(
                name: "Materias",
                url: "materias",
                defaults: new { controller = "Materia", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                 name: "Alumno",
                 url: "usuario/alumno",
                 defaults: new { controller = "Usuario", action = "Index" }
            );






        }
    }
}
