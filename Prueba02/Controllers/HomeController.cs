using Microsoft.AspNetCore.Mvc;
using Prueba02.Models;
using Prueba02.Models.dbModels;
using Prueba02.Models.DTO;
using Prueba02.Models.ViewModel;
using System.Diagnostics;

namespace Prueba02.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProyectoContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ProyectoContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }

        public IActionResult Materias()
        {
            
            List<MateriaDTO> materiaDTOs = new List<MateriaDTO>();
            foreach (var item in _context.Materia.ToList())
            {
                MateriaDTO materia = new MateriaDTO()
                {
                    IdMateria = item.IdMateria,
                    Nombre = item.Nombre,
                    Descripcion = item.Descripcion,
                };
                materiaDTOs.Add(materia);
            }

            MateriasViewModel viewModel = new() 
            { 
                Materias = materiaDTOs
            };
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

