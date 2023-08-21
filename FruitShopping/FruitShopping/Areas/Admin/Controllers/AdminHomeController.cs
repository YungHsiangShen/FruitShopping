using Microsoft.AspNetCore.Mvc;

namespace FruitShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : Controller
    {
        public IActionResult ProductManager()
        {
            return View();
        }
    }
}
