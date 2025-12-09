using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos_Accesorios_Belen.CapaEntidades
{
    public class Proveedor
    {
        public int ProveedorID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string TipoProducto { get; set; }
        public bool Estado { get; set; }
    }
}

