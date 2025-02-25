using AUT02_05.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.CompilerServices;
namespace AUT02_05.Controllers
{
    public class AdminController : Controller
    {
        private readonly GabrielContext _context;
        private readonly DiccionarioContext _diccionarioContext;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AdminController(GabrielContext context, SignInManager<IdentityUser> signInManager, DiccionarioContext diccionarioContext)
        {
            _context = context;
            _signInManager = signInManager;
            _diccionarioContext = diccionarioContext;
        }
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Usuarios()
        {
            var users =   _context.Users;
            return View(users.ToList());
        }
        [HttpGet]
        public IActionResult GetPremium() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetPremium(IFormCollection collection)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            await _signInManager.UserManager.AddToRoleAsync(user, "Premium");
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index","Espengs");
        }
    }
}
