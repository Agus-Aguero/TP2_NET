﻿using Academia.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Academia.Logic;
using Academia.Util;

namespace UI.Desktop
{
    public partial class CursoDesktop : ApplicationForm
    {
        public cursos CursoActual { get; set; }

        private ModoForm _Modo { get; set; }
        public CursoDesktop()
        {
            InitializeComponent();
        }
        public CursoDesktop(ModoForm modo) : this()
        {
            _Modo = modo;
        }
        public CursoDesktop(int ID, ModoForm modo) : this()
        {
            _Modo = modo;
            CursoLogic cursoLogic = new CursoLogic();

            this.CursoActual = cursoLogic.Get(ID);

            MapearDeDatos();
        }
        public override void MapearDeDatos()
        {

            switch (_Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
                default:
                    break;
            }
            this.txtID.Text = this.CursoActual.id_curso.ToString();
            this.txtAnioCalendario.Text = this.CursoActual.anio_calendario.ToString();
            this.txtCupo.Text = this.CursoActual.cupo.ToString();
            this.txtIdComision.Text = this.CursoActual.id_comision.ToString();
            this.txtIdMateria.Text = this.CursoActual.id_materia.ToString();
        }

        public override void MapearADatos()
        {

            switch (this._Modo)
            {
                case ModoForm.Alta:
                    this.CursoActual = new cursos();
                    this.CursoActual.State = States.New;
                    break;
                case ModoForm.Baja:
                    this.CursoActual.State = States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    this.CursoActual.State = States.Modified;
                    break;
            }

            this.CursoActual.anio_calendario = Int32.Parse(this.txtAnioCalendario.Text);
            this.CursoActual.cupo = Int32.Parse(this.txtCupo.Text);
            this.CursoActual.id_materia = Int32.Parse(this.txtIdMateria.Text);
            this.CursoActual.id_comision = Int32.Parse(this.txtIdComision.Text);


        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            CursoLogic cursoLogic = new CursoLogic();

            cursoLogic.Save(CursoActual);
        }

        public override bool Validar()
        {
            bool estado = true;
  
            return estado;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                this.Close();
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
