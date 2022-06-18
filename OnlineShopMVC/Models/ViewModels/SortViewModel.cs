using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopMVC.Services;

namespace OnlineShopMVC.Models.ViewModels
{
    public class SortViewModel
    {
        public SortState TitleSort { get; private set; }
        public SortState PriceSort { get; private set; }
        public SortState ProducerSort { get; private set; }
        public SortState TypeSort { get; private set; }
        public SortState AmountSort { get; private set; }
        public SortState Current { get; private set; }

        public SortViewModel(SortState sortOrder)
        {
            TitleSort = sortOrder == SortState.Title ? SortState.TitleDesc : SortState.Title;
            PriceSort = sortOrder == SortState.Price ? SortState.PriceDesc : SortState.Price;
            ProducerSort = sortOrder == SortState.Producer ? SortState.ProducerDesc : SortState.Producer;
            TypeSort = sortOrder == SortState.Type ? SortState.TypeDesc : SortState.Type;
            AmountSort = sortOrder == SortState.Amount ? SortState.AmountDesc : SortState.Amount;
            Current = sortOrder;
        }
    }
}
