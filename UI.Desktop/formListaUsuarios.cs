using Academia.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class formListaUsuarios : Form
    {
        protected UsuarioLogic _usuarios;
        public UsuarioLogic oUsuario
        {
            get { return _usuarios; }
            set { _usuarios = value; }
        }
        public formListaUsuarios()
        {
            InitializeComponent();
            this.oUsuario = new UsuarioLogic();
            //this.dgvUsuarios.DataSource = this.oUsuario.GetAllDataTable();

        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            this.GuardarCambios();
            this.RecargarGrilla();
        }
              

        private void RecargarGrilla()
        {
            this.dgvUsuarios.DataSource = this.oUsuario.GetAll();
        }

        private void GuardarCambios()
        {
            this.oUsuario.GuardarCambios((DataTable)this.dgvUsuarios.DataSource);
        }

    }
}
