using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Group_Project.Models;

namespace Group_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminUserController : Controller
    {
        private readonly AppDbContext _context;

        public AdminUserController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminUser/Index
        public IActionResult Index()
        {
            var users = _context.Users.ToList(); // ApplicationUser from IdentityDbContext
            return View(users);
        }

        // GET: Admin/AdminUser/Details/{id}
        public IActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();
            return View(user);
        }

        // GET: Admin/AdminUser/Delete/{id}
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();
            return View(user);
        }

        // POST: Admin/AdminUser/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
