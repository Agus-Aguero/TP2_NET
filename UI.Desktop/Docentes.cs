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
using Academia.EntityFramework;

namespace UI.Desktop
{
    public partial class Docentes : Form
    {
        public PersonaLogic pLogic { get; set; }
        public PersonaRepository personaRepository { get; set; }
        public Docentes()
        {
            InitializeComponent();
            GenerarColumnas();
            this.dgvDocentes.AutoGenerateColumns = false;
            this.pLogic = new PersonaLogic();
            this.personaRepository = new PersonaRepository();
        }

        private void GenerarColumnas()
        {
            DataGridViewTextBoxColumn colLegajo = new DataGridViewTextBoxColumn();
            colLegajo.Name = "Legajo";
            colLegajo.HeaderText = "Legajo";
            colLegajo.DataPropertyName = "legajo";
            colLegajo.DisplayIndex = 0;
            this.dgvDocentes.Columns.Add(colLegajo);

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.DataPropertyName = "nombre";
            colNombre.DisplayIndex = 1;
            this.dgvDocentes.Columns.Add(colNombre);

            DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
            colApellido.Name = "apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.DataPropertyName = "apellido";
            colApellido.DisplayIndex = 1;
            this.dgvDocentes.Columns.Add(colApellido);
        }

        public void Listar()
        {
            this.dgvDocentes.AutoGenerateColumns = false;
            this.dgvDocentes.DataSource = null;
            IEnumerable<personas> docentes = pLogic.GetAll().Where(per => per.tipo_persona == TipoPersona.Docente).ToList();
            this.dgvDocentes.DataSource = docentes;
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
            int nroLegajo = Convert.ToInt32(this.dgvDocentes.Rows[this.dgvDocentes.CurrentRow.Index].Cells[0].Value);
            personas persona = personaRepository.GetByLegajo(nroLegajo);
            DocenteDesktop formAlumno = new DocenteDesktop(persona.id_persona, ApplicationForm.ModoForm.Modificacion);
            formAlumno.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int nroLegajo = Convert.ToInt32(this.dgvDocentes.Rows[this.dgvDocentes.CurrentRow.Index].Cells[0].Value);
            personas persona = personaRepository.GetByLegajo(nroLegajo);
            DocenteDesktop formDocente = new DocenteDesktop(persona.id_persona, ApplicationForm.ModoForm.Modificacion);
            formDocente.ShowDialog();
            this.Listar();
        }

        private void Docentes_Load_1(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
