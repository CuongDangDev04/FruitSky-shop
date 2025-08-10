
using FruitSky.Models;
using Microsoft.EntityFrameworkCore;
namespace FruitSky.Repository
{
	public class DataContext: DbContext
	{
			public DataContext(DbContextOptions<DataContext> options) : base(options)
			{
			}
			public DbSet<CategoryModel> Categories { get; set; }
			public DbSet<ProductModel> Products { get; set; }
			public DbSet<UserModel> Users { get; set; }
			public DbSet<ContactModel> Contacts { get; set; }
			public DbSet<CheckoutModel> Checkouts { get; set; }
			public DbSet<CartItemModel> CartItems { get; set; }
	}
}
