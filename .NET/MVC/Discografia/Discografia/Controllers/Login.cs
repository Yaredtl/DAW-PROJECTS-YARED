using Microsoft.AspNetCore.Mvc;

namespace Discografia.Controllers
{
	public class Login : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
