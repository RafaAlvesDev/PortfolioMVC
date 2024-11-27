using Microsoft.AspNetCore.Mvc;
using PortfolioMVC.Interface;
using PortfolioMVC.Models;

namespace PortfolioMVC.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IContatoService _contatoService;
        public PortfolioController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Portfolio()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contato(ContatoViewModel contatoViewModel)
        {
            await _contatoService.Enviar(contatoViewModel);
            return View();
        }

        public IActionResult Obrigado()
        {
            return View();
        }
    }
}
