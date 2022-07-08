using InventoryDemo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InventoryDemo.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            var x = new RegisterView();

            return View();
        }
    }
}
