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
    public partial class FrmProductos : Form
    {
        private ProductoBLL2 productoBLL = new ProductoBLL2();
        private int idSeleccionado = 0;

        private void CargarProductos()
        {
            dgvProductos.DataSource = productoBLL.Listar();
        }
        public FrmProductos()
        {
            InitializeComponent();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0) return;

            idSeleccionado = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells["Id"].Value);

            txtNombre.Text = dgvProductos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            txtPrecio.Text = dgvProductos.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
            txtStock.Text = dgvProductos.Rows[e.RowIndex].Cells["Stock"].Value.ToString();

            chkEstado.Checked = Convert.ToBoolean(
                dgvProductos.Rows[e.RowIndex].Cells["Estado"].Value
            );

            cmbCategoria.SelectedValue = Convert.ToInt32(
                dgvProductos.Rows[e.RowIndex].Cells["Id_Categoria"].Value
            );
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();
            CargarCategorias();
            LimpiarCampos();
        }

        

        private void LimpiarCampos()
        {
            idSeleccionado = 0;
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            chkEstado.Checked = true;
            cmbCategoria.SelectedIndex = 0;
        }
        private void CargarCategorias()
        {
            CategoriaBLL categoriaBLL = new CategoriaBLL();
            cmbCategoria.DataSource = categoriaBLL.Listar();
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "Id";
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto p = new Producto()
            {
                Id = idSeleccionado,
                Nombre = txtNombre.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text),
                Estado = chkEstado.Checked,
                Id_Categoria = (int)cmbCategoria.SelectedValue
            };

            productoBLL.Guardar(p);
            MessageBox.Show("Producto guardado");

            CargarProductos();
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un producto primero.");
                return;
            }

            Producto p = new Producto()
            {
                Id = idSeleccionado,
                Nombre = txtNombre.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text),
                Estado = chkEstado.Checked,
                Id_Categoria = (int)cmbCategoria.SelectedValue,
               
            };

            if (productoBLL.Editar(p))
            {
                MessageBox.Show("Producto modificado correctamente.");
                CargarProductos();
                LimpiarCampos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            productoBLL.Eliminar(idSeleccionado);

            CargarProductos();
            LimpiarCampos();
        }
        

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

    
