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
    public partial class Modulos : Form
    {
        public ModuloLogic mLogic { get; set; }
        public Modulos()
        {
            InitializeComponent();
           GenerarColumnas();
            this.dgvModulos.AutoGenerateColumns = false;
             mLogic = new ModuloLogic();

        }

        private void toolStripContainer1_RightToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        public void Listar()
        {
            this.dgvModulos.AutoGenerateColumns = false;
            this.dgvModulos.DataSource =null;
            var modulos = mLogic.GetAll();
            this.dgvModulos.DataSource = mLogic.GetAll();
        }

        private void Modulos_Load(object sender, EventArgs e)
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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ModuloDesktop formModulo = new ModuloDesktop(ApplicationForm.ModoForm.Alta);
            formModulo.ShowDialog();
            this.Listar();
        }

        private void tstEditar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvModulos.Rows[this.dgvModulos.CurrentRow.Index].Cells[2].Value);
            ModuloDesktop formModulo = new ModuloDesktop(ID,ApplicationForm.ModoForm.Modificacion);
            formModulo.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvModulos.Rows[this.dgvModulos.CurrentRow.Index].Cells[2].Value);
            mLogic.Delete(ID);
            this.Listar();
        }

        private void GenerarColumnas()
        {


    

            DataGridViewTextBoxColumn colDescripcion = new DataGridViewTextBoxColumn();
            colDescripcion.Name = "Descripcion";
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.DataPropertyName = "desc_modulo";
            colDescripcion.DisplayIndex = 0;
            this.dgvModulos.Columns.Add(colDescripcion);


            DataGridViewTextBoxColumn colEjecuta = new DataGridViewTextBoxColumn();
            colEjecuta.Name = "ejecuta";
            colEjecuta.HeaderText = "Ejecuta";
            colEjecuta.DataPropertyName = "ejecuta";
            colEjecuta.DisplayIndex = 0;
            this.dgvModulos.Columns.Add(colEjecuta);
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "id";
            colId.HeaderText = "ID";
            colId.DataPropertyName = "id_modulo";
            colId.DisplayIndex = 0;
            this.dgvModulos.Columns.Add(colId);


        }
    }
}
