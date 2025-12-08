using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Pos_Accesorios_Belen.Reportes
{
    public class ReporteVentasModel2
    {
        public DataTable Tabla { get; }
        public DateTime Inicio { get; }
        public DateTime Fin { get; }

        public ReporteVentasModel2(DataTable tabla, DateTime inicio, DateTime fin)
        {
            Tabla = tabla;
            Inicio = inicio;
            Fin = fin;
        }
    }
}

