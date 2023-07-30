using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaPan.BusinessLayer.Abstract;
using PizzaPan.BusinessLayer.Conctrete;
using PizzaPan.BusinessLayer.ValidationRules.OurTeamValidator;
using PizzaPan.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPan.PresentationLayer.Controllers
{
    [Authorize]
    public class OurTeamController : Controller
    {
        private readonly IOurTeamService  _ourTeamService;

        public OurTeamController(IOurTeamService ourTeamService)
        {
            _ourTeamService = ourTeamService;
        }

        public IActionResult Index()
        {
            var values = _ourTeamService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddOurTeam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddOurTeam(OurTeam ourTeam)
        {
            CreateOurTeamValidator createOurTeamValidator = new CreateOurTeamValidator();
            ValidationResult result = createOurTeamValidator.Validate(ourTeam);
            if (result.IsValid)
            {
                _ourTeamService.TInsert(ourTeam);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteOurTeam(int id)
        {
            var values = _ourTeamService.TGetByID(id);
            _ourTeamService.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateOurTeam(int id)
        {
            var values = _ourTeamService.TGetByID(id);
            return View(values);
        } 
        [HttpPost]
        public IActionResult UpdateOurTeam(OurTeam ourTeam)
        {
            _ourTeamService.TUpdate(ourTeam);
            return RedirectToAction("Index");
        }
    }
}
