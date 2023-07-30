using Microsoft.AspNetCore.Mvc;
using PizzaPan.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPan.PresentationLayer.ViewComponents.About
{
    public class _OurTeamPartial:ViewComponent
    {
        private readonly IOurTeamService _ourTeamService;

        public _OurTeamPartial(IOurTeamService ourTeamService)
        {
            _ourTeamService = ourTeamService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _ourTeamService.TGetList();
            return View(values);
        }
    }
}
