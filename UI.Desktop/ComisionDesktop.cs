using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Academia.Entities;
using Academia.Logic;
using Academia.Util;

namespace UI.Desktop
{
    public partial class ComisionDesktop : ApplicationForm
    {
        public comisiones ComisionActual { get; set; }
        private ModoForm _Modo { get; set; }
        public ComisionDesktop()
        {
            InitializeComponent();
        }

        public ComisionDesktop(ModoForm modo) : this()
        {
            // Internamete debe setear a ModoForm en el modo enviado, este constructor
            // servirá para las altas.
            _Modo = modo;
        }

        public ComisionDesktop(int ID, ModoForm modo) : this()
        {
            // En este nuevo constructor seteamos el modo que ha sido especificado en
            // el parámetro
            _Modo = modo;
            ComisionLogic comisionLogic = new ComisionLogic();

            this.ComisionActual = comisionLogic.Get(ID);

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
            this.txtDescripcion.Text = this.ComisionActual.desc_comision;
            this.txtAnioEsp.Text = this.ComisionActual.anio_especialidad.ToString();
            this.txtIDPlan.Text = this.ComisionActual.id_plan.ToString();
        }

        public override void MapearADatos()
        {
            switch (this._Modo)
            {
                case ModoForm.Alta:
                    this.ComisionActual = new comisiones();
                    this.ComisionActual.State = States.New;
                    break;
                case ModoForm.Baja:
                    this.ComisionActual.State = States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    this.ComisionActual.State = States.Modified;
                    break;
            }
            this.ComisionActual.State = this._Modo == ModoForm.Alta ? States.New : States.Modified;
            this.ComisionActual.desc_comision = this.txtDescripcion.Text;
            this.ComisionActual.anio_especialidad = Convert.ToInt32(this.txtAnioEsp.Text);
            this.ComisionActual.id_plan = Convert.ToInt32(this.txtIDPlan.Text);
        }

        public override bool Validar()
        {
            bool estado = true;
            string error_msj = "Completar:\n";
            if (this.txtDescripcion.Text == String.Empty)
            {
                estado = false;
                error_msj += "Descripcion\n";
            }

            if (this.txtAnioEsp.Text == String.Empty)
            {
                estado = false;
                error_msj += "Año Especialidad\n";
            }

            if (this.txtIDPlan.Text == String.Empty)
            {
                estado = false;
                error_msj += "Id Plan\n";
            }

            if (!estado)
            {
                Notificar(error_msj, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return estado;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            ComisionLogic comisionLogic = new ComisionLogic();

            comisionLogic.Save(ComisionActual);

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
