using Microsoft.AspNetCore.Mvc;
using DemoMvc.Data;
using DemoMvc.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;

namespace DemoMvc.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SinhVienController(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ - hiển thị danh sách
        public IActionResult Index()
        {
                var list = _context.SinhViens
                       .Include(s => s.Khoa)
                       .ToList();
            return View(list);
        }

        // CREATE
        public IActionResult Create()
        {
            ViewBag.Khoas = new SelectList(_context.Khoas, "KhoaId", "TenKhoa");
            return View();
        }

[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(SinhVien sv)
{
    if (!ModelState.IsValid)
    {
        var errors = ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage);

        ViewBag.Khoas = new SelectList(_context.Khoas, "KhoaId", "TenKhoa", sv.KhoaId);
        return Content("Lỗi: " + string.Join(" | ", errors));
    }

    _context.SinhViens.Add(sv);
    _context.SaveChanges();
    return RedirectToAction("Index");
}

        // EDIT
        public IActionResult Edit(int id)
        {
            var sv = _context.SinhViens.Find(id);

            if (sv == null) return NotFound();
          ViewBag.Khoas = new SelectList(_context.Khoas, "KhoaId", "TenKhoa", sv.KhoaId);
            return View(sv);
        }

        [HttpPost]
        public IActionResult Edit(SinhVien sv)
        {
            if (ModelState.IsValid)
            {
                _context.SinhViens.Update(sv);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
                ViewBag.Khoas = new SelectList(_context.Khoas, "KhoaId", "TenKhoa", sv.KhoaId);
            return View(sv);
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var sv = _context.SinhViens.Find(id);
            return View(sv);
        }

        [HttpPost]
        public IActionResult Delete(SinhVien sv)
        {
            var data = _context.SinhViens.Find(sv.Id);

            if (data != null)
            {
                _context.SinhViens.Remove(data);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
    public IActionResult ImportExcel()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ImportExcel(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return Content("Chưa chọn file!");
        }

        using (var stream = new MemoryStream())
        {
            file.CopyTo(stream);

            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using (var package = new OfficeOpenXml.ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    var sv = new SinhVien
                    {
                        MaSinhVien = worksheet.Cells[row, 1].Text,
                        HoTen = worksheet.Cells[row, 2].Text,
                        KhoaId = int.Parse(worksheet.Cells[row, 3].Text)
                    };

                    _context.SinhViens.Add(sv);
                }

                _context.SaveChanges();
            }
        }

        return Content("Import thành công!");
    }

    }
}