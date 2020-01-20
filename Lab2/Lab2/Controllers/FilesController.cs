using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Lab2.Controllers
{
    public class FilesController : Controller
    {
        private IWebHostEnvironment _hostingEnvironment;
        public FilesController(IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        public IActionResult Index()
        {
            string[] files = Directory.GetFiles(_hostingEnvironment.ContentRootPath + "/TextFiles").Select(Path.GetFileName).ToArray();
           // string[] files = Directory.GetFiles( "/TextFiles").Select(Path.GetFileName).ToArray();

            ViewBag.FileBag = files;
            return View();
        }

        public IActionResult Content(string id)
        {
            string text = System.IO.File.ReadAllText("./TextFiles/" + id);

            ViewBag.FileText = text;
            return View();

        }
    }
}