using Pos_Accesorios_Belen.CapaDatos;
using Pos_Accesorios_Belen.CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos_Accesorios_Belen.CapaNegocio
{
    public class CompraBLL2
    {
        private CompraDAL dal = new CompraDAL();

        // LISTAR COMPRAS (con o sin filtros)
        public List<Compra> Listar(int proveedorId = 0, int productoId = 0)
        {
            return CompraDAL.ObtenerCompras(proveedorId, productoId);
        }

        // OBTENER TODAS SIN FILTRO
        public List<Compra> ListarTodo()
        {
            return CompraDAL.ObtenerCompras();
        }

        // GUARDAR (Insertar o actualizar)
        public int Guardar(Compra c)
        {
            // VALIDACIONES
            if (c.ProveedorID <= 0)
                throw new ArgumentException("Debe seleccionar un proveedor válido.");

            if (c.TotalCompra <= 0)
                throw new ArgumentException("El total de la compra debe ser mayor a cero.");

            if (string.IsNullOrWhiteSpace(c.MetodoPago))
                throw new ArgumentException("Debe seleccionar un método de pago.");

            if (c.CompraID == 0)
            {
                // INSERTAR
                return CompraDAL.RegistrarCompra(c);
            }
            else
            {
                // ACTUALIZAR
                bool ok = CompraDAL.ActualizarCompra(c);
                if (!ok)
                    throw new Exception("No se pudo actualizar la compra.");

                return c.CompraID;
            }
        }

        // ELIMINAR
        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID de compra inválido.");

            return CompraDAL.EliminarCompra(id);
        }
    }
}
