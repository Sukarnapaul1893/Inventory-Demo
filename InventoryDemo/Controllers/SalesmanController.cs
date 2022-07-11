using InventoryDemo.Data;
using InventoryDemo.Models.DataModels;
using InventoryDemo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryDemo.Controllers
{
    public class SalesmanController : Controller
    {
        private readonly InventoryDemoContext _context;

        public SalesmanController(InventoryDemoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var _salesman = _context.Salesman.Select(x => new SalesmanView
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                TotalSellCustomer = x.TotalSellCustomer,
                TotalSellPrice = x.TotalSellPrice,
                Image = x.Image
            });

            return View(await _salesman.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name, Email, PhoneNumber,TotalSellCustomer, TotalSellPrice, Salary, FileUpload, Image")] SalesmanView salesmanVM)
        {
            salesmanVM.Image = Path.GetFileName(salesmanVM.FileUpload.FileName);

            var file = salesmanVM.FileUpload;

            if (file.Length > 0)
            {
                salesmanVM.Image = "\\Images\\" + salesmanVM.Image;
            }

            Salesman salesman = new Salesman();
            salesman.Id = salesmanVM.Id;
            salesman.Name = salesmanVM.Name;
            salesman.Email = salesmanVM.Email;
            salesman.PhoneNumber = salesmanVM.PhoneNumber;
            salesman.TotalSellCustomer = salesmanVM.TotalSellCustomer;
            salesman.TotalSellPrice = salesmanVM.TotalSellPrice;
            salesman.Salary = salesmanVM.Salary;
            salesman.Image = salesmanVM.Image;

            if (ModelState.IsValid)
            {
                _context.Add(salesman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(salesmanVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Email, PhoneNumber,TotalSellCustomer, TotalSellPrice, Salary, FileUpload, Image")] SalesmanView salesmanVM)
        {
            if (id != salesmanVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                salesmanVM.Image = Path.GetFileName(salesmanVM.FileUpload.FileName);

                var file = salesmanVM.FileUpload;

                if (file.Length > 0)
                {
                    salesmanVM.Image = "\\Images\\" + salesmanVM.Image;
                }

                Salesman salesman = new Salesman
                {
                    Id = salesmanVM.Id,
                    Name = salesmanVM.Name,
                    Email = salesmanVM.Email,
                    PhoneNumber = salesmanVM.PhoneNumber,
                    TotalSellCustomer = salesmanVM.TotalSellCustomer,
                    TotalSellPrice = salesmanVM.TotalSellPrice,
                    Image = salesmanVM.Image
            };

                try
                {
                    _context.Update(salesman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesmanExists(salesman.Id))
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
            return View(salesmanVM);
        }

        private bool SalesmanExists(int id)
        {
            return _context.Salesman.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesman = await _context.Salesman
                                         .FirstOrDefaultAsync(m => m.Id == id);
            if (salesman == null)
            {
                return NotFound();
            }

            SalesmanView salesmanVM = new SalesmanView
            {
                Id = salesman.Id,
                Name = salesman.Name,
                Email = salesman.Email,
                PhoneNumber = salesman.PhoneNumber,
                TotalSellCustomer = salesman.TotalSellCustomer,
                TotalSellPrice = salesman.TotalSellPrice,
                Image = salesman.Image
            };

            return View(salesmanVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesman = await _context.Salesman.FindAsync(id);
            _context.Salesman.Remove(salesman);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
