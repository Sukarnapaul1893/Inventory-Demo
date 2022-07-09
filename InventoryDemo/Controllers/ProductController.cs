using InventoryDemo.Data;
using InventoryDemo.Models.DataModels;
using InventoryDemo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly InventoryDemoContext _context;

        public ProductController(InventoryDemoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var _products = _context.Product.Select(x => new ProductView
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Instock = x.Instock,
                InstockWeight = x.InstockWeight,
                Image = x.Image
            });

            return View(await _products.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name, Price, Instock, InstockWeight, FileUpload, Image")] ProductView productVM)
        {
            productVM.Image = Path.GetFileName(productVM.FileUpload.FileName);

            var file = productVM.FileUpload;

            if (file.Length > 0)
            {
                productVM.Image = "\\Images\\" + productVM.Image;
            }

            Product product = new Product();
            product.Id = productVM.Id;
            product.Name = productVM.Name;
            product.Price = productVM.Price;
            product.Instock = productVM.Instock;
            product.InstockWeight = productVM.InstockWeight;
            product.Image = productVM.Image;

            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Price, Instock, InstockWeight, FileUpload, Image")] ProductView productVM)
        {
            if (id != productVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                productVM.Image = Path.GetFileName(productVM.FileUpload.FileName);

                var file = productVM.FileUpload;

                if (file.Length > 0)
                {
                    productVM.Image = "\\Images\\" + productVM.Image;
                }

                Product product = new Product
                {
                    Id = productVM.Id,
                    Name = productVM.Name,
                    Price = productVM.Price,
                    Instock = productVM.Instock,
                    InstockWeight = productVM.InstockWeight,
                    Image = productVM.Image
                };

                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productVM);
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            ProductView productVM = new ProductView
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Instock = product.Instock,
                InstockWeight = product.InstockWeight,
                Image = product.Image
            };

            return View(productVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
