using Pos_Accesorios_Belen.CapaDatos;
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
    public partial class FrmGestionProveedores : Form
    {
        public Proveedor ProveedorEditar { get; set; }

        public FrmGestionProveedores()
        {
            InitializeComponent();
          
        }
        private int IDSeleccionado = 0;
       
       
        private void FrmGestionProveedores_Load(object sender, EventArgs e)
        {
            // cargar combo
            cboTipoProd.Items.Add("CELULARES");
            cboTipoProd.Items.Add("CARGADORES");
            cboTipoProd.Items.Add("AUDIFONOS");
            cboTipoProd.Items.Add("PROTECTORES");
            cboTipoProd.Items.Add("CONSOLAS DE VIDEO JUEGOS");
            cboTipoProd.Items.Add("OTRO");

            cboTipoProd.SelectedIndex = -1;

            // cargar lista
            CargarLista();

            // Inicialmente:
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void CargarLista()
        {
            dgvLista.DataSource = ProveedorBLL.Buscar("", "");
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            cboTipoProd.SelectedIndex = -1;
            chkEstado.Checked = false;

            IDSeleccionado = 0;

            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }
        

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                IDSeleccionado = Convert.ToInt32(dgvLista.Rows[e.RowIndex].Cells["ProveedorID"].Value);

                txtNombre.Text = dgvLista.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtTelefono.Text = dgvLista.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                txtEmail.Text = dgvLista.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtDireccion.Text = dgvLista.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();
                cboTipoProd.Text = dgvLista.Rows[e.RowIndex].Cells["TipoProducto"].Value.ToString();
                chkEstado.Checked = Convert.ToBoolean(dgvLista.Rows[e.RowIndex].Cells["Estado"].Value);

                // Activar botones especiales
                btnGuardar.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Proveedor p = new Proveedor()
            {
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text,
                Direccion = txtDireccion.Text,
                TipoProducto = cboTipoProd.Text,
                Estado = chkEstado.Checked
            };

            string r = ProveedorBLL.Guardar(p);

            if (r == "OK")
            {
                MessageBox.Show("Proveedor guardado correctamente.");
                CargarLista();
                LimpiarCampos();
            }
            else
                MessageBox.Show(r);
        }

        

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            if (IDSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor.");
                return;
            }

            Proveedor p = new Proveedor()
            {
                ProveedorID = IDSeleccionado,
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text,
                Direccion = txtDireccion.Text,
                TipoProducto = cboTipoProd.Text,
                Estado = chkEstado.Checked
            };

            string r = ProveedorBLL.Actualizar(p);

            if (r == "OK")
            {
                MessageBox.Show("Proveedor actualizado.");
                CargarLista();
                LimpiarCampos();
            }
            else
                MessageBox.Show(r);
        }
        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (IDSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor.");
                return;
            }

            if (MessageBox.Show("¿Desea eliminar este proveedor?",
                "CONFIRMAR", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string r = ProveedorBLL.Eliminar(IDSeleccionado);

                if (r == "OK")
                {
                    MessageBox.Show("Proveedor eliminado.");
                    CargarLista();
                    LimpiarCampos();
                }
                else
                    MessageBox.Show(r);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Limpiar()
        {
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtDireccion.Text = "";
            cboTipoProd.SelectedIndex = 0;
            chkEstado.Checked = false;

            IDSeleccionado = 0;

           
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
    




