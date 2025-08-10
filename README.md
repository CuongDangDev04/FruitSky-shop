# FruitSky-shop

## Giới thiệu

FruitSky là một dự án web bán hàng được xây dựng bằng ASP.NET Core MVC, sử dụng Entity Framework Core để quản lý dữ liệu. Dự án cung cấp các chức năng quản lý và hiển thị sản phẩm, danh mục, với khả năng mở rộng cho các tính năng thương mại điện tử.

## Yêu cầu hệ thống

- .NET 8.0
- SQL Server 
- Visual Studio 2022 hoặc Visual Studio Code

## Hướng dẫn cài đặt

1. **Clone dự án về máy:**
   ```bash
   git clone <đường dẫn repository>
   ```

2. **Cấu hình chuỗi kết nối cơ sở dữ liệu:**
   - Mở file `appsettings.json` (hoặc thông qua biến môi trường).
   - Đặt giá trị cho `ConnectionStrings:ConnectedDb` với chuỗi kết nối SQL Server của bạn.

3. **Khôi phục các package NuGet:**
   - Nếu dùng Visual Studio: Chuột phải vào solution > Restore NuGet Packages.
   - Nếu dùng CLI:
     ```bash
     dotnet restore
     ```

4. **Chạy migration 
   - Đảm bảo database đã được tạo và có quyền truy cập.
   - Có thể sử dụng lệnh:
     ```bash
     dotnet ef database update
     ```

## Hướng dẫn chạy dự án

- Sử dụng Visual Studio: Nhấn F5 hoặc chọn "Start Debugging".
- Sử dụng CLI:
  ```bash
  dotnet run 
  ```

## Cấu trúc dự án

- `Program.cs`: File cấu hình và khởi tạo ứng dụng.
- `Repository/`: Chứa các lớp truy cập dữ liệu (DataContext, SeedData, ...).
- `Models/`: Chứa các model định nghĩa kiểu dữ liệu cho database
- `Controllers/`: Chứa các controller xử lý request.
- `Views/`: Chứa các file giao diện Razor.
- `wwwroot/`: Chứa tài nguyên tĩnh (ảnh, css, js).
...
## Một số lưu ý

- Dữ liệu mẫu sẽ được seed tự động khi khởi động ứng dụng.
- Đường dẫn truy cập danh mục: `/Category/{Slug?}`.
- Đường dẫn mặc định: `/Home/Index`.


