using InventoryDemo.Data;
using InventoryDemo.Models.DataModels;
using InventoryDemo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryDemo.Controllers
{
    public class SaleController : Controller
    {
        private readonly InventoryDemoContext _context;

        public SaleController(InventoryDemoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var _sales = _context.Sale.Select(x => new SaleView
            {
                Id = x.Id,
                CustomerId = x.CustomerId,
                Date = x.Date,
                SalesmanId = x.SalesmanId
            });

            return View(await _sales.ToListAsync());
        }

        public IActionResult Create()
        {
            var model = new SaleView()
            {
                Products = _context.Product.Select(x => new SaleProductView
                {
                    Id = x.Id,
                    Image = x.Image,
                    Instock = x.Instock,
                    InstockWeight = x.InstockWeight,
                    Name = x.Name,
                    Price = x.Price,
                    IsPurchased = false
                }).ToList(),

                Customers = _context.Customer.Select(x => new CustomerView
                {
                    Id = x.Id,
                    Name = x.Name,
                    PhoneNumber = x.PhoneNumber,
                    IsPurchasing = false,
                    PremiumMembership = x.PremiumMembership
                }).ToList(),
                Date = DateTime.Now,
                CustomerId = 1,
                SalesmanId = 1
            };
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Date, CustomerId, SalesmanId, Products, Customers")] SaleView saleVM)
        {

            Sale sale = new Sale();
            sale.Id = saleVM.Id;
            sale.CustomerId = saleVM.CustomerId;
            sale.SalesmanId = saleVM.SalesmanId;
            sale.Date = saleVM.Date;

            foreach(var x in saleVM.Products)
            {
                var sz = _context.PurchasedProduct.Count();
                PurchasedProduct purchasedProduct = new PurchasedProduct()
                {
                    ProductId = x.Id,
                    SaleId = sale.Id,
                    Quantity = x.Instock,
                    Weight = x.InstockWeight
                };
                _context.Add(purchasedProduct);
                await _context.SaveChangesAsync();
            }

            

            if (ModelState.IsValid)
            {
                _context.Add(sale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(saleVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            string path = ".\\wwwroot" + product.Image;
            using (var stream = System.IO.File.OpenRead(path))
            {
                ProductView productVM = new ProductView
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Instock = product.Instock,
                    InstockWeight = product.InstockWeight,
                    Image = product.Image,
                    FileUpload = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                };
                return View(productVM);
            }
            /*ProductView productVM = new ProductView
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Instock = product.Instock,
                InstockWeight = product.InstockWeight,
                Image = product.Image,
                FileUpload = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
            };

            return View(productVM);*/
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
                var x = Path.GetFileName(productVM.FileUpload.FileName);

                var file = productVM.FileUpload;

                if (file.Length > 0)
                {
                    productVM.Image = "\\Images\\" + x;
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



            if (productVM.FileUpload == null && productVM.Id != null && productVM.Name != null && productVM.Price != null && productVM.Instock != null && productVM.InstockWeight != null)
            {
                var product = _context.Product.Where(x => x.Id == productVM.Id).FirstOrDefault();
                product.Name = productVM.Name;
                product.Instock = productVM.Instock;
                product.InstockWeight = productVM.InstockWeight;
                product.Price = productVM.Price;

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
