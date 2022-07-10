using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.Models;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(Request request,
            IProductService productService) 
            : base(request)
        {
            this.productService = productService;
        }

        [Authorize]
        public Response Create()
            => this.View( new { IsAuthenticated = true });

        [HttpPost]
        [Authorize]
        public Response Create(CreateViewModel model)
        {
            var (created, error) = productService.CreateProduct(model);

            if (!created)
            {
                return View(new { ErrorMessage = error }, "/Error");
            }

            return Redirect("/");
        }
    }
}