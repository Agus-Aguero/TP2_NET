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
    public partial class Especialidades : Form
    {
        public EspecialidadLogic eLogic { get; set; }

        public Especialidades()
        {
            eLogic = new EspecialidadLogic();
            InitializeComponent();
            GenerarColumnas();
            this.dgvEspecialidades.AutoGenerateColumns = false;

        }

        public void Listar()
        {
            this.dgvEspecialidades.AutoGenerateColumns = false;
            this.dgvEspecialidades.DataSource = eLogic.GetAll();
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
            EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            formEspecialidad.ShowDialog();
            this.Listar();
        }

        private void tstEditar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvEspecialidades.Rows[this.dgvEspecialidades.CurrentRow.Index].Cells[0].Value);
            EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formEspecialidad.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvEspecialidades.Rows[this.dgvEspecialidades.CurrentRow.Index].Cells[0].Value);

            DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desea eliminar el registro?", "Eliminar registro",
                                    MessageBoxButtons.OKCancel);

            if (dialogResult == DialogResult.OK)
            {
                eLogic.Delete(ID);
                this.Listar();
            }
            else
            {
                this.Close();
            }
        }

        private void Especialidades_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void GenerarColumnas()
        {


            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "id";
            colId.HeaderText = "ID";
            colId.DataPropertyName = "id_especialidad";
            colId.DisplayIndex = 0;
            this.dgvEspecialidades.Columns.Add(colId);

            DataGridViewTextBoxColumn colDescripcion = new DataGridViewTextBoxColumn();
            colDescripcion.Name = "descripcion";
            colDescripcion.HeaderText = "Descripcion";
            colDescripcion.DataPropertyName = "desc_especialidad";
            colDescripcion.DisplayIndex = 0;
            this.dgvEspecialidades.Columns.Add(colDescripcion);



            

        }

    }
}
