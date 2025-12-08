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
    public partial class FrmEntradasInventario : Form
    {
        private ProductoBLL2 productoBLL = new ProductoBLL2();
        private MovimientosInventarioBLL movimientosBLL = new MovimientosInventarioBLL();

        public FrmEntradasInventario()
        {
            InitializeComponent();
        }

        private void lblBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (comboProducto.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idProducto = Convert.ToInt32(comboProducto.SelectedValue);
            int cantidad = Convert.ToInt32(nudCantidad.Value);
            string proveedor = txtProveedor.Text.Trim();
            DateTime fecha = dtpFecha.Value;

            try
            {
                movimientosBLL.RegistrarEntrada(idProducto, cantidad, proveedor, fecha);
                MessageBox.Show("Entrada registrada correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarEntradasRecientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar entrada:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmEntradasInventario_Load(object sender, EventArgs e)
        {
            CargarProductosEnCombo();
            dtpFecha.Value = DateTime.Now;
            CargarEntradasRecientes();
        }
        private void CargarProductosEnCombo()
        {
            DataTable dt = productoBLL.Listar();
            comboProducto.DisplayMember = "Nombre";
            comboProducto.ValueMember = "Id";
            comboProducto.DataSource = dt;
        }
        private void CargarEntradasRecientes()
        {
            dgvEntradasRecientes.DataSource = movimientosBLL.ListarEntradasRecientes(50);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
