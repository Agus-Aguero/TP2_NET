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
        public UsuarioLogic()
        {
            this.repository = new UsuarioRepository();
        }

        #region Propiedades

        #endregion

        #region Metodos
        public override usuarios Get(int ID)
        {
            return base.Get(ID);
        }
        #endregion

    }
}
