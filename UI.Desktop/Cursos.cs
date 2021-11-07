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
            CursoDesktop formCurso = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            formCurso.ShowDialog();
            this.Listar();
        }

        private void tstEditar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvCursos.Rows[this.dgvCursos.CurrentRow.Index].Cells[0].Value);
            CursoDesktop formCurso = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formCurso.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvCursos.Rows[this.dgvCursos.CurrentRow.Index].Cells[0].Value);
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desea eliminar el registro?", "Eliminar registro",
                                       MessageBoxButtons.OKCancel);

            if (dialogResult == DialogResult.OK)
            {
                bool rta;
                rta = cLogic.Delete(ID);

                if (rta)
                {
                    this.Listar();
                }
                else
                {
                    MessageBox.Show("No se puede eliminar el registro");
                    this.Close();

                }
            }
            else
            {
                this.Close();
            }
            
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void GenerarColumnas(bool? habilitaInscripcion)
        {
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "id";
            colId.HeaderText = "ID Curso";
            colId.DataPropertyName = "id_curso";
            colId.DisplayIndex = 0;
            this.dgvCursos.Columns.Add(colId);

            DataGridViewTextBoxColumn colIComision = new DataGridViewTextBoxColumn();
            colIComision.Name = "comision";
            colIComision.HeaderText = "ID Comisión";
            colIComision.DataPropertyName = "id_comision";
            colIComision.DisplayIndex = 1;
            this.dgvCursos.Columns.Add(colIComision);

            DataGridViewTextBoxColumn colIdMateria = new DataGridViewTextBoxColumn();
            colIdMateria.Name = "materia";
            colIdMateria.HeaderText = "Materia";
            colIdMateria.DataPropertyName = "nombre_materia";
            colIdMateria.DisplayIndex = 2;
            this.dgvCursos.Columns.Add(colIdMateria);

            DataGridViewTextBoxColumn colAnioCalendario = new DataGridViewTextBoxColumn();
            colAnioCalendario.Name = "anioCalendario";
            colAnioCalendario.HeaderText = "Año calendario";
            colAnioCalendario.DataPropertyName = "anio_calendario";
            colAnioCalendario.DisplayIndex = 3;
            this.dgvCursos.Columns.Add(colAnioCalendario);

            DataGridViewTextBoxColumn colCupo = new DataGridViewTextBoxColumn();
            colCupo.Name = "cupo";
            colCupo.HeaderText = "Cupo";
            colCupo.DataPropertyName = "cupo";
            colCupo.DisplayIndex = 4;
            this.dgvCursos.Columns.Add(colCupo);


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
            try
            {
                if (e.ColumnIndex == dgvCursos.Columns["Inscribir"].Index && e.RowIndex >= 0)
                {
                    int idCurso = (int)dgvCursos.CurrentRow.Cells["id"].Value;

                    var inscripcion = new Inscripcion(personaAInscribir, idCurso, (bool)dgvCursos.CurrentRow.Cells[5].Value);
                    inscripcion.ShowDialog();
                    dgvCursos.CurrentRow.Cells[5].Value = inscripcion.Inscripto;

                }
            } catch
            {

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CursoReport report = new CursoReport();
            report.ShowDialog();
        }
    }
}
