using FruitSky.Repository;
using Microsoft.AspNetCore.Mvc;
using FruitSky.Models;
using Microsoft.EntityFrameworkCore;
using FruitSky.Models.ViewModels;
using FruitSky.Models.Components;
using X.PagedList;

namespace FruitSky.Controllers
{
    public class ShopController : Controller
    {
        private readonly DataContext _dataContext;
      
        public ShopController(DataContext context)
        {
            _dataContext = context;
        }

        public IActionResult Category(string Slug = "")
        {
            if (!string.IsNullOrEmpty(Slug))
            {
                CategoryModel category = _dataContext.Categories.FirstOrDefault(s => s.Slug == Slug);
                if (category == null) return RedirectToAction("Index");

                var productsByCategory = _dataContext.Products.Where(p => p.CategoryId == category.Id);
                var sortedProducts = productsByCategory.OrderByDescending(p => p.Id).ToList();
                return View(sortedProducts);
            }
            else
            {
                var allProducts = _dataContext.Products.ToList();
                return View(allProducts);
            }
        }
        public IActionResult Index(int? page =1)
        {
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            var products = _dataContext.Products.AsNoTracking().OrderBy(p => p.Id);
            var pagedProducts = products.ToPagedList(pageNumber, pageSize);
            return View(pagedProducts);
        }
       
        [HttpPost]
        public IActionResult Search(string keyWord)
        {
			var searchResults = _dataContext.Products.Where(p => p.ProductName.Contains(keyWord)).ToList();
			return View(searchResults);
        }
        
    }
}
