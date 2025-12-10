using Pos_Accesorios_Belen.CapaDatos;
using Pos_Accesorios_Belen.CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos_Accesorios_Belen.CapaNegocio
{
    public class CompraBLL
    {
        public static List<Compra> ObtenerCompras()
        {
            return CompraDAL.ObtenerCompras();
        }

        public static int RegistrarCompra(Compra compra)
        {
            // VALIDACIONES
            if (compra.ProveedorID <= 0)
                throw new Exception("Debe seleccionar un proveedor.");

            if (compra.TotalCompra < 0)
                throw new Exception("El total de la compra no puede ser negativo.");

            if (string.IsNullOrWhiteSpace(compra.MetodoPago))
                compra.MetodoPago = "N/A";

            return CompraDAL.RegistrarCompra(compra);
        }

        public static bool ActualizarCompra(Compra compra)
        {
            if (compra.CompraID <= 0)
                throw new Exception("ID de compra inválido.");

            if (compra.ProveedorID <= 0)
                throw new Exception("Debe seleccionar un proveedor.");

            if (compra.TotalCompra < 0)
                throw new Exception("El total de la compra no puede ser negativo.");

            return CompraDAL.ActualizarCompra(compra);
        }

        public static bool EliminarCompra(int id)
        {
            if (id <= 0)
                throw new Exception("ID inválido para eliminar la compra.");

            return CompraDAL.EliminarCompra(id);
        }
        // si ya tienes ObtenerCompras() sin params puedes mantenerla y llamar a la nueva:
        

        // versión con filtros
        public static List<Compra> ObtenerCompras(int proveedorId = 0, int productoId = 0)
        {
            return CompraDAL.ObtenerCompras(proveedorId, productoId);
        }

        // ... resto de métodos (RegistrarCompra, ActualizarCompra, EliminarCompra) ...
    }
}

