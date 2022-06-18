using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopMVC.Models;

namespace OnlineShopMVC.Services
{
    public static class SortHelper
    {
        public static List<Product> GetSortedList(List<Product> products, SortState sortOrder)
        {
            products = sortOrder switch
            {
                SortState.TitleDesc => products.OrderByDescending(p => p.Title).ToList(),
                SortState.Price => products.OrderBy(p => p.Price).ToList(),
                SortState.PriceDesc => products.OrderByDescending(p => p.Price).ToList(),
                SortState.Producer => products.OrderBy(p => p.Producer).ToList(),
                SortState.ProducerDesc => products.OrderByDescending(p => p.Producer).ToList(),
                SortState.Type => products.OrderBy(p => p.Type).ToList(),
                SortState.TypeDesc => products.OrderByDescending(p => p.Type).ToList(),
                SortState.Amount => products.OrderBy(p => p.Amount).ToList(),
                SortState.AmountDesc => products.OrderByDescending(p => p.Amount).ToList(),
                _ => products.OrderBy(p => p.Title).ToList(),
            };

            return products;
        }
    }
}
