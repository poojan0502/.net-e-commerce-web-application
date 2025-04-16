using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Group_Project.Models;
using System;
using System.Linq;

namespace Group_Project.Controllers
{
    public class AdminCategoryController : Controller
    {
        private readonly AppDbContext _context;

        public AdminCategoryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /AdminCategory/Index
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        // GET: /AdminCategory/Details/5
        public IActionResult Details(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
                return NotFound();
            return View(category);
        }

        // GET: /AdminCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /AdminCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: /AdminCategory/Edit/5
        public IActionResult Edit(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
                return NotFound();
            return View(category);
        }

        // POST: /AdminCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Category category)
        {
            if (id != category.CategoryId)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Unable to update category");
                    return View(category);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: /AdminCategory/Delete/5
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
                return NotFound();
            return View(category);
        }

        // POST: /AdminCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
                return NotFound();

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
