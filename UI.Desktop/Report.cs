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
    public partial class Report : Form
        
    {
        public Academia.Logic.CursoLogic CursoLogic { get; set; }
        public Report()
        {
            InitializeComponent();
            CursoLogic = new Academia.Logic.CursoLogic();
          
            ReportDataSource datasource = new ReportDataSource("Cursos", (CursoLogic.GetAll().ToList()));
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
           

        }

        private void Report_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
