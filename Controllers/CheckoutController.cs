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

		public IActionResult Index()
		{
			if (HttpContext.Session.GetString("Username") == null)
			{
				return RedirectToAction("Index", "Account");
			}

			List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
			CartItemViewModel cartVM = new()
			{
				CartItems = cartItems,
				GrandTotal = cartItems.Sum(x => x.Quantity * x.Price)
			};

			var checkoutVM = new CheckoutViewModel
			{
				CartItemViewModel = cartVM,
				CheckoutModel = new CheckoutModel() // khởi tạo model trống để bind form
			};

			return View(checkoutVM);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult PostOrder(CheckoutModel checkoutModel)
		{
			var username = HttpContext.Session.GetString("Username");
			if (string.IsNullOrEmpty(username))
			{
				return RedirectToAction("Index", "Account");
			}

			if (!ModelState.IsValid)
			{
				List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
				CartItemViewModel cartVM = new()
				{
					CartItems = cartItems,
					GrandTotal = cartItems.Sum(x => x.Quantity * x.Price)
				};

				var checkoutVM = new CheckoutViewModel
				{
					CartItemViewModel = cartVM,
					CheckoutModel = checkoutModel
				};

				return View("Index", checkoutVM);
			}

			var user = _dataContext.Users.FirstOrDefault(u => u.UserName == username);
			if (user == null)
			{
				return RedirectToAction("Index", "Account");
			}

			checkoutModel.UserId = user.Id;
			checkoutModel.OrderDate = DateTime.Now;

			// Khởi tạo collection tránh null reference
			checkoutModel.OrderDetails = new List<OrderDetailModel>();

			// Lấy giỏ hàng từ session
			var cartItemsSession = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();

			// Tạo OrderDetails từ giỏ hàng
			foreach (var cartItem in cartItemsSession)
			{
				var orderDetail = new OrderDetailModel
				{
					ProductId = cartItem.ProductId,
					Quantity = cartItem.Quantity,
					Price = cartItem.Price
				};
				checkoutModel.OrderDetails.Add(orderDetail);
			}

			// Thêm CheckoutModel cùng các OrderDetails vào DbContext
			_dataContext.Checkouts.Add(checkoutModel);
			_dataContext.SaveChanges();

			// Xóa giỏ hàng
			HttpContext.Session.Remove("Cart");

			return RedirectToAction("OrderSuccessful", new { id = checkoutModel.Id });
		}


		public IActionResult OrderSuccessful(int id)
		{
			var checkoutModel = _dataContext.Checkouts
				.Include(c => c.User)
				.Include(c => c.OrderDetails)
				.ThenInclude(od => od.Product)
				.FirstOrDefault(c => c.Id == id);

			if (checkoutModel == null)
			{
				return NotFound();
			}

			// Tạo danh sách CartItemModel từ OrderDetails để view hiển thị
			var cartItems = checkoutModel.OrderDetails.Select(od => new CartItemModel
			{
				ProductId = od.ProductId,
				ProductName = od.Product?.ProductName ?? "N/A",
				Quantity = od.Quantity,
				Price = od.Price,
				Img = od.Product?.Img ?? ""
			}).ToList();

			var cartVM = new CartItemViewModel
			{
				CartItems = cartItems,
				GrandTotal = cartItems.Sum(ci => ci.Quantity * ci.Price)
			};

			var checkoutVM = new CheckoutViewModel
			{
				CartItemViewModel = cartVM,
				CheckoutModel = checkoutModel
			};

			return View(checkoutVM);
		}
	}
}
