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
           //return new List<Usuario>(Usuarios);
            try
            {

                List<Usuario> usuarios = new List<Usuario>();
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("Select * From usuarios", this._conn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();


                while (drUsuarios.Read())
                {
                    /*
                     *Creamos un objeto Usuario de la capa de entidades par coipiar
                     *lo datos de la fila del DataReader al objeto de entidades
                     */

                Usuario usr = new Usuario();

                usr.ID = (int)drUsuarios["id_usuarios"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];

                    usuarios.Add(usr);
                }
                //cerramos el DataReade y la conexcion a la BD
                drUsuarios.Close();
                this.CloseConnection();
                // devolvemos el objeto
                return usuarios;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }

         
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


        public Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("Select * From usuarios", this._conn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();


                while (drUsuarios.Read())
                {
                    /*
                     *Creamos un objeto Usuario de la capa de entidades par coipiar
                     *lo datos de la fila del DataReader al objeto de entidades
                     */


                    usr.ID = (int)drUsuarios["id_usuarios"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];

                }
                //cerramos el DataReade y la conexcion a la BD
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }

        public void Delete(int ID)
        {
            // Usuarios.Remove(this.GetOne(ID));

            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete =
                    new SqlCommand("delete usuarios where id_usuario=@id", _conn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }



        public void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave =
                   new SqlCommand("UPDATE usuarios SET nombre_usuario=@nombre_usuario,clave=@clave,"
                   +"habilitado=@habilitado,nombre=@nombre,apellido=@apellido,email=@email"+
                   "where @id=id_usuario"
                   , _conn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar).Value = usuario.EMail;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al editar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "insert into usuarios(nombre_usuario,clave,habilitado,nombre,apellido,email) " +
                    "values(@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email) " +
                    "select @@identity",
                    _conn);
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.VarChar, 50).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.EMail;
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save (Usuario usuario)
        {
            if (usuario.State == States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if(usuario.State == States.New)
            {
                this.Update(usuario);
            }
            else if (usuario.State == States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = States.Unmodified;
        }

       /* public void Save(Usuario usuario)
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
        }*/
    }
}
