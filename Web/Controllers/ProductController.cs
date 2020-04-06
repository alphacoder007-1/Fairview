using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        DatabaseContext db = null;
        public ProductController()
        {
            db = new DatabaseContext();
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            // var products = db.Products.ToList();

            var products = (from p in db.Products
                            join c in db.Categories
                            on p.CategoryId equals c.CategoryId
                            select new ProductViewModel
                            {
                                ProductId = p.ProductId,
                                Name = p.Name,
                                UnitPrice = p.Unitprice,
                                Description = p.Description,
                                Category = c.Name
                            }).ToList();


            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = db.Categories.ToList();
            return View();       
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            try
            {
                db.Products.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ViewBag.Message = $"Something went wrong : {ex.Message}";
            }
            ViewBag.Category = db.Categories.ToList();
            return View();
        }


        public IActionResult Edit(int Id)
        {
             ViewBag.Categories = db.Categories.ToList();
            Product prd = db.Products.Where(p => p.ProductId == Id).FirstOrDefault();
            return View("Create",prd);
        }
        [HttpPost]
        public IActionResult Edit(Product model)
        {
            try
            {
                // db.Products.Update(model);

                db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                //var product = db.Products.Where(p => p.ProductId == model.ProductId).FirstOrDefault();
                //product.Unitprice = model.Unitprice;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

            }

            ViewBag.Categories = db.Categories.ToList();
            return View("Create");
        }

        public IActionResult Delete(int id)
        {
            var product = db.Products.Where(p => p.ProductId == id).FirstOrDefault();
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }
    }
}
