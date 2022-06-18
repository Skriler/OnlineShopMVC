using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopMVC.Models;
using OnlineShopMVC.Models.ViewModels;

namespace OnlineShopMVC.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationContext db;

        public OrdersController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ViewResult> IndexAsync()
        {
            List<Order> orders = await db.Orders
                .Include(o => o.Product)
                .AsNoTracking()
                .ToListAsync();

            return View(orders);
        }

        [HttpGet]
        public ActionResult Create(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Products");

            ViewBag.ProductId = id;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(Order order)
        {
            if (!ModelState.IsValid)
                return View(order);

            db.Orders.Add(order);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
