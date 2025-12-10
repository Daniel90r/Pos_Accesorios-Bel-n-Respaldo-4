using Pos_Accesorios_Belen.CapaEntidades;
using Pos_Accesorios_Belen.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pos_Accesorios_Belen.CapaPresentacion
{
    public partial class FrmCompras : Form
    {
        private List<Compra> listaCompras = new List<Compra>();
        public FrmCompras()
        {
            InitializeComponent();
        }

        private void FrmCompras_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarCompras();   // muestra todas las compras al iniciar
        }
        // ==========================================================
        // 2. CARGAR COMBOS
        // ==========================================================
        private void CargarCombos()
        {
            // ----- Combo Proveedores -----
            var proveedores = ProveedorBLL.ObtenerProveedores();

            cmbProveedor.DataSource = proveedores;
            cmbProveedor.DisplayMember = "Nombre";
            cmbProveedor.ValueMember = "ProveedorID";

            // Añadir opción "TODOS"
            proveedores.Insert(0, new Proveedor { ProveedorID = 0, Nombre = "Todos" });

            cmbProveedor.DataSource = proveedores;
            cmbProveedor.DisplayMember = "Nombre";
            cmbProveedor.ValueMember = "ProveedorID";
            cmbProveedor.SelectedIndex = 0;


            // ----- Combo Productos -----
            var productos = ProductoBLL2.ObtenerProductos();

            cmbProducto.DataSource = productos;
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "Id";

            // Opción "Todos"
            productos.Insert(0, new Producto { Id = 0, Nombre = "Todos" });

            cmbProducto.DataSource = productos;
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "Id";
            cmbProducto.SelectedIndex = 0;
        }
        // 3. CARGAR LISTA DE COMPRAS
        // ==========================================================
        private void CargarCompras(int proveedorId = 0, int productoId = 0)
        {
            try
            {
                var lista = CompraBLL.ObtenerCompras(proveedorId, productoId);

                dgvCompra.DataSource = lista;

                FormatearGridCompras();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar compras: " + ex.Message);
            }
        }
        private void FormatearGridCompras()
        {
            if (dgvCompra.Columns.Count == 0) return;

            dgvCompra.Columns["CompraID"].HeaderText = "ID";
            dgvCompra.Columns["ProveedorID"].Visible = false;
            dgvCompra.Columns["NombreProveedor"].HeaderText = "Proveedor";
            dgvCompra.Columns["Fecha"].HeaderText = "Fecha";
            dgvCompra.Columns["TotalCompra"].HeaderText = "Total ($)";
            dgvCompra.Columns["MetodoPago"].HeaderText = "Método Pago";
            dgvCompra.Columns["Observaciones"].HeaderText = "Notas";

            dgvCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCompra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompra.ReadOnly = true;
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int proveedorId = 0;
            int productoId = 0;

            if (cmbProveedor.SelectedItem is Proveedor prov)
                proveedorId = prov.ProveedorID;

            if (cmbProducto.SelectedItem is Producto prod)
                productoId = prod.Id;

            CargarCompras(proveedorId, productoId);
        }

        private void dgvCompras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int compraID = Convert.ToInt32(dgvCompra.Rows[e.RowIndex].Cells["CompraID"].Value);

            CargarDetalle(compraID);
        }

        private void CargarDetalle(int compraID)
        {
            try
            {
                var lista = DetalleCompraBLL.ObtenerDetallePorCompra(compraID);

                dgvDetalle.DataSource = lista;
                FormatearGridDetalle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalle: " + ex.Message);
            }
        }

        private void FormatearGridDetalle()
        {
            if (dgvDetalle.Columns.Count == 0) return;

            dgvDetalle.Columns["DetalleCompraID"].Visible = false;
            dgvDetalle.Columns["CompraID"].Visible = false;
            dgvDetalle.Columns["ProductoID"].Visible = false;

            dgvDetalle.Columns["NombreProducto"].HeaderText = "Producto";
            dgvDetalle.Columns["Cantidad"].HeaderText = "Cantidad";
            dgvDetalle.Columns["PrecioCompra"].HeaderText = "Precio ($)";
            dgvDetalle.Columns["SubTotal"].HeaderText = "Subtotal ($)";

            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.ReadOnly = true;
        }
        

        private void btnRegistrarCompra_Click(object sender, EventArgs e)
        {
            FrmGestionCompra frm = new FrmGestionCompra();
            frm.ShowDialog();

            // Al volver, refrescar lista de compras
            CargarCompras();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvCompras_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (dgvCompra.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una compra para editar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int compraID = Convert.ToInt32(dgvCompra.SelectedRows[0].Cells["CompraID"].Value);

            FrmGestionCompra frm = new FrmGestionCompra();
            frm.CargarCompra(compraID);
            frm.ShowDialog();

            CargarCompras(); // refrescar listado
        }
    }
}
