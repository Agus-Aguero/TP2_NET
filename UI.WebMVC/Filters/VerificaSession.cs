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
    }
}