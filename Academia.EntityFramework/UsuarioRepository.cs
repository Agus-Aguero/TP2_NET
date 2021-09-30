﻿using Academia.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                context.modulos_usuarios.AddRange(entityToUpdate.modulos_usuarios.ToList());
                context.SaveChanges();

            }
        }
        public override usuarios Get(int id)

        {
            using (var context = new Academia())
            {

                return context.usuarios.Where(usu => usu.id_usuario == id)
                                .Include(usus => usus.personas)
                                .Include(usuarios => usuarios.modulos_usuarios).FirstOrDefault();

            }
        }

        public usuarios findByUserName(string username)
        {
            using (var context = new Academia())
            {
                usuarios usuario = context.usuarios
                    .Include(usus => usus.personas)
                    .Where(usu => usu.nombre_usuario == username)
                    .FirstOrDefault();
                return usuario;
            }

        }
        public IEnumerable<alumnos_inscripciones> getInscripcionesAlumno(int alumnoId)
        {
            using (var context = new Academia())
            {
                IEnumerable<alumnos_inscripciones> inscripciones = context.alumnos_inscripciones.Include(insc => insc.personas).
                                                    Include(insc => insc.cursos)
                                                    .Include(ins=>ins.cursos.materias)
                                                    .Where(insc => insc.id_alumno == alumnoId).ToList();
                return inscripciones;
            }
        }
    }
}
