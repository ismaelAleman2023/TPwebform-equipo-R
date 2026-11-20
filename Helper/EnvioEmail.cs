using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class EnvioEmail
    {
        private MailMessage email;
        private SmtpClient server;
        private readonly string _correoEquipo = "a456017@gmail.com";

        public EnvioEmail()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("a456017@gmail.com", "koubdpdadfhooceq");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo, byte[] pdfBytes = null, string nombreArchivo = "Comprobante.pdf")
        {
            email = new MailMessage();
            email.From = new MailAddress("a456017@gmail.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = cuerpo;

            if (pdfBytes != null && pdfBytes.Length > 0)
            {
                var stream = new MemoryStream(pdfBytes);
                var adjunto = new Attachment(stream, nombreArchivo, MediaTypeNames.Application.Pdf);
                email.Attachments.Add(adjunto);
            }
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EnviarConsultaAEquipo(string nombreRemitente, string emailRemitente, string mensaje)
        {
            string asunto = $"Consulta de {nombreRemitente}";
            string cuerpo = $@"
                <h3>Nueva consulta recibida</h3>
                <p><b>Nombre:</b> {nombreRemitente}</p>
                <p><b>Correo:</b> {emailRemitente}</p>
                <p><b>Mensaje:</b><br/>{mensaje}</p>";

            armarCorreo(_correoEquipo, asunto, cuerpo);
            enviarEmail();
        }

        public void EnviarConfirmacionPedido(DatosComprobante pedido)
        {
            byte[] pdf = GeneradorComprobantePdf.CrearPdf(pedido);
            string asunto = $"Confirmación de pedido #{pedido.NumeroPedido}";
            string cuerpo = $@"
                <h2>¡Gracias por tu compra, {pedido.NombreCliente}!</h2>
                <p>Tu pedido <b>#{pedido.NumeroPedido}</b> fue confirmado. Te adjuntamos el comprobante en PDF.</p>
                <p><b>Total:</b> ${pedido.Total:N2}</p>";

            armarCorreo(
                emailDestino: pedido.EmailCliente,
                asunto: asunto,
                cuerpo: cuerpo,
                pdfBytes: pdf,
                nombreArchivo: $"Pedido_{pedido.NumeroPedido}.pdf"
            );
            enviarEmail();
        }
    }
}