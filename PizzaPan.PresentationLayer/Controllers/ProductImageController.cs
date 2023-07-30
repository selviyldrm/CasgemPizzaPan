using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaPan.BusinessLayer.Abstract;
using PizzaPan.EntityLayer.Concrete;
using PizzaPan.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPan.PresentationLayer.Controllers
{
    [Authorize]
    public class ProductImageController : Controller
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ImageFileViewModel model)
        {
            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(model.Image.FileName);
            var imageName = Guid.NewGuid() + extension;
            var savelocation=resource+"/wwwroot/images/"+imageName;
            var stream = new FileStream(savelocation, FileMode.Create);
            model.Image.CopyTo(stream);
            ProductImage productImage = new ProductImage();
            productImage.ImageUrl = imageName;
            _productImageService.TInsert(productImage);
            return RedirectToAction("ImageList");

        }
        public IActionResult ImageList()
        {
            var values=_productImageService.TGetList();
            return View(values);
        }
    }
}
