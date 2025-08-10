using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruitSky.Models
{
	public class ContactModel
	{
		[Key]
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Email { get; set; }
		public int Phone { get; set; }
		public string? Subject { get; set; }
		public string? Message { get; set; }
    }
}
