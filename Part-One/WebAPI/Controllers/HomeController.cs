using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using static WebAPI.Constants.PathConstant;
using WebAPI.Filters;
using WebAPI.Models;
using System;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var customers = CustomerContext.Customers;
            return View (customers);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Customer());
        }

        [HttpPost]
        [ValidFirstName] //Bu action bitmeden veri kaydedilmez
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                Customer lastCustomer = null;
                if (CustomerContext.Customers.Count > 0)
                {
                    lastCustomer = CustomerContext.Customers.Last();
                }

                lastCustomer.Id = 1;
                if (lastCustomer != null)
                {
                    lastCustomer.Id = lastCustomer.Id + 1;
                }

                CustomerContext.Customers.Add(customer);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var removedCustomer = CustomerContext.Customers.Find(p => p.Id == id);
            CustomerContext.Customers.Remove(removedCustomer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var updatedCustomer = CustomerContext.Customers.FirstOrDefault(p => p.Id == id);
            return View(updatedCustomer);
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            var updatedCustomer = CustomerContext.Customers.FirstOrDefault(p => p.Id == customer.Id);
            updatedCustomer.FirstName = customer.FirstName; 
            updatedCustomer.LastName = customer.LastName;
            updatedCustomer.Age = customer.Age;
            return RedirectToAction("Index");
        }

		public IActionResult Status(int? code)
		{
			return View(code);
		}

		public IActionResult Error()
		{
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            var logFolderPath = Path.Combine(Directory.GetCurrentDirectory(), WWWROOT, LOGS);

            var logFileName = DateTime.Now.ToString();
            logFileName = logFileName.Replace(" ", "_");
            logFileName = logFileName.Replace(":", "-");
            logFileName = logFileName.Replace("/", "-");

            logFileName += ".txt";

            var logFilePath = Path.Combine(logFolderPath,logFileName);

            DirectoryInfo directoryInfo = new DirectoryInfo(logFolderPath); 

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            FileInfo fileInfo = new FileInfo(logFilePath);
            var writer = fileInfo.CreateText();
            writer.WriteLine("Hatanın gerçekleştiği yer: " + exceptionHandlerPathFeature.Path);
			writer.WriteLine("Hatanın mesajı: " + exceptionHandlerPathFeature.Error.Message);
            writer.Close();
			return View();
		}

        public IActionResult Hata()
        {
            throw new System.Exception("Sistemsel hata oluştur");
        }
	} 
}
