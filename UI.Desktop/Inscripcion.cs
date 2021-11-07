using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Academia.Entities;
using Academia.Logic;
using Academia.Util;
using Academia.EntityFramework;

namespace UI.Desktop
{
    public partial class Inscripcion : ApplicationForm
    {
        public alumnos_inscripciones InscripcionAlumnoActual { get; set; }
        public personas AlumnoActual { get; set; }
        public cursos CursoActual { get; set; }
        public bool Inscripto { get; set; }
        public InscripcionRepository inscripcionRepository { get; set; }
        public CursoRepository cursoRepository { get; set; }
        private ModoForm _Modo { get; set; }

        public Inscripcion(personas persona, int idCurso,bool inscripto)
        {
            //inscripcionRepository = new InscripcionRepository();
            AlumnoActual = persona;
            this.Inscripto = inscripto;
            cursoRepository = new CursoRepository();
            CursoActual = cursoRepository.Get(idCurso);
            InitializeComponent();
            MapearDeDatos();
            if (inscripto)
            {
                this.inscribirButton.Text = "Eliminar Inscripción";
            }
        }


        public override void MapearDeDatos()
        {
            this.txtLegajo.Text = this.AlumnoActual.legajo.ToString();
            this.txtNombre.Text = this.AlumnoActual.nombre.ToString() + " " + this.AlumnoActual.apellido.ToString();
            this.txtTipoUsuario.Text = this.AlumnoActual.tipo_persona.ToString();
            this.txtComision.Text = this.CursoActual.id_comision.ToString();
            this.txtMateria.Text = this.CursoActual.id_materia.ToString();
        }

        private void inscribirButton_Click(object sender, EventArgs e)
        {
            if (Inscripto)
            {
                this.cursoRepository.EliminarInscripcion(AlumnoActual.id_persona, CursoActual.id_curso);

            }
            else
            {
                this.cursoRepository.Inscribir(AlumnoActual.id_persona, CursoActual.id_curso);

            }
            string msjRespuesta = Inscripto ? "Se Eliminó la inscripcion" : "Se ha inscripto al curso correctamente";
            MessageBox.Show(msjRespuesta);
            this.Inscripto = !Inscripto;

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
