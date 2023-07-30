using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaPan.BusinessLayer.Abstract;
using PizzaPan.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPan.PresentationLayer.Controllers
{
    [Authorize]
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public IActionResult CreateCode()
        {
            string[] symbol = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M" };
            int c1, c2, c3, c4;
            Random random = new Random();
            c1 = random.Next(0, symbol.Length);
            c2 = random.Next(0, symbol.Length);
            c3 = random.Next(0, symbol.Length);
            c4 = random.Next(0, symbol.Length);
            int c5 = random.Next(10, 100);
            ViewBag.v = symbol[c1] + symbol[c2] + symbol[c3] + symbol[c4] + c5;
            return View();
        }
        [HttpPost]
        public IActionResult CreateCode(Discount discount)
        {
            discount.CreatedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            discount.EndingDate = Convert.ToDateTime(DateTime.Now.AddDays(3));
            _discountService.TInsert(discount);
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var values = _discountService.TGetList();
            return View(values);
        }
    }
}
