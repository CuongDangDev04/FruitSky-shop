using FruitSky.Models;
using FruitSky.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FruitSky.Controllers
{
	public class AccountController : Controller
	{
		private readonly DataContext _dataContext;

		public AccountController(DataContext context)
		{
			_dataContext = context;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Register(UserModel userModel)
		{
			if (ModelState.IsValid)
			{
				if (_dataContext != null)
				{
					var existingUserByUsername = _dataContext.Users.FirstOrDefault(u => u.UserName == userModel.UserName);
					var existingUserByEmail = _dataContext.Users.FirstOrDefault(u => u.Email == userModel.Email);

					if (existingUserByUsername == null && existingUserByEmail == null)
					{
						userModel.Password = HashPassword(userModel.Password);

						_dataContext.Users.Add(userModel);
						_dataContext.SaveChanges();

						return RedirectToAction("Index");
					}
					else
					{
						if (existingUserByUsername != null)
						{
							ModelState.AddModelError("", "Tên đăng nhập đã tồn tại, vui lòng nhập tên khác");
						}

						if (existingUserByEmail != null)
						{
							ModelState.AddModelError("", "Email đã tồn tại, vui lòng nhập email khác");
						}
					}
				}
			}

			return View("Register", userModel);
		}
		private string HashPassword(string password)
		{
			return BCrypt.Net.BCrypt.HashPassword(password);
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(UserModel userModel)
		{
			if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
			{
				return RedirectToAction("Error", "Home");
			}
			if (ModelState.IsValid)
			{
				var user = _dataContext.Users.FirstOrDefault(u => u.UserName == userModel.UserName);

				if (user != null)
				{
					if (BCrypt.Net.BCrypt.Verify(userModel.Password, user.Password))
					{
						HttpContext.Session.SetString("Username", user.UserName);

						string returnUrl = HttpContext.Session.GetString("ReturnUrl");

						if (!string.IsNullOrEmpty(returnUrl))
						{
							return Redirect(returnUrl);
						}

						return RedirectToAction("Index", "Home");
					}
					else
					{
						ModelState.AddModelError("", "Sai mật khẩu. Vui lòng kiểm tra lại thông tin đăng nhập.");
					}
				}
				else
				{
					ModelState.AddModelError("", "Tên đăng nhập không tồn tại. Vui lòng kiểm tra lại thông tin đăng nhập.");
				}
			}

			return View(userModel);
		}
		public IActionResult Logout()
		{
			HttpContext.Session.Remove("Username");
			return RedirectToAction("Index", "Home");
		}

	}
}