using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Group_Project.Models;

namespace Group_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminOrderController : Controller
    {
        private readonly AppDbContext _context;

        public AdminOrderController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminOrder/Index
        public IActionResult Index()
        {
            var orders = _context.Orders.ToList();
            return View(orders);
        }

        // GET: Admin/AdminOrder/Details/5
        public IActionResult Details(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == id);
            if (order == null)
                return NotFound();
            return View(order);
        }

        // Optionally, add actions to update the order status or process orders.
    }
}
