using System.ComponentModel.DataAnnotations;

namespace FruitSky.Models
{
	public class CategoryModel
	{
		[Key]
		public int Id { get; set; }
		public string? CategoryName { get; set; }
		public string? Slug { get; set; }
	}
}

