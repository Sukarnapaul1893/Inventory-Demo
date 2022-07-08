using Microsoft.AspNetCore.Mvc;

namespace InventoryDemo.Controllers
{
    public class CompanyInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
