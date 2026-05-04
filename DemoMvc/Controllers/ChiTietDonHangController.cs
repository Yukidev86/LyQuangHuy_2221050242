using Microsoft.AspNetCore.Mvc;
using DemoMvc.Data;
using DemoMvc.Models;

public class ChiTietDonHangController : Controller
{
    private readonly ApplicationDbContext _context;

    public ChiTietDonHangController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Add(int donHangId, int sanPhamId, int soLuong)
    {
        var ct = new ChiTietDonHang
        {
            DonHangId = donHangId,
            SanPhamId = sanPhamId,
            SoLuong = soLuong
        };

        _context.ChiTietDonHangs.Add(ct);
        _context.SaveChanges();

        return RedirectToAction("Details", "DonHang", new { id = donHangId });
    }
}