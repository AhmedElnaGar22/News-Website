using FirstCoreApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApp.Controllers
{
    public class HomeController : Controller
    {
        NewsContext db;
        public HomeController(NewsContext context)
        {
            db = context;
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            var result = db.Categories.ToList();

            return View(result);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveContact(ContactUS model)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Contact", model);

        }

        public IActionResult Messages()
        {
            var result = db.Contacts.ToList();
            return View(result);
        }

        [Authorize]
        public IActionResult News(int id)
        {
            Category c = db.Categories.Find(id);
            //ViewBag.cat = c.Name;
            ViewData["Cat"] = c.Name;

            var result = db.News.Where(x => x.categoryId == id).OrderByDescending(x => x.Date).ToList();
            return View(result);
        }

        public IActionResult DeleteNews(int id)
        {
            var news = db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
