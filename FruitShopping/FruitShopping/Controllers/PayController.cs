using Microsoft.AspNetCore.Mvc;

namespace FruitShopping.Controllers
{
    public class PayController : Controller
    {
        public IActionResult Payment()
        {
            return View();
        }
        public IActionResult cart()
        {
            return View();
        }
    }
}
