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
    public partial class Materias : Form
    {
        public MateriaLogic mLogic { get; set; }
        public Materias()
        {
            InitializeComponent();
            GenerarColumnas();
            this.dgvMaterias.AutoGenerateColumns = false;
            this.mLogic = new MateriaLogic();
        }


        public void Listar()
        {
            this.dgvMaterias.AutoGenerateColumns = false;
            this.dgvMaterias.DataSource = null;
            this.dgvMaterias.DataSource = mLogic.GetAll();
        }
        private void Materias_Load(object sender, EventArgs e)
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
            DataGridViewTextBoxColumn colIdMateria = new DataGridViewTextBoxColumn();
            colIdMateria.Name = "Id Materia";
            colIdMateria.HeaderText = "Id Materia";
            colIdMateria.DataPropertyName = "id_materia";
            colIdMateria.DisplayIndex = 0;
            this.dgvMaterias.Columns.Add(colIdMateria);

            DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
            colDesc.Name = "descripcion";
            colDesc.HeaderText = "Descripcion";
            colDesc.DataPropertyName = "desc_materia";
            colDesc.DisplayIndex = 1;
            this.dgvMaterias.Columns.Add(colDesc);

            DataGridViewTextBoxColumn colHsSemanal = new DataGridViewTextBoxColumn();
            colHsSemanal.Name = "HS Semanal";
            colHsSemanal.HeaderText = "HS Semanales";
            colHsSemanal.DataPropertyName = "hs_semanales";
            colHsSemanal.DisplayIndex = 2;
            this.dgvMaterias.Columns.Add(colHsSemanal);

            DataGridViewTextBoxColumn colHsTotales = new DataGridViewTextBoxColumn();
            colHsTotales.Name = "HS Totales";
            colHsTotales.HeaderText = "Total de horas";
            colHsTotales.DataPropertyName = "hs_totales";
            colHsTotales.DisplayIndex = 3;
            this.dgvMaterias.Columns.Add(colHsTotales);

            DataGridViewTextBoxColumn colIdPlan = new DataGridViewTextBoxColumn();
            colIdPlan.Name = "Id Plan";
            colIdPlan.HeaderText = "Id Plan";
            colIdPlan.DataPropertyName = "id_plan";
            colIdPlan.DisplayIndex = 4;
            this.dgvMaterias.Columns.Add(colIdPlan);

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            MateriasDesktop formMaterias = new MateriasDesktop(ApplicationForm.ModoForm.Alta);
            formMaterias.ShowDialog();
            this.Listar();
        }

        private void tstEditar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvMaterias.Rows[this.dgvMaterias.CurrentRow.Index].Cells[0].Value);
            MateriasDesktop formMaterias = new MateriasDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formMaterias.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvMaterias.Rows[this.dgvMaterias.CurrentRow.Index].Cells[0].Value);
            DialogResult dialogResult= MessageBox.Show("¿Esta seguro que desea eliminar el registro?", "Eliminar registro", 
                                        MessageBoxButtons.OKCancel );

            if (dialogResult == DialogResult.OK)
            {
                bool rta;
                rta = mLogic.Delete(ID);

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

    }
}
