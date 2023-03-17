using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QrMenu.Data;
using QrMenu.Models;
using System.Diagnostics;

namespace QrMenu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db;

        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult KitchenMenu()
        {
            
            IEnumerable<Product> objProductList = _db.Products.Include("Category").Where(t=>t.ProductStatus.Equals("0")
            && (t.Category.CategoryName.Equals("PASTA")
            || t.Category.CategoryName.Equals("PIZZA"))
            );
            return View(objProductList);
        }

        public IActionResult BarMenu()
        {
            IEnumerable<Product> objProductList = _db.Products.Include("Category").Where(t => t.ProductStatus.Equals("0")
            && (t.Category.CategoryName.Equals("COFEE & TEA")
            || t.Category.CategoryName.Equals("NON-ALCOHOLIC DRINKS"))
            );
            return View(objProductList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}