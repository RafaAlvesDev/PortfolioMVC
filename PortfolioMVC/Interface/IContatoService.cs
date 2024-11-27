using PortfolioMVC.Models;

namespace PortfolioMVC.Interface
{
    public interface IContatoService
    {
        Task Enviar(ContatoViewModel contato);
    }
}
