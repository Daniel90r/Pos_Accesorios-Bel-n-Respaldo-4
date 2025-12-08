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
    public partial class FrmClientes : Form
    {
        //variable para almacenar el id del ciente a modificar o eliminar
        int idCliente = 0;
        //creamos un objeto en la clase ClienteBLL para poder acceder a sus metodos
        ClienteBLL bll = new ClienteBLL();
        public FrmClientes()
        {
            InitializeComponent();
        }
        void HabilitarBotones()
        {
           
            btnEliminar.Enabled = false;
            dgvClientes.ClearSelection();
            dgvClientes.SelectionChanged += (s, e) =>
            {
                bool filaSeleccionada = dgvClientes.SelectedRows.Count > 0;      
                btnEliminar.Enabled = filaSeleccionada;
            };
        }
        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
            Limpiar();
            HabilitarBotones();
        }
        void CargarDatos()
        {
            dgvClientes.DataSource = bll.Listar();
        }
        void Limpiar()
        {
            idCliente = 0;
            txtNombre.Clear();
            txtDui.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtBuscar.Clear();
            chkEstado.Checked = true;
            txtNombre.Focus();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Clientes c = new Clientes()
                {
                    Id = idCliente,//si es 0, es nuevo registro
                    Nombre = txtNombre.Text.Trim(),
                    Dui = txtDui.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Estado = chkEstado.Checked
                };

                //llamamos al metodo guardar de la bll
                int id = bll.Guardar(c);
                MessageBox.Show("El Cliente se ha Guardado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idCliente = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["Id"].Value);
                txtNombre.Text = dgvClientes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtDui.Text = dgvClientes.Rows[e.RowIndex].Cells["Dui"].Value.ToString();
                txtTelefono.Text = dgvClientes.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                txtCorreo.Text = dgvClientes.Rows[e.RowIndex].Cells["Correo"].Value.ToString();
                chkEstado.Checked = Convert.ToBoolean(dgvClientes.Rows[e.RowIndex].Cells["Estado"].Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idCliente == 0)
            {
                MessageBox.Show("Seleccione un cliente para eliminar");
                return;
            }
            if (MessageBox.Show("¿Estas seguro de Eliminar el Cliente?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bll.Eliminar(idCliente);
                CargarDatos();
                Limpiar();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgvClientes.DataSource = bll.Buscar(txtBuscar.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
