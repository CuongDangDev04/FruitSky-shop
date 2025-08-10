using FruitSky.Models;
using FruitSky.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FruitSky.Controllers
{
	public class ContactController : Controller
	{
		private readonly DataContext _dataContext;

		public ContactController(DataContext context)
		{
			_dataContext = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(ContactModel contactModel)
		{
			if (ModelState.IsValid)
			{
				_dataContext.Contacts.Add(contactModel);
				_dataContext.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
