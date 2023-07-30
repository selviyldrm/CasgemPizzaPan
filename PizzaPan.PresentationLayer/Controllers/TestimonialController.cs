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
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            var values = _testimonialService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTestimonial(Testimonial testimonial)
        {
            _testimonialService.TInsert(testimonial);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            _testimonialService.TUpdate(testimonial);
            return RedirectToAction("Index");
        }
    }
}
