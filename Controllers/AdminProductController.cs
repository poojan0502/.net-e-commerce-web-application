using System;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Group_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Group_Project.Controllers
{
    public class AdminProductController : Controller
    {
        private readonly AppDbContext _context;

        public AdminProductController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products.Include(p => p.Category).ToList();
            return View(products);
        }
        // GET: /AdminProduct/Create
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
            return View();
        }

        // POST: /AdminProduct/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, IFormFile productImage)
        {
            if (ModelState.IsValid)
            {
                // If a file is uploaded, process and save it.
                if (productImage != null && productImage.Length > 0)
                {
                    // Create a unique filename using a GUID.
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(productImage.FileName);
                    // Define the path to the "products" images folder under wwwroot.
                    var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "products");

                    // Ensure the uploads directory exists.
                    if (!Directory.Exists(uploads))
                    {
                        Directory.CreateDirectory(uploads);
                    }

                    // Combine the uploads path with the file name.
                    var filePath = Path.Combine(uploads, fileName);

                    // Save the file to disk.
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await productImage.CopyToAsync(stream);
                    }

                    // Store the relative path in the product model (for displaying later).
                    product.ImageURL = "/images/products/" + fileName;
                }

                product.CreatedAt = DateTime.Now;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
            return View(product);
        }
        // GET: /AdminProduct/Edit/5
        public IActionResult Edit(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // POST: /AdminProduct/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product, IFormFile productImage)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                // If a new image file is uploaded, process and update the product image.
                if (productImage != null && productImage.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(productImage.FileName);
                    var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "products");

                    if (!Directory.Exists(uploads))
                    {
                        Directory.CreateDirectory(uploads);
                    }

                    var filePath = Path.Combine(uploads, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await productImage.CopyToAsync(stream);
                    }

                    product.ImageURL = "/images/products/" + fileName;
                }

                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Unable to update product");
                    return View(product);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }
    }
}
