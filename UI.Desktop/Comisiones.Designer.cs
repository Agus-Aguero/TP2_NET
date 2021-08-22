
namespace UI.Desktop
{
    partial class Comisiones
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
            this.tcComisiones = new System.Windows.Forms.ToolStripContainer();
            this.tsComisiones = new System.Windows.Forms.ToolStrip();
            this.tlComisiones = new System.Windows.Forms.TableLayoutPanel();
            this.dgvComisiones = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tcComisiones.ContentPanel.SuspendLayout();
            this.tcComisiones.TopToolStripPanel.SuspendLayout();
            this.tcComisiones.SuspendLayout();
            this.tsComisiones.SuspendLayout();
            this.tlComisiones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComisiones)).BeginInit();
            this.SuspendLayout();
            // 
            // tcComisiones
            // 
            // 
            // tcComisiones.ContentPanel
            // 
            this.tcComisiones.ContentPanel.Controls.Add(this.tlComisiones);
            this.tcComisiones.ContentPanel.Size = new System.Drawing.Size(611, 225);
            this.tcComisiones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcComisiones.Location = new System.Drawing.Point(0, 0);
            this.tcComisiones.Name = "tcComisiones";
            this.tcComisiones.Size = new System.Drawing.Size(611, 250);
            this.tcComisiones.TabIndex = 0;
            this.tcComisiones.Text = "toolStripContainer1";
            // 
            // tcComisiones.TopToolStripPanel
            // 
            this.tcComisiones.TopToolStripPanel.Controls.Add(this.tsComisiones);
            // 
            // tsComisiones
            // 
            this.tsComisiones.Dock = System.Windows.Forms.DockStyle.None;
            this.tsComisiones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsComisiones.Location = new System.Drawing.Point(3, 0);
            this.tsComisiones.Name = "tsComisiones";
            this.tsComisiones.Size = new System.Drawing.Size(112, 25);
            this.tsComisiones.TabIndex = 0;
            // 
            // tlComisiones
            // 
            this.tlComisiones.ColumnCount = 2;
            this.tlComisiones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlComisiones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlComisiones.Controls.Add(this.dgvComisiones, 0, 0);
            this.tlComisiones.Controls.Add(this.btnActualizar, 0, 1);
            this.tlComisiones.Controls.Add(this.btnSalir, 1, 1);
            this.tlComisiones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlComisiones.Location = new System.Drawing.Point(0, 0);
            this.tlComisiones.Name = "tlComisiones";
            this.tlComisiones.RowCount = 2;
            this.tlComisiones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlComisiones.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlComisiones.Size = new System.Drawing.Size(611, 225);
            this.tlComisiones.TabIndex = 0;
            // 
            // dgvComisiones
            // 
            this.dgvComisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlComisiones.SetColumnSpan(this.dgvComisiones, 2);
            this.dgvComisiones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComisiones.Location = new System.Drawing.Point(3, 3);
            this.dgvComisiones.Name = "dgvComisiones";
            this.dgvComisiones.Size = new System.Drawing.Size(605, 190);
            this.dgvComisiones.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(452, 199);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(533, 199);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = global::UI.Desktop.Properties.Resources.createIcon;
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(23, 22);
            this.tsbNuevo.Text = "toolStripButton1";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = global::UI.Desktop.Properties.Resources.editIcon;
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(23, 22);
            this.tsbEditar.Text = "toolStripButton2";
            this.tsbEditar.Click += new System.EventHandler(this.tstEditar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = global::UI.Desktop.Properties.Resources.deleteIcon;
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsbEliminar.Text = "toolStripButton3";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // Comisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 250);
            this.Controls.Add(this.tcComisiones);
            this.Name = "Comisiones";
            this.Text = "Comisiones";
            this.tcComisiones.ContentPanel.ResumeLayout(false);
            this.tcComisiones.TopToolStripPanel.ResumeLayout(false);
            this.tcComisiones.TopToolStripPanel.PerformLayout();
            this.tcComisiones.ResumeLayout(false);
            this.tcComisiones.PerformLayout();
            this.tsComisiones.ResumeLayout(false);
            this.tsComisiones.PerformLayout();
            this.tlComisiones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComisiones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcComisiones;
        private System.Windows.Forms.TableLayoutPanel tlComisiones;
        private System.Windows.Forms.DataGridView dgvComisiones;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip tsComisiones;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
    }
}