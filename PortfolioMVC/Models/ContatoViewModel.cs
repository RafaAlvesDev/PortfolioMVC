using System.ComponentModel.DataAnnotations;

namespace PortfolioMVC.Models
{
    public class ContatoViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A mensagem é obrigatório.")]
        public string? Mensagem { get; set; }
    }
}
