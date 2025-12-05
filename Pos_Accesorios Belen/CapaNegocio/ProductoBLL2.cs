using Pos_Accesorios_Belen.CapaDatos;
using Pos_Accesorios_Belen.CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos_Accesorios_Belen.CapaNegocio
{
    public class ProductoBLL2
    {
        private ProductoDAL2 dal = new ProductoDAL2();

        public DataTable Listar()
        {
            return dal.Listar();
        }

        public int Guardar(Producto p)
        {
            // VALIDACIONES
            if (string.IsNullOrWhiteSpace(p.Nombre))
                throw new ArgumentException("El nombre es obligatorio.");

            if (p.Precio <= 0)
                throw new ArgumentException("El precio debe ser mayor a cero.");

            if (p.Stock < 0)
                throw new ArgumentException("El stock no puede ser negativo.");

            if (p.Id_Categoria <= 0)
                throw new ArgumentException("Seleccione una categoría válida.");

            // INSERTAR
            if (p.Id == 0)
                return dal.Insertar(p);

            // ACTUALIZAR
            dal.Actualizar(p);
            return p.Id;
        }

        public bool Eliminar(int id)
        {
            return dal.Eliminar(id);
        }

        public DataTable Buscar(string filtro)
        {
            return dal.Buscar(filtro);
        }

        public bool Editar(Producto p)
        {
            return dal.Actualizar(p);
        }
    }
}
