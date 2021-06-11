using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public Usuario UsuarioActual { get; set; }
        public UsuarioDesktop()
        {
            InitializeComponent();
        }
        public UsuarioDesktop(ModoForm modo) : this()
        {
            
        }
        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            UsuarioLogic usuarioLogic= new UsuarioLogic();

           this.UsuarioActual=usuarioLogic.GetOne(ID);
            MapearADatos();
        }

        public override void MapearDeDatos() {
            //completar el mapeo de los demás controles.
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
                }
        public override void MapearADatos() { }
       
        public override void GuardarCambios() { }
     
        public override bool Validar() { return false; }
    }
}
