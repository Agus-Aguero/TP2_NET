using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Business.Entities;

namespace Data.Database
{
    public class UsuarioAdapter:Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Usuario> _Usuarios;

        private static List<Usuario> Usuarios
        {
            get
            {
                if (_Usuarios == null)
                {
                    _Usuarios = new List<Business.Entities.Usuario>();
                    Business.Entities.Usuario usr;
                    usr = new Business.Entities.Usuario();
                    usr.ID = 1;
                    usr.State = States.Unmodified;
                    usr.Nombre = "Casimiro";
                    usr.Apellido = "Cegado";
                    usr.NombreUsuario = "casicegado";
                    usr.Clave = "miro";
                    usr.EMail = "casimirocegado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 2;
                    usr.State = States.Unmodified;
                    usr.Nombre = "Armando Esteban";
                    usr.Apellido = "Quito";
                    usr.NombreUsuario = "aequito";
                    usr.Clave = "carpintero";
                    usr.EMail = "armandoquito@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 3;
                    usr.State = States.Unmodified;
                    usr.Nombre = "Alan";
                    usr.Apellido = "Brado";
                    usr.NombreUsuario = "alanbrado";
                    usr.Clave = "abrete sesamo";
                    usr.EMail = "alanbrado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                }
                return _Usuarios;
            }
        }
        #endregion


        #region constructor
        public UsuarioAdapter()
        {
           /*
             * Este connection string es para conectarse con la base de datos academia en el servidor
             * del departamento sistemas desde una PC de los laboratorios de sistemas,
             * si realiza este Laboratorio desde su PC puede probar el siguiente connection string
             * 
             * "Data Source=localhost;Initial Catalog=academia;Integrated Security=true;"
             * 
             * Si realiza esta práctica sobre el MS SQL SERVER 2005 Express Edition entonce debe 
             * utilizar el siguiente connection string
             * 
             * "Data Source=localhost\SQLEXPRESS;Initial Catalog=academia;Integrated Security=true;"
             */

            this.sqlDataAdapter = new SqlDataAdapter("select * from usuarios", this.Conn);

            this.sqlDataAdapter.UpdateCommand =
            new SqlCommand(" UPDATE usuarios " +
            " SET tipo_doc = @tipo_doc, nro_doc = @nro_doc, fecha_nac = @fecha_nac, " +
            " apellido = @apellido, nombre = @nombre, direccion = @direccion, " +
            " telefono = @telefono, email = @email, celular = @celular, usuario = @usuario, " +
            " clave = @clave WHERE id=@id ", this.Conn);
            this.sqlDataAdapter.UpdateCommand.Parameters.Add("@tipo_doc", SqlDbType.Int, 1, "tipo_doc");
            this.sqlDataAdapter.UpdateCommand.Parameters.Add("@nro_doc", SqlDbType.Int, 1, "nro_doc");
            this.sqlDataAdapter.UpdateCommand.Parameters.Add("@fecha_nac", SqlDbType.DateTime, 1, "fecha_nac");
            this.sqlDataAdapter.UpdateCommand.Parameters.Add("@apellido", SqlDbType.VarChar, 50, "apellido");
            this.sqlDataAdapter.UpdateCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "nombre");
            this.sqlDataAdapter.UpdateCommand.Parameters.Add("@direccion", SqlDbType.VarChar, 50, "direccion");
            this.sqlDataAdapter.UpdateCommand.Parameters.Add("@telefono", SqlDbType.VarChar, 50, "telefono");
            this.sqlDataAdapter.UpdateCommand.Parameters.Add("@email", SqlDbType.VarChar, 50, "email");
            this.sqlDataAdapter.UpdateCommand.Parameters.Add("@celular", SqlDbType.VarChar, 50, "celular");
            this.sqlDataAdapter.UpdateCommand.Parameters.Add("@usuario", SqlDbType.VarChar, 50, "usuario");
            this.sqlDataAdapter.UpdateCommand.Parameters.Add("@clave", SqlDbType.VarChar, 50, "clave");
            this.sqlDataAdapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 1, "id");
            this.sqlDataAdapter.InsertCommand =
            new SqlCommand(" INSERT INTO usuarios(tipo_doc,nro_doc,fecha_nac,apellido, " +
                " nombre,direccion,telefono,email,celular,usuario,clave) " +
                " VALUES (@tipo_doc,@nro_doc,@fecha_nac,@apellido,@nombre,@direccion, " +
                " @telefono,@email,@celular, @usuario, @clave  )", this.Conn);
            this.sqlDataAdapter.InsertCommand.Parameters.Add("@tipo_doc", SqlDbType.Int, 1, "tipo_doc");
            this.sqlDataAdapter.InsertCommand.Parameters.Add("@nro_doc", SqlDbType.Int, 1, "nro_doc");
            this.sqlDataAdapter.InsertCommand.Parameters.Add("@fecha_nac", SqlDbType.DateTime, 1, "fecha_nac");
            this.sqlDataAdapter.InsertCommand.Parameters.Add("@apellido", SqlDbType.VarChar, 50, "apellido");
            this.sqlDataAdapter.InsertCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "nombre");
            this.sqlDataAdapter.InsertCommand.Parameters.Add("@direccion", SqlDbType.VarChar, 50, "direccion");
            this.sqlDataAdapter.InsertCommand.Parameters.Add("@telefono", SqlDbType.VarChar, 50, "telefono");
            this.sqlDataAdapter.InsertCommand.Parameters.Add("@email", SqlDbType.VarChar, 50, "email");
            this.sqlDataAdapter.InsertCommand.Parameters.Add("@celular", SqlDbType.VarChar, 50, "celular");
            this.sqlDataAdapter.InsertCommand.Parameters.Add("@usuario", SqlDbType.VarChar, 50, "usuario");
            this.sqlDataAdapter.InsertCommand.Parameters.Add("@clave", SqlDbType.VarChar, 50, "clave");



            this.sqlDataAdapter.DeleteCommand =
                         new SqlCommand(" DELETE FROM usuarios WHERE id=@id ", this.Conn);
            this.sqlDataAdapter.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 1, "id");
        }
      

        #endregion
         

        public List<Usuario> GetAll()
        {
           return new List<Usuario>(Usuarios);
        }
        //se Usa en el ejercicio lab 3.2,ver si lo tenemos que usar en el TP
        public DataTable GetAllDataTable()
        {
            DataTable dtUsuarios = new DataTable();
            this.sqlDataAdapter.Fill(dtUsuarios);
            return dtUsuarios;
        }
        public void GuardarCambios(DataTable dtUsuarios)
        {
            this.sqlDataAdapter.Update(dtUsuarios);
            dtUsuarios.AcceptChanges();
        }
        //se Usa en el ejercicio lab 3.2


        public Business.Entities.Usuario GetOne(int ID)
        {
            return Usuarios.Find(delegate(Usuario u) { return u.ID == ID; });
        }

        public void Delete(int ID)
        {
            Usuarios.Remove(this.GetOne(ID));
        }

        public void Save(Usuario usuario)
        {
            if (usuario.State == States.New)
            {
                int NextID = 0;
                foreach (Usuario usr in Usuarios)
                {
                    if (usr.ID > NextID)
                    {
                        NextID = usr.ID;
                    }
                }
                usuario.ID = NextID + 1;
                Usuarios.Add(usuario);
            }
            else if (usuario.State == States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == States.Modified)
            {
                Usuarios[Usuarios.FindIndex(delegate(Usuario u) { return u.ID == usuario.ID; })]=usuario;
            }
            usuario.State = States.Unmodified;            
        }
    }
}
