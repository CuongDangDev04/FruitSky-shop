using FruitSky.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace FruitSky.Models.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly DataContext _dataContext;
        public CategoriesViewComponent(DataContext context)
        {
            _dataContext = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_dataContext.Categories.ToList());
        }
    }
}
