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
    public class PropostaController : Controller
    {
        private readonly MyDbContext _context;

        public PropostaController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Proposta
        public async Task<IActionResult> Index()
        {
            return View(await _context.proposta.ToListAsync());
        }

        // GET: Proposta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propostum = await _context.proposta
                .FirstOrDefaultAsync(m => m.id_proposta == id);
            if (propostum == null)
            {
                return NotFound();
            }

            return View(propostum);
        }

        // GET: Proposta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proposta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_proposta,nome_proposta,tipo_talento,expr_minima,total_horas,descricao")] propostum propostum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propostum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propostum);
        }

        // GET: Proposta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propostum = await _context.proposta.FindAsync(id);
            if (propostum == null)
            {
                return NotFound();
            }
            return View(propostum);
        }

        // POST: Proposta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_proposta,nome_proposta,tipo_talento,expr_minima,total_horas,descricao")] propostum propostum)
        {
            if (id != propostum.id_proposta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propostum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!propostumExists(propostum.id_proposta))
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
            return View(propostum);
        }

        // GET: Proposta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propostum = await _context.proposta
                .FirstOrDefaultAsync(m => m.id_proposta == id);
            if (propostum == null)
            {
                return NotFound();
            }

            return View(propostum);
        }

        // POST: Proposta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propostum = await _context.proposta.FindAsync(id);
            _context.proposta.Remove(propostum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool propostumExists(int id)
        {
            return _context.proposta.Any(e => e.id_proposta == id);
        }
    }
}
