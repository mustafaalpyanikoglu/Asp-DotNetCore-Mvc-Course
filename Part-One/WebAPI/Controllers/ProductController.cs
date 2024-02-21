using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Index(int id)
		{
			return View(id);
		}
	}
}
