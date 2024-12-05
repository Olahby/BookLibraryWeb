using Microsoft.AspNetCore.Mvc;

namespace BookLibraryWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
