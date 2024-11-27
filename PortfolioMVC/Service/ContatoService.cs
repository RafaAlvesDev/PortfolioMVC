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
                var caminhoArquivoXml = @"C:\Users\rafah\source\repos\EmailConfig.xml";
                // Carregar configurações do arquivo XML externo
                var configuracao = CarregarConfiguracaoEmail(caminhoArquivoXml);

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

        private EmailConfig CarregarConfiguracaoEmail(string caminhoArquivoXml)
        {
            if (!File.Exists(caminhoArquivoXml))
                throw new FileNotFoundException($"Arquivo de configuração não encontrado: {caminhoArquivoXml}");

            var xml = XDocument.Load(caminhoArquivoXml);

            return new EmailConfig
            {
                SmtpServer = xml.Root.Element("SmtpServer")?.Value,
                Port = int.Parse(xml.Root.Element("Port")?.Value ?? "587"),
                UserEmail = xml.Root.Element("UserEmail")?.Value,
                Password = xml.Root.Element("Password")?.Value,
                Recipient = xml.Root.Element("Recipient")?.Value
            };
        }
    }
}
