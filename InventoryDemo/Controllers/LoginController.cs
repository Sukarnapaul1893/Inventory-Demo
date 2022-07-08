using InventoryDemo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InventoryDemo.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

