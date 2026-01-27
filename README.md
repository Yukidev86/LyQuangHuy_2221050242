Họ tên: Lý Quang Huy  
MSSV: 2221050242 

BUỔI HỌC SỐ 3
1. Tìm hiểu cấu trúc thư mục của dự án .Net MVC:
-sau khi tạo thư mục bằng lệnh "dotnet new mvc -n DemoMvc" trong terminal xuất hiện project DemoMvc gồm các mục:
    -bin\Debug\net10.0 //Chức năng: Chứa file đã biên dịch; Được tạo tự động khi chạy project; Không chỉnh sửa thủ công
    -Controllers //Chức năng: Chứa các Controller; Nhận request từ URL; Xử lý logic; Trả về View hoặc dữ liệu
    -Models //Chức năng: Chứa các lớp dữ liệu; Đại diện cho dữ liệu xử lý hoặc CSDL
    -obj //Chức năng: Chứa file trung gian khi build; Phục vụ quá trình biên dịch; Không chỉnh sửa thủ công /Thư mục này có thể xóa và build lại sẽ tự tạo 
    -Properties //Chức năng: Chứa cấu hình chạy ứng dụng
    -Views //Chức năng: Chứa giao diện người dùng; File có đuôi .cshtml; Kết hợp HTML và Razor
    -wwwroot //Chức năng: Chứa file tĩnh; Trình duyệt truy cập trực tiếp
    -appsettings.Development.json //Chức năng: Cấu hình chung cho toàn ứng dụng; Logging; Chuỗi kết nối CSDL
    -appsettings.json //Chức năng: Cấu hình riêng cho môi trường Development; Ghi đè appsettings.json; Chỉ dùng khi chạy local
    -DemoMvc.csproj //Chức năng: File cấu hình project; Khai báo:
                                                            -Framework
                                                            -Package
                                                            -Cách build
    -Program.cs //Chức năng: File khởi động ứng dụng; Cấu hình middleware; Cấu hình Routing
2. Tìm hiểu về định tuyến (Route) trong .Net MVC:
-Routing giúp ASP.NET biết khi người dùng gõ URL thì chạy hàm nào trong Controller
-Vai trò của Routing trong mô hình MVC: URL → Routing → Controller → Action → View
-Routing được cấu hình ở Program.cs
-Mở file Program.cs trong thư mục DemoMvc ta thấy dòng code sau:
    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    -giả thích:
        +name: "default"
            Tên của route
            Dùng để phân biệt với các route khác
        +pattern: "{controller=Home}/{action=Index}/{id?}"
            controller:	Tên Controller
            =Home:	Controller mặc định
            action:	Tên Action
            =Index:	Action mặc định
            id?:	Tham số (không bắt buộc)
3. Tìm hiểu về Controller, View trong .Net MVC:
3.1 Controller:
    -Controller là thành phần:
        -Nhận yêu cầu (request) từ trình duyệt
        -Xử lý logic
        -Quyết định trả về View hoặc dữ liệu
    -Controller là trung gian giữa Model và View.
    -Quy tắc đặt tên:
        -Tên phải kết thúc bằng Controller
        -Không phân biệt hoa thường trên URL
    -Cấu trúc cơ bản của một Controller:
    vidu:
        using Microsoft.AspNetCore.Mvc;
        namespace DemoMvc.Controllers
        {
            public class DemoController : Controller
            {
                public IActionResult Index()
                {
                    return View();
                }
            }
        }        
    // using Microsoft.AspNetCore.Mvc; -> Import thư viện MVC
    // public class DemoController : Controller -> Khai báo Controller
    // public IActionResult Index() -> Action (phương thức xử lý)
    // return View(); -> trả về View cùng tên Action
    -Các kiểu dữ liệu trả về từ Controller:
        View()	Trả về View
        Content()	Trả về chuỗi
        Json()	Trả về JSON
        Redirect()	Chuyển hướng
3.2 View
    -View là thành phần:
        Hiển thị giao diện cho người dùng
        Viết bằng HTML + Razor (.cshtml)
    -Quy tắc: Views/TênController/TênAction.cshtml
    -Razor Syntax trong View:
        -Razor là gì?
            +Là cú pháp cho phép viết C# trong HTML
            +Bắt đầu bằng @
            -vidu: <h2>@DateTime.Now</h2>
        -Truyền dữ liệu từ Controller sang View:
            -Controller:
                public IActionResult Index()
                {
                    ViewBag.Message = "Hello MVC";
                    return View();
                }
            -View:
                <h2>@ViewBag.Message</h2>
        -ViewData và ViewBag
            | Công cụ  | Đặc điểm    |
            | -------- | ----------- |
            | ViewData | Dictionary  |
            | ViewBag  | Dynamic     |
            | TempData | Dữ liệu tạm |
        -View dùng Layout như thế nào?:
            _Layout.cshtml
            Views/Shared/_Layout.cshtml
            <body>
            @RenderBody()
            </body>
            -> Mọi View đều hiển thị trong Layout chung
        -Luồng hoạt động Controller – View:
            Người dùng → URL → Controller → Action → View → Trình duyệt
        -Lỗi thường gặp khi làm Controller & View:
            +Sai tên View
            +Sai thư mục View
            +Action không public
