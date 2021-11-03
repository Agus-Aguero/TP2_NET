using Academia.Logic;
using Microsoft.Reporting.WinForms;
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
    public partial class CursoReport : Form
    {
        public CursoLogic cursosLogic { get; set; }
        public CursoReport()
        {
            InitializeComponent();
            cursosLogic = new CursoLogic();
        }

        private void CursoReport_Load(object sender, EventArgs e)
        {
            ReportDataSource datasource = new ReportDataSource("Cursos", (cursosLogic.GetAll().ToList()));
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            this.reportViewer1.RefreshReport();
        }
    }
}
