using Microsoft.AspNetCore.Mvc;
using PizzaPan.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPan.PresentationLayer.ViewComponents.About
{
    public class _StatisticPartial:ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.HappyCustomer = context.Testimonials.Count();
            return View();
        }
    }
}
