using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public Usuario UsuarioActual { get; set; }

        private ModoForm _Modo { get; set; }

        public UsuarioDesktop()
        {
            InitializeComponent();
        }
        public UsuarioDesktop(ModoForm modo) : this()
        {
            // Internamete debe setear a ModoForm en el modo enviado, este constructor
            // servirá para las altas. ?
            _Modo = modo;
        }
        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            // En este nuevo constructor seteamos el modo que ha sido especificado en
            // el parámetro
           _Modo = modo;
            UsuarioLogic usuarioLogic = new UsuarioLogic();

            this.UsuarioActual = usuarioLogic.GetOne(ID);
            
            MapearDeDatos();
        }

        public override void MapearDeDatos() {

            switch (_Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
                default:
                    break;
            }
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;
            this.txtEmail.Text = this.UsuarioActual.EMail;

            // 14.Dentro del mismo método setearemos el texto del botón Aceptar en
            // función del Modo del formulario de esta forma:

        }
        public override void MapearADatos()
        {
            this.UsuarioActual = new Usuario();
            this.UsuarioActual.State = this._Modo == ModoForm.Alta ? States.New : States.Modified;
            this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
            this.UsuarioActual.Nombre = this.txtNombre.Text;
            this.UsuarioActual.Apellido= this.txtApellido.Text;
            this.UsuarioActual.NombreUsuario= this.txtUsuario.Text;
            this.UsuarioActual.Clave= this.txtConfirmarClave.Text;
            this.UsuarioActual.EMail= this.txtEmail.Text;

        }
       
        public override void GuardarCambios()
        {
            this.MapearADatos();
            UsuarioLogic usuarioLogic = new UsuarioLogic();

            usuarioLogic.Save(UsuarioActual);

        }

        public override bool Validar() 
        {
            bool estado=true;
            string error_msj="Completar:\n";
            if (this.txtNombre.Text == String.Empty)
            {
                estado = false;
                error_msj+= "Nombre\n";
            }

            if (this.txtApellido.Text == String.Empty)
            {
                estado = false;
                error_msj += "Apellido\n";
            }

            if (this.txtUsuario.Text == String.Empty)
            {
                estado = false;
                error_msj += "Usuario\n";
            }

            if (!IsValidEmail(this.txtEmail.Text)) //this.txtEmail.Text == String.Empty)
            {
                error_msj+= String.IsNullOrEmpty(this.txtEmail.Text) ? "Email\n" : "Email no valido\n";
                estado = false;             
            }

            if (String.IsNullOrEmpty(this.txtClave.Text)|| this.txtClave.Text.Length<= 8 || this.txtClave.Text != this.txtConfirmarClave.Text )
            {
                error_msj += String.IsNullOrEmpty(this.txtClave.Text) ? "Clave\n" : this.txtClave.Text.Length <= 8 ?
                    "Debe tener mas de 8" : "Debe coincidir con Confirmar Clave"; 
                estado = false;
            }

            if (!estado)
            {
                Notificar(error_msj, MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }

            return estado; 
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
           if (Validar())
            {
                GuardarCambios();
                this.Close();
            }

           
        }
    }
}
