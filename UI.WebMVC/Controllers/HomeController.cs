using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Academia.Entities;
using Academia.Logic;
using Academia.EntityFramework;
using Academia.Util;


namespace UI.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private usuarios usuario;

        public ActionResult Index()
        {
            usuario = (usuarios)Session["User"];

            if (usuario == null)
            {
                return View();

            } else
            {

                return Redirect("~/Usuario/Index");

            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Login(usuarios userDataFromPost)
        {

            UsuarioRepository usuarioRepository = new UsuarioRepository();
            usuarios usuario = usuarioRepository.findByUserName(userDataFromPost.nombre_usuario);

            if (usuario != null && usuario.clave == userDataFromPost.clave)
            {
                Session["User"] = usuario;

                return Redirect("~/Usuario/Index");
            }
            else
            {
                ViewBag.ErrorMessage = "No pudimos validar su usuario y/o contraseña. Intente nuevamente.";
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["User"] = null;
            return View("Index");
        }
    }
}