4. Tạo DemoController và View Index trả về thông báo "Hello + Họ tên và mã sinh viên"
    B1: tạo file DemoController.cs trong thư mục Controllers với code sau:
        using Microsoft.AspNetCore.Mvc;

        namespace DemoMvc.Controllers
        {
            public class DemoController : Controller
            {
                public IActionResult Index()
                {
                    return View();
                }
            }
        }
    B2: tạo thư mục Demo trong thư mục Views sau đó tạo file Index.cshtml với code sau: 
        @{
        ViewData["Title"] = "Demo";
        }

        <h1>Hello Lý Quang Huy - 2221050242</h1>
    B3: run đoạn mã sau trong Terminal: dotnet run
        xuất hiện  http://localhost:5213 copy thêm /Demo/Index sẽ thành http://localhost:5213/Demo/Index chạy lên trình duyệt sẽ ra
        kết quả
    //Nếu trước đó đã chạy dotnet run thì cần nhấn tổ hợp phím CTRL+SHIFR+ESC tìm DemoMvc rồi tắt nó đi

    BUỔI HỌC SỐ 4
    1. TÌM HIỂU VỀ ViewBag TRONG MVC
        -ViewBag là gì? 
            ViewBag dùng để truyền dữ liệu từ Controller sang View
            Kiểu dynamic → không cần khai báo kiểu dữ liệu
            Chỉ tồn tại trong 1 request
        -Dùng khi:
            Gửi chuỗi
            Gửi số
            Gửi dữ liệu đơn giản (không phức tạp)
        -Cú pháp ViewBag
            Controller
                ViewBag.Message = "Hello MVC";
            View
                <h2>@ViewBag.Message</h2>
2. VÍ DỤ: GỬI DỮ LIỆU TỪ CONTROLLER → VIEW BẰNG ViewBag
    Bước 1: Tạo Controller
    Controllers/DemoController.cs
        using Microsoft.AspNetCore.Mvc;
        namespace DemoMvc.Controllers
        {
            public class DemoController : Controller
            {
                public IActionResult Index()
                {
                    ViewBag.Message = "Xin chào ASP.NET MVC";
                    return View();
                }
            }
        }
    Bước 2: Tạo View
    Views/Demo/Index.cshtml
    <h2>@ViewBag.Message</h2>
    Truy cập:
    /Demo/Index
3. Tìm hiểu về gửi nhận dữ liệu giữa View và Controller thông qua Submit form.
    -BẢN CHẤT CỦA SUBMIT FORM TRONG MVC
        Trong ASP.NET MVC, khi submit form, dữ liệu sẽ đi theo luồng:
            View (Form HTML)
            ↓ submit
            Controller (Action [HttpPost])
            ↓ xử lý
            Controller → View (trả kết quả)
        MVC không xử lý form ở View, mà:
            View → chỉ hiển thị + nhập dữ liệu
            Controller → nhận dữ liệu + xử lý logic
    -FORM HTML GỬI DỮ LIỆU NHƯ THẾ NÀO?
    Ví dụ form đơn giản:
        <form method="post">
            <input type="text" name="fullName" />
        <button type="submit">Gửi</button>
    Khi bấm Submit:
    Trình duyệt gửi dữ liệu:
        fullName=Nguyen Van A
    Gửi bằng HTTP POST
    -CONTROLLER NHẬN DỮ LIỆU RA SAO?
        Cách 1: Nhận bằng tham số đơn lẻ
        [HttpPost]
        public IActionResult Index(string fullName)
        {
            ViewBag.Message = "Xin chào " + fullName;
            return View();
        }
        Điều kiện:
        name="fullName" trong View
        trùng tên với tham số string fullName
        ➡ MVC tự động binding
4. Lấy ví dụ: nhập họ tên trên view gửi dữ liệu lên controller, controller xử lý và gửi thông báo "Xin chào " + Họ tên về hiển thị lên view.
    -Bước 1: Controller
    Controllers/HelloController.cs
        using Microsoft.AspNetCore.Mvc;
        namespace DemoMvc.Controllers
        {
            public class HelloController : Controller
            {
                [HttpGet]
                public IActionResult Index()
                {
                    return View();
                }
                [HttpPost]
                public IActionResult Index(string fullName)
                {
                    ViewBag.Message = "Xin chào " + fullName;
                    return View();
                }
            }
        }
    -Bước 2: View
        Views/Hello/Index.cshtml
        <h2>Nhập họ tên</h2>
        <form method="post">
            <input type="text" name="fullName" placeholder="Nhập họ tên" />
            <button type="submit">Gửi</button>
        </form>
        @if (ViewBag.Message != null)
        {
            <h3>@ViewBag.Message</h3>
        }
    -Cơ chế:
        View → submit → Controller (POST) → ViewBag → View
    
        

