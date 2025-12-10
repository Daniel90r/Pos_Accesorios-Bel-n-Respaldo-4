namespace Pos_Accesorios_Belen.CapaPresentacion
{
    partial class FrmHistorialInventario
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
            this.lblInicio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.comboTodos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.TIPO = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lblInicio.Location = new System.Drawing.Point(287, 33);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(441, 45);
            this.lblInicio.TabIndex = 9;
            this.lblInicio.Text = "HISTORIAL DE INVANTARIO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(12, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 32);
            this.label1.TabIndex = 10;
            this.label1.Text = "DESDE:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(398, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 32);
            this.label2.TabIndex = 11;
            this.label2.Text = "HASTA:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(114, 138);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(263, 39);
            this.dtpDesde.TabIndex = 12;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(502, 138);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(264, 39);
            this.dtpHasta.TabIndex = 13;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Black;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(797, 171);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(157, 53);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(114, 293);
            this.dgvHistorial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersWidth = 62;
            this.dgvHistorial.Size = new System.Drawing.Size(689, 230);
            this.dgvHistorial.TabIndex = 15;
            // 
            // comboTodos
            // 
            this.comboTodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTodos.FormattingEnabled = true;
            this.comboTodos.Location = new System.Drawing.Point(114, 210);
            this.comboTodos.Name = "comboTodos";
            this.comboTodos.Size = new System.Drawing.Size(263, 40);
            this.comboTodos.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(7, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 32);
            this.label3.TabIndex = 18;
            this.label3.Text = "TODOS:";
            // 
            // comboTipo
            // 
            this.comboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Location = new System.Drawing.Point(502, 213);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(263, 40);
            this.comboTipo.TabIndex = 19;
            // 
            // TIPO
            // 
            this.TIPO.AutoSize = true;
            this.TIPO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TIPO.Location = new System.Drawing.Point(398, 213);
            this.TIPO.Name = "TIPO";
            this.TIPO.Size = new System.Drawing.Size(69, 32);
            this.TIPO.TabIndex = 20;
            this.TIPO.Text = "TIPO";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.Location = new System.Drawing.Point(822, 480);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(112, 43);
            this.btnCerrar.TabIndex = 21;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FrmHistorialInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(966, 577);
            this.ControlBox = false;
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.TIPO);
            this.Controls.Add(this.comboTipo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboTodos);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblInicio);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmHistorialInventario";
            this.Text = "HistorialInventario";
            this.Load += new System.EventHandler(this.FrmHistorialInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.ComboBox comboTodos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboTipo;
        private System.Windows.Forms.Label TIPO;
        private System.Windows.Forms.Button btnCerrar;
    }
}