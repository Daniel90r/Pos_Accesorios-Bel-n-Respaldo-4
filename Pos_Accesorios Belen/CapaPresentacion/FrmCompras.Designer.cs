namespace Pos_Accesorios_Belen.CapaPresentacion
{
    partial class FrmCompras
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvCompra = new System.Windows.Forms.DataGridView();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.btnAgregarCompra = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.btnEditar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(398, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "COMPRAS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "PROVEEDOR:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(424, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "PRODUCTO:";
            // 
            // cmbProducto
            // 
            this.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(581, 56);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(240, 40);
            this.cmbProducto.TabIndex = 4;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBuscar.Location = new System.Drawing.Point(844, 57);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(122, 42);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvCompra
            // 
            this.dgvCompra.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompra.Location = new System.Drawing.Point(66, 129);
            this.dgvCompra.Name = "dgvCompra";
            this.dgvCompra.ReadOnly = true;
            this.dgvCompra.RowHeadersWidth = 62;
            this.dgvCompra.RowTemplate.Height = 28;
            this.dgvCompra.Size = new System.Drawing.Size(397, 307);
            this.dgvCompra.TabIndex = 6;
            this.dgvCompra.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompras_CellClick);
            this.dgvCompra.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompras_CellContentDoubleClick);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(523, 129);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersWidth = 62;
            this.dgvDetalle.RowTemplate.Height = 28;
            this.dgvDetalle.Size = new System.Drawing.Size(397, 307);
            this.dgvDetalle.TabIndex = 7;
            // 
            // btnAgregarCompra
            // 
            this.btnAgregarCompra.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAgregarCompra.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAgregarCompra.Location = new System.Drawing.Point(101, 451);
            this.btnAgregarCompra.Name = "btnAgregarCompra";
            this.btnAgregarCompra.Size = new System.Drawing.Size(323, 43);
            this.btnAgregarCompra.TabIndex = 8;
            this.btnAgregarCompra.Text = "REGISTRAR COMPRA";
            this.btnAgregarCompra.UseVisualStyleBackColor = false;
            this.btnAgregarCompra.Click += new System.EventHandler(this.btnRegistrarCompra_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.Location = new System.Drawing.Point(679, 451);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(129, 43);
            this.btnCerrar.TabIndex = 9;
            this.btnCerrar.Text = "CERRAR";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(178, 59);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(240, 40);
            this.cmbProveedor.TabIndex = 10;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(456, 451);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(129, 43);
            this.btnEditar.TabIndex = 11;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Visible = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click_1);
            // 
            // FrmCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(978, 518);
            this.ControlBox = false;
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.cmbProveedor);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnAgregarCompra);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.dgvCompra);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cmbProducto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmCompras";
            this.Text = "COMPRAS";
            this.Load += new System.EventHandler(this.FrmCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvCompra;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Button btnAgregarCompra;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Button btnEditar;
    }
}