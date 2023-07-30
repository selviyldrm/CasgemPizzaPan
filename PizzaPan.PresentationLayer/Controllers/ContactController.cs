using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaPan.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPan.PresentationLayer.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var values = _contactService.TGetList();
            return View(values);
        }
        public IActionResult DeleteContact(int id)
        {
            var values = _contactService.TGetByID(id);
            _contactService.TDelete(values);
            return RedirectToAction("Index");
        }

        public IActionResult GetMessageByTesekkur()
        {
            var values = _contactService.TGetContactBySubjectWithTesekkur();
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            var value = _contactService.TGetByID(id);
            return View(value);
        }
        }
}
