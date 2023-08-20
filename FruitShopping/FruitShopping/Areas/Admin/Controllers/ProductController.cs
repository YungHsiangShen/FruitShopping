using Microsoft.AspNetCore.Mvc;

namespace FruitShopping.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
