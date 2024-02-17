using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using ZeroOnzeTour.DB;
using ZeroOnzeTour.Models;
using Microsoft.EntityFrameworkCore;
using ZeroOnzeTour.Util;

namespace ZeroOnzeTourSite.Controllers
{
    public class Account : Controller
    {
        private readonly MySqlContext _context;

        public Account(MySqlContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([Bind("Password,Email")] login model)
        {
            if (ModelState.IsValid)
            {
                var _senha = Hash.CreateMD5(model.Password);
                var usuario = await _context.Usuario
                          .FirstOrDefaultAsync(m => m.Senha == _senha && m.Email == model.Email);
                if (usuario == null)
                {
                    ModelState.AddModelError(string.Empty, "Usuário ou senha invalido!");
                }
                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(usuario.Id)),
                        new Claim(ClaimTypes.Name, usuario.Nome),
                        new Claim("Favorite", "User")
                };
                //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                var principal = new ClaimsPrincipal(identity);
                //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                {
                    IsPersistent = true
                });

                return RedirectToAction("Index", "ViagemTours");

            }

                return View(model);
        }
        public async Task<IActionResult> LogOut()
        {
            //SignOutAsync is Extension method for SignOut    
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //Redirect to home page    
            return LocalRedirect("/");
        }
    }
}
