using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            GenerarColumnas();
            this.dgvUsuarios.AutoGenerateColumns = false;

        }

        private void toolStripContainer1_RightToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        public void Listar()
        {
            UsuarioLogic uLogic = new UsuarioLogic();
            this.dgvUsuarios.AutoGenerateColumns = false;
            //this.dgvUsuarios.DataSource = uLogic.GetAll();
            this.dgvUsuarios.DataSource = uLogic.GetAllDataTable();
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
            UsuarioDesktop formUsuario = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            formUsuario.ShowDialog();
            this.Listar();
        }

        private void tstEditar_Click(object sender, EventArgs e)
        {
            //int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            int ID = 1;
            UsuarioDesktop formUsuario = new UsuarioDesktop(ID,ApplicationForm.ModoForm.Modificacion);
            formUsuario.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;

            UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);
            formUsuario.ShowDialog();
            this.Listar();
        }

        private void GenerarColumnas()
        {


            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "id";
            colId.HeaderText = "ID";
            colId.DataPropertyName = "id";
            colId.DisplayIndex = 0;
            this.dgvUsuarios.Columns.Add(colId);

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.DataPropertyName = "nombre";
            colNombre.DisplayIndex = 0;
            this.dgvUsuarios.Columns.Add(colNombre);

            DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
            colApellido.Name = "apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.DataPropertyName = "apellido";
            colApellido.DisplayIndex = 0;
            this.dgvUsuarios.Columns.Add(colApellido);

            DataGridViewTextBoxColumn colUsuario = new DataGridViewTextBoxColumn();
            colUsuario.Name = "usuario";
            colUsuario.HeaderText = "Usuario";
            colUsuario.DataPropertyName = "usuario";
            colUsuario.DisplayIndex = 0;
            this.dgvUsuarios.Columns.Add(colUsuario);

            DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
            colEmail.Name = "email";
            colEmail.HeaderText = "Email";
            colEmail.DataPropertyName = "email";
            colEmail.DisplayIndex = 0;
            this.dgvUsuarios.Columns.Add(colEmail);

            DataGridViewTextBoxColumn colClave = new DataGridViewTextBoxColumn();
            colClave.Name = "clave";
            colClave.HeaderText = "Clave";
            colClave.DataPropertyName = "clave";
            colClave.DisplayIndex = 0;
            this.dgvUsuarios.Columns.Add(colClave);

        }
    }
}
