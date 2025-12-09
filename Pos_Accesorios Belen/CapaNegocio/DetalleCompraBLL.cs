using Pos_Accesorios_Belen.CapaDatos;
using Pos_Accesorios_Belen.CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos_Accesorios_Belen.CapaNegocio
{
    public class DetalleCompraBLL
    {
        public static List<DetalleCompra> ObtenerDetallePorCompra(int compraID)
        {
            if (compraID <= 0)
                throw new Exception("ID de compra inválido.");

            return DetalleCompraDAL.ObtenerDetallePorCompra(compraID);
        }

        public static bool InsertarDetalle(DetalleCompra detalle)
        {
            // VALIDACIONES
            if (detalle.CompraID <= 0)
                throw new Exception("Debe seleccionar una compra válida.");

            if (detalle.ProductoID <= 0)
                throw new Exception("Debe seleccionar un producto.");

            if (detalle.Cantidad <= 0)
                throw new Exception("La cantidad debe ser mayor a 0.");

            if (detalle.PrecioCompra <= 0)
                throw new Exception("El precio debe ser mayor a 0.");

            return DetalleCompraDAL.InsertarDetalle(detalle);
        }

        public static bool EliminarDetalle(int id)
        {
            if (id <= 0)
                throw new Exception("ID inválido para eliminar detalle.");

            return DetalleCompraDAL.EliminarDetalle(id);
        }
    }
}
