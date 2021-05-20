using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        public UsuarioLogic()
            {}

        
        public Data.Database.UsuarioAdapter UsuarioData { get; set; }


        #region Metodos
        /*
        public Usuario GetOne(int ID)
        { 

        }*/

        public List<Usuario> GetAll()
        {
                                    // REVISAR SI ESTO ESTA BIEN 

            List<Usuario> usuarios = new List<Usuario>();
            return usuarios;
        }

        public void Save()
        { }

        public void Delete()
        { }

        #endregion

    }
}
