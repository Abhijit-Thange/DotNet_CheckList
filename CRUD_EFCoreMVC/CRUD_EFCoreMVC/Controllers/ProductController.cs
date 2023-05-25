using Microsoft.AspNetCore.Mvc;

namespace CRUD_EFCoreMVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
