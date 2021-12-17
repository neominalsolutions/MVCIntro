using Microsoft.AspNetCore.Mvc;
using MVCIntro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCIntro.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(string id)
        {
            var model = new ProductDetailViewModel
            {
                CategoryName = "Kategori 1",
                Name = "Urun 1",
                Price = 30,
                Stock = 14
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult ListProduct()
        {
            // view ile ilgili tüm operasyonları denetleyeceğimiz action

            var category = new Category
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Kategori 1"
            };

            var products = new List<Product> {
                new Product
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Product 1",
                Price = 10,
                Stock = 30
            },
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Product 2",
                    Price = 15,
                    Stock = 50
                }

            };

            var model = new ProductViewModel
            {
                Category = category,
                Products = products,
                TotalCount = 10

            };

            // view tek bir tane model gönderme hakkımız var.

            return View(model);
        }

        [HttpGet]
        public IActionResult ProductCrudJS()
        {
            var category = new Category
            {
                Id = "681a12cd-32f6-4b83-a180-1bf2c2bf4875",
                Name = "Kategori 1"
            };

            var products = new List<Product> {
                new Product
            {
                Id = "4e7d9761-7962-467c-85a2-09f30d77d985",
                Name = "Product 1",
                Price = 10,
                Stock = 30
            },
                new Product
                {
                    Id = "681a12cd-32f6-4b83-a180-1bf2c2bf4875",
                    Name = "Product 2",
                    Price = 15,
                    Stock = 50
                }

            };


            var model = new ProductViewModel
            {
                Category = category,
                Products = products,
                TotalCount = 10,
                Input = new ProductInputModel() 

            };

            return View(model);
        }


        [HttpGet]
        public IActionResult ProductCrud(bool addButtonClick, bool editButtonClick,string clickId, string message)
        {

            var category = new Category
            {
                Id = "681a12cd-32f6-4b83-a180-1bf2c2bf4875",
                Name = "Kategori 1"
            };

            var products = new List<Product> {
                new Product
            {
                Id = "4e7d9761-7962-467c-85a2-09f30d77d985",
                Name = "Product 1",
                Price = 10,
                Stock = 30
            },
                new Product
                {
                    Id = "681a12cd-32f6-4b83-a180-1bf2c2bf4875",
                    Name = "Product 2",
                    Price = 15,
                    Stock = 50
                }

            };

           
         
            ViewData["addButtonClick"] = addButtonClick;
            ViewData["editButtonClick"] = editButtonClick;
            ViewData["ClickId"] = clickId;
            ViewData["Message"] = message;


            var model = new ProductViewModel
            {
                Category = category,
                Products = products,
                TotalCount = 10,
                Input = addButtonClick ? new ProductInputModel() : new ProductInputModel
                {
                    Name = "Kazak",
                    Price = 30,
                    Stock = 40
                }

            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ProductInputModel model)
        {

            TempData["Message"] = "Kayıt Başarılı";
           

            // Kayıt başalı olunca benim addButtonClick kapamam lazım
            return Redirect($"ProductCrud?addButtonClick=false&editButtonClick=false&clickId=null&message=Kayıt Başarılı");
        }


        [HttpPost]
        public IActionResult Update(ProductInputModel model)
        {

            TempData["Message"] = "Güncelleme Başarılı";


            // Kayıt başalı olunca benim addButtonClick kapamam lazım
            return Redirect($"ProductCrud?addButtonClick=false&editButtonClick=false&clickId=null");
        }

        [HttpPost]
        public IActionResult Delete(string DeleteId)
        {
            TempData["Message"] = "Silme işlemi Başarılı";

            return Redirect($"ProductCrud?addButtonClick=false&editButtonClick=false&clickId=null");
        }


        [HttpPost]
        public JsonResult CreateJson([FromBody] Product model)
        {
            return Json(model);
        }
    }
}
