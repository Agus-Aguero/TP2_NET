using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Academia.Logic;
using Academia.Entities;
using Academia.Util;

namespace UI.Desktop
{
    public partial class DocenteDesktop : ApplicationForm
    {
        public personas DocenteActual { get; set; }
        private ModoForm _Modo { get; set; }
        public DocenteDesktop()
        {
            InitializeComponent();
        }

        public DocenteDesktop(ModoForm modo) : this()
        {
            _Modo = modo;
        }
        public DocenteDesktop(int ID, ModoForm modo) : this()
        {
            _Modo = modo;
            PersonaLogic pLogic = new PersonaLogic();

            this.DocenteActual = pLogic.Get(ID);

            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
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

            this.txtLegajo.Text = this.DocenteActual.legajo.ToString();
            this.txtNombre.Text = this.DocenteActual.nombre.ToString();
            this.txtApellido.Text = this.DocenteActual.apellido.ToString();
            this.txtDireccion.Text = this.DocenteActual.direccion.ToString();

        }

        public override void MapearADatos()
        {
            switch (this._Modo)
            {
                case ModoForm.Baja:
                    this.DocenteActual.State = States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    this.DocenteActual.State = States.Modified;
                    break;
            }

            this.DocenteActual.legajo = Convert.ToInt32(this.txtLegajo);
            this.DocenteActual.nombre = this.txtNombre.ToString();
            this.DocenteActual.apellido = this.txtApellido.ToString();
            this.DocenteActual.direccion = this.txtDireccion.ToString();
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            PersonaLogic pLogic = new PersonaLogic();

            pLogic.Save(DocenteActual);
        }


        public override bool Validar()
        {
            bool estado = true;

            string error_msj = "Completar:\n\n";

            if (this.txtNombre.Text == String.Empty)
            {
                estado = false;
                error_msj += "El Nombre\n";
            }

            if (this.txtApellido.Text == String.Empty)
            {
                error_msj += "El Apellido\n";
                estado = false;
            }

            if (this.txtDireccion.Text == String.Empty)
            {
                error_msj += "El domicilio\n";
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInscribirDocente_Click(object sender, EventArgs e)
        {

        }
    }
}
