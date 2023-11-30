using Microsoft.AspNetCore.Mvc;
using ModeloOrganizacional.Models;
using System.Diagnostics;
using ModeloOrganizacional.Data;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Create([Bind("Titulo","Descricao")]Topicos topico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(topico);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível cadastrar o tópico");
            }
            return View(topico);
        }
        public async Task<ActionResult> Edit(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var topico = await _context.Topicos.SingleOrDefaultAsync(i=>i.Id==id);
            if (topico == null)
            {
                return NotFound();
            }
            return View(topico);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id,[Bind("Id","Titulo", "Descricao")] Topicos topico)
        {
            if(id != topico.Id)
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
                    if(!TopicosExists(topico.Id))
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
            if(id == null)
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
        [HttpPost,ActionName("Delete")]
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
