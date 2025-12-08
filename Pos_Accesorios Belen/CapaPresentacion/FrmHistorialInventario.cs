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
    public partial class FrmHistorialInventario : Form
    {
        private MovimientosInventarioBLL movimientosBLL = new MovimientosInventarioBLL();
        private ProductoBLL2 productoBLL = new ProductoBLL2();
        public FrmHistorialInventario()
        {
            InitializeComponent();
        }

        private void FrmHistorialInventario_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now.AddMonths(-1);
            dtpHasta.Value = DateTime.Now;
            CargarProductosFiltro();
            CargarTipos();
            CargarHistorial();
            
        }
        private void CargarProductosFiltro()
        {
            var dt = productoBLL.Listar();
            DataRow fila = dt.NewRow();
            fila["Id"] = 0;
            fila["Nombre"] = "-- Todos --";
            dt.Rows.InsertAt(fila, 0);

            comboTodos.DisplayMember = "Nombre";
            comboTodos.ValueMember = "Id";
            comboTodos.DataSource = dt;
        }
        private void CargarTipos()
        {
            comboTipo.Items.Clear();
            comboTipo.Items.Add("-- TODOS --");
            comboTipo.Items.Add("ENTRADA");
            comboTipo.Items.Add("SALIDA");
            comboTipo.SelectedIndex = 0;
        }
        private void CargarHistorial()
        {
            int idProducto = Convert.ToInt32(comboTodos.SelectedValue);
            string tipo = comboTipo.SelectedItem.ToString() == "-- TODOS --" ? "" : comboTipo.SelectedItem.ToString();

            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1);

            // Traer todo desde BLL
            DataTable dt = movimientosBLL.BuscarMovimientos(desde, hasta, tipo, null);

            // Filtro por producto si no está en "Todos"
            if (idProducto > 0)
            {
                DataRow[] filtrar = dt.Select($"ProductoID = {idProducto}");
                DataTable dtFiltrado = dt.Clone();

                foreach (var row in filtrar)
                    dtFiltrado.ImportRow(row);

                dgvHistorial.DataSource = dtFiltrado;
            }
            else
            {
                dgvHistorial.DataSource = dt;
            }
        }

        

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarHistorial();
        }
    }
}
