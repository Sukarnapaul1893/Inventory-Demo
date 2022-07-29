using InventoryDemo.Data;
using InventoryDemo.Models.DataModels;
using InventoryDemo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryDemo.Controllers
{
    public class CustomerController : Controller
    {
        private readonly InventoryDemoContext _context;

        public CustomerController(InventoryDemoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var _customers = _context.Customer.Select(x => new CustomerView
            {
                Id = x.Id,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                PremiumMembership = x.PremiumMembership
            });

            return View(await _customers.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name, PhoneNumber, PremiumMembership")] CustomerView customerVM)
        {

            Customer customer = new Customer();
            customer.Id = customerVM.Id;
            customer.Name = customerVM.Name;
            customer.PhoneNumber = customerVM.PhoneNumber;
            customer.PremiumMembership = customerVM.PremiumMembership;

            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(customerVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, PhoneNumber, PremiumMembership")] CustomerView customerVM)
        {
            if (id != customerVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                Customer customer = new Customer
                {
                    Id = customerVM.Id,
                    Name = customerVM.Name,
                    PhoneNumber = customerVM.PhoneNumber,
                    PremiumMembership = customerVM.PremiumMembership
                };

                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            return View(customerVM);
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                                         .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            CustomerView customerVM = new CustomerView
            {
                Id = customer.Id,
                Name = customer.Name,
                PhoneNumber = customer.PhoneNumber,
                PremiumMembership = customer.PremiumMembership
            };

            return View(customerVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
