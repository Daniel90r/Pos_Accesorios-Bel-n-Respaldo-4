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
    public partial class FrmCategoria : Form
    {

        CategoriaBLL bll = new CategoriaBLL();

        int categoriaID = 0;  // Guarda el ID seleccionado
        string Modo = "Nuevo"; // Nuevo o Editar


        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            CargarDatos();
            HabilitarBotones();
        }
        //METODO PARA HABILITAR BOTONES EDITAR Y ELIMINAR
        void HabilitarBotones()
        {
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            dgvCategorias.ClearSelection();
            dgvCategorias.SelectionChanged += (s, e) =>
            {
                bool filaSeleccionada = dgvCategorias.SelectedRows.Count > 0;
                btnEditar.Enabled = filaSeleccionada;
                btnEliminar.Enabled = filaSeleccionada;
            };
        }
        void CargarDatos()
        {
            dgvCategorias.DataSource = bll.Listar();
            dgvCategorias.ClearSelection();
            categoriaID = 0;   // Reiniciar ID seleccionado

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgvCategorias.DataSource = bll.Buscar(txtBuscar.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmCategoriaGestion frm = new FrmCategoriaGestion(); //Aca dará error hasta que construyamos el Formulario llamado  FrmCategoriaGestion

            // MODO CREAR NUEVA CATEGORIA
            frm.Modo = "Nuevo"; //definimos por defecto que sea “nuevo”
            frm.Id = 0; //Guardara el Id que traigamos  del FrmCategoriaGestion

            frm.ShowDialog();  // Abrir como modal
            CargarDatos();     // Refrescar al cerrar     
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (categoriaID == 0)
            {
                MessageBox.Show("Seleccione una categoría",
                   "Información",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                return;
            }
            FrmCategoriaGestion frm = new FrmCategoriaGestion();
            // MODO EDITAR
            frm.Modo = "Editar";
            frm.Id = categoriaID;

            // Pasar información desde el DGV
            frm.Nombre = dgvCategorias.CurrentRow.Cells["Nombre"].Value.ToString();
            frm.Descripcion = dgvCategorias.CurrentRow.Cells["Descripcion"].Value.ToString();

            frm.ShowDialog();
            CargarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (categoriaID == 0)
            {
                MessageBox.Show("Seleccione una categoría",
                   "Información",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                return;

            }
            // Abrir formulario de eliminación
            FrmCategoriaEliminar frm = new FrmCategoriaEliminar();

            frm.Id = categoriaID;
            frm.Nombre = dgvCategorias.CurrentRow.Cells["Nombre"].Value.ToString();
            frm.Descripcion = dgvCategorias.CurrentRow.Cells["Descripcion"].Value.ToString();

            frm.ShowDialog();
            CargarDatos();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si clickeamos una fila válida
            if (e.RowIndex >= 0)
            {
                categoriaID = Convert.ToInt32(dgvCategorias.Rows[e.RowIndex].Cells["Id"].Value);
            }
        }
    }
}
