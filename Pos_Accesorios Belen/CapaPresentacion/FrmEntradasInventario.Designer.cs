namespace Pos_Accesorios_Belen.CapaPresentacion
{
    partial class FrmEntradasInventario
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
            this.lblBuscar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboProducto = new System.Windows.Forms.ComboBox();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.dgvEntradasRecientes = new System.Windows.Forms.DataGridView();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntradasRecientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBuscar.Location = new System.Drawing.Point(243, 9);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(316, 32);
            this.lblBuscar.TabIndex = 9;
            this.lblBuscar.Text = "ENTRADAS DE PRODUCTO";
            this.lblBuscar.Click += new System.EventHandler(this.lblBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(25, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 32);
            this.label1.TabIndex = 10;
            this.label1.Text = "PRODUCTO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(476, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 32);
            this.label2.TabIndex = 11;
            this.label2.Text = "CANTIDAD:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(25, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 32);
            this.label3.TabIndex = 12;
            this.label3.Text = "PROVEEDOR:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(491, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 32);
            this.label4.TabIndex = 13;
            this.label4.Text = "FECHA:";
            // 
            // comboProducto
            // 
            this.comboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProducto.FormattingEnabled = true;
            this.comboProducto.Location = new System.Drawing.Point(195, 90);
            this.comboProducto.Name = "comboProducto";
            this.comboProducto.Size = new System.Drawing.Size(261, 40);
            this.comboProducto.TabIndex = 14;
            // 
            // txtProveedor
            // 
            this.txtProveedor.Location = new System.Drawing.Point(195, 175);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(261, 39);
            this.txtProveedor.TabIndex = 16;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(629, 178);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(261, 39);
            this.dtpFecha.TabIndex = 17;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(195, 474);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(281, 44);
            this.btnRegistrar.TabIndex = 18;
            this.btnRegistrar.Text = "Registrar Entrada";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // dgvEntradasRecientes
            // 
            this.dgvEntradasRecientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntradasRecientes.Location = new System.Drawing.Point(195, 243);
            this.dgvEntradasRecientes.Name = "dgvEntradasRecientes";
            this.dgvEntradasRecientes.RowHeadersWidth = 62;
            this.dgvEntradasRecientes.RowTemplate.Height = 28;
            this.dgvEntradasRecientes.Size = new System.Drawing.Size(536, 204);
            this.dgvEntradasRecientes.TabIndex = 19;
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(629, 91);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(120, 39);
            this.nudCantidad.TabIndex = 20;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(619, 475);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(112, 43);
            this.btnCerrar.TabIndex = 22;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FrmEntradasInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(916, 563);
            this.ControlBox = false;
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.dgvEntradasRecientes);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.txtProveedor);
            this.Controls.Add(this.comboProducto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBuscar);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmEntradasInventario";
            this.Text = "FrmEntradasInventario";
            this.Load += new System.EventHandler(this.FrmEntradasInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntradasRecientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboProducto;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.DataGridView dgvEntradasRecientes;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Button btnCerrar;
    }
}