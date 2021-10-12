using System;

using System.Windows.Forms;
using Academia.Entities;
using Academia.Util;
using Academia.Logic;
using System.Collections.Generic;

namespace UI.Desktop
{
    public partial class PersonaDektop: ApplicationForm
    {
        public personas PersonaActual { get; set; }
        public List<usuarios> usuarios { get; set; }

        protected PersonaLogic PersonaL;
        public IEnumerable<modulos>  Modulos { get; set; }


        private ModoForm _Modo { get; set; }

        public PersonaDektop()
        {
            InitializeComponent();
            PersonaL = new PersonaLogic();
            usuarios = new List<usuarios>();
            GenerarColumnasUsuarios();

        }



        public PersonaDektop(ModoForm modo) : this()
        {
            // Internamete debe setear a ModoForm en el modo enviado, este constructor
            // servirá para las altas.
            _Modo = modo;
            ModuloLogic ModuloLogic = new ModuloLogic();

            this.Modulos = ModuloLogic.GetAll();
            ListBox listaModulos = new ListBox();
            listaModulos.DataSource = this.Modulos;
            ((ListBox)ModuloListCheck).DataSource = this.Modulos;
            ((ListBox)ModuloListCheck).DisplayMember = "desc_modulo";
            ((ListBox)ModuloListCheck).ValueMember = "id_modulo";
            comboTipoPersona.DataSource = Enum.GetValues(typeof(TipoPersona));     
            

        }
        public PersonaDektop(int ID, ModoForm modo) : this()
        {
            // En este nuevo constructor seteamos el modo que ha sido especificado en
            // el parámetro
           _Modo = modo;




            this.PersonaActual = this.PersonaL.Get(ID);


            MapearDeDatos();
        }

        public override void MapearDeDatos() {

            switch (_Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
                default:
                    break;
            }
            this.txtID.Text = this.PersonaActual.id_persona.ToString();
            this.txtTelefono.Text = this.PersonaActual.nombre;
            this.txtApellido.Text = this.PersonaActual.apellido;
            this.datePickeFecNac.Value = this.PersonaActual.fecha_nac;
            this.txtEmail.Text = this.PersonaActual.email;
            this.txtLegajo.Text = this.PersonaActual.legajo.ToString();
            this.txtNombre.Text = this.PersonaActual.nombre;
            foreach (var item in this.PersonaActual.usuarios)
            {
                usuarios.Add(item);
            }
            this.dgvUsuarios.AutoGenerateColumns = false;
            this.dgvUsuarios.DataSource = usuarios;







        }
        public override void MapearADatos()
        {

            switch (this._Modo)
            {
                case ModoForm.Alta:
                    this.PersonaActual = new personas();
                    this.PersonaActual.State = States.New;
                    break;
                case ModoForm.Baja:
                    this.PersonaActual.State = States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    this.PersonaActual.State = States.Modified;
                    break;
            }
            this.PersonaActual.State = this._Modo == ModoForm.Alta ? States.New : States.Modified;
         
        
          

    }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            

            PersonaL.Save(PersonaActual);

        }

        public override bool Validar() 
        {
            bool estado=true;
            string error_msj="Completar:\n";
            if (this.txtNombre.Text == String.Empty)
            {
                estado = false;
                error_msj+= "Nombre\n";
            }

            if (this.txtApellido.Text == String.Empty)
            {
                estado = false;
                error_msj += "Apellido\n";
            }

            if (this.txtTelefono.Text == String.Empty)
            {
                estado = false;
                error_msj += "personas\n";
            }

            if (!IsValidEmail(this.txtEmail.Text)) //this.txtEmail.Text == String.Empty)
            {
                error_msj+= String.IsNullOrEmpty(this.txtEmail.Text) ? "Email\n" : "Email no valido\n";
                estado = false;             
            }

            //if (String.IsNullOrEmpty(this.txtClave.Text)|| this.txtClave.Text.Length<= 8 || this.txtClave.Text != this.txtLegajo.Text )
            //{
            //    error_msj += String.IsNullOrEmpty(this.txtClave.Text) ? "Clave\n" : this.txtClave.Text.Length <= 8 ?
            //        "Debe tener mas de 8" : "Debe coincidir con Confirmar Clave"; 
            //    estado = false;
            //}

            if (!estado)
            {
                Notificar(error_msj, MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }

            return estado; 
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
           if (Validar())
            {
                GuardarCambios();
                this.Close();
            }

           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void create_Click(object sender, EventArgs e)
        {
            //this.usuarios.Add(new usuarios());
            //this.dgvUsuarios.DataSource = null;
            //this.dgvUsuarios.DataSource = this.usuarios;

            using (var usuariosDesktop = new UsuarioDesktop(ModoForm.Alta))
            {
                usuariosDesktop.ShowDialog();
                this.usuarios.Add(usuariosDesktop.UsuarioActual);
                this.dgvUsuarios.DataSource = null;
                this.dgvUsuarios.DataSource = this.usuarios;
            }

            



        }

        private void edit_Click(object sender, EventArgs e)
        {

        }

        private void delete_Click(object sender, EventArgs e)
        {

        }
        private void GenerarColumnasUsuarios()
        {


            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "id";
            colId.HeaderText = "ID";
            colId.DataPropertyName = "id_usuario";
            colId.DisplayIndex = 0;
            colId.ReadOnly = true;
            this.dgvUsuarios.Columns.Add(colId);


      

            DataGridViewTextBoxColumn colUsuario = new DataGridViewTextBoxColumn();
            colUsuario.Name = "usuario";
            colUsuario.HeaderText = "Usuario";
            colUsuario.DataPropertyName = "nombre_usuario";
            colUsuario.DisplayIndex = 0;
            colUsuario.ReadOnly = false;
            this.dgvUsuarios.Columns.Add(colUsuario);



            DataGridViewTextBoxColumn colClave = new DataGridViewTextBoxColumn();
            colClave.Name = "clave";
            colClave.HeaderText = "Clave";
            colClave.DataPropertyName = "clave";
            colClave.DisplayIndex = 0;
            this.dgvUsuarios.Columns.Add(colClave);

            DataGridViewCheckBoxColumn colHabilitado = new DataGridViewCheckBoxColumn();
            colHabilitado.Name = "habilitado";
            colHabilitado.HeaderText = "Habilitado";
            colHabilitado.DataPropertyName = "Habilitado";
            colHabilitado.DisplayIndex = 0;
            this.dgvUsuarios.Columns.Add(colHabilitado);

        }
    }
}
