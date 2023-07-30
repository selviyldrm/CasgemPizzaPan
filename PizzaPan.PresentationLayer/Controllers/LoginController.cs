using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PizzaPan.EntityLayer.Concrete;
using PizzaPan.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPan.PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
