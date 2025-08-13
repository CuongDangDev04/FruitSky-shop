using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruitSky.Models
{
	public class CheckoutModel
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Họ tên là bắt buộc")]
		public string FullName { get; set; }

		[Required(ErrorMessage = "Email là bắt buộc")]
		[EmailAddress(ErrorMessage = "Email không hợp lệ")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Số điện thoại là bắt buộc")]
		[Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
		public string Phone { get; set; }  // Đổi thành string

		[Required(ErrorMessage = "Địa chỉ là bắt buộc")]
		public string Address { get; set; }

		public string? Note { get; set; }

		// Khóa ngoại CartItem



		// Khóa ngoại User
		public int? UserId { get; set; }

		[ForeignKey("UserId")]
		public UserModel? User { get; set; }
		// Liên kết 1 đơn hàng sẽ có nhiều chi tiết đơn hàng
		public virtual ICollection<OrderDetailModel> OrderDetails { get; set; } = new List<OrderDetailModel>();

		public DateTime OrderDate { get; set; } = DateTime.Now;
	}
}
