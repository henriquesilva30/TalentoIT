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
    public class Talento_SkillController : Controller
    {
        private readonly MyDbContext _context;

        public Talento_SkillController()
        {
            _context = new MyDbContext() ;
        }

        // GET: Talento_Skill
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.talento_skills.Include(t => t.id_perfil_talentoNavigation).Include(t => t.id_skillNavigation);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Talento_Skill/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talento_skill = await _context.talento_skills
                .Include(t => t.id_perfil_talentoNavigation)
                .Include(t => t.id_skillNavigation)
                .FirstOrDefaultAsync(m => m.id_talento_skill == id);
            if (talento_skill == null)
            {
                return NotFound();
            }

            return View(talento_skill);
        }

        // GET: Talento_Skill/Create
        public IActionResult Create()
        {
            ViewData["id_perfil_talento"] = new SelectList(_context.perfil_talentos, "id_perfil_talento", "email");
            ViewData["id_skill"] = new SelectList(_context.skills, "id_skill", "area");
            return View();
        }

        // POST: Talento_Skill/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_talento_skill,id_skill,id_perfil_talento")] talento_skill talento_skill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(talento_skill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_perfil_talento"] = new SelectList(_context.perfil_talentos, "id_perfil_talento", "email", talento_skill.id_perfil_talento);
            ViewData["id_skill"] = new SelectList(_context.skills, "id_skill", "area", talento_skill.id_skill);
            return View(talento_skill);
        }

        // GET: Talento_Skill/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talento_skill = await _context.talento_skills.FindAsync(id);
            if (talento_skill == null)
            {
                return NotFound();
            }
            ViewData["id_perfil_talento"] = new SelectList(_context.perfil_talentos, "id_perfil_talento", "email", talento_skill.id_perfil_talento);
            ViewData["id_skill"] = new SelectList(_context.skills, "id_skill", "area", talento_skill.id_skill);
            return View(talento_skill);
        }

        // POST: Talento_Skill/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_talento_skill,id_skill,id_perfil_talento")] talento_skill talento_skill)
        {
            if (id != talento_skill.id_talento_skill)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(talento_skill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!talento_skillExists(talento_skill.id_talento_skill))
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
            ViewData["id_perfil_talento"] = new SelectList(_context.perfil_talentos, "id_perfil_talento", "email", talento_skill.id_perfil_talento);
            ViewData["id_skill"] = new SelectList(_context.skills, "id_skill", "area", talento_skill.id_skill);
            return View(talento_skill);
        }

        // GET: Talento_Skill/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talento_skill = await _context.talento_skills
                .Include(t => t.id_perfil_talentoNavigation)
                .Include(t => t.id_skillNavigation)
                .FirstOrDefaultAsync(m => m.id_talento_skill == id);
            if (talento_skill == null)
            {
                return NotFound();
            }

            return View(talento_skill);
        }

        // POST: Talento_Skill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var talento_skill = await _context.talento_skills.FindAsync(id);
            _context.talento_skills.Remove(talento_skill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool talento_skillExists(int id)
        {
            return _context.talento_skills.Any(e => e.id_talento_skill == id);
        }
    }
}
