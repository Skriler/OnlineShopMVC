using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopMVC.Models;

namespace OnlineShopMVC.Services
{
    public static class DataHelper
    {
        public static List<Product> GetSortedList(List<Product> products, string sortOrder)
        {
            switch(sortOrder)
            {
                case "Price":
                    products = products.OrderBy(p => p.Price).ToList();
                    break;
                case "PriceDesc":
                    products = products.OrderByDescending(p => p.Price).ToList();
                    break;
                case "Producer":
                    products = products.OrderBy(p => p.Producer).ToList();
                    break;
                case "ProducerDesc":
                    products = products.OrderByDescending(p => p.Producer).ToList();
                    break;
            }

            return products;
        }
    }
}
