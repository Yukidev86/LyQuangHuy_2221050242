using Microsoft.AspNetCore.Mvc;
using DemoMvc.Data;
using DemoMvc.Models;
using System.Linq;

public class KhachHangController : Controller
{
    private readonly ApplicationDbContext _context;

    public KhachHangController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.KhachHangs.ToList());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(KhachHang kh)
    {
        if (ModelState.IsValid)
        {
            _context.KhachHangs.Add(kh);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(kh);
    }
}