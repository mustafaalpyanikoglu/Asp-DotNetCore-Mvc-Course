using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = "Yanıkoğlu";
            ViewData["Name"] = "Mustafa Alp";
            Customer customer = new Customer() { Age = 23 , FirstName = "alp", LastName= "yanıkoğlu"};
            return View(customer);
        }
        public IActionResult Alp()
        {
            return View();
        }
    }
}
