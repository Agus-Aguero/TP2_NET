using Academia.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using UI.WebMVC.Controllers;

namespace UI.WebMVC.Filters
{
    public class VerificaSession:ActionFilterAttribute
    {
        private usuarios usuario;
      
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            usuario = (usuarios)HttpContext.Current.Session["User"];
            if (usuario == null)
            {

                if ((filterContext.Controller is HomeController) == false)
                {

                    RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                    redirectTargetDictionary.Add("controller", "Home");

                    filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);



                }
                base.OnActionExecuting(filterContext);
            }
        }

        public bool ValidacionAcceso(int id)
        {
            usuario = (usuarios)HttpContext.Current.Session["User"];
            if(id != usuario.id_persona)
            {
                return false;
            }

            return true;
        }

        public bool PermisoVisualizacionCurso(cursos curso)
        {
            bool permiso = false;
            try
            {
                usuario = (usuarios)HttpContext.Current.Session["User"];
                foreach (var docente in curso.docentes_cursos)
                {
                    if (docente.id_docente == usuario.id_persona)
                    {
                        permiso = true;
                    }
                }
            } catch
            {
                return permiso;
            }
            return permiso;
        }
    }
}