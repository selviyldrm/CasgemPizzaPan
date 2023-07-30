﻿using Microsoft.AspNetCore.Mvc;
using PizzaPan.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPan.PresentationLayer.ViewComponents.Menu
{
    public class _PizzaPartial:ViewComponent
    {
		private readonly IProductService _productService;
		public _PizzaPartial(IProductService productService)
		{
			_productService = productService;
		}
		public IViewComponentResult Invoke()
		{
			var values = _productService.TGetProductsWithCategory().Where(x => x.CategoryID==1);

			return View(values);
		}
	}
}
   