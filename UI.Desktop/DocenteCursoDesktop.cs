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
    public partial class DocenteCursoDesktop : ApplicationForm
    {
        public docentes_cursos DocenteCursoActual { get; set; }
        private ModoForm _Modo { get; set; }

        public DocenteCursoDesktop()
        {
            InitializeComponent();
        }
        public DocenteCursoDesktop(ModoForm modo) : this()
        {
            _Modo = modo;
        }

        public DocenteCursoDesktop(int ID, ModoForm modo) : this()
        {
            _Modo = modo;
            DocenteCursoLogic dcLogic = new DocenteCursoLogic();

            this.DocenteCursoActual = dcLogic.Get(ID);

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
            this.txtId.Text = this.DocenteCursoActual.id_dictado.ToString();
            this.txtCargo.Text = this.DocenteCursoActual.cargo.ToString();
            this.comboCurso.Text = this.DocenteCursoActual.id_curso.ToString(); ;
            this.comboDocente.Text = this.DocenteCursoActual.personas.apellido.ToString();
        }

        public override void MapearADatos()
        {
            switch (this._Modo)
            {
                case ModoForm.Alta:
                    this.DocenteCursoActual = new docentes_cursos();
                    this.DocenteCursoActual.State = States.New;
                    break;
                case ModoForm.Baja:
                    this.DocenteCursoActual.State = States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    this.DocenteCursoActual.State = States.Modified;
                    break;
            }

            this.DocenteCursoActual.cargo = Convert.ToInt32(this.txtCargo.Text);
            this.DocenteCursoActual.id_docente = Convert.ToInt32(this.comboDocente.SelectedValue);
            this.DocenteCursoActual.id_curso = Convert.ToInt32(this.comboCurso.SelectedValue);
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            DocenteCursoLogic dcLogic = new DocenteCursoLogic();

            dcLogic.Save(DocenteCursoActual);
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

        //populating
        private void populatingDocentes()
        {
            PersonaLogic perLogic = new PersonaLogic();
            this.comboDocente.DataSource = perLogic.GetAll();
            this.comboDocente.DisplayMember = "apellido";
            this.comboDocente.ValueMember = "id_persona";
        }

        private void populatingCursos()
        {
            CursoLogic cLogic = new CursoLogic();
            this.comboCurso.DataSource = cLogic.GetAll();
            this.comboCurso.DisplayMember = "id_curso";
            this.comboCurso.ValueMember = "id_curso";
        }
        //
    }
}
