using Academia.Entities;
using Academia.EntityFramework;
using Academia.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Login : Form
    {
        public usuarios UsuarioActual { get; set; }
        public UsuarioRepository usr { get; set;} 
        public Login()
        {
            InitializeComponent();        

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Contacte al area de Sistemas 3152", "Olvidé mi contraseña",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioRepository usr = new UsuarioRepository();
            this.UsuarioActual = usr.findByUserName(this.txtUsuario.Text);

            if (UsuarioActual != null)
            {
                if(UsuarioActual.clave== this.txtPass.Text)
                {

                    if (this.UsuarioActual.personas.tipo_persona == Academia.Util.TipoPersona.Admin)
                    {
                        Menu menu = new Menu();
                        this.Hide();
                        menu.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usted no tiene permisos para acceder\nContacte a Sistemas 3152", "Login"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos", "Login"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Login"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Academia_Load(object sender, EventArgs e)
        {

        }
    }
}
