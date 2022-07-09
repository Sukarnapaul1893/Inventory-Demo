using Microsoft.AspNetCore.Mvc;

namespace InventoryDemo.Controllers
{
    public class SaleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
