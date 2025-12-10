using Pos_Accesorios_Belen.CapaDatos;
using Pos_Accesorios_Belen.CapaEntidades;
using Pos_Accesorios_Belen.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pos_Accesorios_Belen.CapaPresentacion
{
    public partial class FrmGestionCompra : Form
    {
        // ============================
        // VARIABLES GLOBALES (única fuente de verdad para el ID)
        // ============================
        private CompraBLL compraBLL = new CompraBLL();
        private DetalleCompraBLL2 detalleBLL = new DetalleCompraBLL2();
        private ProductoBLL2 productoBLL = new ProductoBLL2();

        private int currentCompraID = 0;   // 0 = nuevo registro / >0 = editar
        private decimal totalGeneral = 0m;
        private bool esModoEdicion = false;
        public FrmGestionCompra()
        {
            InitializeComponent();
            
        }
        //      VARIABLES DE APOYO
        // =============================
        private int compraSeleccionadaID = 0;

        private void FrmGestionCompra_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            CargarMetodoPago();
            CargarProductos();

            lblTotal.Text = "0.00";
            dgvDetalle.AutoGenerateColumns = false; // Importante: columnas definidas en designer
            ConfigurarColumnasDetalle();
            AjustarBotonesModo();

        }
        private void ConfigurarColumnasDetalle()
        {
            dgvDetalle.Columns.Clear();

            // ===============================
            // 1. Columna ProductoID (oculta)
            // ===============================
            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.Name = "ProductoID";
            colID.HeaderText = "ID";
            colID.Visible = false;
            dgvDetalle.Columns.Add(colID);

            // ===============================
            // 2. Nombre del producto
            // ===============================
            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "NombreProducto";
            colNombre.HeaderText = "Producto";
            colNombre.Width = 200;
            dgvDetalle.Columns.Add(colNombre);

            // ===============================
            // 3. Precio de compra
            // ===============================
            DataGridViewTextBoxColumn colPrecio = new DataGridViewTextBoxColumn();
            colPrecio.Name = "PrecioCompra";
            colPrecio.HeaderText = "Precio ($)";
            colPrecio.DefaultCellStyle.Format = "0.00";
            dgvDetalle.Columns.Add(colPrecio);

            // ===============================
            // 4. Cantidad
            // ===============================
            DataGridViewTextBoxColumn colCantidad = new DataGridViewTextBoxColumn();
            colCantidad.Name = "Cantidad";
            colCantidad.HeaderText = "Cantidad";
            dgvDetalle.Columns.Add(colCantidad);

            // ===============================
            // 5. SubTotal
            // ===============================
            DataGridViewTextBoxColumn colSub = new DataGridViewTextBoxColumn();
            colSub.Name = "SubTotal";
            colSub.HeaderText = "SubTotal ($)";
            colSub.DefaultCellStyle.Format = "0.00";
            dgvDetalle.Columns.Add(colSub);
        }

        public void CargarCompra(int compraId)
        {
            currentCompraID = compraId;
            esModoEdicion = true;
            AjustarBotonesModo();

            // Usamos DAL directamente para traer la compra (puedes cambiar a BLL si lo deseas)
            var compra = CompraDAL.ObtenerCompras().FirstOrDefault(x => x.CompraID == compraId);
            if (compra == null)
            {
                MessageBox.Show("La compra no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cargar datos de compra en controles
            cmbProveedor.SelectedValue = compra.ProveedorID;
            dtpFecha.Value = compra.Fecha;
            // Si el método no existe en el combo, dejamos el texto (por seguridad)
            if (!string.IsNullOrWhiteSpace(compra.MetodoPago))
            {
                if (cmbMetodoPago.Items.Contains(compra.MetodoPago))
                    cmbMetodoPago.Text = compra.MetodoPago;
                else
                    cmbMetodoPago.Text = compra.MetodoPago;
            }
            else
            {
                cmbMetodoPago.SelectedIndex = -1;
            }

            txtObservaciones.Text = compra.Observaciones ?? string.Empty;
            lblTotal.Text = compra.TotalCompra.ToString("0.00");

            // Cargar detalle
            CargarDetalle(compra.CompraID);
        }

        private void CargarDetalle(int compraID)
        {
            dgvDetalle.Rows.Clear();

            var detalles = DetalleCompraDAL.ObtenerDetallePorCompra(compraID);

            foreach (var d in detalles)
            {
                dgvDetalle.Rows.Add(
                    d.ProductoID,
                    d.NombreProducto,
                    d.PrecioCompra,
                    d.Cantidad,
                    d.SubTotal
                );
            }

            CalcularTotalGeneral();
        }

        // ============================
        // CARGA DE COMBOS
        // ============================
        private void CargarProveedores()
        {
            try
            {
                var lista = ProveedorBLL.ObtenerProveedores();
                cmbProveedor.DataSource = lista;
                cmbProveedor.DisplayMember = "Nombre";
                cmbProveedor.ValueMember = "ProveedorID";
                cmbProveedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarMetodoPago()
        {
            try
            {
                // Cargar manualmente (como acordamos)
                var lista = new[] { "-- Seleccione --", "Efectivo", "Tarjeta", "Transferencia" };
                cmbMetodoPago.DataSource = lista;
                cmbMetodoPago.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar métodos de pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProductos()
        {
            try
            {
                var lista = ProductoBLL2.ObtenerProductos();
                cmbProducto.DataSource = lista;
                cmbProducto.DisplayMember = "Nombre";
                cmbProducto.ValueMember = "Id";
                cmbProducto.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================
        // VALIDACIONES
        // ============================
        private bool ValidarCampos()
        {
            if (cmbProveedor.SelectedIndex == -1 || Convert.ToInt32(cmbProveedor.SelectedValue) == 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbMetodoPago.SelectedIndex <= 0)
            {
                MessageBox.Show("Debe seleccionar un método de pago.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dgvDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.IsNewRow) continue;

                if (!int.TryParse(row.Cells["Cantidad"].Value.ToString(), out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Hay productos con cantidad inválida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!decimal.TryParse(row.Cells["PrecioCompra"].Value.ToString(), out decimal precio) || precio <= 0)
                {
                    MessageBox.Show("Hay productos con precio inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        // ============================
        // CÁLCULOS Y UTILIDADES
        // ============================
        private void CalcularTotalGeneral()
        {
            totalGeneral = 0m;

            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.IsNewRow) continue;
                totalGeneral += Convert.ToDecimal(row.Cells["SubTotal"].Value);
            }

            lblTotal.Text = totalGeneral.ToString("0.00");
        }

        private void AjustarBotonesModo()
        {
            btnGuardar.Enabled = !esModoEdicion;
            btnActualizar.Enabled = esModoEdicion;
            btnEliminar.Enabled = esModoEdicion;
        }

        private void LimpiarFormulario()
        {
            currentCompraID = 0;
            esModoEdicion = false;

            cmbProveedor.SelectedIndex = -1;
            cmbMetodoPago.SelectedIndex = 0;
            cmbProducto.SelectedIndex = -1;
            txtObservaciones.Clear();
            dtpFecha.Value = DateTime.Now;

            dgvDetalle.Rows.Clear();
            lblTotal.Text = "0.00";

            CalcularTotalGeneral();
            AjustarBotonesModo();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // ===== VALIDACIONES =====
            if (cmbProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrecioCompra.Text) ||
                !decimal.TryParse(txtPrecioCompra.Text, out decimal precio))
            {
                MessageBox.Show("Ingrese un precio válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productoID = Convert.ToInt32(cmbProducto.SelectedValue);
            string nombreProducto = cmbProducto.Text;
            int cantidad = Convert.ToInt32(nudCantidad.Value);
            decimal precioCompra = precio;

            // ===== EVITAR PRODUCTOS DUPLICADOS =====
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (Convert.ToInt32(row.Cells["ProductoID"].Value) == productoID)
                {
                    MessageBox.Show("El producto ya está agregado.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // ===== CALCULAR SUBTOTAL =====
            decimal subTotal = precioCompra * cantidad;

            // ===== AGREGAR FILA AL DGV =====
            dgvDetalle.Rows.Add(
                productoID,
                nombreProducto,
                precioCompra.ToString("0.00"),
                cantidad,
                subTotal.ToString("0.00")
            );

            // ===== ACTUALIZAR TOTAL GENERAL =====
            CalcularTotalGeneral();

            // ===== LIMPIAR ENTRADAS =====
            cmbProducto.SelectedIndex = -1;
            txtPrecioCompra.Clear();
            nudCantidad.Value = 1;
        }
        

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una fila para quitar.", "Quitar producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvDetalle.Rows.RemoveAt(dgvDetalle.SelectedRows[0].Index);
            CalcularTotalGeneral();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            // Construir objeto compra
            Compra compra = new Compra
            {
                CompraID = 0,
                ProveedorID = Convert.ToInt32(cmbProveedor.SelectedValue),
                Fecha = dtpFecha.Value,
                TotalCompra = totalGeneral,
                MetodoPago = cmbMetodoPago.Text,
                Observaciones = txtObservaciones.Text?.Trim()
            };

            try
            {
                // 1) Insertar la cabecera y obtener id
                int newCompraId = CompraDAL.RegistrarCompra(compra);
                if (newCompraId <= 0)
                {
                    MessageBox.Show("Error al registrar la compra (cabecera).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2) Insertar detalles y actualizar stock (en cada iteración)
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    if (row.IsNewRow) continue;

                    var detalle = new DetalleCompra
                    {
                        CompraID = newCompraId,
                        ProductoID = Convert.ToInt32(row.Cells["ProductoID"].Value),
                        Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value),
                        PrecioCompra = Convert.ToDecimal(row.Cells["PrecioCompra"].Value)
                    };

                    bool ins = DetalleCompraDAL.InsertarDetalle(detalle);
                    if (!ins)
                    {
                        // Intentar limpiar la compra para no dejar cabecera huérfana
                        try { CompraDAL.EliminarCompra(newCompraId); } catch { }
                        MessageBox.Show("Error al insertar detalle. Operación revertida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Actualizar stock (SQL directo para garantizar existencia del método)
                    ActualizarStockSQL(detalle.ProductoID, detalle.Cantidad);
                }

                MessageBox.Show("Compra registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la compra: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!esModoEdicion || currentCompraID == 0)
            {
                MessageBox.Show("No hay compra cargada para actualizar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidarCampos()) return;

            // 1) Obtener detalle antiguo para revertir stock
            var detallesAntiguos = DetalleCompraDAL.ObtenerDetallePorCompra(currentCompraID);

            // 2) Revertir stock retirando las cantidades anteriores
            foreach (var d in detallesAntiguos)
                ActualizarStockSQL(d.ProductoID, -d.Cantidad);

            // 3) Actualizar cabecera
            var compra = new Compra
            {
                CompraID = currentCompraID,
                ProveedorID = Convert.ToInt32(cmbProveedor.SelectedValue),
                Fecha = dtpFecha.Value,
                TotalCompra = totalGeneral,
                MetodoPago = cmbMetodoPago.Text,
                Observaciones = txtObservaciones.Text?.Trim()
            };

            bool cabOk = CompraDAL.ActualizarCompra(compra);
            if (!cabOk)
            {
                // Re-aplicar stock antiguo porque la actualización falló
                foreach (var d in detallesAntiguos)
                    ActualizarStockSQL(d.ProductoID, d.Cantidad);

                MessageBox.Show("No se pudo actualizar la compra (cabecera).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4) Eliminar detalles antiguos
            EliminarDetallesAnteriores(currentCompraID);

            // 5) Insertar nuevos detalles y sumar stock
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.IsNewRow) continue;

                var detalle = new DetalleCompra
                {
                    CompraID = currentCompraID,
                    ProductoID = Convert.ToInt32(row.Cells["ProductoID"].Value),
                    Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value),
                    PrecioCompra = Convert.ToDecimal(row.Cells["PrecioCompra"].Value)
                };

                bool ins = DetalleCompraDAL.InsertarDetalle(detalle);
                if (!ins)
                {
                    MessageBox.Show("Error insertando detalle al actualizar. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Intentamos restaurar estado anterior (simple intento)
                    foreach (var d in detallesAntiguos)
                        DetalleCompraDAL.InsertarDetalle(d);
                    foreach (var d in detallesAntiguos)
                        ActualizarStockSQL(d.ProductoID, d.Cantidad);
                    return;
                }

                // Sumar stock con la nueva cantidad
                ActualizarStockSQL(detalle.ProductoID, detalle.Cantidad);
            }

            MessageBox.Show("Compra actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
        }
        private void EliminarDetallesAnteriores(int compraID)
        {
            var detalles = DetalleCompraDAL.ObtenerDetallePorCompra(compraID);

            foreach (var d in detalles)
            {
                DetalleCompraDAL.EliminarDetalle(d.DetalleCompraID);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!esModoEdicion || currentCompraID == 0)
            {
                MessageBox.Show("No hay compra cargada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Eliminar la compra completa? Esto restará del stock las cantidades correspondientes.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            // Antes de borrar, restamos stock (reversamos la compra)
            var detalles = DetalleCompraDAL.ObtenerDetallePorCompra(currentCompraID);
            foreach (var d in detalles)
                ActualizarStockSQL(d.ProductoID, -d.Cantidad);

            bool ok = CompraDAL.EliminarCompra(currentCompraID);
            if (ok)
            {
                MessageBox.Show("Compra eliminada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar la compra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // ============================
        // UTIL: actualizar stock con SQL directo (fallback seguro)
        // ============================
        private void ActualizarStockSQL(int productoId, int cantidadDiferencia)
        {
            // cantidadDiferencia puede ser positiva (sumar) o negativa (restar)
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = "UPDATE Producto SET Stock = Stock + @Cantidad WHERE Id = @ProductoID";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Cantidad", cantidadDiferencia);
                    cmd.Parameters.AddWithValue("@ProductoID", productoId);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}   

