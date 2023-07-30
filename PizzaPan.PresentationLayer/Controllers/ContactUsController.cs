using Microsoft.AspNetCore.Mvc;
using PizzaPan.DataAccessLayer.Concrete;
using PizzaPan.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPan.PresentationLayer.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly Context _context;

        public ContactUsController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Index(SendMessage p)
        {
            if (ModelState.IsValid) { 
            p.Date=DateTime.Now;
            _context.SendMessages.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
            }
            return View();
        }
    }
}
