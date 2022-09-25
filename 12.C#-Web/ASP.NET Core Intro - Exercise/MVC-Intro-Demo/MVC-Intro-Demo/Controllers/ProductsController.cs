using Microsoft.AspNetCore.Mvc;
using MVC_Intro_Demo.Models;
using System.Text;
using System.Text.Json;

namespace MVC_Intro_Demo.Controllers
{
    public class ProductsController : Controller
    {
        private IEnumerable<ProductViewModel> products
            = new List<ProductViewModel>()
            {
                new ProductViewModel()
                {
                    Id = 1,
                    Name = "Cheese",
                    Price = 7.00M
                },
                new ProductViewModel()
                {
                    Id = 2,
                    Name = "Ham",
                    Price = 5.50M
                },
                new ProductViewModel()
                {
                    Id = 3,
                    Name = "Bread",
                    Price = 1.50M
                }
            };

        [ActionName("My-Products")]
        public ActionResult All(string keyword)
        {
            if (keyword != null)
            {
                var foundProducts = this.products
                                        .Where(pr => pr.Name.ToLower().Contains(keyword.ToLower()))
                                        .ToList();

                return View(foundProducts);
            }

            return View(this.products);
        }

        public ActionResult ById(int id)
        {
            var product = this.products
                              .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return BadRequest();
            }

            return this.View(product);
        }

        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return Json(products, options);
        }

        public IActionResult AllAsText()
        {
            var text = String.Empty;

            foreach (var pr in this.products)
            {
                text += $"Product {pr.Id}: {pr.Name} - {pr.Price}lv";
                text += "\r\n";
            }

            byte[] textAsByteArr = Encoding.ASCII.GetBytes(text);
            return File(textAsByteArr, "plain/text", "products.txt");
        }
    }
}