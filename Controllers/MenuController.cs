using Microsoft.AspNetCore.Mvc;
using ModeloOrganizacional.Models;
using System.Diagnostics;
using ModeloOrganizacional.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace ModeloOrganizacional.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        private readonly ILogger<MenuController> _logger;
        private readonly ContasContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public MenuController(ContasContext context, UserManager<ApplicationUser> userManager, ILogger<MenuController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Topicos.OrderBy(i => i.Titulo).ToListAsync());
        }
        

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titulo", "Descricao")] Topicos topico)
        {
            if (!User.Identity.IsAuthenticated)
            {
                _logger.LogInformation("User is not authenticated");
                return Challenge(); // Returns a 401 Unauthorized response
            }
            try
            {

                    var user = await _userManager.GetUserAsync(User);

                    topico.ApplicationUserId = user.Id;
                    topico.ApplicationUser = user;
                    _context.Add(topico);

                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index");

            }
            catch (DbUpdateException ex)
            {
                // Log the exception message
                Console.WriteLine(ex.Message);
                ModelState.AddModelError("", "Não foi possível cadastrar o tópico");
            }
            catch (Exception ex)
            {
                // Log the exception message
                Console.WriteLine(ex.Message);
                throw;
            }
            return View(topico);
        }
        public async Task<ActionResult> Edit(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var topico = await _context.Topicos.SingleOrDefaultAsync(i => i.Id == id);
            if (topico == null)
            {
                return NotFound();
            }
            return View(topico);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("Id", "Titulo", "Descricao")] Topicos topico)
        {
            if (id != topico.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topico);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    if (!TopicosExists(topico.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(topico);
        }

        private bool TopicosExists(long? Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var topico = await _context.Topicos.SingleOrDefaultAsync(i => i.Id == id);
            if (topico == null)
            {
                return NotFound();
            }
            return View(topico);
        }
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var topico = await _context.Topicos.SingleOrDefaultAsync(i => i.Id == id);
            if (topico == null)
            {
                return NotFound();
            }
            return View(topico);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var topico = await _context.Topicos.SingleOrDefaultAsync(i => i.Id == id);
            _context.Topicos.Remove(topico);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
