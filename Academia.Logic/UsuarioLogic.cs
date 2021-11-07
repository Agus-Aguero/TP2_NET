using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Academia.Entities;
using Academia.EntityFramework;
using Academia.Util;

namespace Academia.Logic
{
    public class UsuarioLogic : BusinessLogic<usuarios>
    {
        public UsuarioRepository UsuarioRepository { get; set; }
        public UsuarioLogic()
        {
            this.repository = new UsuarioRepository();
            UsuarioRepository= new UsuarioRepository(); 
        }

        #region Propiedades

        #endregion

        #region Metodos
        public override usuarios Get(int ID)
        {
            return this.repository.Get(ID);
        }
        public usuarios findByUserName(string username)
        {
           return UsuarioRepository.findByUserName(username);
        }
        
        #endregion

    }
}
