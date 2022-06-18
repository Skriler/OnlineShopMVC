using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopMVC.Models;
using OnlineShopMVC.Models.ViewModels;
using OnlineShopMVC.Services;

namespace OnlineShopMVC.Controllers
{
    public class ProductsController : Controller
    {
        private static readonly int PAGE_SIZE = 10;

        private ApplicationContext db;

        public ProductsController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ViewResult> IndexAsync(string selectedType, string selectedProducer, 
            int page = 1, SortState sortOrder = SortState.Title)
        {
            List<Product> products = await db.Products.AsNoTracking().ToListAsync();
            if (!String.IsNullOrEmpty(selectedProducer) && selectedProducer != "All")
            {
                products = products.Where(p => p.Producer.Contains(selectedProducer)).ToList();
            }
            if (!String.IsNullOrEmpty(selectedType))
            {
                products = products.Where(p => p.Type.Contains(selectedType)).ToList();
            }
            products = SortHelper.GetSortedList(products, sortOrder);

            int count = products.Count();
            IEnumerable<Product> currentPageProducts = products.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE).ToList();

            ProductListViewModel productListViewModel = new ProductListViewModel(
                currentPageProducts,
                new SortViewModel(sortOrder),
                new FilterViewModel(
                    db.Products.Select(p => p.Producer).ToList(), 
                    selectedProducer, 
                    selectedType
                    ),
                new PageViewModel(count, page, PAGE_SIZE)
                );

            return View(productListViewModel);
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
