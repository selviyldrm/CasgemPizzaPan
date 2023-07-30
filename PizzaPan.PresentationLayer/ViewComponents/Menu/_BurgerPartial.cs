using Microsoft.AspNetCore.Mvc;
using PizzaPan.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPan.PresentationLayer.ViewComponents.Menu
{
    public class _BurgerPartial : ViewComponent
    {

        private readonly  IProductService _productService;
        public _BurgerPartial(IProductService productService)
        {
            _productService = productService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _productService.TGetProductsWithCategory().Where(x => x.CategoryID == 2);
            return View(values);
        }
    }
}