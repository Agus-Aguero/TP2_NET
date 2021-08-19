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
           // GenerarColumnas();
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
    }
}
