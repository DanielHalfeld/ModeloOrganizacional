using Microsoft.AspNetCore.Mvc;
using ModeloOrganizacional.Models;
using System.Diagnostics;

namespace ModeloOrganizacional.Controllers
{
    public class MenuController : Controller
    {
        private readonly ModeloOrganizacionalContext _context;

        public MenuController(ModeloOrganizacionalContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
