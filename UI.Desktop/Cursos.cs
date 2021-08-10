﻿using Academia.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Cursos : Form
    {
        public Cursos()
        {
            InitializeComponent();
            GenerarColumnas();
            this.dgvCursos.AutoGenerateColumns = false;

        }

        public void Listar()
        {
            CursoLogic cLogic = new CursoLogic();
            this.dgvCursos.AutoGenerateColumns = false;
            this.dgvCursos.DataSource = cLogic.GetAll();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            CursoDesktop formEspecialidad = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            formEspecialidad.ShowDialog();
            this.Listar();
        }

        private void tstEditar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvCursos.Rows[this.dgvCursos.CurrentRow.Index].Cells[0].Value);
            CursoDesktop formEspecialidad = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formEspecialidad.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(this.dgvCursos.Rows[this.dgvCursos.CurrentRow.Index].Cells[0].Value);

            CursoDesktop formEspecialidad = new CursoDesktop(ID, ApplicationForm.ModoForm.Baja);
            formEspecialidad.ShowDialog();
            this.Listar();
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void GenerarColumnas()
        {
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "id";
            colId.HeaderText = "ID";
            colId.DataPropertyName = "id_curso";
            colId.DisplayIndex = 0;
            this.dgvCursos.Columns.Add(colId);

            DataGridViewTextBoxColumn colAnioCalendario = new DataGridViewTextBoxColumn();
            colAnioCalendario.Name = "anioCalendario";
            colAnioCalendario.HeaderText = "Año calendario";
            colAnioCalendario.DataPropertyName = "anio_calendario";
            colAnioCalendario.DisplayIndex = 0;
            this.dgvCursos.Columns.Add(colAnioCalendario);

            DataGridViewTextBoxColumn colCupo = new DataGridViewTextBoxColumn();
            colCupo.Name = "cupo";
            colCupo.HeaderText = "Cupo";
            colCupo.DataPropertyName = "cupo";
            colCupo.DisplayIndex = 0;
            this.dgvCursos.Columns.Add(colCupo);

            DataGridViewTextBoxColumn colIdMateria = new DataGridViewTextBoxColumn();
            colIdMateria.Name = "materia";
            colIdMateria.HeaderText = "Materia";
            colIdMateria.DataPropertyName = "id_materia";
            colIdMateria.DisplayIndex = 0;
            this.dgvCursos.Columns.Add(colIdMateria);

            DataGridViewTextBoxColumn colIComision = new DataGridViewTextBoxColumn();
            colIComision.Name = "comision";
            colIComision.HeaderText = "Comisión";
            colIComision.DataPropertyName = "id_comision";
            colIComision.DisplayIndex = 0;
            this.dgvCursos.Columns.Add(colIComision);
        }
    }
}
