using Pos_Accesorios_Belen.CapaDatos;
using Pos_Accesorios_Belen.CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos_Accesorios_Belen.CapaNegocio
{
    public class DetalleCompraBLL2
    {
        // LISTAR DETALLE POR COMPRA
        public List<DetalleCompra> ListarPorCompra(int compraID)
        {
            if (compraID <= 0)
                throw new ArgumentException("El ID de compra es inválido.");

            return DetalleCompraDAL.ObtenerDetallePorCompra(compraID);
        }

        // INSERTAR DETALLE
        public bool Guardar(DetalleCompra d)
        {
            if (d.CompraID <= 0)
                throw new ArgumentException("El ID de compra es obligatorio.");

            if (d.ProductoID <= 0)
                throw new ArgumentException("Debe seleccionar un producto válido.");

            if (d.Cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a 0.");

            if (d.PrecioCompra <= 0)
                throw new ArgumentException("El precio de compra debe ser mayor a 0.");

            // SUBTOTAL CALCULADO
            d.SubTotal = d.Cantidad * d.PrecioCompra;

            return DetalleCompraDAL.InsertarDetalle(d);
        }

        // ELIMINAR DETALLE
        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID del detalle inválido.");

            return DetalleCompraDAL.EliminarDetalle(id);
        }
    }
}
