using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruitSky.Models
{
	public class CheckoutModel
	{
		[Key]
		public int Id { get; set; }
		public string? FullName { get; set; }
		
		public string? Email { get; set; }
		public int Phone { get; set; }
		public string? Address { get; set; }
		public string? Note { get; set; }
		[ForeignKey("CartItemId")]
		public CartItemModel CartItem { get; set; }
		[ForeignKey("UserId")]
        public UserModel User { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
	}

}
