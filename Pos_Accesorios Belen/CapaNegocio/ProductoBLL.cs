using Pos_Accesorios_Belen.CapaDatos;
using Pos_Accesorios_Belen.CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pos_Accesorios_Belen.CapaNegocio
{
    public class ProductoBLL
    {
        ProductoDAL dAl = new ProductoDAL();
        //Creamos un objeto de la clase ProductoDAL para acceder a sus métodos

        //metodo para listar todos los registros de la tabla productos
        public DataTable Listar()
        {
            return dAl.Listar();
            //la BLL no toca SQL, solo llama a los métodos de la DAL
        }

        //metodo para insertar o actualizar un registro en la tabla productos
        public int Guardar(Producto p)
        {
            //validaciones de negocio ======================
            if (string.IsNullOrWhiteSpace(p.Nombre))
                throw new ArgumentException("El nombre del producto es obligatorio.");

            if (p.Precio <= 0)
                throw new ArgumentException("El precio debe ser mayor a cero.");

            if (p.Stock < 0)
                throw new ArgumentException("El stock no puede ser negativo.");

            if (p.Id_Categoria <= 0)
                throw new ArgumentException("Debe seleccionar una categoría válida.");

            //Si el ID es 0, es un nuevo registro
            if (p.Id == 0)
            {
                return dAl.Insertar(p);
            }
            else
            {
                //Si el ID es diferente de 0, se actualiza
                dAl.Actualizar(p);
                MessageBox.Show("Producto actualizado correctamente.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return p.Id;
            }
        }

        //METODO PARA ELIMINAR UN REGISTRO DE LA TABLA PRODUCTOS
        public bool Eliminar(int id)
        {
            return dAl.Eliminar(id);
            //Si deseas, puedes añadir un MessageBox aquí como en tu ejemplo:
            //MessageBox.Show("Registro eliminado correctamente.", "Aviso",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //METODO PARA BUSCAR UN PRODUCTO POR NOMBRE
        public DataTable Buscar(string filtro)
        {
            return dAl.Buscar(filtro);
        }
        public bool Editar(Producto p)
        {
            return dAl.Actualizar(p); // IMPORTANTE: este método debe existir en DAL
        }
    }
}

