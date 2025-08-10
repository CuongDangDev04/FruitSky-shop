using FruitSky.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FruitSky.Controllers
{
	public class ProductController : Controller
	{

        readonly DataContext _dataContext;
        public ProductController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index (int Id)
        {
            if (Id == 0) return RedirectToAction("Error","Home");
            var productsById = _dataContext.Products.Where(p => p.Id == Id).FirstOrDefault();
            return View(productsById);
        }
	}
}
