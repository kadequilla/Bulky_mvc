using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController(ApplicationDbContext context) : Controller
    {
        public IActionResult Index()
        {
            List<Category> categories = [.. context.Category];
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
                context.Category.Add(category);
                context.SaveChanges();
                TempData["success"] = "Successfully created category!";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id is null or 0) return NotFound();
            var categoryFromDb = context.Category.Find(id);
            if (categoryFromDb is null) return NotFound();
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Category.Update(category);
                context.SaveChanges();
                TempData["success"] = "Successfully updated category!";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id is null or 0) return NotFound();
            var categoryFromDb = context.Category.Find(id);
            if (categoryFromDb == null) return NotFound();
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            context.Category.Remove(category);
            context.SaveChanges();
            TempData["success"] = "Successfully deleted category!";
            return RedirectToAction("Index");
        }
    }
}