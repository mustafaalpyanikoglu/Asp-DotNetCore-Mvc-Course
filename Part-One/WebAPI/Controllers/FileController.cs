using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using static WebAPI.Constants.PathConstant;

namespace WebAPI.Controllers
{
    public class FileController : Controller
    {
        public IActionResult List()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), WWWROOT, FILES));
            var files = directoryInfo.GetFiles();

            return View(files);
        }

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(string fileName)
		{
			FileInfo fileInfo = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), WWWROOT, FILES, fileName));
			if (!fileInfo.Exists)
			{
				fileInfo.Create();
			}
			return RedirectToAction("List");
		}

		public IActionResult CreateWithDate()
		{
			FileInfo fileInfo = new FileInfo
				(Path.Combine(
						Directory.GetCurrentDirectory(), 
						WWWROOT, 
						FILES, 
						Guid.NewGuid().ToString()+ ".txt")
				);

			StreamWriter writer = fileInfo.CreateText();
			writer.Write("Merhaba ben Alp");
			writer.Close();

			return RedirectToAction("List");
		}

		public IActionResult Remove(string fileName)
		{
			FileInfo info = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), WWWROOT, FILES, fileName));
			if (info.Exists)
			{
				info.Delete();
			}
			return RedirectToAction("List");
		}

		public IActionResult Upload()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Upload(IFormFile formFile)
		{
			if (formFile.ContentType == "image/png")
			{
                var ext = Path.GetExtension(formFile.FileName);
                var path = Directory.GetCurrentDirectory() + "/" + WWWROOT + "/" + IMAGES + "/" + Guid.NewGuid() + ext;
                FileStream stream = new FileStream(path, FileMode.Create);
                formFile.CopyTo(stream);
				TempData["message"] = "Dosya yükleme işlemi başarıyla gerçekleşti";
            }
			else
			{
                TempData["message"] = "Dosya yükleme işlemi gerçekleşemedi";
            }


            return RedirectToAction("List");
		}
	}
}
