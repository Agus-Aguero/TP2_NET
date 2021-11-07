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
    public partial class MateriasDesktop : ApplicationForm
    {
        public materias MateriaActual { get; set; }
        private ModoForm _Modo { get; set; }
        public MateriasDesktop()
        {
            InitializeComponent();
            populatingPlanes();
        }

        public MateriasDesktop(ModoForm modo) : this()
        {
            // Internamete debe setear a ModoForm en el modo enviado, este constructor
            // servirá para las altas.
            _Modo = modo;
        }

        public MateriasDesktop(int ID, ModoForm modo) : this()
        {
            // En este nuevo constructor seteamos el modo que ha sido especificado en
            // el parámetro
            _Modo = modo;
            MateriaLogic materiaLogic = new MateriaLogic();

            this.MateriaActual = materiaLogic.Get(ID);

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
            this.txtID.Text = this.MateriaActual.id_materia.ToString();
            this.txtDescripcion.Text = this.MateriaActual.desc_materia;
            this.txtHSSemanal.Text = this.MateriaActual.hs_semanales.ToString();
            this.txtHSTotales.Text = this.MateriaActual.hs_totales.ToString();
            this.comboPlan.Text = this.MateriaActual.id_plan.ToString();
        }

        public override void MapearADatos()
        {
            switch (this._Modo)
            {
                case ModoForm.Alta:
                    this.MateriaActual = new materias();
                    this.MateriaActual.State = States.New;
                    break;
                case ModoForm.Baja:
                    this.MateriaActual.State = States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    this.MateriaActual.State = States.Modified;
                    break;
            }
            this.MateriaActual.State = this._Modo == ModoForm.Alta ? States.New : States.Modified;
            this.MateriaActual.desc_materia = this.txtDescripcion.Text;
            this.MateriaActual.hs_semanales = Convert.ToInt32(this.txtHSSemanal.Text);
            this.MateriaActual.hs_totales = Convert.ToInt32(this.txtHSTotales.Text);
            this.MateriaActual.id_plan = Convert.ToInt32(this.comboPlan.SelectedValue);
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

            if (this.txtHSSemanal.Text == String.Empty)
            {
                estado = false;
                error_msj += "HS semanales\n";
            }

            if (this.txtHSTotales.Text == String.Empty)
            {
                estado = false;
                error_msj += "Hs totales\n";
            }

            if (this.comboPlan.Text == String.Empty)
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
            MateriaLogic materiaLogic = new MateriaLogic();

            materiaLogic.Save(MateriaActual);

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

        private void populatingPlanes()
        {
            PlanesLogic pLogic = new PlanesLogic();
            var planes = pLogic.GetAll();
            this.comboPlan.DataSource = planes.ToList();
            this.comboPlan.DisplayMember = "desc_plan";
            this.comboPlan.ValueMember = "id_plan";
        }


    }
}
