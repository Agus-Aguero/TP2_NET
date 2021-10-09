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
    public partial class Alumnos : Form
    {
        public PersonaLogic pLogic { get; set; }
        public Alumnos()
        {
            InitializeComponent();
            GenerarColumnas();
            this.dgvAlumnos.AutoGenerateColumns = false;
            this.pLogic = new PersonaLogic();
        }

        private void GenerarColumnas()
        {
            DataGridViewTextBoxColumn colLegajo = new DataGridViewTextBoxColumn();
            colLegajo.Name = "Legajo";
            colLegajo.HeaderText = "Legajo";
            colLegajo.DataPropertyName = "legajo";
            colLegajo.DisplayIndex = 0;
            this.dgvAlumnos.Columns.Add(colLegajo);

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.DataPropertyName = "nombre";
            colNombre.DisplayIndex = 1;
            this.dgvAlumnos.Columns.Add(colNombre);

            DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
            colApellido.Name = "apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.DataPropertyName = "apellido";
            colApellido.DisplayIndex = 1;
            this.dgvAlumnos.Columns.Add(colApellido);

        }

        public void Listar()
        {
            this.dgvAlumnos.AutoGenerateColumns = false;
            this.dgvAlumnos.DataSource = null;
            IEnumerable<personas> alumnos = pLogic.GetAll().Where(per => per.tipo_persona == TipoPersona.Alumno).ToList();
            this.dgvAlumnos.DataSource = alumnos;
        }
        private void Alumnos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tstEditar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvAlumnos.Rows[this.dgvAlumnos.CurrentRow.Index].Cells[0].Value);
            AlumnoDesktop formAlumno = new AlumnoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formAlumno.ShowDialog();
            this.Listar();
        }


    }
}
