using Microsoft.AspNetCore.Mvc;
using System.IO;
using static WebAPI.Constants.PathConstant;

namespace WebAPI.Controllers
{
    public class FolderController : Controller
    {
        public IActionResult List()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), WWWROOT));
            var folders = directoryInfo.GetDirectories();

            return View(folders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string folderName)
        {
            DirectoryInfo info = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), WWWROOT, folderName));
            if (!info.Exists)
            {
                info.Create();
            }
            return RedirectToAction("List");
        }

        public IActionResult Remove(string folderName)
        {
            DirectoryInfo info = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), WWWROOT, folderName));
            if (info.Exists)
            {
                info.Delete(true);
            }
            return RedirectToAction("List");
        }
    }
}
