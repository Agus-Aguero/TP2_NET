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
            string username = this.txtUser.Text.ToString();
            string password = this.txtPassword.Text.ToString();

            this.login(username, password);

        }

        protected void login(string username, string password)
        {
            UsuarioRepository usuarioRepository = new UsuarioRepository();
            usuarios usuario = usuarioRepository.findByUserName(username);

            if(usuario != null && usuario.clave == password)
            {
                Session["usuario"] = usuario;
                Page.Response.Redirect("MenuUsuario.aspx");
            } else 
            {
                Page.Response.Write("Nombre de usuario y/o contraseña inválido");
            }

        }
    }
}