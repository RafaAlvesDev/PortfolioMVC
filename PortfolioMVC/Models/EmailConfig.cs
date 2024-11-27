namespace PortfolioMVC.Models
{
    public class EmailConfig
    {
        public string? SmtpServer { get; set; }
        public int Port { get; set; }
        public string? UserEmail { get; set; }
        public string? Password { get; set; }
        public string? Recipient { get; set; }
    }
}
