using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.EntityFramework;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic<usuarios>
    {
        

        public UsuarioLogic()
        {
            
            UsuarioAdapter usuarioData = new UsuarioAdapter();
            UsuarioData = usuarioData;
        }


        #region Propiedades
        public Data.Database.UsuarioAdapter UsuarioData { get; set; }

        #endregion

        #region Metodos
        
        public Usuario GetOne(int ID)
        {
            
            return UsuarioData.GetOne(ID);
        }

        public List<usuarios> GetAll()
        {
            var Usuarios = this.repository.GetAll();
            return Usuarios.ToList();
        }
        public DataTable GetAllDataTable()
        {
            return UsuarioData.GetAllDataTable();
        }
        public void GuardarCambios(DataTable dataTable)
        {
             UsuarioData.GuardarCambios(dataTable);
        }

        public void Save(Usuario usuario )
        {
            var user = new usuarios();
            user.apellido = usuario.Apellido;
            user.nombre = usuario.Nombre;
            user.id_usuario = usuario.ID;
            user.nombre_usuario = usuario.NombreUsuario;
            user.clave = usuario.Clave;
            user.email = usuario.EMail;
            user.habilitado = usuario.Habilitado;

            switch (usuario.State)
            {
                case States.New:
                    repository.Insert(user);
                    break;
                case States.Deleted:
                    repository.Delete(user);
                    break;
                case States.Modified:
                    repository.Update(user);
                    break;
                default:
                    break;
            }

            if (usuario.State== States.New)
            {
                repository.Insert(user);
            }
            UsuarioData.Save(usuario);
        }

        public void Delete(int ID)
        {
            UsuarioData.Delete(ID);
        }

        #endregion

    }
}
