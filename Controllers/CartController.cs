using Microsoft.AspNetCore.Mvc;

namespace Group_Project.Controllers
{
    public class CartController : Controller
    {
        // GET: /Cart/Index
        public IActionResult Index()
        {
            // Retrieve cart items from session or database and pass to the view.
            return View();
        }

        // POST: /Cart/AddToCart
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            // Implement logic to add the product to the user's cart (using session, cookie, or database).
            return RedirectToAction("Index");
        }
    }
}
