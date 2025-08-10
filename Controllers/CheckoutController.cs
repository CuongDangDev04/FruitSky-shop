using FruitSky.Models.ViewModels;
using FruitSky.Models;
using FruitSky.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FruitSky.Controllers
{   
	public class CheckoutController : Controller
	{
		private readonly DataContext _dataContext;

		public CheckoutController(DataContext context)
		{
			_dataContext = context;
		}
		public IActionResult Index(CheckoutModel checkoutModel)
		{
			HttpContext.Session.SetString("ReturnUrl", Url.Action("Index", "Checkout"));

			if (HttpContext.Session.GetString("Username") == null)
			{
				return RedirectToAction("Index", "Account");
			}

			HttpContext.Session.Remove("ReturnUrl");

			List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
			CartItemViewModel cartVM = new()
			{
				CartItems = cartItems,
				GrandTotal = cartItems.Sum(x => x.Quantity * x.Price)
			};

			var checkout = new CheckoutViewModel
			{
				CartItemViewModel = cartVM,
				CheckoutModel = checkoutModel
			};

			return View(checkout);
		}
		public IActionResult OrderSuccessful(CheckoutModel checkoutModel)
		{
			List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
			CartItemViewModel cartVM = new()
			{
				CartItems = cartItems,
				GrandTotal = cartItems.Sum(x => x.Quantity * x.Price)
			};
            var checkout = new CheckoutViewModel
            {
                CartItemViewModel = cartVM,
                CheckoutModel = checkoutModel
			};
            HttpContext.Session.Remove("Cart");

            return View(checkout);
		}
	}
}
