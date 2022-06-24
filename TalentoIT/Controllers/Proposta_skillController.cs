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
    public class Proposta_skillController : Controller
    {
        private readonly MyDbContext _context;

        public Proposta_skillController()
        {
            _context = new MyDbContext() ;
        }

        // GET: Proposta_skill
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.proposta_skills.Include(p => p.id_propostaNavigation).Include(p => p.id_skillNavigation);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Proposta_skill/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proposta_skill = await _context.proposta_skills
                .Include(p => p.id_propostaNavigation)
                .Include(p => p.id_skillNavigation)
                .FirstOrDefaultAsync(m => m.id_proposta_skill == id);
            if (proposta_skill == null)
            {
                return NotFound();
            }

            return View(proposta_skill);
        }

        // GET: Proposta_skill/Create
        public IActionResult Create()
        {
            ViewData["id_proposta"] = new SelectList(_context.proposta, "id_proposta", "descricao");
            ViewData["id_skill"] = new SelectList(_context.skills, "id_skill", "area");
            return View();
        }

        // POST: Proposta_skill/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_proposta_skill,id_skill,id_proposta")] proposta_skill proposta_skill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proposta_skill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_proposta"] = new SelectList(_context.proposta, "id_proposta", "descricao", proposta_skill.id_proposta);
            ViewData["id_skill"] = new SelectList(_context.skills, "id_skill", "area", proposta_skill.id_skill);
            return View(proposta_skill);
        }

        // GET: Proposta_skill/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proposta_skill = await _context.proposta_skills.FindAsync(id);
            if (proposta_skill == null)
            {
                return NotFound();
            }
            ViewData["id_proposta"] = new SelectList(_context.proposta, "id_proposta", "descricao", proposta_skill.id_proposta);
            ViewData["id_skill"] = new SelectList(_context.skills, "id_skill", "area", proposta_skill.id_skill);
            return View(proposta_skill);
        }

        // POST: Proposta_skill/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_proposta_skill,id_skill,id_proposta")] proposta_skill proposta_skill)
        {
            if (id != proposta_skill.id_proposta_skill)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proposta_skill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!proposta_skillExists(proposta_skill.id_proposta_skill))
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
            ViewData["id_proposta"] = new SelectList(_context.proposta, "id_proposta", "descricao", proposta_skill.id_proposta);
            ViewData["id_skill"] = new SelectList(_context.skills, "id_skill", "area", proposta_skill.id_skill);
            return View(proposta_skill);
        }

        // GET: Proposta_skill/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proposta_skill = await _context.proposta_skills
                .Include(p => p.id_propostaNavigation)
                .Include(p => p.id_skillNavigation)
                .FirstOrDefaultAsync(m => m.id_proposta_skill == id);
            if (proposta_skill == null)
            {
                return NotFound();
            }

            return View(proposta_skill);
        }

        // POST: Proposta_skill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proposta_skill = await _context.proposta_skills.FindAsync(id);
            _context.proposta_skills.Remove(proposta_skill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool proposta_skillExists(int id)
        {
            return _context.proposta_skills.Any(e => e.id_proposta_skill == id);
        }
    }
}
