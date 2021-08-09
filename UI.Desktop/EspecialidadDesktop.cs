using System;


using System.Windows.Forms;
using Academia.Entities;
using Academia.Util;
using Academia.Logic;
using static UI.Desktop.ApplicationForm;

namespace UI.Desktop
{
    public partial class EspecialidadDesktop : ApplicationForm
    {

        public especialidades EspecialidadActual { get; set; }

        private ModoForm _Modo { get; set; }

        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadDesktop(ModoForm modo) : this()
        {
            _Modo = modo;
        }
        public EspecialidadDesktop(int ID, ModoForm modo) : this()
        {
            _Modo = modo;
            EspecialidadLogic especialidadLogic = new EspecialidadLogic();

            this.EspecialidadActual = especialidadLogic.Get(ID);

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
            this.txtID.Text = this.EspecialidadActual.id_especialidad.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.desc_especialidad;

        }

        public override void MapearADatos()
        {

            switch (this._Modo)
            {
                case ModoForm.Alta:
                    this.EspecialidadActual = new especialidades();
                    this.EspecialidadActual.State = States.New;
                    break;
                case ModoForm.Baja:
                    this.EspecialidadActual.State = States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    this.EspecialidadActual.State = States.Modified;
                    break;
            }

            this.EspecialidadActual.desc_especialidad = this.txtDescripcion.Text;


        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            EspecialidadLogic especialidadLogic = new EspecialidadLogic();

            especialidadLogic.Save(EspecialidadActual);

        }

        public override bool Validar()
        {
            return true;
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
