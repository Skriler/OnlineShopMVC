using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopMVC.Models;
using OnlineShopMVC.Services;

namespace OnlineShopMVC.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationContext db;

        public ProductsController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ViewResult> IndexAsync(string sortOrder)
        {
            ViewBag.PriceSortParm = sortOrder == "Price" ? "PriceDesc" : "Price";
            ViewBag.ProducerSortParm = sortOrder == "Producer" ? "ProducerDesc" : "Producer";

            List<Product> products = await db.Products.AsNoTracking().ToListAsync();

            products = DataHelper.GetSortedList(products, sortOrder);

            return View(products);
        }

        public async Task<ActionResult> DetailsAsync(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            Product product = await db.Products.FindAsync(id);

            if (product == null)
                return RedirectToAction("Index");

            return View(product);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            db.Products.Add(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> EditAsync(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            Product product = await db.Products.FindAsync(id);

            if (product == null)
                return RedirectToAction("Index");

            return View(product);
        }

        [HttpPost]
        public async Task<ActionResult> EditAsync(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            db.Attach(product).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<RedirectToActionResult> DeleteAsync(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            Product product = await db.Products.FindAsync(id);

            if (product != null)
            {
                db.Products.Remove(product);
                await db.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
