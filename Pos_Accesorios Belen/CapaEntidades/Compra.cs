using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos_Accesorios_Belen.CapaEntidades
{
    public class Compra
    {
        public int CompraID { get; set; }
        public int ProveedorID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal TotalCompra { get; set; }
        public string MetodoPago { get; set; }
        public string Observaciones { get; set; }

        // Relación
        public string NombreProveedor { get; set; } // para mostrar en el formulario
    }
}

