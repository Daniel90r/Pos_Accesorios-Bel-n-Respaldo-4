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
    public partial class FrmProveedores : Form
    {
        public FrmProveedores()
        {
            InitializeComponent();
          
        }
        


        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            cboProducto.Items.Add("CELULARES");
            cboProducto.Items.Add("CARGADORES");
            cboProducto.Items.Add("AUDIFONOS");
            cboProducto.Items.Add("PROTECTORES");
            cboProducto.Items.Add("CONSOLAS DE VIDEO JUEGOS");
            cboProducto.Items.Add("VARIOS");

            cboProducto.SelectedIndex = -1;

            CargarProveedores(); // mostrar todo al iniciar
        }
        private void CargarProveedores()
        {
            dgvProveedores.DataSource = ProveedorBLL.Buscar("", "");  // todos
        }
        private void BuscarProveedores()
        {
            string nombre = txtNombre.Text;
            string tipo = cboProducto.Text;

            dgvProveedores.DataSource = ProveedorBLL.Buscar(nombre, tipo);
        }


        // -----------------------------------------
        // CARGAR PROVEEDORES
        // -----------------------------------------
        private void CargarProveedores(string filtroCampo = "", string filtroValor = "")
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
                {
                    cn.Open();

                    string sql = "SELECT IdProveedor, Nombre, Contacto, Telefono, Direccion FROM Proveedores";

                    if (!string.IsNullOrEmpty(filtroValor))
                    {
                        sql += $" WHERE {filtroCampo} LIKE @valor";
                    }

                    SqlCommand cmd = new SqlCommand(sql, cn);

                    if (!string.IsNullOrEmpty(filtroValor))
                    {
                        cmd.Parameters.AddWithValue("@valor", "%" + filtroValor + "%");
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvProveedores.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message);
            }
        }

        // -----------------------------------------
        // FILTRAR
        // -----------------------------------------
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string campo = cboProducto.SelectedItem.ToString();
            string valor = txtNombre.Text.Trim();

            CargarProveedores(campo, valor);
        }

        
        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmGestionProveedores frm = new FrmGestionProveedores();
            frm.ShowDialog();


        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string tipo = cboProducto.Text.Trim();

            dgvProveedores.DataSource = ProveedorBLL.Buscar(nombre, tipo);
        }

        private void dgvProveedores_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Proveedor p = new Proveedor()
                {
                    ProveedorID = Convert.ToInt32(dgvProveedores.Rows[e.RowIndex].Cells["ProveedorID"].Value),
                    Nombre = dgvProveedores.Rows[e.RowIndex].Cells["Nombre"].Value.ToString(),
                    Telefono = dgvProveedores.Rows[e.RowIndex].Cells["Telefono"].Value.ToString(),
                    Email = dgvProveedores.Rows[e.RowIndex].Cells["Email"].Value.ToString(),
                    Direccion = dgvProveedores.Rows[e.RowIndex].Cells["Direccion"].Value.ToString(),
                    TipoProducto = dgvProveedores.Rows[e.RowIndex].Cells["TipoProducto"].Value.ToString(),
                    Estado = Convert.ToBoolean(dgvProveedores.Rows[e.RowIndex].Cells["Estado"].Value)
                };

                FrmGestionProveedores frm = new FrmGestionProveedores();
                frm.ProveedorEditar = p;
                frm.ShowDialog();


                CargarProveedores();
            }
        }

        private void dgvProveedores_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            BuscarProveedores();
        }
    }
}
