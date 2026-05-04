using Microsoft.AspNetCore.Mvc;
using DemoMvc.Data;
using DemoMvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

public class DonHangController : Controller
{
    private readonly ApplicationDbContext _context;

    public DonHangController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var data = _context.DonHangs.Include(d => d.KhachHang).ToList();
        return View(data);
    }

    public IActionResult Create()
    {
        ViewBag.KhachHangs = new SelectList(_context.KhachHangs, "Id", "TenKhachHang");
        return View();
    }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DonHang dh)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);

                ViewBag.KhachHangs = new SelectList(_context.KhachHangs, "Id", "TenKhachHang");
                return Content("Lỗi: " + string.Join(" | ", errors));
            }

            dh.NgayDat = DateTime.Now;

            _context.DonHangs.Add(dh);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    // XEM CHI TIẾT ĐƠN HÀNG
    public IActionResult Details(int id)
    {
        var dh = _context.DonHangs
            .Include(d => d.KhachHang)
            .Include(d => d.ChiTietDonHangs)
                .ThenInclude(ct => ct.SanPham)
            .FirstOrDefault(d => d.Id == id);

        return View(dh);
    }
}