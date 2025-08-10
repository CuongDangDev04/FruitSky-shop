using FruitSky.Models.ViewModels;
using FruitSky.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FruitSky.Controllers
{
	public class HomeController : Controller
	{
		private readonly DataContext _dataContext;
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger,DataContext context)
		{
			_logger = logger;
			_dataContext = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error(int statsuscode)
		{
			if (statsuscode == 404)
			{
				return View();
			}
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
