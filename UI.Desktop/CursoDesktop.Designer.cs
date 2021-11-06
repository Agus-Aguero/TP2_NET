
namespace UI.Desktop
{
    partial class CursoDesktop
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblAnioCalendario = new System.Windows.Forms.Label();
            this.lblCupo = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtAnioCalendario = new System.Windows.Forms.TextBox();
            this.comboComision = new System.Windows.Forms.ComboBox();
            this.lblIdComision = new System.Windows.Forms.Label();
            this.comboMateria = new System.Windows.Forms.ComboBox();
            this.txtCupo = new System.Windows.Forms.TextBox();
            this.lblIdMateria = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.41667F));
            this.tableLayoutPanel1.Controls.Add(this.lblAnioCalendario, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCupo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtAnioCalendario, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboComision, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblIdComision, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboMateria, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtCupo, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblIdMateria, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblId, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(762, 144);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblAnioCalendario
            // 
            this.lblAnioCalendario.AutoSize = true;
            this.lblAnioCalendario.Location = new System.Drawing.Point(3, 26);
            this.lblAnioCalendario.Name = "lblAnioCalendario";
            this.lblAnioCalendario.Size = new System.Drawing.Size(57, 26);
            this.lblAnioCalendario.TabIndex = 1;
            this.lblAnioCalendario.Text = "año Calendario";
            // 
            // lblCupo
            // 
            this.lblCupo.AutoSize = true;
            this.lblCupo.Location = new System.Drawing.Point(3, 52);
            this.lblCupo.Name = "lblCupo";
            this.lblCupo.Size = new System.Drawing.Size(32, 13);
            this.lblCupo.TabIndex = 2;
            this.lblCupo.Text = "Cupo";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(76, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(265, 20);
            this.txtID.TabIndex = 4;
            // 
            // txtAnioCalendario
            // 
            this.txtAnioCalendario.Location = new System.Drawing.Point(76, 29);
            this.txtAnioCalendario.Name = "txtAnioCalendario";
            this.txtAnioCalendario.Size = new System.Drawing.Size(265, 20);
            this.txtAnioCalendario.TabIndex = 5;
            // 
            // comboComision
            // 
            this.comboComision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboComision.Location = new System.Drawing.Point(76, 81);
            this.comboComision.Name = "comboComision";
            this.comboComision.Size = new System.Drawing.Size(265, 21);
            this.comboComision.TabIndex = 9;
            // 
            // lblIdComision
            // 
            this.lblIdComision.AutoSize = true;
            this.lblIdComision.Location = new System.Drawing.Point(3, 78);
            this.lblIdComision.Name = "lblIdComision";
            this.lblIdComision.Size = new System.Drawing.Size(49, 13);
            this.lblIdComision.TabIndex = 8;
            this.lblIdComision.Text = "Comision";
            // 
            // comboMateria
            // 
            this.comboMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMateria.Location = new System.Drawing.Point(76, 108);
            this.comboMateria.Name = "comboMateria";
            this.comboMateria.Size = new System.Drawing.Size(265, 21);
            this.comboMateria.TabIndex = 10;
            // 
            // txtCupo
            // 
            this.txtCupo.Location = new System.Drawing.Point(76, 55);
            this.txtCupo.Name = "txtCupo";
            this.txtCupo.Size = new System.Drawing.Size(265, 20);
            this.txtCupo.TabIndex = 6;
            // 
            // lblIdMateria
            // 
            this.lblIdMateria.AutoSize = true;
            this.lblIdMateria.Location = new System.Drawing.Point(3, 105);
            this.lblIdMateria.Name = "lblIdMateria";
            this.lblIdMateria.Size = new System.Drawing.Size(42, 13);
            this.lblIdMateria.TabIndex = 7;
            this.lblIdMateria.Text = "Materia";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(3, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Id";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(100, 174);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(197, 174);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // CursoDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 234);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CursoDesktop";
            this.Text = "Curso";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion



        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblAnioCalendario;
        private System.Windows.Forms.Label lblCupo;
        private System.Windows.Forms.Label lblIdMateria;
        private System.Windows.Forms.Label lblIdComision;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtAnioCalendario;
        private System.Windows.Forms.TextBox txtCupo;
        private System.Windows.Forms.ComboBox comboMateria;
        private System.Windows.Forms.ComboBox comboComision;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}