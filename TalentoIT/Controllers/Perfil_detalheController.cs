using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TalentoIT.Context;
using TalentoIT.Entities;

namespace TalentoIT.Controllers
{
    public class Perfil_detalheController : Controller
    {
        private readonly MyDbContext _context;

        public Perfil_detalheController(MyDbContext context)
        {
            _context = context;
        }
        
        public IActionResult ErroDelete()
        {
            return View();
        }

        // GET: Perfil_detalhe
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.perfil_detalhes.Include(p => p.id_perfil_talentoNavigation);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Perfil_detalhe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfil_detalhe = await _context.perfil_detalhes
                .Include(p => p.id_perfil_talentoNavigation)
                .FirstOrDefaultAsync(m => m.id_perfil_detalhe == id);
            if (perfil_detalhe == null)
            {
                return NotFound();
            }

            return View(perfil_detalhe);
        }

        // GET: Perfil_detalhe/Create
        public IActionResult Create()
        {
            ViewData["id_perfil_talento"] = new SelectList(_context.perfil_talentos, "id_perfil_talento", "email");
            return View();
        }

        // POST: Perfil_detalhe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_perfil_detalhe,titulo_exp,nome_empresa,ano_inico,ano_fim,id_perfil_talento")] perfil_detalhe perfil_detalhe)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _context.Add(perfil_detalhe);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["id_perfil_talento"] = new SelectList(_context.perfil_talentos, "id_perfil_talento", "email", perfil_detalhe.id_perfil_talento);
                return View(perfil_detalhe);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return RedirectToAction(nameof(ErroDelete));
            }
        }

        // GET: Perfil_detalhe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfil_detalhe = await _context.perfil_detalhes.FindAsync(id);
            if (perfil_detalhe == null)
            {
                return NotFound();
            }
            ViewData["id_perfil_talento"] = new SelectList(_context.perfil_talentos, "id_perfil_talento", "email", perfil_detalhe.id_perfil_talento);
            return View(perfil_detalhe);
        }

        // POST: Perfil_detalhe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_perfil_detalhe,titulo_exp,nome_empresa,ano_inico,ano_fim,id_perfil_talento")] perfil_detalhe perfil_detalhe)
        {
            if (id != perfil_detalhe.id_perfil_detalhe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perfil_detalhe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!perfil_detalheExists(perfil_detalhe.id_perfil_detalhe))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_perfil_talento"] = new SelectList(_context.perfil_talentos, "id_perfil_talento", "email", perfil_detalhe.id_perfil_talento);
            return View(perfil_detalhe);
        }

        // GET: Perfil_detalhe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfil_detalhe = await _context.perfil_detalhes
                .Include(p => p.id_perfil_talentoNavigation)
                .FirstOrDefaultAsync(m => m.id_perfil_detalhe == id);
            if (perfil_detalhe == null)
            {
                return NotFound();
            }

            return View(perfil_detalhe);
        }

        // POST: Perfil_detalhe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perfil_detalhe = await _context.perfil_detalhes.FindAsync(id);
            _context.perfil_detalhes.Remove(perfil_detalhe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool perfil_detalheExists(int id)
        {
            return _context.perfil_detalhes.Any(e => e.id_perfil_detalhe == id);
        }
    }
}
