using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Helper
{
    public class ItemComprobante
    {
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }

    public class DatosComprobante
    {
        public string NumeroPedido { get; set; }
        public string NombreCliente { get; set; }
        public string EmailCliente { get; set; }
        public DateTime Fecha { get; set; }
        public string RutaLogo { get; set; }
        public List<ItemComprobante> Items { get; set; } = new List<ItemComprobante>();
        public decimal Subtotal => Items.Sum(x => x.Subtotal);
        public decimal Descuento { get; set; }
        public decimal Envio { get; set; }
        public decimal Total { get; set; }
    }

    public class GeneradorComprobantePdf
    {
        public static byte[] CrearPdf(DatosComprobante pedido)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            QuestPDF.Settings.ThrowOnMissingFontFamilies = false;

            RegistrarFuenteSiExiste(@"C:\Windows\Fonts\arial.ttf");
            RegistrarFuenteSiExiste(@"C:\Windows\Fonts\arialbd.ttf");

            var documento = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(36);
                    page.DefaultTextStyle(x => x.FontFamily("Arial").FontSize(11));

                    page.Header().Column(headerCol =>
                    {
                        if (!string.IsNullOrEmpty(pedido.RutaLogo) && File.Exists(pedido.RutaLogo))
                        {
                            headerCol.Item().AlignCenter().Height(45).Image(pedido.RutaLogo).FitArea();
                            headerCol.Item().PaddingBottom(8);
                        }

                        headerCol.Item().Row(row =>
                        {
                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text("RESUMEN DE PEDIDO").Bold().FontSize(18);
                                col.Item().Text("Comprobante interno (no válido como factura)").FontSize(9).FontColor(Colors.Grey.Darken1);
                            });

                            row.ConstantItem(160).AlignRight().Column(col =>
                            {
                                col.Item().Text($"Pedido #{pedido.NumeroPedido}").Bold().FontSize(13);
                                col.Item().Text($"Fecha: {pedido.Fecha:dd/MM/yyyy}");
                            });
                        });
                    });

                    page.Content().PaddingVertical(20).Column(col =>
                    {
                        col.Item().Text($"Cliente: {pedido.NombreCliente}").Bold();
                        col.Item().Text($"Correo: {pedido.EmailCliente}");
                        col.Item().PaddingVertical(10);

                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(4);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(2);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Producto").Bold();
                                header.Cell().Background(Colors.Grey.Lighten3).Padding(5).AlignCenter().Text("Cant.").Bold();
                                header.Cell().Background(Colors.Grey.Lighten3).Padding(5).AlignRight().Text("Precio").Bold();
                                header.Cell().Background(Colors.Grey.Lighten3).Padding(5).AlignRight().Text("Subtotal").Bold();
                            });

                            foreach (var item in pedido.Items)
                            {
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(item.Producto);
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).AlignCenter().Text(item.Cantidad.ToString());
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).AlignRight().Text($"${item.PrecioUnitario:N2}");
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).AlignRight().Text($"${item.Subtotal:N2}");
                            }
                        });

                        col.Item().PaddingTop(12).AlignRight().Column(resumen =>
                        {
                            resumen.Item().Text($"Subtotal: ${pedido.Subtotal:N2}");
                            resumen.Item().Text($"Descuento: -${pedido.Descuento:N2}");
                            resumen.Item().Text($"Envío: ${pedido.Envio:N2}");
                            resumen.Item().PaddingTop(4).Text($"TOTAL: ${pedido.Total:N2}").Bold().FontSize(14);
                        });
                    });

                    page.Footer().AlignCenter().Text("Gracias por su compra - Documento no válido como factura").FontSize(9).FontColor(Colors.Grey.Medium);
                });
            });

            return documento.GeneratePdf();
        }

        private static void RegistrarFuenteSiExiste(string ruta)
        {
            if (File.Exists(ruta))
            {
                FontManager.RegisterFontFromFile(ruta);
            }
        }
    }
}