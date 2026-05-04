using Microsoft.AspNetCore.Mvc;
using DemoMvc.Models;
using DemoMvc.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class KhoaController : Controller
{
    private readonly ApplicationDbContext _context;

    public KhoaController(ApplicationDbContext context)
    {
        _context = context;
    }

    // 📌 Danh sách
    public IActionResult Index()
    {
        return View(_context.Khoas.ToList());
    }

    // 📌 GET Create
    public IActionResult Create()
    {
        return View();
    }

    // 📌 POST Create
    [HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Faculty k)
{
    if (!ModelState.IsValid)
    {
        var errors = ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage);

        return Content("Lỗi: " + string.Join(" | ", errors));
    }

    _context.Khoas.Add(k);
    _context.SaveChanges();
    return RedirectToAction("Index");
}

    // 📌 GET Edit
    public IActionResult Edit(int id)
    {
        var k = _context.Khoas.Find(id);
        if (k == null) return NotFound();
        return View(k);
    }

    // 📌 POST Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Faculty k)
    {
        if (ModelState.IsValid)
        {
            _context.Khoas.Update(k);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(k);
    }

    // 📌 Delete
    public IActionResult Delete(int id)
    {
        var k = _context.Khoas.Find(id);
        if (k != null)
        {
            _context.Khoas.Remove(k);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
    
}