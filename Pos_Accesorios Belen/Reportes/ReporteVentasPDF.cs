
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Infrastructure;   // Requerido para usar LicenseType y GeneratePdf
using System.Data;

namespace Pos_Accesorios_Belen.Reportes
{

    namespace Pos_Accesorios_Belen.Reportes
    {
        // Clase estática que contiene el método GenerarPDF
        public static class ReporteVentasPDF
        {
            // Método estático: se puede llamar sin crear instancias
            public static void GenerarPDF(DataTable tabla, DateTime inicio, DateTime fin, string rutaArchivo)
            {
                // QuestPDF requiere declarar la licencia (Community es gratuita)
                QuestPDF.Settings.License = LicenseType.Community;

                // 1) Creamos el modelo de datos (DataTable y rango de fechas)
                var modelo = new ReporteVentasModel(tabla, inicio, fin);

                // 2) Creamos el documento PDF usando ese modelo
                var documento = new ReporteVentasDocumento(modelo);

                // 3) Generamos el archivo PDF en disco
                documento.GeneratePdf(rutaArchivo);
            }
        }
    }
}
