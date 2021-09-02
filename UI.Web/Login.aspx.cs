using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academia.Entities;
using Academia.Logic;
using Academia.EntityFramework;


namespace UI.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioRepository usuarioRepository = new UsuarioRepository();
            usuarios usuario = usuarioRepository.findByUserName(1);
            Page.Response.Write(usuario.ToString());
        }
    }
}