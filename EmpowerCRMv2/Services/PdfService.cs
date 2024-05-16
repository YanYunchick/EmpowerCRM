namespace EmpowerCRMv2.Services
{
    using DinkToPdf;
    using DinkToPdf.Contracts;
    using EmpowerCRMv2.Components.Pages;
    using EmpowerCRMv2.Models;
    using System.Collections.Generic;

    public class PdfService : IPdfService
    {
        private readonly IConverter _converter;

        public PdfService(IConverter converter)
        {
            _converter = converter;
        }

        public string GenerateInvoicePdf(Opportunity opp)
        {
            var htmlContent = GenerateInvoiceHtml(opp);

            var document = new HtmlToPdfDocument
            {
                GlobalSettings = {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
            },
                Objects = {
                new ObjectSettings {
                    PagesCount = true,
                    HtmlContent = htmlContent,
                    WebSettings = { DefaultEncoding = "utf-8" },
                    HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                    FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Invoice" }
                }
            }
            };

            
            var pdfBytes = _converter.Convert(document);
            return Convert.ToBase64String(pdfBytes);
        }

        private string GenerateInvoiceHtml(Opportunity opp)
        {
            var html = "<html><head><style>table, th, td {width: 100%; margin-bottom: 20px; margin-top: 20px; border: 1px solid #dddddd; border-collapse: collapse;} p {margin: 0; padding: 0;}</style></head><body>";
            html += "<h1>Invoice</h1>";
            html += "<h2>BILL TO</h2>";
            html += $"<p>Name: {opp.Contact.FirstName} {opp.Contact.LastName}</p>";
            html += $"<p>Company: {opp.Contact.Company}</p>";
            html += $"<p>Address: {opp.Contact.Address}</p>";
            html += $"<p>Phone: {opp.Contact.Phone}</p>";
            html += $"<p>Email: {opp.Contact.Email}</p>";

            html += "<table><tr><th>Product Name</th><th>Quantity</th><th>Unit Price</th></tr>";

            foreach (var product in opp.OpportunityProducts)
            {
                html += $"<tr><td>{product.Product.Name}</td><td>{product.Quantity}</td><td>${product.Price}</td></tr>";
            }
            
            html += "</table>";
            html += $"<h3>TOTAL PRICE: ${opp.OpportunityProducts.Sum(item => item.Price * item.Quantity)}</h3>";
            html += "</table></body></html>";
            return html;
        }
    }
}
