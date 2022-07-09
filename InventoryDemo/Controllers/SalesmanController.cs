using Microsoft.AspNetCore.Mvc;

namespace InventoryDemo.Controllers
{
    public class SalesmanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
