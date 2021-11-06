using Academia.Entities;
using Academia.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.WebMVC.Controllers;

namespace UI.WebMVC.Filters
{
    public class DocenteFilter: ActionFilterAttribute
    {
        private usuarios usuario;
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            usuario = (usuarios)HttpContext.Current.Session["User"];
            if (usuario != null)
            {
                if (usuario.personas.tipo_persona == TipoPersona.Docente)
                {

                    if ((filterContext.Controller is HomeController) == false)
                    {

                        filterContext.HttpContext.Response.Redirect("~/Home");

                    }
                }
            }
      
        }

        
    }
}