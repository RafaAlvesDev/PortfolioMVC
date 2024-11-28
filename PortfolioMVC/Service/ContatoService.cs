using dotenv.net;
using PortfolioMVC.Interface;
using PortfolioMVC.Models;
using System.Net;
using System.Net.Mail;
using System.Xml.Linq;

namespace PortfolioMVC.Service
{
    public class ContatoService : IContatoService
    {
        public async Task Enviar(ContatoViewModel contato)
        {
            try
            {
                DotEnv.Load();

                var configuracao = new EmailConfig()
                {
                    SmtpServer = Environment.GetEnvironmentVariable("SMTPSERVER"),
                    Port = int.Parse(Environment.GetEnvironmentVariable("PORT")),
                    UserEmail = Environment.GetEnvironmentVariable("USEREMAIL"),
                    Password = Environment.GetEnvironmentVariable("PASSWORD"),
                    Recipient = Environment.GetEnvironmentVariable("RECIPIENT")
                };

                if (configuracao != null)
                {
                    if (configuracao.UserEmail == null)
                    {
                        throw new Exception("");
                    }

                    if (configuracao.Recipient == null)
                    {
                        throw new Exception("");
                    }

                    // Configuração do cliente SMTP
                    using (SmtpClient smtpClient = new SmtpClient(configuracao.SmtpServer, configuracao.Port)
                    {
                        Credentials = new NetworkCredential(configuracao.UserEmail, configuracao.Password),
                        EnableSsl = true
                    })

                    using (MailMessage mail = new MailMessage
                    {
                        From = new MailAddress(configuracao.UserEmail),
                        Subject = $"Protfolio - {contato.Nome}",
                        Body = $"De: {contato.Nome} \r\nEmail: {contato.Email} \r\nMensagem : {contato.Mensagem}",
                        IsBodyHtml = false
                    })
                    {
                        mail.To.Add(configuracao.Recipient);

                        // Enviar o e-mail
                        await smtpClient.SendMailAsync(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
            }
        }
    }
}
