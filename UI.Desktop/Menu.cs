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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.Open = false;
        }
        public bool Open { get; set; }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            PictureBox img = (PictureBox)sender;
            img.BackColor =  Color.FromArgb(220, 110, 40); // this should be pink-ish
            img.Cursor= System.Windows.Forms.Cursors.Hand;


        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            PictureBox img = (PictureBox)sender;
            img.BackColor = Color.Transparent; // this should be pink-ish
            img.Cursor = System.Windows.Forms.Cursors.Default;


        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseHover(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var usuariosForm = new Usuarios();
            usuariosForm.ShowDialog();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            var modulosForm = new Modulos();
            modulosForm.ShowDialog();

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Open = !this.Open;
            if (this.Open)
            {
                this.PanelRight.Width = 300;
            }
            else
            {
                this.PanelRight.Width = 43;
                
            }
        }

        private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            var img = (PictureBox)sender;
            img.BackColor = Color.FromArgb(220, 110, 40); // this should be pink-ish
            img.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void docenteCursolbl_Click(object sender, EventArgs e)
        {
            var docenteCursoForm = new DocentesCursos();
            docenteCursoForm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            var modulos = new Modulos();
            modulos.ShowDialog();
        }

        private void lblUsuarios_Click(object sender, EventArgs e)
        {
            var usuarios = new Usuarios();
            usuarios.ShowDialog();


        }

        private void especialidadLbl_Click(object sender, EventArgs e)
        {
            var especialidades = new Especialidades();
            especialidades.ShowDialog();
        }

        private void lblDocentes_Click(object sender, EventArgs e)
        {
           /* var docente = new Docentes();
            materias.ShowDialog();*/
        }

        private void lblMaterias_Click(object sender, EventArgs e)
        {
            var materias = new Materias();
            materias.ShowDialog();

        }

        private void lblPlanes_Click(object sender, EventArgs e)
        {
            var planes = new Planes();
            planes.ShowDialog();
        }

        private void lblCursos_Click(object sender, EventArgs e)
        {
            var cursos = new Cursos();
            cursos.ShowDialog();
        }

        private void lblComisiones_Click(object sender, EventArgs e)
        {
            var comisiones = new Comisiones();
            comisiones.ShowDialog();
        }
    }
}
