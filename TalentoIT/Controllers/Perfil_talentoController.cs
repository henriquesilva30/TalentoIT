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
    public class Perfil_talentoController : Controller
    {
        private readonly MyDbContext _context;

        public Perfil_talentoController()
        {
            _context = new MyDbContext() ;

        }

        // GET: Perfil_talento
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.perfil_talentos.Include(p => p.id_userNavigation);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Perfil_talento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfil_talento = await _context.perfil_talentos
                .Include(p => p.id_userNavigation)
                .FirstOrDefaultAsync(m => m.id_perfil_talento == id);
            if (perfil_talento == null)
            {
                return NotFound();
            }

            return View(perfil_talento);
        }

        // GET: Perfil_talento/Create
        public IActionResult Create()
        {
            ViewData["id_user"] = new SelectList(_context.users, "id_user", "email");
            return View();
        }

        // POST: Perfil_talento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_perfil_talento,nome_talento,preco_hora,email,flag,id_user")] perfil_talento perfil_talento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perfil_talento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_user"] = new SelectList(_context.users, "id_user", "email", perfil_talento.id_user);
            return View(perfil_talento);
        }

        // GET: Perfil_talento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfil_talento = await _context.perfil_talentos.FindAsync(id);
            if (perfil_talento == null)
            {
                return NotFound();
            }
            ViewData["id_user"] = new SelectList(_context.users, "id_user", "email", perfil_talento.id_user);
            return View(perfil_talento);
        }

        // POST: Perfil_talento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_perfil_talento,nome_talento,preco_hora,email,flag,id_user")] perfil_talento perfil_talento)
        {
            if (id != perfil_talento.id_perfil_talento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perfil_talento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!perfil_talentoExists(perfil_talento.id_perfil_talento))
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
            ViewData["id_user"] = new SelectList(_context.users, "id_user", "email", perfil_talento.id_user);
            return View(perfil_talento);
        }

        // GET: Perfil_talento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfil_talento = await _context.perfil_talentos
                .Include(p => p.id_userNavigation)
                .FirstOrDefaultAsync(m => m.id_perfil_talento == id);
            if (perfil_talento == null)
            {
                return NotFound();
            }

            return View(perfil_talento);
        }

        // POST: Perfil_talento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perfil_talento = await _context.perfil_talentos.FindAsync(id);
            _context.perfil_talentos.Remove(perfil_talento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool perfil_talentoExists(int id)
        {
            return _context.perfil_talentos.Any(e => e.id_perfil_talento == id);
        }
    }
}
