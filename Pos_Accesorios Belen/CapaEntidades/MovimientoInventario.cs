using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos_Accesorios_Belen.CapaEntidades
{
    public class MovimientoInventario
    {
        public int IdMovimiento { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public string Tipo { get; set; } // "ENTRADA" o "SALIDA"
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; } // proveedor/observacion/razon
    }
}
