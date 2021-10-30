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
    public partial class AlumnoDesktop : ApplicationForm
    {
        public personas AlumnoActual { get; set; }
        private ModoForm _Modo { get; set; }
        public AlumnoDesktop()
        {

            InitializeComponent();
        }

        public AlumnoDesktop(ModoForm modo) : this()
        {
            _Modo = modo;
        }

        public AlumnoDesktop(int ID, ModoForm modo) : this()
        {
            _Modo = modo;
            PersonaLogic pLogic = new PersonaLogic();

            this.AlumnoActual = pLogic.Get(ID);

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

            this.txtLegajo.Text = this.AlumnoActual.legajo.ToString();
            this.txtNombre.Text = this.AlumnoActual.nombre.ToString();
            this.txtApellido.Text = this.AlumnoActual.apellido.ToString();
            this.txtDireccion.Text = this.AlumnoActual.direccion.ToString();

        }

        public override void MapearADatos()
        {
            switch (this._Modo)
            {
                case ModoForm.Baja:
                    this.AlumnoActual.State = States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    this.AlumnoActual.State = States.Modified;
                    break;
            }

            this.AlumnoActual.legajo = Convert.ToInt32(this.txtLegajo);
            this.AlumnoActual.nombre = this.txtNombre.ToString();
            this.AlumnoActual.apellido = this.txtApellido.ToString();
            this.AlumnoActual.direccion = this.txtDireccion.ToString();
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            PersonaLogic pLogic = new PersonaLogic();

            pLogic.Save(AlumnoActual);
        }

        public override bool Validar()
        {
            bool estado = true;

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


        private void buttonInscripcion_Click(object sender, EventArgs e)
        {
            var cursos = new Cursos(AlumnoActual);
            cursos.ShowDialog();
        }

    }
}
