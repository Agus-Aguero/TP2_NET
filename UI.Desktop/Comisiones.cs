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
    public partial class Comisiones : Form
    {
        public ComisionLogic cLogic { get; set; }
        public Comisiones()
        {
            InitializeComponent();
            GenerarColumnas();
            this.dgvComisiones.AutoGenerateColumns = false;
            this.cLogic = new ComisionLogic();
        }

        public void Listar()
        {
            this.dgvComisiones.AutoGenerateColumns = false;
            this.dgvComisiones.DataSource = null;
            this.dgvComisiones.DataSource = cLogic.GetAll();
        }

        private void Comisiones_Load(object sender, EventArgs e)
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
            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.Name = "ID";
            colID.HeaderText = "ID Comision";
            colID.DataPropertyName = "id_comision";
            colID.DisplayIndex = 0;
            this.dgvComisiones.Columns.Add(colID);

            DataGridViewTextBoxColumn colAnioEsp = new DataGridViewTextBoxColumn();
            colAnioEsp.Name = "Año especialidad";
            colAnioEsp.HeaderText = "Año Especialidad";
            colAnioEsp.DataPropertyName = "anio_especialidad";
            colAnioEsp.DisplayIndex = 1;
            this.dgvComisiones.Columns.Add(colAnioEsp);

            DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
            colDesc.Name = "descripcion";
            colDesc.HeaderText = "Descripcion";
            colDesc.DataPropertyName = "desc_comision";
            colDesc.DisplayIndex = 2;
            this.dgvComisiones.Columns.Add(colDesc);

            DataGridViewTextBoxColumn colIdPlan = new DataGridViewTextBoxColumn();
            colIdPlan.Name = "Id Plan";
            colIdPlan.HeaderText = "Id Plan";
            colIdPlan.DataPropertyName = "id_plan";
            colIdPlan.DisplayIndex = 3;
            this.dgvComisiones.Columns.Add(colIdPlan);

        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionDesktop formComisiones = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            formComisiones.ShowDialog();
            this.Listar();
        }

        private void tstEditar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvComisiones.Rows[this.dgvComisiones.CurrentRow.Index].Cells[0].Value);
            ComisionDesktop formComisiones = new ComisionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formComisiones.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvComisiones.Rows[this.dgvComisiones.CurrentRow.Index].Cells[0].Value);
            cLogic.Delete(ID);
            this.Listar();
        }
    }
}
