using Microsoft.AspNetCore.Mvc;

namespace InventoryDemo.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
