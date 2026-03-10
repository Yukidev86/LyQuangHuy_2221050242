using Microsoft.AspNetCore.Mvc;
using DemoMvc.Data;
using DemoMvc.Models;
using System.Linq;

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
            var list = _context.SinhViens.ToList();
            return View(list);
        }

        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SinhVien sv)
        {
            if (ModelState.IsValid)
            {
                _context.SinhViens.Add(sv);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sv);
        }

        // EDIT
        public IActionResult Edit(int id)
        {
            var sv = _context.SinhViens.Find(id);
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
    }
}