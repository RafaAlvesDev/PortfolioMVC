using Microsoft.AspNetCore.Mvc;

namespace PortfolioMVC.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Portfolio()
        {
            return View();
        }

        public IActionResult Contato()
        {
            return View();
        }
    }
}
