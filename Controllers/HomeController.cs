using Microsoft.AspNetCore.Mvc;

namespace VideoGameApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); 
        }
    }
}
