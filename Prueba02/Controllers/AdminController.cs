using Microsoft.AspNetCore.Mvc;

namespace Prueba02.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
    
}
