using Microsoft.AspNetCore.Mvc;

namespace Book.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
