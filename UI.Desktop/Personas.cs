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
    public partial class Personas : Form
    {
        public PersonaLogic uLogic { get; set; }
        public Personas()
        {
           InitializeComponent();
           GenerarColumnas();
           uLogic = new PersonaLogic();
        }

        private void toolStripContainer1_RightToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        public void Listar()
        {
            this.dgvPersonas.AutoGenerateColumns = false;
            this.dgvPersonas.DataSource = null;
            this.dgvPersonas.DataSource = uLogic.GetAll();
        }

        private void Usuarios_Load(object sender, EventArgs e)
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
            PersonaDektop formUsuario = new PersonaDektop(ApplicationForm.ModoForm.Alta);
            formUsuario.ShowDialog();
            this.Listar();
        }

        private void tstEditar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvPersonas.Rows[this.dgvPersonas.CurrentRow.Index].Cells[0].Value);
            PersonaDektop formUsuario = new PersonaDektop(ID,ApplicationForm.ModoForm.Modificacion);
            formUsuario.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvPersonas.Rows[this.dgvPersonas.CurrentRow.Index].Cells[0].Value);

            DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desea eliminar el registro?", "Eliminar registro",
                                    MessageBoxButtons.OKCancel);

            if (dialogResult == DialogResult.OK)
            {
                bool rta;
                rta= uLogic.Delete(ID);

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

        private void GenerarColumnas()
        {

            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "id";
            colId.HeaderText = "ID Persona";
            colId.DataPropertyName = "id_persona";
            colId.DisplayIndex = 0;
            this.dgvPersonas.Columns.Add(colId);

            DataGridViewTextBoxColumn Collegajo = new DataGridViewTextBoxColumn();
            Collegajo.Name = "legajo";
            Collegajo.HeaderText = "Legajo";
            Collegajo.DataPropertyName = "legajo";
            Collegajo.DisplayIndex = 1;
            this.dgvPersonas.Columns.Add(Collegajo);

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.DataPropertyName = "nombre";
            colNombre.DisplayIndex = 2;
            this.dgvPersonas.Columns.Add(colNombre);

            DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
            colApellido.Name = "apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.DataPropertyName = "apellido";
            colApellido.DisplayIndex = 3;
            this.dgvPersonas.Columns.Add(colApellido);        

            DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
            colEmail.Name = "email";
            colEmail.HeaderText = "Email";
            colEmail.DataPropertyName = "email";
            colEmail.DisplayIndex = 4;
            this.dgvPersonas.Columns.Add(colEmail);

            DataGridViewTextBoxColumn colTel = new DataGridViewTextBoxColumn();
            colTel.Name = "telefono";
            colTel.HeaderText = "Telefono";
            colTel.DataPropertyName = "telefono";
            colTel.DisplayIndex = 5;
            this.dgvPersonas.Columns.Add(colTel);

            DataGridViewTextBoxColumn colFec = new DataGridViewTextBoxColumn();
            colFec.Name = "fecha_nac";
            colFec.HeaderText = "Fecha Nacimiento";
            colFec.DataPropertyName = "fecha_nac";
            colFec.DisplayIndex = 6;
            this.dgvPersonas.Columns.Add(colFec);        
            
            DataGridViewTextBoxColumn coltipo_persona = new DataGridViewTextBoxColumn();
            coltipo_persona.Name = "tipo_persona";
            coltipo_persona.HeaderText = "Tipo de Persona";
            coltipo_persona.DataPropertyName = "tipo_persona";
            coltipo_persona.DisplayIndex = 7;
            this.dgvPersonas.Columns.Add(coltipo_persona);

            DataGridViewTextBoxColumn col_desc_plan = new DataGridViewTextBoxColumn();
            col_desc_plan.Name = "desc_plan";
            col_desc_plan.HeaderText = "Plan";
            col_desc_plan.DataPropertyName = "desc_plan";
            col_desc_plan.DisplayIndex = 8;
            this.dgvPersonas.Columns.Add(col_desc_plan);
        }
    }
}
