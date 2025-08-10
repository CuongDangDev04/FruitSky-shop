using FruitSky.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FruitSky.Repository
{
    public class SeedData
    {
        public static void SeedingData(DataContext _context)
        {
            _context.Database.Migrate();

            if (!_context.Products.Any())
            {
                CategoryModel categoryCam = new CategoryModel { CategoryName = "Cam", Slug = "cam" };
                CategoryModel categoryDau = new CategoryModel { CategoryName = "Dâu", Slug = "dau" };
                CategoryModel categoryXoai = new CategoryModel { CategoryName = "Xoài", Slug = "xoai" };
                CategoryModel categoryLe = new CategoryModel { CategoryName = "Lê", Slug = "le" };
                CategoryModel categoryTao = new CategoryModel { CategoryName = "Táo", Slug = "tao" };

                _context.Categories.AddRange(categoryCam, categoryDau, categoryXoai, categoryLe, categoryTao);
                _context.SaveChanges();

                _context.Products.AddRange(
                    new ProductModel { ProductName = "Cam Sành", Slug = "cam-sanh", Price = 15000, Description = "Cam chín sành mịn, ngon ngọt", Img = "cam-sanh.jpg", Category = categoryCam },
                    new ProductModel { ProductName = "Dâu Tây", Slug = "dau-tay", Price = 30000, Description = "Dâu tây tươi ngon", Img = "dau-tay.jpg", Category = categoryDau },
                    new ProductModel { ProductName = "Xoài Cát", Slug = "xoai-cat", Price = 20000, Description = "Xoài cát ngọt và thơm", Img = "xoai-cat.jpg", Category = categoryXoai },
                    new ProductModel { ProductName = "Lê Nam Định", Slug = "le-nam-dinh", Price = 18000, Description = "Lê Nam Định chín và ngọt", Img = "le-nam-dinh.jpg", Category = categoryLe },
                    new ProductModel { ProductName = "Táo Envy", Slug = "tao-envy", Price = 25000, Description = "Táo Envy cực kỳ ngon", Img = "tao-envy.jpg", Category = categoryTao },
                    new ProductModel { ProductName = "Cam Ruột Đỏ", Slug = "cam-ruot-do", Price = 17000, Description = "Cam ruột đỏ ngọt thanh", Img = "cam-ruot-do.jpg", Category = categoryCam },
                    new ProductModel { ProductName = "Dâu Hạt Lựu", Slug = "dau-hat-luu", Price = 32000, Description = "Dâu hạt lựu, hương vị đặc trưng", Img = "dau-hat-luu.jpg", Category = categoryDau },
                    new ProductModel { ProductName = "Xoài Keo", Slug = "xoai-keo", Price = 23000, Description = "Xoài keo mọng nước", Img = "xoai-keo.jpg", Category = categoryXoai },
                    new ProductModel { ProductName = "Lê Phổ Yên", Slug = "le-pho-yen", Price = 19000, Description = "Lê Phổ Yên ngon và giòn", Img = "le-pho-yen.jpg", Category = categoryLe },
                    new ProductModel { ProductName = "Táo Fuji", Slug = "tao-fuji", Price = 28000, Description = "Táo Fuji ngọt và giữ màu", Img = "tao-fuji.jpg", Category = categoryTao },
                    new ProductModel { ProductName = "Cam Vinh", Slug = "cam-vinh", Price = 16000, Description = "Cam Vinh chín và thơm", Img = "cam-vinh.jpg", Category = categoryCam },
                    new ProductModel { ProductName = "Dâu Rừng", Slug = "dau-rung", Price = 35000, Description = "Dâu rừng tự nhiên", Img = "dau-rung.jpg", Category = categoryDau },
                    new ProductModel { ProductName = "Xoài Cao Phong", Slug = "xoai-cao-phong", Price = 22000, Description = "Xoài Cao Phong độc đáo", Img = "xoai-cao-phong.jpg", Category = categoryXoai },
                    new ProductModel { ProductName = "Lê Yên Bái", Slug = "le-yen-bai", Price = 21000, Description = "Lê Yên Bái thơm và giòn", Img = "le-yen-bai.jpg", Category = categoryLe },
                    new ProductModel { ProductName = "Táo Green", Slug = "tao-green", Price = 24000, Description = "Táo Green mát lạnh", Img = "tao-green.jpg", Category = categoryTao },
                    new ProductModel { ProductName = "Cam Cao Phong", Slug = "cam-cao-phong", Price = 18000, Description = "Cam Cao Phong ngon và lạ", Img = "cam-cao-phong.jpg", Category = categoryCam },
                    new ProductModel { ProductName = "Dâu Ninh Bình", Slug = "dau-ninh-binh", Price = 32000, Description = "Dâu Ninh Bình tươi ngon", Img = "dau-ninh-binh.jpg", Category = categoryDau },
                    new ProductModel { ProductName = "Xoài Cần Thơ", Slug = "xoai-can-tho", Price = 26000, Description = "Xoài Cần Thơ ngọt và mát", Img = "xoai-can-tho.jpg", Category = categoryXoai },
                    new ProductModel { ProductName = "Lê Vĩnh Phúc", Slug = "le-vinh-phuc", Price = 20000, Description = "Lê Vĩnh Phúc chín và thơm", Img = "le-vinh-phuc.jpg", Category = categoryLe },
                    new ProductModel { ProductName = "Táo Pink Lady", Slug = "tao-pink-lady", Price = 30000, Description = "Táo Pink Lady ngọt và giữ màu", Img = "tao-pink-lady.jpg", Category = categoryTao },
                    new ProductModel { ProductName = "Cam Bảo Lộc", Slug = "cam-bao-loc", Price = 19000, Description = "Cam Bảo Lộc ngon và mát", Img = "cam-bao-loc.jpg", Category = categoryCam },
                    new ProductModel { ProductName = "Dâu Đà Lạt", Slug = "dau-da-lat", Price = 27000, Description = "Dâu Đà Lạt tươi và thơm", Img = "dau-da-lat.jpg", Category = categoryDau },
                    new ProductModel { ProductName = "Cam Mỹ", Slug = "cam-my", Price = 18000, Description = "Cam Mỹ ngọt và thơm", Img = "cam-my.jpg", Category = categoryCam },
                    new ProductModel { ProductName = "Dâu Sapa", Slug = "dau-sapa", Price = 34000, Description = "Dâu Sapa tươi ngon", Img = "dau-sapa.jpg", Category = categoryDau },
                    new ProductModel { ProductName = "Xoài Lò Cai", Slug = "xoai-lo-cai", Price = 25000, Description = "Xoài Lò Cai mọng nước", Img = "xoai-lo-cai.jpg", Category = categoryXoai },
                    new ProductModel { ProductName = "Lê Thái Bình", Slug = "le-thai-binh", Price = 20000, Description = "Lê Thái Bình chín và giòn", Img = "le-thai-binh.jpg", Category = categoryLe },
                    new ProductModel { ProductName = "Táo Granny Smith", Slug = "tao-granny-smith", Price = 27000, Description = "Táo Granny Smith mát lạnh", Img = "tao-granny-smith.jpg", Category = categoryTao }
                );

                _context.SaveChanges();
            }
        }

        internal static void SeedingData(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}