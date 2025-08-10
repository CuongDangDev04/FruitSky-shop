using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruitSky.Models
{
	public class ProductModel
	{
		[Key]
		public int Id { get; set; }
		public string? ProductName { get; set; }
		public string? Slug { get; set; }
		public int Price { get; set; }
		public string? Description { get; set; }

		public string? Img { get; set; }
		public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
		public CategoryModel? Category { get; set; }

	}
}

