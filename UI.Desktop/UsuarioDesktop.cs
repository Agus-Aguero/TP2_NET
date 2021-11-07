using System;

using System.Windows.Forms;
using Academia.Entities;
using Academia.Util;
using Academia.Logic;
using System.Collections.Generic;
using System.Linq;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public usuarios UsuarioActual { get; set; }
        public static usuarios UsuarioGuardado { get; set; }
        public   UsuarioLogic UsuarioLogic { get; set; }
        public bool  isPerson { get; set; }
        public IEnumerable<modulos>  Modulos { get; set; }
        

        private ModoForm _Modo { get; set; }

        public UsuarioDesktop()
        {
            InitializeComponent();
            this.UsuarioLogic = new UsuarioLogic();


        }
        public UsuarioDesktop(ModoForm modo,bool isPerson) : this()
        {
            // Internamete debe setear a ModoForm en el modo enviado, este constructor
            // servirá para las altas.
            _Modo = modo;
            ModuloLogic ModuloLogic = new ModuloLogic();

            this.Modulos = ModuloLogic.GetAll();
            ListBox listaModulos = new ListBox();
            listaModulos.DataSource = this.Modulos;
            this.isPerson = isPerson;



        }
        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            // En este nuevo constructor seteamos el modo que ha sido especificado en
            // el parámetro
           _Modo = modo;
            UsuarioLogic usuarioLogic = new UsuarioLogic(); 
            ModuloLogic ModuloLogic = new ModuloLogic();


            this.UsuarioActual = usuarioLogic.Get(ID);
            this.Modulos = ModuloLogic.GetAll();
            ListBox listaModulos = new ListBox();
            listaModulos.DataSource = this.Modulos;
       
      

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
            this.txtID.Text = this.UsuarioActual.id_usuario.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.habilitado;
            this.txtUsuario.Text = this.UsuarioActual.nombre_usuario;
            this.txtClave.Text = this.UsuarioActual.clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.clave;
            


        }
        public override void MapearADatos()
        {

            switch (this._Modo)
            {
                case ModoForm.Alta:
                    this.UsuarioActual = new usuarios();
                    this.UsuarioActual.State = States.New;
                    break;
                case ModoForm.Baja:
                    this.UsuarioActual.State = States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    this.UsuarioActual.State = States.Modified;
                    break;
            }
            this.UsuarioActual.State = this._Modo == ModoForm.Alta ? States.New : States.Modified;
            this.UsuarioActual.habilitado = this.chkHabilitado.Checked;
            this.UsuarioActual.nombre_usuario = this.txtUsuario.Text;
            this.UsuarioActual.clave = this.txtConfirmarClave.Text;
            this.UsuarioActual.modulos_usuarios = new List<modulos_usuarios>();
    

    }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            this.UsuarioLogic.Save(UsuarioActual);

        }

        public override bool Validar() 
        {
            bool estado=true;
            string error_msj="Completar:\n";
          
            if (this.txtUsuario.Text == String.Empty)
            {
                estado = false;
                error_msj += "usuarios\n";
            }
            else
            {
                if (this.UsuarioLogic.findByUserName(this.txtUsuario.Text)!=null)
                {
                    estado = false;
                    error_msj = "";
                    error_msj += "El Usuario ya es está registrado \n";
                }

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
                this.Close();
                this.MapearADatos();
                if (!this.isPerson)
                {
                    this.GuardarCambios();
                }
            }

           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
