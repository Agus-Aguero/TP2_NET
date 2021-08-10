using Academia.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.EntityFramework
{
    public class UsuarioRepository:GenericRepository<usuarios>
    {
        public override void Update(usuarios entityToUpdate)
        {
            using (var context=new Academia())
            {
              
                context.usuarios.AddOrUpdate(entityToUpdate);
                context.SaveChanges();

            }
        }
    }
}
