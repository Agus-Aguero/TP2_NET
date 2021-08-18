namespace Academia.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editUsuarios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.alumnos_inscripciones",
                c => new
                    {
                        id_inscripcion = c.Int(nullable: false, identity: true),
                        id_alumno = c.Int(nullable: false),
                        id_curso = c.Int(nullable: false),
                        condicion = c.String(nullable: false, maxLength: 50, unicode: false),
                        nota = c.Int(),
                    })
                .PrimaryKey(t => t.id_inscripcion)
                .ForeignKey("dbo.cursos", t => t.id_curso)
                .ForeignKey("dbo.personas", t => t.id_alumno)
                .Index(t => t.id_alumno)
                .Index(t => t.id_curso);
            
            CreateTable(
                "dbo.cursos",
                c => new
                    {
                        id_curso = c.Int(nullable: false, identity: true),
                        id_materia = c.Int(nullable: false),
                        id_comision = c.Int(nullable: false),
                        anio_calendario = c.Int(nullable: false),
                        cupo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_curso)
                .ForeignKey("dbo.comisiones", t => t.id_comision)
                .ForeignKey("dbo.materias", t => t.id_materia)
                .Index(t => t.id_materia)
                .Index(t => t.id_comision);
            
            CreateTable(
                "dbo.comisiones",
                c => new
                    {
                        id_comision = c.Int(nullable: false, identity: true),
                        desc_comision = c.String(nullable: false, maxLength: 50, unicode: false),
                        anio_especialidad = c.Int(nullable: false),
                        id_plan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_comision)
                .ForeignKey("dbo.planes", t => t.id_plan)
                .Index(t => t.id_plan);
            
            CreateTable(
                "dbo.planes",
                c => new
                    {
                        id_plan = c.Int(nullable: false, identity: true),
                        desc_plan = c.String(nullable: false, maxLength: 50, unicode: false),
                        id_especialidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_plan)
                .ForeignKey("dbo.especialidades", t => t.id_especialidad)
                .Index(t => t.id_especialidad);
            
            CreateTable(
                "dbo.especialidades",
                c => new
                    {
                        id_especialidad = c.Int(nullable: false, identity: true),
                        desc_especialidad = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id_especialidad);
            
            CreateTable(
                "dbo.materias",
                c => new
                    {
                        id_materia = c.Int(nullable: false, identity: true),
                        desc_materia = c.String(nullable: false, maxLength: 50, unicode: false),
                        hs_semanales = c.Int(nullable: false),
                        hs_totales = c.Int(nullable: false),
                        id_plan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_materia)
                .ForeignKey("dbo.planes", t => t.id_plan)
                .Index(t => t.id_plan);
            
            CreateTable(
                "dbo.personas",
                c => new
                    {
                        id_persona = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        apellido = c.String(nullable: false, maxLength: 50, unicode: false),
                        direccion = c.String(maxLength: 50, unicode: false),
                        email = c.String(maxLength: 50, unicode: false),
                        telefono = c.String(maxLength: 50, unicode: false),
                        fecha_nac = c.DateTime(nullable: false),
                        legajo = c.Int(),
                        tipo_persona = c.Int(nullable: false),
                        id_plan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_persona)
                .ForeignKey("dbo.planes", t => t.id_plan)
                .Index(t => t.id_plan);
            
            CreateTable(
                "dbo.docentes_cursos",
                c => new
                    {
                        id_dictado = c.Int(nullable: false, identity: true),
                        id_curso = c.Int(nullable: false),
                        id_docente = c.Int(nullable: false),
                        cargo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_dictado)
                .ForeignKey("dbo.personas", t => t.id_docente)
                .ForeignKey("dbo.cursos", t => t.id_curso)
                .Index(t => t.id_curso)
                .Index(t => t.id_docente);
            
            CreateTable(
                "dbo.usuarios",
                c => new
                    {
                        id_usuario = c.Int(nullable: false, identity: true),
                        nombre_usuario = c.String(nullable: false, maxLength: 50, unicode: false),
                        clave = c.String(nullable: false, maxLength: 50, unicode: false),
                        habilitado = c.Boolean(nullable: false),
                        cambia_clave = c.Boolean(),
                        id_persona = c.Int(),
                    })
                .PrimaryKey(t => t.id_usuario)
                .ForeignKey("dbo.personas", t => t.id_persona)
                .Index(t => t.id_persona);
            
            CreateTable(
                "dbo.modulos_usuarios",
                c => new
                    {
                        id_modulo_usuario = c.Int(nullable: false, identity: true),
                        id_modulo = c.Int(nullable: false),
                        id_usuario = c.Int(nullable: false),
                        alta = c.Boolean(),
                        baja = c.Boolean(),
                        modificacion = c.Boolean(),
                        consulta = c.Boolean(),
                    })
                .PrimaryKey(t => t.id_modulo_usuario)
                .ForeignKey("dbo.modulos", t => t.id_modulo)
                .ForeignKey("dbo.usuarios", t => t.id_usuario)
                .Index(t => t.id_modulo)
                .Index(t => t.id_usuario);
            
            CreateTable(
                "dbo.modulos",
                c => new
                    {
                        id_modulo = c.Int(nullable: false, identity: true),
                        desc_modulo = c.String(maxLength: 50, unicode: false),
                        ejecuta = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id_modulo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.docentes_cursos", "id_curso", "dbo.cursos");
            DropForeignKey("dbo.personas", "id_plan", "dbo.planes");
            DropForeignKey("dbo.usuarios", "id_persona", "dbo.personas");
            DropForeignKey("dbo.modulos_usuarios", "id_usuario", "dbo.usuarios");
            DropForeignKey("dbo.modulos_usuarios", "id_modulo", "dbo.modulos");
            DropForeignKey("dbo.docentes_cursos", "id_docente", "dbo.personas");
            DropForeignKey("dbo.alumnos_inscripciones", "id_alumno", "dbo.personas");
            DropForeignKey("dbo.materias", "id_plan", "dbo.planes");
            DropForeignKey("dbo.cursos", "id_materia", "dbo.materias");
            DropForeignKey("dbo.planes", "id_especialidad", "dbo.especialidades");
            DropForeignKey("dbo.comisiones", "id_plan", "dbo.planes");
            DropForeignKey("dbo.cursos", "id_comision", "dbo.comisiones");
            DropForeignKey("dbo.alumnos_inscripciones", "id_curso", "dbo.cursos");
            DropIndex("dbo.modulos_usuarios", new[] { "id_usuario" });
            DropIndex("dbo.modulos_usuarios", new[] { "id_modulo" });
            DropIndex("dbo.usuarios", new[] { "id_persona" });
            DropIndex("dbo.docentes_cursos", new[] { "id_docente" });
            DropIndex("dbo.docentes_cursos", new[] { "id_curso" });
            DropIndex("dbo.personas", new[] { "id_plan" });
            DropIndex("dbo.materias", new[] { "id_plan" });
            DropIndex("dbo.planes", new[] { "id_especialidad" });
            DropIndex("dbo.comisiones", new[] { "id_plan" });
            DropIndex("dbo.cursos", new[] { "id_comision" });
            DropIndex("dbo.cursos", new[] { "id_materia" });
            DropIndex("dbo.alumnos_inscripciones", new[] { "id_curso" });
            DropIndex("dbo.alumnos_inscripciones", new[] { "id_alumno" });
            DropTable("dbo.modulos");
            DropTable("dbo.modulos_usuarios");
            DropTable("dbo.usuarios");
            DropTable("dbo.docentes_cursos");
            DropTable("dbo.personas");
            DropTable("dbo.materias");
            DropTable("dbo.especialidades");
            DropTable("dbo.planes");
            DropTable("dbo.comisiones");
            DropTable("dbo.cursos");
            DropTable("dbo.alumnos_inscripciones");
        }
    }
}
