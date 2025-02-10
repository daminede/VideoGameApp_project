
using Microsoft.AspNetCore.Mvc;
using VideoGameApp.Models;


namespace VideoGameApp.Auth
{
    public class LoginModel : Controller
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public IActionResult Index()
        {
            return View();
        }
    }
}