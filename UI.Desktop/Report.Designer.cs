
namespace UI.Desktop
{
    partial class Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
           
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.AcademiaDataSet = new UI.Desktop.AcademiaDataSet();
            this.usuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usuariosTableAdapter = new UI.Desktop.AcademiaDataSetTableAdapters.usuariosTableAdapter();
            this.comisionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comisionesTableAdapter = new UI.Desktop.AcademiaDataSetTableAdapters.comisionesTableAdapter();
            this.planesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.planesTableAdapter = new UI.Desktop.AcademiaDataSetTableAdapters.planesTableAdapter();
            this.cursosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cursosTableAdapter = new UI.Desktop.AcademiaDataSetTableAdapters.cursosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.AcademiaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comisionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cursosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "Cursos";
            reportDataSource1.Value = this.usuariosBindingSource;
          
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
   
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Desktop.Resources.Reports.Alumnos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(258, 88);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(449, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // AcademiaDataSet
            // 
            this.AcademiaDataSet.DataSetName = "AcademiaDataSet";
            this.AcademiaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usuariosBindingSource
            // 
            this.usuariosBindingSource.DataMember = "usuarios";
            this.usuariosBindingSource.DataSource = this.AcademiaDataSet;
            // 
            // usuariosTableAdapter
            // 
            this.usuariosTableAdapter.ClearBeforeFill = true;
            // 
            // comisionesBindingSource
            // 
            this.comisionesBindingSource.DataMember = "comisiones";
            this.comisionesBindingSource.DataSource = this.AcademiaDataSet;
            // 
            // comisionesTableAdapter
            // 
            this.comisionesTableAdapter.ClearBeforeFill = true;
            // 
            // planesBindingSource
            // 
            this.planesBindingSource.DataMember = "planes";
            this.planesBindingSource.DataSource = this.AcademiaDataSet;
            // 
            // planesTableAdapter
            // 
            this.planesTableAdapter.ClearBeforeFill = true;
            // 
            // cursosBindingSource
            // 
            this.cursosBindingSource.DataMember = "cursos";
            this.cursosBindingSource.DataSource = this.AcademiaDataSet;
            // 
            // cursosTableAdapter
            // 
            this.cursosTableAdapter.ClearBeforeFill = true;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AcademiaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comisionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cursosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource usuariosBindingSource;
        private AcademiaDataSet AcademiaDataSet;
        private System.Windows.Forms.BindingSource comisionesBindingSource;
        private System.Windows.Forms.BindingSource planesBindingSource;
        private System.Windows.Forms.BindingSource cursosBindingSource;
        private AcademiaDataSetTableAdapters.usuariosTableAdapter usuariosTableAdapter;
        private AcademiaDataSetTableAdapters.comisionesTableAdapter comisionesTableAdapter;
        private AcademiaDataSetTableAdapters.planesTableAdapter planesTableAdapter;
        private AcademiaDataSetTableAdapters.cursosTableAdapter cursosTableAdapter;
    }
}