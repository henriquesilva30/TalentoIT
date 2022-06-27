using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TalentoIT;
using TalentoIT.Models;
using TalentoIT.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Controllers
{
    public class AuthController : Controller
    {
        private readonly MyDbContext _context;

        public AuthController()
        {
            _context = new MyDbContext();
        }
        
        public IActionResult Login()
        {
            return View();
        }  
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Password")] LoginModel login)
        {

            var user = _context.users
                .FirstOrDefault(u => u.email.Equals(login.Email) && u.pass.Equals(login.Password));

            if (user != null)
            {
                UserSession.UserId = user.id_user;
                UserSession.Username = user.nome_user;
                return RedirectToAction(controllerName: "Home", actionName: "Index");
            }
            
            ViewData["HasError"] = true;
            
            return View(login);
        }
    }
}