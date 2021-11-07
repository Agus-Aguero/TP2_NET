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

namespace UI.Desktop
{
    public partial class Planes : Form
    {
        public PlanesLogic pLogic { get; set; }
        public Planes()
        {
            InitializeComponent();
            GenerarColumnas();
            this.dgvPlanes.AutoGenerateColumns = false;
            this.pLogic = new PlanesLogic();

        }

        public void Listar()
        {
            
            this.dgvPlanes.AutoGenerateColumns = false;
            this.dgvPlanes.DataSource = null;
           // var planes = pLogic.GetAll();
            this.dgvPlanes.DataSource = pLogic.GetAll();
        }

        private void Planes_Load(object sender, EventArgs e)
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

        private void GenerarColumnas()
        {


            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "id";
            colId.HeaderText = "ID";
            colId.DataPropertyName = "id_plan";
            colId.DisplayIndex = 0;
            this.dgvPlanes.Columns.Add(colId);

            DataGridViewTextBoxColumn colIdEsp = new DataGridViewTextBoxColumn();
            colIdEsp.Name = "IdEsp";
            colIdEsp.HeaderText = "Especialidad";
            colIdEsp.DataPropertyName = "desc_especialidad";
            colIdEsp.DisplayIndex = 1;
            this.dgvPlanes.Columns.Add(colIdEsp);

            DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
            colDesc.Name = "descripcion";
            colDesc.HeaderText = "Descripcion";
            colDesc.DataPropertyName = "desc_plan";
            colDesc.DisplayIndex = 2;
            this.dgvPlanes.Columns.Add(colDesc);

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PlanesDesktop formPlanes = new PlanesDesktop(ApplicationForm.ModoForm.Alta);
            formPlanes.ShowDialog();
            this.Listar();
        }

        private void tstEditar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvPlanes.Rows[this.dgvPlanes.CurrentRow.Index].Cells[0].Value);
            PlanesDesktop formPlanes = new PlanesDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formPlanes.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvPlanes.Rows[this.dgvPlanes.CurrentRow.Index].Cells[0].Value);
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desea eliminar el registro?", "Eliminar registro",
                                       MessageBoxButtons.OKCancel);

            if (dialogResult == DialogResult.OK)
            {
                bool rta;
                rta = pLogic.Delete(ID);

                if (rta)
                {
                    MessageBox.Show("Se elimino el registro exitosamente");
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            PlanReport planReport = new PlanReport();
            planReport.ShowDialog();

        }
    }
}
