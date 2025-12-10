namespace Pos_Accesorios_Belen.CapaPresentacion
{
    partial class FrmGestionCompra
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.gbDatosCompra = new System.Windows.Forms.GroupBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.gbDetalleCompra = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtPrecioCompra = new System.Windows.Forms.TextBox();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gbDatosCompra.SuspendLayout();
            this.gbDetalleCompra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(412, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "GESTION DE COMPRAS";
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblProveedor.Location = new System.Drawing.Point(6, 30);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(135, 28);
            this.lblProveedor.TabIndex = 2;
            this.lblProveedor.Text = "PROVEEDOR:";
            // 
            // gbDatosCompra
            // 
            this.gbDatosCompra.Controls.Add(this.dtpFecha);
            this.gbDatosCompra.Controls.Add(this.lblFecha);
            this.gbDatosCompra.Controls.Add(this.txtObservaciones);
            this.gbDatosCompra.Controls.Add(this.cmbProveedor);
            this.gbDatosCompra.Controls.Add(this.cmbMetodoPago);
            this.gbDatosCompra.Controls.Add(this.lblObservaciones);
            this.gbDatosCompra.Controls.Add(this.lblMetodoPago);
            this.gbDatosCompra.Controls.Add(this.lblProveedor);
            this.gbDatosCompra.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatosCompra.Location = new System.Drawing.Point(12, 57);
            this.gbDatosCompra.Name = "gbDatosCompra";
            this.gbDatosCompra.Size = new System.Drawing.Size(813, 165);
            this.gbDatosCompra.TabIndex = 3;
            this.gbDatosCompra.TabStop = false;
            this.gbDatosCompra.Text = "DATOS DE LA COMPRA";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(514, 62);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 34);
            this.dtpFecha.TabIndex = 10;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFecha.Location = new System.Drawing.Point(509, 27);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(79, 28);
            this.lblFecha.TabIndex = 9;
            this.lblFecha.Text = "FECHA:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(207, 117);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(199, 34);
            this.txtObservaciones.TabIndex = 8;
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(207, 27);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(199, 36);
            this.cmbProveedor.TabIndex = 7;
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Location = new System.Drawing.Point(207, 73);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(199, 36);
            this.cmbMetodoPago.TabIndex = 5;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblObservaciones.Location = new System.Drawing.Point(6, 116);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(177, 28);
            this.lblObservaciones.TabIndex = 4;
            this.lblObservaciones.Text = "OBSERVACIONES:";
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMetodoPago.Location = new System.Drawing.Point(6, 73);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(195, 28);
            this.lblMetodoPago.TabIndex = 3;
            this.lblMetodoPago.Text = "METODO DE PAGO:";
            // 
            // gbDetalleCompra
            // 
            this.gbDetalleCompra.Controls.Add(this.lblTotal);
            this.gbDetalleCompra.Controls.Add(this.btnQuitar);
            this.gbDetalleCompra.Controls.Add(this.btnAgregar);
            this.gbDetalleCompra.Controls.Add(this.txtPrecioCompra);
            this.gbDetalleCompra.Controls.Add(this.nudCantidad);
            this.gbDetalleCompra.Controls.Add(this.cmbProducto);
            this.gbDetalleCompra.Controls.Add(this.label8);
            this.gbDetalleCompra.Controls.Add(this.label7);
            this.gbDetalleCompra.Controls.Add(this.label6);
            this.gbDetalleCompra.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDetalleCompra.Location = new System.Drawing.Point(12, 229);
            this.gbDetalleCompra.Name = "gbDetalleCompra";
            this.gbDetalleCompra.Size = new System.Drawing.Size(813, 210);
            this.gbDetalleCompra.TabIndex = 4;
            this.gbDetalleCompra.TabStop = false;
            this.gbDetalleCompra.Text = "DETALLE COMPRA";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotal.Location = new System.Drawing.Point(358, 80);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(225, 28);
            this.lblTotal.TabIndex = 15;
            this.lblTotal.Text = "TOTAL DE LA COMPRA";
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.Color.Black;
            this.btnQuitar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnQuitar.Location = new System.Drawing.Point(408, 147);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(246, 43);
            this.btnQuitar.TabIndex = 14;
            this.btnQuitar.Text = "QUITAR SELECCIONADO";
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Black;
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAgregar.Location = new System.Drawing.Point(136, 147);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(120, 43);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtPrecioCompra
            // 
            this.txtPrecioCompra.Location = new System.Drawing.Point(603, 30);
            this.txtPrecioCompra.Name = "txtPrecioCompra";
            this.txtPrecioCompra.Size = new System.Drawing.Size(199, 34);
            this.txtPrecioCompra.TabIndex = 11;
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(136, 74);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(120, 34);
            this.nudCantidad.TabIndex = 12;
            // 
            // cmbProducto
            // 
            this.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(136, 27);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(199, 36);
            this.cmbProducto.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(358, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(239, 28);
            this.label8.TabIndex = 5;
            this.label8.Text = "PRECIO DE LA COMPRA:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(9, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 28);
            this.label7.TabIndex = 5;
            this.label7.Text = "CANTIDAD:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(6, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 28);
            this.label6.TabIndex = 11;
            this.label6.Text = "PRODUCTO:";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(831, 72);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.RowHeadersWidth = 62;
            this.dgvDetalle.RowTemplate.Height = 28;
            this.dgvDetalle.Size = new System.Drawing.Size(418, 367);
            this.dgvDetalle.TabIndex = 5;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Black;
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGuardar.Location = new System.Drawing.Point(148, 468);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(160, 43);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.Black;
            this.btnActualizar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnActualizar.Location = new System.Drawing.Point(375, 468);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(180, 43);
            this.btnActualizar.TabIndex = 16;
            this.btnActualizar.Text = "ACTUALIZAR";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Visible = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Black;
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEliminar.Location = new System.Drawing.Point(615, 468);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(162, 43);
            this.btnEliminar.TabIndex = 17;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Black;
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLimpiar.Location = new System.Drawing.Point(828, 468);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(133, 43);
            this.btnLimpiar.TabIndex = 18;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Black;
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.Location = new System.Drawing.Point(1019, 468);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 43);
            this.btnCerrar.TabIndex = 19;
            this.btnCerrar.Text = "CERRAR";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FrmGestionCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1284, 560);
            this.ControlBox = false;
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.gbDetalleCompra);
            this.Controls.Add(this.gbDatosCompra);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmGestionCompra";
            this.Text = "GestionCompra";
            this.Load += new System.EventHandler(this.FrmGestionCompra_Load);
            this.gbDatosCompra.ResumeLayout(false);
            this.gbDatosCompra.PerformLayout();
            this.gbDetalleCompra.ResumeLayout(false);
            this.gbDetalleCompra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.GroupBox gbDatosCompra;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.GroupBox gbDetalleCompra;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtPrecioCompra;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}