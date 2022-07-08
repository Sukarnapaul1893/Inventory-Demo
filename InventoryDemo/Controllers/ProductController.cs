using Microsoft.AspNetCore.Mvc;

namespace InventoryDemo.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
