using FruitSky.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruitSky.Models
{
	public class CartItemModel
	{
		[Key]
		public int Id { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
		public string? ProductName { get; set; }
		public int Quantity { get; set; }
		public int Price { get; set; }
		public string? Img { get; set; }
       
        public ProductModel Product { get; set; }
        public decimal Total
		{
			get { return Quantity * Price; }
		}
		public CartItemModel() { }
		public CartItemModel(ProductModel product)
		{
			ProductId = product.Id;
			ProductName = product.ProductName;
			Quantity = 1;
			Price = product.Price;
			Img = product.Img;
		}
	}
}
