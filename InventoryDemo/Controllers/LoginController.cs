using InventoryDemo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InventoryDemo.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            var x = new LoginView();
            
            return View(x);
        }
    }
}

