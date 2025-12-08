using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Data;

namespace Pos_Accesorios_Belen.Reportes
{
    public class ReporteVentasDocumento2 : IDocument
    {
        private readonly ReporteVentasModel Modelo;

        public ReporteVentasDocumento2(ReporteVentasModel modelo)
        {
            Modelo = modelo;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
        public DocumentSettings GetSettings() => new DocumentSettings();

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(25);

                // ENCABEZADO
                page.Header().Column(col =>
                {
                    col.Item().Text("CAFÉ DULCE AROMA")
                        .Bold().FontSize(20).AlignCenter();

                    col.Item().Text("REPORTE DE VENTAS POR PERÍODO")
                        .FontSize(14).AlignCenter();

                    col.Item().Text($"Desde {Modelo.Inicio:dd/MM/yyyy}  —  Hasta {Modelo.Fin:dd/MM/yyyy}")
                        .FontSize(11).AlignCenter();
                });

                // CONTENIDO (TABLA)
                page.Content().PaddingTop(20)
                    .Element(GenerarTabla);

                // PIE DE PÁGINA
                page.Footer()
                    .AlignCenter()
                    .Text($"Generado el {DateTime.Now:dd/MM/yyyy HH:mm} — Sistema POS Café Dulce Aroma");
            });
        }

        private void GenerarTabla(IContainer container)
        {
            container.Table(table =>
            {
                // Columnas
                table.ColumnsDefinition(cols =>
                {
                    cols.RelativeColumn(3); // Producto
                    cols.RelativeColumn(1); // Cantidad
                    cols.RelativeColumn(1); // Precio
                    cols.RelativeColumn(1); // Subtotal
                });

                // Encabezado
                table.Header(header =>
                {
                    header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Producto").SemiBold();
                    header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Cantidad").SemiBold();
                    header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Precio").SemiBold();
                    header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Subtotal").SemiBold();
                });

                decimal total = 0;

                // Filas
                foreach (DataRow row in Modelo.Tabla.Rows)
                {
                    string producto = row["Nombre"].ToString();
                    int cantidad = Convert.ToInt32(row["Cantidad"]);
                    decimal precio = Convert.ToDecimal(row["PrecioUnitario"]);
                    decimal subtotal = Convert.ToDecimal(row["SubTotal"]);

                    total += subtotal;

                    table.Cell().Padding(4).Text(producto);
                    table.Cell().Padding(4).Text(cantidad.ToString());
                    table.Cell().Padding(4).Text(precio.ToString("C2"));
                    table.Cell().Padding(4).Text(subtotal.ToString("C2"));
                }

                // TOTAL GENERAL
                table.Cell().ColumnSpan(4).AlignRight().Padding(10)
                    .Text($"TOTAL GENERAL: {total:C2}")
                    .Bold()
                    .FontSize(14);
            });
        }
    }
}
