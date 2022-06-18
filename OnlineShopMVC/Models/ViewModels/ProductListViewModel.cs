using System.Collections.Generic;
using OnlineShopMVC.Models;

namespace OnlineShopMVC.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; private set; }
        public SortViewModel SortViewModel { get; private set; }
        public FilterViewModel FilterViewModel { get; private set; }
        public PageViewModel PageViewModel { get; private set; }

        public ProductListViewModel(IEnumerable<Product> products, SortViewModel sortViewModel,
            FilterViewModel filterViewModel, PageViewModel pageViewModel)
        {
            Products = products;
            SortViewModel = sortViewModel;
            FilterViewModel = filterViewModel;
            PageViewModel = pageViewModel;
        }
    }
}
