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
            this.UsuarioActual.State = BusinessEntity.States.Modified;
            if (this._Modo == ModoForm.Alta)
            {
                this.UsuarioActual = new Usuario();
                this.UsuarioActual.State = BusinessEntity.States.New;
            }
            
            this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
            this.UsuarioActual.Nombre = this.txtNombre.Text;
            this.UsuarioActual.Apellido= this.txtApellido.Text;
            this.UsuarioActual.NombreUsuario= this.txtUsuario.Text;
            this.UsuarioActual.Clave= this.txtConfirmarClave.Text;
            this.UsuarioActual.EMail= this.txtEmail.Text;

        }
       
        public override void GuardarCambios() { }
     
        public override bool Validar() { return false; }
    }
}
