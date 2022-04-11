using FirstCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApp.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class DefaultController : Controller
    {
        NewsContext db;
        public DefaultController(NewsContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            int teamCount = db.Teammembers.Count();
            int NewsCount = db.News.Count();
            int ContactCount = db.Contacts.Count();
            int CatCount = db.Categories.Count();

            return View(new AdminNumbers { team = teamCount, news = NewsCount, contact = ContactCount, category = CatCount});
        }
    }
    public class AdminNumbers
    {
        public int team { get; set; }
        public int news { get; set; }
        public int contact { get; set; }
        public int category { get; set; }
    }
}
