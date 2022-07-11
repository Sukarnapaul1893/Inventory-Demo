using InventoryDemo.Data;
using InventoryDemo.Models.DataModels;
using InventoryDemo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryDemo.Controllers
{
    public class LoginController : Controller
    {
        private readonly InventoryDemoContext _context;

        public LoginController(InventoryDemoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Id, Email, Password")] LoginView loginVM)
        {
            Login login = new Login();
            login.Id = loginVM.Id;
            login.Email = loginVM.Email;
            login.Password = loginVM.Password;

            if (ModelState.IsValid)
            {
                var lst = _context.Login.Where(x => x.Email == login.Email).ToList();
                
                if (login.Email == "admin" && login.Password == "123")
                {
                    _context.Add(login);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }

                if(lst.Count > 1)
                {
                    _context.Add(login);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index","Home");
                }

                
                
            }

            return View(loginVM);
        }

        

    }
}
