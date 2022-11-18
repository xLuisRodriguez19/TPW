using SuperShop.Models.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

namespace SuperShop.Business.Tracking.Services
{
    public class EmailService
    {
        public EmailService()
        {
        }

        public Task SendEmail(string destino, string ubicacion, int status)
        {
            string EmailOrigen = "luisgmorh200@gmail.com";
            string EmailDestino = destino;
            string password = "zqlqjxftmovabgxv";
            string Estado = "";
            switch (status)
            {
                case 0:
                    Estado = "Preparando";
                    break;
                case 1:
                    Estado = "En Camino";
                    break;
                case 2:
                    Estado = "EnSucursal";
                    break;
                case 3:
                    Estado = "En Ruta de Entrega";
                    break;
                case 4:
                    Estado = "Entregado";
                    break;
            }
            var credentials = new NetworkCredential(EmailOrigen, password);

            MailMessage mail = new MailMessage(EmailOrigen, EmailDestino, "Status de Pedido", $"<p>Su pedido se encuentra en estado {Estado} en {ubicacion}</p>");

            mail.IsBodyHtml = true;
            mail.To.Add(new MailAddress(EmailDestino));
            var client = new SmtpClient()
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = credentials
            };

            client.Send(mail);
            Console.WriteLine($"Bill total:\t{EmailOrigen}");
            Console.WriteLine($"Bill total:\t{EmailDestino}");
            Console.WriteLine($"Bill total:\t{Estado}");
            Console.WriteLine($"Bill total:\t{ubicacion}");
            return Task.CompletedTask;
        }
    }
}