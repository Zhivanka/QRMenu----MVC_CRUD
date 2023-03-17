using Microsoft.AspNetCore.Mvc;
using QrMenu.Models;
using QrMenu.Data;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Dynamic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace QrMenu.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _db;

        public AdminController(AppDbContext db)
        {
            _db = db;
        }


        


        public IActionResult Logged()
        {
            return View();
        }

        //ako ne e deinirano po default e get
        public IActionResult CreateCategory()
        {
            return View();
        }

        //koga kje se klikne create category button
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory(Category obj)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("DisplayCategory","Admin");
        }


        //ako ne e deinirano po default e get
        public IActionResult EditCategory(int? id)
        {
            if (id == null || id == 0)
            { return NotFound(); }

            var CategoryFromDb = _db.Categories.Find(id);
            if (CategoryFromDb == null)
            { return NotFound(); }
            return View(CategoryFromDb);
        }

        //koga kje se klikne create category button
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory(Category obj)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("DisplayCategory", "Admin");
        }


        //ako ne e deinirano po default e get
        public IActionResult DeleteCategory(int? id)
        {
            if (id == null || id == 0)
            { return NotFound(); }

            var CategoryFromDb = _db.Categories.Find(id);
            if (CategoryFromDb == null)
            { return NotFound(); }
            return View(CategoryFromDb);
        }

        //koga kje se klikne create category button
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(Category obj)
        {

            var objDB = _db.Categories.Find(obj.CategoryId);
            if (objDB == null)
            { return NotFound(); }

            _db.Categories.Remove(objDB);
            _db.SaveChanges();
            return RedirectToAction("DisplayCategory", "Admin");
        }


        public IActionResult DisplayCategory()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }


        public IActionResult CreateProduct()
        {
            ViewBag.Category = GetCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct(Product obj)
        {
            _db.Products.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("DisplayProduct", "Admin");
        }

        //ako ne e deinirano po default e get
        public IActionResult EditProduct(int? id)
        {
            if (id == null || id == 0)
            { return NotFound(); }
            ViewBag.Category = GetCategories();
            var ProductFromDb = _db.Products.Find(id);
            if (ProductFromDb == null)
            { return NotFound(); }
            return View(ProductFromDb);
        }

        //koga kje se klikne create category button
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(Product obj)
        {
            _db.Products.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("DisplayProduct", "Admin");

        }

        //ako ne e deinirano po default e get
        public IActionResult DeleteProduct(int? id)
        {
            if (id == null || id == 0)
            { return NotFound(); }
            ViewBag.Category = GetCategories();
            var ProductFromDb = _db.Products.Find(id);
            if (ProductFromDb == null)
            { return NotFound(); }
           return View(ProductFromDb);
        }

        //koga kje se klikne create category button
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(Product obj)
        {

            var objDB = _db.Products.Find(obj.ProductId);
            if (objDB == null)
            { return NotFound(); }

            _db.Products.Remove(objDB);
            _db.SaveChanges();
            return RedirectToAction("DisplayProduct", "Admin");
        }



        public IActionResult DisplayProduct()
        {   
                IEnumerable<Product> objProductList = _db.Products.Include("Category");
                return View(objProductList);
        }


        public IEnumerable<Category> GetCategories()
        {
            IEnumerable<Category> categories = _db.Categories;
            return categories;

        }

        public IEnumerable<Product> GetProducts()
        {
            IEnumerable<Product> products = _db.Products;
            return products;

        }




    }
}
