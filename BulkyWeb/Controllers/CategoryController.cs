using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;

        public IActionResult Index()
        {
            List<Category> categories = [.. _context.Category];
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {

            if (ModelState.IsValid)
            {
                _context.Category.Add(category);
                _context.SaveChanges();
                TempData["success"] = "Successfully created category!";
                TempData["variant"] = "alert alert-dismissible alert-success";

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();

            Category? categoryFromDb = _context.Category.Find(id);

            if (categoryFromDb == null) return NotFound();

            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Category.Update(category);
                _context.SaveChanges();
                TempData["success"] = "Successfully updated category!";
                TempData["variant"] = "alert alert-dismissible alert-info";

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();

            Category? categoryFromDb = _context.Category.Find(id);

            if (categoryFromDb == null) return NotFound();

            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _context.Category.Remove(category);
            _context.SaveChanges();
            TempData["success"] = "Successfully deleted category!";
            TempData["variant"] = "alert alert-dismissible alert-warning";

            return RedirectToAction("Index");
        }

    }
}
