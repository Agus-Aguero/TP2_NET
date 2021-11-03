using Academia.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.EntityFramework
{
    public class InscripcionRepository : GenericRepository<alumnos_inscripciones>
    {
        //public override void Update(alumnos_inscripciones entityToUpdate)
        //{
        //    using (var context = new Academia())
        //    {
        //        var usuario = this.Get(entityToUpdate.id_inscripcion);
        //        //usuario = entityToUpdate;
        //        //ModuloUsuarioRepository moduloUsuarioRepository = new ModuloUsuarioRepository();

        //        //context.usuarios.AddOrUpdate(usuario);
        //        //context.SaveChanges();
        //        //foreach (var mod in usuario.modulos_usuarios)
        //        //{
        //        //    moduloUsuarioRepository.Update(mod);
        //        //}
        //    }
        //}


        public List<alumnos_inscripciones> GetInscripcionesByAlumno(int idAlumno)
        {
            try
            {
                using (var context = new Academia())
                {
                    var inscripciones = context.alumnos_inscripciones.
                        Include(insc => insc.cursos).
                        Where(insc => insc.id_alumno == idAlumno).ToList();
                    return inscripciones;
                }
            } catch
            {
                return null;
            }
         
        }
    }
}
