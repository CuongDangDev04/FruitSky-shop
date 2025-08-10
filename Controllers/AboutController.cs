using Microsoft.AspNetCore.Mvc;

namespace FruitSky.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
