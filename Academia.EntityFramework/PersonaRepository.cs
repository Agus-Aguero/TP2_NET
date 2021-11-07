using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Entities;

namespace Academia.EntityFramework
{
    public class PersonaRepository : GenericRepository<personas>
    {
        public personas GetByLegajo(int nroLegajo)
        {
            using (var context = new Academia())
            {
                return context.personas.Where(per => per.legajo == nroLegajo).FirstOrDefault();
            }
        }
        public override IEnumerable<personas> GetAll()
        {
            using (var context = new Academia())
            {
                return context.personas.Include(per => per.planes)
                                       .Include(per => per.usuarios).ToList();

            }
        }
        public override personas Get(int id)
        {
            using (var context = new Academia())
            {
                return context.personas.Include(per => per.planes)
                                       .Include(per => per.usuarios)
                                       .Include(per=>per.alumnos_inscripciones)
                                       .Include(per=>per.docentes_cursos)
                                       .Where(per => per.id_persona == id)
                                       .FirstOrDefault();
            
            }
        }
        public  override void Update(personas entityToUpdate)
        {
            try
            {
                
                using (var context = new Academia())
                {
                    var transaction = context.Database.BeginTransaction();
                    context.personas.AddOrUpdate(entityToUpdate);

                    context.SaveChanges();
                  
                    var usuRepo = new UsuarioRepository();
                   
                    foreach (var usuarioUdpdate in entityToUpdate.usuarios)
                    {
                        usuRepo.Update(usuarioUdpdate);
                    }
                    context.SaveChanges();
                    transaction.Commit();

                }


            }
            catch (Exception ex)
            {

            }
        }
        public override void Insert(personas entity)
        {
            entity.legajo = this.getLastLegajo();   
            base.Insert(entity);
        }
        public int getLastLegajo()
        {
            int Legajo;
            using (var context = new Academia())
            {
                var persona=context.personas.OrderByDescending(per => per.legajo).FirstOrDefault();
                if (persona != null)
                {
                    Legajo = (int)(persona.legajo!=null ? persona.legajo+1 : 1);
                }
                else
                {
                    Legajo = 1;

                }

            }
            return Legajo;
        }

        public void UpdateMVC(personas persona)
        {
            try
            {
                using (var context = new Academia())
                {
                    context.personas.AddOrUpdate(persona);
                    context.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {

            }
        }

    }    
}
