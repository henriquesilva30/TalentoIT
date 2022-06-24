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
    public class User_skillController : Controller
    {
        private readonly MyDbContext _context;

        public User_skillController()
        {
            _context = new MyDbContext() ;
        }

        // GET: User_skill
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.user_skills.Include(u => u.id_skillNavigation).Include(u => u.id_userNavigation);
            return View(await myDbContext.ToListAsync());
        }

        // GET: User_skill/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_skill = await _context.user_skills
                .Include(u => u.id_skillNavigation)
                .Include(u => u.id_userNavigation)
                .FirstOrDefaultAsync(m => m.id_user_skill == id);
            if (user_skill == null)
            {
                return NotFound();
            }

            return View(user_skill);
        }

        // GET: User_skill/Create
        public IActionResult Create()
        {
            ViewData["id_skill"] = new SelectList(_context.skills, "id_skill", "area");
            ViewData["id_user"] = new SelectList(_context.users, "id_user", "email");
            return View();
        }

        // POST: User_skill/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_user_skill,id_skill,id_user")] user_skill user_skill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user_skill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_skill"] = new SelectList(_context.skills, "id_skill", "area", user_skill.id_skill);
            ViewData["id_user"] = new SelectList(_context.users, "id_user", "email", user_skill.id_user);
            return View(user_skill);
        }

        // GET: User_skill/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_skill = await _context.user_skills.FindAsync(id);
            if (user_skill == null)
            {
                return NotFound();
            }
            ViewData["id_skill"] = new SelectList(_context.skills, "id_skill", "area", user_skill.id_skill);
            ViewData["id_user"] = new SelectList(_context.users, "id_user", "email", user_skill.id_user);
            return View(user_skill);
        }

        // POST: User_skill/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_user_skill,id_skill,id_user")] user_skill user_skill)
        {
            if (id != user_skill.id_user_skill)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user_skill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!user_skillExists(user_skill.id_user_skill))
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
            ViewData["id_skill"] = new SelectList(_context.skills, "id_skill", "area", user_skill.id_skill);
            ViewData["id_user"] = new SelectList(_context.users, "id_user", "email", user_skill.id_user);
            return View(user_skill);
        }

        // GET: User_skill/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_skill = await _context.user_skills
                .Include(u => u.id_skillNavigation)
                .Include(u => u.id_userNavigation)
                .FirstOrDefaultAsync(m => m.id_user_skill == id);
            if (user_skill == null)
            {
                return NotFound();
            }

            return View(user_skill);
        }

        // POST: User_skill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user_skill = await _context.user_skills.FindAsync(id);
            _context.user_skills.Remove(user_skill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool user_skillExists(int id)
        {
            return _context.user_skills.Any(e => e.id_user_skill == id);
        }
    }
}
