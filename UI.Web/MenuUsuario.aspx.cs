using Academia.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academia.Entities;
using Academia.Logic;

namespace UI.Web
{
    public partial class MenuUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //int id = Convert.ToInt32(Request.QueryString["id"]);
            //UsuarioRepository usuarioRepository = new UsuarioRepository();
            //usuarios usuario = usuarioRepository.Get(id);

            usuarios usuario = (usuarios)Session["usuario"];

            this.lblPrueba.Text = usuario.nombre_usuario;

        }
    }
}