using Microsoft.AspNetCore.Mvc;
using Group_Project.Models;
using System.Linq;

namespace Group_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Admin/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Admin/Login (implement proper authentication in production)
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Username == username && a.Password == password);
            if (admin != null)
            {
                // Add authentication logic here (set authentication cookie or session)
                return RedirectToAction("Index");
            }

            ViewBag.Error = "Invalid username or password.";
            return View();
        }

        // GET: /Admin/Index (Admin Dashboard)
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Admin/Products
        public IActionResult Products()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // GET: /Admin/Users
        public IActionResult Users()
        {
            // If using Identity, ApplicationUser contains your user data.
            var users = _context.Users.ToList();
            return View(users);
        }

        // GET: /Admin/Orders
        public IActionResult Orders()
        {
            var orders = _context.Orders.ToList();
            return View(orders);
        }
    }
}
