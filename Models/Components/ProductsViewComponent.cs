using FruitSky.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace FruitSky.Models.Components
{
    public class ProductsViewComponent : ViewComponent
    {
        private readonly DataContext _dataContext;
        public ProductsViewComponent(DataContext context)
        {
            _dataContext = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_dataContext.Products.ToList());
        }
    }
}