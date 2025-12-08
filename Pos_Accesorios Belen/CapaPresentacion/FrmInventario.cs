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
    public partial class FrmInventario : Form
    {
        private ProductoBLL2 productoBLL = new ProductoBLL2();
        private CategoriaBLL categoriaBLL = new CategoriaBLL();
        private MovimientosInventarioBLL movimientosBLL = new MovimientosInventarioBLL();
        public FrmInventario()
        {
            InitializeComponent();
        }
        private void FrmInventario_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarProductos();
            ActualizarAlertasBajoStock();
        }
        private void CargarCategorias()
        {
            var dt = categoriaBLL.Listar();
            DataRow fila = dt.NewRow();
            fila["Id"] = 0;
            fila["Nombre"] = "-- Todas --";
            fila["Descripcion"] = DBNull.Value;
            dt.Rows.InsertAt(fila, 0);

            comboCategoria.DisplayMember = "Nombre";
            comboCategoria.ValueMember = "Id";
            comboCategoria.DataSource = dt;
        }

        private void CargarProductos()
        {
            var dt = productoBLL.Listar();
            dgvProductos.DataSource = dt;

            // Opcional: ocultar columnas no necesarias
            if (dgvProductos.Columns.Contains("Id_Categoria"))
                dgvProductos.Columns["Id_Categoria"].Visible = false;
        }

        private void FiltrarProductos()
        {
            string nombre = txtBuscar.Text.Trim();
            int idCategoria = comboCategoria.SelectedIndex > 0 ? Convert.ToInt32(comboCategoria.SelectedValue) : 0;

            DataTable dt;
            // Si se escribe texto o categoria seleccionada, delegamos al DAL (mejor rendimiento)
            if (!string.IsNullOrEmpty(nombre) || idCategoria > 0)
            {
                // Puedes ampliar ProductoDAL2 con un método BuscarPorCategoriaYNnombre.
                // Mientras tanto, filtrar en memoria:
                DataTable todos = productoBLL.Listar();
                string filtro = "";

                if (!string.IsNullOrEmpty(nombre))
                    filtro += $"Nombre LIKE '%{nombre.Replace("'", "''")}%'";

                if (idCategoria > 0)
                {
                    if (!string.IsNullOrEmpty(filtro)) filtro += " AND ";
                    filtro += $"Id_Categoria = {idCategoria}";
                }

                DataRow[] filas = todos.Select(filtro);
                dt = todos.Clone();
                foreach (var r in filas) dt.ImportRow(r);
            }
            else
            {
                dt = productoBLL.Listar();
            }

            dgvProductos.DataSource = dt;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarProductos();
        }

        private void comboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarProductos();
        }

        private void btnRegistrarEntrada_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmEntradasInventario())
            {
                frm.ShowDialog();
            }
            CargarProductos();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmHistorialInventario())
            {
                frm.ShowDialog();
            }
        }
        private void ActualizarAlertasBajoStock()
        {
            var dt = productoBLL.Listar();
            int count = 0;
            foreach (DataRow r in dt.Rows)
            {
                int stock = Convert.ToInt32(r["Stock"]);
                int stockMinimo = 5; // puedes tomar valor por producto si agregas campo StockMinimo
                if (stock <= stockMinimo) count++;
            }
            lblAlertaCount.Text = $"Productos bajos de stock: {count}";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmProductos frm = new FrmProductos();
            frm.Show();
        }
    }
}
