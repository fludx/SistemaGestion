using System;
using System.Net;
using System.Net.Mail;

namespace Sesion
{
    public class EnviarMail
    {
        public static void SendCustomMail(string toEmail, string subject, string htmlBody)
        {
            string fromEmail = "sistemadegestiongrupoa2025@gmail.com";
            string displayName = "Primer Ingreso";

            try
            {
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(fromEmail, displayName),
                    Subject = subject,
                    Body = htmlBody,
                    IsBodyHtml = true
                };
                mail.To.Add(toEmail);

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(fromEmail, "bppl tqjt sxgu udie"),
                    EnableSsl = true
                };

                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR AL ENVIAR EL MENSAJE.\n\n" +
                    $"Detalles técnicos: {ex.Message}");
            }
        }
    }
}