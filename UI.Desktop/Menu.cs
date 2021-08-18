﻿using System;
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
    }
}
