using System;

using System.Windows.Forms;
using Academia.Entities;
using Academia.Util;
using Academia.Logic;

namespace UI.Desktop
{
    public partial class ModuloDesktop : ApplicationForm
    {
        public modulos ModuloActual { get; set; }
        public ModuloLogic mLogic { get; set; }

        private ModoForm _Modo { get; set; }

        public ModuloDesktop()
        {
            InitializeComponent();
            this.mLogic = new ModuloLogic();
        }
        public ModuloDesktop(ModoForm modo) : this()
        {
            // Internamete debe setear a ModoForm en el modo enviado, este constructor
            // servirá para las altas.
            _Modo = modo;
        }
        public ModuloDesktop(int ID, ModoForm modo) : this()
        {
            // En este nuevo constructor seteamos el modo que ha sido especificado en
            // el parámetro
           _Modo = modo;
            this.mLogic = new ModuloLogic();


            this.ModuloActual = mLogic.Get(ID);
            
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
            this.txtID.Text = this.ModuloActual.id_modulo.ToString();
            this.txtDescripcion.Text = this.ModuloActual.desc_modulo;
            this.txtEjecuta.Text = this.ModuloActual.ejecuta;



            // 14.Dentro del mismo método setearemos el texto del botón Aceptar en
            // función del Modo del formulario de esta forma:

        }
        public override void MapearADatos()
        {
            
            switch (this._Modo)
            {
                case ModoForm.Alta:
                    this.ModuloActual = new modulos();
                    this.ModuloActual.State = States.New;
                    break;
                case ModoForm.Baja:
                    this.ModuloActual.State = States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    this.ModuloActual.State = States.Modified;
                    break;
            }
            this.ModuloActual.State = this._Modo == ModoForm.Alta ? States.New : States.Modified;
            this.ModuloActual.ejecuta = this.txtEjecuta.Text;
            this.ModuloActual.desc_modulo = this.txtDescripcion.Text;
            this.ModuloActual.ejecuta = this.txtEjecuta.Text;

        }
       
        public override void GuardarCambios()
        {
            this.MapearADatos();

            mLogic.Save(ModuloActual);

        }

        public override bool Validar() 
        {
            bool estado=true;
            string error_msj="Completar:\n";
            if (this.txtDescripcion.Text == String.Empty)
            {
                estado = false;
                error_msj+= "Descripción\n";
            }

            if (this.txtEjecuta.Text == String.Empty)
            {
                estado = false;
                error_msj += "Ejecuta\n";
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
