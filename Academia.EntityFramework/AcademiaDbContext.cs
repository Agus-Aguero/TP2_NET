using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Academia.EntityFramework
{
    public partial class AcademiaDbContext : DbContext
    {
        public AcademiaDbContext()
            : base("name=academiaConnectionString")
        {
        }

        public virtual DbSet<alumnos_inscripciones> alumnos_inscripciones { get; set; }
        public virtual DbSet<comisiones> comisiones { get; set; }
        public virtual DbSet<cursos> cursos { get; set; }
        public virtual DbSet<docentes_cursos> docentes_cursos { get; set; }
        public virtual DbSet<especialidades> especialidades { get; set; }
        public virtual DbSet<materias> materias { get; set; }
        public virtual DbSet<modulos> modulos { get; set; }
        public virtual DbSet<modulos_usuarios> modulos_usuarios { get; set; }
        public virtual DbSet<personas> personas { get; set; }
        public virtual DbSet<planes> planes { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<alumnos_inscripciones>()
                .Property(e => e.condicion)
                .IsUnicode(false);

            modelBuilder.Entity<comisiones>()
                .Property(e => e.desc_comision)
                .IsUnicode(false);

            modelBuilder.Entity<comisiones>()
                .HasMany(e => e.cursos)
                .WithRequired(e => e.comisiones)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cursos>()
                .HasMany(e => e.alumnos_inscripciones)
                .WithRequired(e => e.cursos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cursos>()
                .HasMany(e => e.docentes_cursos)
                .WithRequired(e => e.cursos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<especialidades>()
                .Property(e => e.desc_especialidad)
                .IsUnicode(false);

            modelBuilder.Entity<especialidades>()
                .HasMany(e => e.planes)
                .WithRequired(e => e.especialidades)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<materias>()
                .Property(e => e.desc_materia)
                .IsUnicode(false);

            modelBuilder.Entity<materias>()
                .HasMany(e => e.cursos)
                .WithRequired(e => e.materias)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<modulos>()
                .Property(e => e.desc_modulo)
                .IsUnicode(false);

            modelBuilder.Entity<modulos>()
                .Property(e => e.ejecuta)
                .IsUnicode(false);

            modelBuilder.Entity<modulos>()
                .HasMany(e => e.modulos_usuarios)
                .WithRequired(e => e.modulos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<personas>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<personas>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<personas>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<personas>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<personas>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<personas>()
                .HasMany(e => e.alumnos_inscripciones)
                .WithRequired(e => e.personas)
                .HasForeignKey(e => e.id_alumno)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<personas>()
                .HasMany(e => e.docentes_cursos)
                .WithRequired(e => e.personas)
                .HasForeignKey(e => e.id_docente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<planes>()
                .Property(e => e.desc_plan)
                .IsUnicode(false);

            modelBuilder.Entity<planes>()
                .HasMany(e => e.comisiones)
                .WithRequired(e => e.planes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<planes>()
                .HasMany(e => e.materias)
                .WithRequired(e => e.planes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<planes>()
                .HasMany(e => e.personas)
                .WithRequired(e => e.planes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.nombre_usuario)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.clave)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .HasMany(e => e.modulos_usuarios)
                .WithRequired(e => e.usuarios)
                .WillCascadeOnDelete(false);
        }
    }
}
