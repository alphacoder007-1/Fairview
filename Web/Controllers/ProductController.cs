using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;

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
            var products = db.Products.ToList();
            return View(products);
        }
    }
}
