using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;




namespace Pos_Accesorios_Belen.Reportes
{
    public class ReporteVentasPDF2
    {
        internal static void GenerarPDF(DataTable tabla, DateTime inicio, DateTime fin, string ruta)
        {
            throw new NotImplementedException();
        }

        public class ReporteVentasPDF
        {
            public static void GenerarPDF(DataTable tabla, DateTime inicio, DateTime fin, string rutaArchivo)
            {
                QuestPDF.Settings.License = LicenseType.Community;

                var modelo = new ReporteVentasModel(tabla, inicio, fin);
                var documento = new ReporteVentasDocumento(modelo);

                documento.GeneratePdf(rutaArchivo); // MÉTODO REAL DE QuestPDF
            }
        }
    }
}
