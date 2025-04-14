using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Group_Project.Models;

namespace Group_Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // List all products
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // Display product details by ID
        public IActionResult Details(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
