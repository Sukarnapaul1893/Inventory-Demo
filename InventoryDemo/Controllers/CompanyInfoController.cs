using InventoryDemo.Data;
using InventoryDemo.Models.DataModels;
using InventoryDemo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryDemo.Controllers
{
    public class CompanyInfoController : Controller
    {
        private readonly InventoryDemoContext _context;

        public CompanyInfoController(InventoryDemoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var _branches = _context.CompanyInfo.Select(x => new CompanyInfoView
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Website = x.Website
            });

            return View(await _branches.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name, Address, Email, PhoneNumber, Website")] CompanyInfoView branchVM)
        {

            CompanyInfo branch = new CompanyInfo();
            branch.Id = branchVM.Id;
            branch.Name = branchVM.Name;
            branch.Address = branchVM.Address;
            branch.Email = branchVM.Email;
            branch.PhoneNumber = branchVM.PhoneNumber;
            branch.Website = branchVM.Website;

            if (ModelState.IsValid)
            {
                _context.Add(branch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(branchVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Address, Email, PhoneNumber, Website")] CompanyInfoView branchVM)
        {
            if (id != branchVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                CompanyInfo branch = new CompanyInfo
                {
                    Id = branchVM.Id,
                    Name = branchVM.Name,
                    Address = branchVM.Address,
                    Email = branchVM.Email,
                    PhoneNumber = branchVM.PhoneNumber,
                    Website = branchVM.Website
                };

                try
                {
                    _context.Update(branch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyInfoExists(branch.Id))
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
            return View(branchVM);
        }

        private bool CompanyInfoExists(int id)
        {
            return _context.CompanyInfo.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _context.CompanyInfo
                                        .FirstOrDefaultAsync(m => m.Id == id);
            if (branch == null)
            {
                return NotFound();
            }

            CompanyInfoView branchVM = new CompanyInfoView
            {
                Id = branch.Id,
                Name = branch.Name,
                Address = branch.Address,
                Email = branch.Email,
                PhoneNumber = branch.PhoneNumber,
                Website = branch.Website
            };

            return View(branchVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var branch = await _context.CompanyInfo.FindAsync(id);
            _context.CompanyInfo.Remove(branch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
