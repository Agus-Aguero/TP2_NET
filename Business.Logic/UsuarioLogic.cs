using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        /*public UsuarioLogic( Data.Database.UsuarioAdapter usuarioData)
        {

            UsuarioData = usuarioData;

        }*/ // REVISAR

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

        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();
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
            UsuarioData.Save(usuario);
        }

        public void Delete(int ID)
        {
            UsuarioData.Delete(ID);
        }

        #endregion

    }
}
