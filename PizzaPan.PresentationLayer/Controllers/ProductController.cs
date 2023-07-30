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
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            //var values=_productService.TGetList();
            var values = _productService.TGetProductsWithCategory();
            return View(values);
        }


       [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _productService.TInsert(product);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(int id)
        {
            var values = _productService.TGetByID(id);
            _productService.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var values = _productService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _productService.TUpdate(product);
            return RedirectToAction("Index");
        }
    }
}
