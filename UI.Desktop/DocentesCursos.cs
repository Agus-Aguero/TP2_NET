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


namespace UI.Desktop
{
    public partial class DocentesCursos : Form
    {
        public DocenteCursoLogic dcLogic { get; set; }
        public DocentesCursos()
        {
            dcLogic = new DocenteCursoLogic();
            InitializeComponent();
            GenerarColumnas();
            this.dgvDocentesCursos.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            this.dgvDocentesCursos.AutoGenerateColumns = false;
            this.dgvDocentesCursos.DataSource = dcLogic.GetAll();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            DocenteCursoDesktop formEspecialidad = new DocenteCursoDesktop(ApplicationForm.ModoForm.Alta);
            formEspecialidad.ShowDialog();
            this.Listar();
        }

        private void tstEditar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvDocentesCursos.Rows[this.dgvDocentesCursos.CurrentRow.Index].Cells[0].Value);
            DocenteCursoDesktop formEspecialidad = new DocenteCursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formEspecialidad.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvDocentesCursos.Rows[this.dgvDocentesCursos.CurrentRow.Index].Cells[0].Value);

            dcLogic.Delete(ID);
            this.Listar();
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void GenerarColumnas()
        {
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "id";
            colId.HeaderText = "Dictado";
            colId.DataPropertyName = "id_dictado";
            colId.DisplayIndex = 0;
            this.dgvDocentesCursos.Columns.Add(colId);

            DataGridViewTextBoxColumn colIdCurso = new DataGridViewTextBoxColumn();
            colIdCurso.Name = "curso";
            colIdCurso.HeaderText = "Curso";
            colIdCurso.DataPropertyName = "desc_materia";
            colIdCurso.DisplayIndex = 0;
            this.dgvDocentesCursos.Columns.Add(colIdCurso);

            DataGridViewTextBoxColumn colIdDocente = new DataGridViewTextBoxColumn();
            colIdDocente.Name = "apellido";
            colIdDocente.HeaderText = "Docente";
            colIdDocente.DataPropertyName = "nombre_docente";
            colIdDocente.DisplayIndex = 0;
            this.dgvDocentesCursos.Columns.Add(colIdDocente);

            DataGridViewTextBoxColumn colCargo = new DataGridViewTextBoxColumn();
            colCargo.Name = "cargo";
            colCargo.HeaderText = "Cargo";
            colCargo.DataPropertyName = "cargo";
            colCargo.DisplayIndex = 0;
            this.dgvDocentesCursos.Columns.Add(colCargo);

        }
    }
}
