using Microsoft.AspNetCore.Mvc;

namespace FruitShopping.Controllers
{
	public class MemberController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult customer_service()
		{
			return View();
		}

		public IActionResult favorite_list()
		{
			return View();
		}

		public IActionResult order_history()
		{
			return View();
		}

    }
}
