using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos_Accesorios_Belen.CapaEntidades
{
    public class Producto
    {
       
        
            public int Id { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public int Stock { get; set; }
            public bool Estado { get; set; }
            public int Id_Categoria { get; set; }
        


    }
}
