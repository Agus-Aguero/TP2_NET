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
    public partial class Usuarios : Form
    {
        public UsuarioLogic uLogic { get; set; }
        public Usuarios()
        {
            InitializeComponent();
            GenerarColumnas();
            this.dgvUsuarios.AutoGenerateColumns = false;
            uLogic = new UsuarioLogic();
        }

        private void toolStripContainer1_RightToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        public void Listar()
        {
            this.dgvUsuarios.AutoGenerateColumns = false;
            this.dgvUsuarios.DataSource =null;
            this.dgvUsuarios.DataSource = uLogic.GetAll();
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
            UsuarioDesktop formUsuario = new UsuarioDesktop(ApplicationForm.ModoForm.Alta,false);
            formUsuario.ShowDialog();
            this.Listar();
        }

        private void tstEditar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvUsuarios.Rows[this.dgvUsuarios.CurrentRow.Index].Cells[0].Value);
            UsuarioDesktop formUsuario = new UsuarioDesktop(ID,ApplicationForm.ModoForm.Modificacion);
            formUsuario.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvUsuarios.Rows[this.dgvUsuarios.CurrentRow.Index].Cells[0].Value);
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desea eliminar el registro?", "Eliminar registro",
                                       MessageBoxButtons.OKCancel);

            if (dialogResult == DialogResult.OK)
            {
                bool rta;
                rta = uLogic.Delete(ID);

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
            colId.HeaderText = "ID";
            colId.DataPropertyName = "id_usuario";
            colId.DisplayIndex = 0;
            this.dgvUsuarios.Columns.Add(colId);

            DataGridViewTextBoxColumn colUsuario = new DataGridViewTextBoxColumn();
            colUsuario.Name = "usuario";
            colUsuario.HeaderText = "Usuario";
            colUsuario.DataPropertyName = "nombre_usuario";
            colUsuario.DisplayIndex = 1;
            this.dgvUsuarios.Columns.Add(colUsuario);

            DataGridViewTextBoxColumn colClave = new DataGridViewTextBoxColumn();
            colClave.Name = "clave";
            colClave.HeaderText = "Clave";
            colClave.DataPropertyName = "clave";
            colClave.DisplayIndex = 2;
            this.dgvUsuarios.Columns.Add(colClave);

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.DataPropertyName = "nombre";
            colNombre.DisplayIndex = 3;
            this.dgvUsuarios.Columns.Add(colNombre);

            DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
            colApellido.Name = "apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.DataPropertyName = "apellido";
            colApellido.DisplayIndex = 4;
            this.dgvUsuarios.Columns.Add(colApellido);

            DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
            colEmail.Name = "email";
            colEmail.HeaderText = "Email";
            colEmail.DataPropertyName = "email";
            colEmail.DisplayIndex = 5;
            this.dgvUsuarios.Columns.Add(colEmail);

            DataGridViewCheckBoxColumn colHabilitado = new DataGridViewCheckBoxColumn();
            colHabilitado.Name = "habilitado";
            colHabilitado.HeaderText = "Habilitado";
            colHabilitado.DataPropertyName = "Habilitado";
            colHabilitado.DisplayIndex = 6;
            this.dgvUsuarios.Columns.Add(colHabilitado);

        }

        private void userGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvUsuarios.Columns[e.ColumnIndex].Index == 2 && e.Value != null)
            {
                dgvUsuarios.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }
    }
}
