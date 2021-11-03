using Academia.EntityFramework;
using Academia.Entities;
using Academia.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Cursos : Form
    {
        public personas personaAInscribir { get; set; }
        public CursoLogic cLogic { get; set; }
        public Cursos()
        {
            InitializeComponent();
            GenerarColumnas(false);
            this.dgvCursos.AutoGenerateColumns = false;

        }

        public Cursos(personas persona)
        {
            personaAInscribir = persona;
            InitializeComponent();
            GenerarColumnas(true);
            this.dgvCursos.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            cLogic = new CursoLogic();
            this.dgvCursos.AutoGenerateColumns = false;
            var index = 0;
            IEnumerable<cursos> cursos  = cLogic.GetAll().Where(cur => cur.cupo > 0).ToList();
            this.dgvCursos.DataSource = cursos;
            if (this.personaAInscribir != null)
            {
                foreach (var curso in cursos)
                {
                    bool inscripto=false;
                    inscripto = this.personaAInscribir.alumnos_inscripciones.Any(alumInsc => alumInsc.id_curso == curso.id_curso);
                    this.dgvCursos.EditMode = DataGridViewEditMode.EditProgrammatically;
                    this.dgvCursos.Rows[index].Cells[5].Value = inscripto;


                    index++;
                    
                }
            }
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
            CursoDesktop formEspecialidad = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            formEspecialidad.ShowDialog();
            this.Listar();
        }

        private void tstEditar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvCursos.Rows[this.dgvCursos.CurrentRow.Index].Cells[0].Value);
            CursoDesktop formEspecialidad = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formEspecialidad.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvCursos.Rows[this.dgvCursos.CurrentRow.Index].Cells[0].Value);

            CursoDesktop formEspecialidad = new CursoDesktop(ID, ApplicationForm.ModoForm.Baja);
            formEspecialidad.ShowDialog();
            this.Listar();
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void GenerarColumnas(bool? habilitaInscripcion)
        {
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "id";
            colId.HeaderText = "ID";
            colId.DataPropertyName = "id_curso";
            colId.DisplayIndex = 0;
            this.dgvCursos.Columns.Add(colId);

            DataGridViewTextBoxColumn colAnioCalendario = new DataGridViewTextBoxColumn();
            colAnioCalendario.Name = "anioCalendario";
            colAnioCalendario.HeaderText = "Año calendario";
            colAnioCalendario.DataPropertyName = "anio_calendario";
            colAnioCalendario.DisplayIndex = 0;
            this.dgvCursos.Columns.Add(colAnioCalendario);

            DataGridViewTextBoxColumn colCupo = new DataGridViewTextBoxColumn();
            colCupo.Name = "cupo";
            colCupo.HeaderText = "Cupo";
            colCupo.DataPropertyName = "cupo";
            colCupo.DisplayIndex = 0;
            this.dgvCursos.Columns.Add(colCupo);

            DataGridViewTextBoxColumn colIdMateria = new DataGridViewTextBoxColumn();
            colIdMateria.Name = "materia";
            colIdMateria.HeaderText = "Materia";
            colIdMateria.DataPropertyName = "nombre_materia";
            colIdMateria.DisplayIndex = 0;
            this.dgvCursos.Columns.Add(colIdMateria);

            DataGridViewTextBoxColumn colIComision = new DataGridViewTextBoxColumn();
            colIComision.Name = "comision";
            colIComision.HeaderText = "Comisión";
            colIComision.DataPropertyName = "id_comision";
            colIComision.DisplayIndex = 0;
            this.dgvCursos.Columns.Add(colIComision);

            if (habilitaInscripcion == true)
            {
                DataGridViewCheckBoxColumn boolGrid = new DataGridViewCheckBoxColumn();
                boolGrid.HeaderText = "Inscripto";
                boolGrid.DisplayIndex = 5;
                this.dgvCursos.Columns.Add(boolGrid);

                DataGridViewButtonColumn btngrid = new DataGridViewButtonColumn();
                btngrid.Name = "Inscribir";
                btngrid.HeaderText = "Inscribir/Desinscribir";
                btngrid.Text = "Inscribir";
                btngrid.DataPropertyName = "Inscribir";
                btngrid.DisplayIndex = 6;
                btngrid.UseColumnTextForButtonValue = true;
                this.dgvCursos.Columns.Add(btngrid);

            }

        }

        //Inicia la inscripción de persona a curso
        private void dgvCursos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not in our 
            if (e.ColumnIndex == dgvCursos.Columns["Inscribir"].Index && e.RowIndex >= 0)
            {
                int idCurso = (int)dgvCursos.CurrentRow.Cells["id"].Value;

                var inscripcion = new Inscripcion(personaAInscribir,idCurso, (bool)dgvCursos.CurrentRow.Cells[5].Value);
                inscripcion.ShowDialog();
                dgvCursos.CurrentRow.Cells[5].Value = inscripcion.Inscripto;

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CursoReport report = new CursoReport();
            report.ShowDialog();
        }
    }
}
