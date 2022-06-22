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
    public class Proposta_userController : Controller
    {
        private readonly MyDbContext _context;

        public Proposta_userController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Proposta_user
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.proposta_users.Include(p => p.id_propostaNavigation).Include(p => p.id_userNavigation);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Proposta_user/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proposta_user = await _context.proposta_users
                .Include(p => p.id_propostaNavigation)
                .Include(p => p.id_userNavigation)
                .FirstOrDefaultAsync(m => m.id_proposta_user == id);
            if (proposta_user == null)
            {
                return NotFound();
            }

            return View(proposta_user);
        }

        // GET: Proposta_user/Create
        public IActionResult Create()
        {
            ViewData["id_proposta"] = new SelectList(_context.proposta, "id_proposta", "descricao");
            ViewData["id_user"] = new SelectList(_context.users, "id_user", "email");
            return View();
        }

        // POST: Proposta_user/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_proposta_user,id_user,id_proposta")] proposta_user proposta_user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proposta_user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_proposta"] = new SelectList(_context.proposta, "id_proposta", "descricao", proposta_user.id_proposta);
            ViewData["id_user"] = new SelectList(_context.users, "id_user", "email", proposta_user.id_user);
            return View(proposta_user);
        }

        // GET: Proposta_user/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proposta_user = await _context.proposta_users.FindAsync(id);
            if (proposta_user == null)
            {
                return NotFound();
            }
            ViewData["id_proposta"] = new SelectList(_context.proposta, "id_proposta", "descricao", proposta_user.id_proposta);
            ViewData["id_user"] = new SelectList(_context.users, "id_user", "email", proposta_user.id_user);
            return View(proposta_user);
        }

        // POST: Proposta_user/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_proposta_user,id_user,id_proposta")] proposta_user proposta_user)
        {
            if (id != proposta_user.id_proposta_user)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proposta_user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!proposta_userExists(proposta_user.id_proposta_user))
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
            ViewData["id_proposta"] = new SelectList(_context.proposta, "id_proposta", "descricao", proposta_user.id_proposta);
            ViewData["id_user"] = new SelectList(_context.users, "id_user", "email", proposta_user.id_user);
            return View(proposta_user);
        }

        // GET: Proposta_user/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proposta_user = await _context.proposta_users
                .Include(p => p.id_propostaNavigation)
                .Include(p => p.id_userNavigation)
                .FirstOrDefaultAsync(m => m.id_proposta_user == id);
            if (proposta_user == null)
            {
                return NotFound();
            }

            return View(proposta_user);
        }

        // POST: Proposta_user/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proposta_user = await _context.proposta_users.FindAsync(id);
            _context.proposta_users.Remove(proposta_user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool proposta_userExists(int id)
        {
            return _context.proposta_users.Any(e => e.id_proposta_user == id);
        }
    }
}
