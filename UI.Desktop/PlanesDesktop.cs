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
    public partial class PlanesDesktop : ApplicationForm
    {
        public planes PlanActual { get; set; }
        private ModoForm _Modo { get; set; }

        public PlanesDesktop()
        {
            InitializeComponent();
        }

        public PlanesDesktop(ModoForm modo) : this()
        {
            // Internamete debe setear a ModoForm en el modo enviado, este constructor
            // servirá para las altas.
            _Modo = modo;
        }

        public PlanesDesktop(int ID, ModoForm modo) : this()
        {
            // En este nuevo constructor seteamos el modo que ha sido especificado en
            // el parámetro
            _Modo = modo;
            PlanesLogic planLogic = new PlanesLogic();

            this.PlanActual = planLogic.Get(ID);

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
            this.txtID.Text = this.PlanActual.id_plan.ToString();
            this.txtDescripcion.Text = this.PlanActual.desc_plan;
            this.txtIDEsp.Text = this.PlanActual.id_especialidad.ToString();

        }

        public override void MapearADatos()
        {

            switch (this._Modo)
            {
                case ModoForm.Alta:
                    this.PlanActual = new planes();
                    this.PlanActual.State = States.New;
                    break;
                case ModoForm.Baja:
                    this.PlanActual.State = States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    this.PlanActual.State = States.Modified;
                    break;
            }
            this.PlanActual.State = this._Modo == ModoForm.Alta ? States.New : States.Modified;
            this.PlanActual.desc_plan = this.txtDescripcion.Text;
            this.PlanActual.id_especialidad = Convert.ToInt32(this.txtIDEsp.Text); // Consultar si esta bien
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

            if (this.txtIDEsp.Text == String.Empty)
            {
                estado = false;
                error_msj += "Id especialidad\n";
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
            PlanesLogic planLogic = new PlanesLogic();

            planLogic.Save(PlanActual);

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
