using System;

using System.Windows.Forms;
using Academia.Entities;
using Academia.Util;
using Academia.Logic;
using System.Collections.Generic;
using System.Linq;

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
            comboTipoPersona.DataSource = Enum.GetValues(typeof(TipoPersona));
            PlanesLogic Plan = new PlanesLogic();
            comboPlan.DataSource = Plan.GetAll();

        }



        public PersonaDektop(ModoForm modo) : this()
        {
            // Internamete debe setear a ModoForm en el modo enviado, este constructor
            // servirá para las altas.
            _Modo = modo;
            ModuloLogic ModuloLogic = new ModuloLogic();
            this.PersonaActual = new personas();

            this.Modulos = ModuloLogic.GetAll().ToList();
            ListBox listaModulos = new ListBox();
            listaModulos.DataSource = this.Modulos;
            comboTipoPersona.DataSource = Enum.GetValues(typeof(TipoPersona));
            PlanesLogic Plan = new PlanesLogic();
            comboPlan.DataSource = Plan.GetAll().ToList();
            comboPlan.DisplayMember = "desc_plan";
            comboPlan.ValueMember = "id_plan";


        }
        public PersonaDektop(int ID, ModoForm modo) : this()
        {
            // En este nuevo constructor seteamos el modo que ha sido especificado en
            // el parámetro
           _Modo = modo;



            PlanesLogic Plan = new PlanesLogic();
            comboPlan.DataSource = Plan.GetAll().ToList();
            comboPlan.DisplayMember = "desc_plan";
            comboPlan.ValueMember = "id_plan";

            this.PersonaActual = this.PersonaL.Get(ID);
            this.comboTipoPersona.SelectedIndex =(int) this.PersonaActual.tipo_persona;
            comboPlan.SelectedValue = this.PersonaActual.id_plan; ;
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
            UsuarioLogic usuarioLogic = new UsuarioLogic();

            this.txtID.Text = this.PersonaActual.id_persona.ToString();
            this.txtTelefono.Text = this.PersonaActual.telefono;
            this.txtApellido.Text = this.PersonaActual.apellido;
            this.datePickeFecNac.Value = this.PersonaActual.fecha_nac;
            this.txtEmail.Text = this.PersonaActual.email;
            this.txtLegajo.Text = this.PersonaActual.legajo.ToString();
            this.txtNombre.Text = this.PersonaActual.nombre;
            this.txtDireccion.Text = this.PersonaActual.direccion;


            foreach (var item in this.PersonaActual.usuarios)
            {
                var usuario = usuarioLogic.Get(item.id_usuario);
                usuarios.Add(usuario);
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

            this.PersonaActual.nombre = this.txtTelefono.Text;
            this.PersonaActual.apellido = this.txtApellido.Text;
            this.PersonaActual.fecha_nac = this.datePickeFecNac.Value;
            this.PersonaActual.email = this.txtEmail.Text;
            this.PersonaActual.telefono = this.txtTelefono.Text;
            this.PersonaActual.direccion = this.txtDireccion.Text;



            if (!String.IsNullOrEmpty(this.txtLegajo.Text))
            {
               this.PersonaActual.legajo = Convert.ToInt32(this.txtLegajo.Text);

            }
            this.PersonaActual.nombre = this.txtNombre.Text;
            this.PersonaActual.id_plan =Convert.ToInt32( this.comboPlan.SelectedValue);
            this.PersonaActual.tipo_persona = (TipoPersona)this.comboTipoPersona.SelectedIndex;
            this.PersonaActual.usuarios = (List<usuarios>) this.dgvUsuarios.DataSource;



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
                error_msj += "Telefono\n";
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

            using (var usuariosDesktop = new UsuarioDesktop(ModoForm.Alta,true))
            {
                usuariosDesktop.ShowDialog();
                usuariosDesktop.UsuarioActual.id_persona = this.PersonaActual.id_persona;
                this.usuarios.Add(usuariosDesktop.UsuarioActual);
                this.dgvUsuarios.DataSource = null;
                this.dgvUsuarios.DataSource = this.usuarios;
            }

            



        }

        private void edit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvUsuarios.Rows[this.dgvUsuarios.CurrentRow.Index].Cells[0].Value);
            UsuarioDesktop usuariosDesktop = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            usuariosDesktop.ShowDialog();
            this.usuarios.RemoveAll(x => x.id_usuario == ID);
            this.usuarios.Add(usuariosDesktop.UsuarioActual);
            this.dgvUsuarios.DataSource = null;
            this.dgvUsuarios.DataSource = this.usuarios;


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
