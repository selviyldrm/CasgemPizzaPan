using Microsoft.AspNetCore.Mvc;
using PizzaPan.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPan.PresentationLayer.ViewComponents.Default
{
    public class _FooterPartial :ViewComponent
    {
        private readonly IContactService _contactservice;

        public _FooterPartial(IContactService contactservice)
        {
            _contactservice = contactservice;
        }

        public IViewComponentResult Invoke()
        {
            var values = _contactservice.TGetList();
            return View(values);
        }
    }
}
