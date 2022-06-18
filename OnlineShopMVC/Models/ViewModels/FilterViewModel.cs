using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopMVC.Models;

namespace OnlineShopMVC.Models.ViewModels
{
    public class FilterViewModel
    {
        public SelectList Producers { get; private set; }
        public string SelectedProducer { get; private set; }
        public string SelectedType { get; private set; }

        public FilterViewModel(List<string> producers, string producer, string type)
        {
            producers = producers.GroupBy(p => p).Select(p => p.Key).ToList();
            producers.Insert(0, "All");
            Producers = new SelectList(producers, producer);
            SelectedProducer = producer;
            SelectedType = type;
        }

    }
}
