using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruitSky.Models
{
    public class OrderDetailModel
    {
        [Key]
        public int Id { get; set; }

        // Sửa tên khóa ngoại cho thống nhất với CheckoutModel.Id
        public int CheckoutId { get; set; }
        [ForeignKey("CheckoutId")]
        public CheckoutModel? Checkout { get; set; }  // Tên property nên trùng với tên class để rõ ràng

        public int ProductId { get; set; }
        public ProductModel? Product { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }  // Giá tại thời điểm đặt

        [NotMapped]  // Không map vào DB, chỉ tính toán
        public decimal Total => Quantity * Price;
    }
}