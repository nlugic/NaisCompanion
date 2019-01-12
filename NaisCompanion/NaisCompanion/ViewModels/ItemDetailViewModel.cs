using System;

using NaisCompanion.Models;

namespace NaisCompanion.ViewModels
{
    // ZA JEDAN TOURIST/REWARD
    public class ItemDetailViewModel : BaseViewModel
    {
        public TouristLocation Item { get; set; }
        public ItemDetailViewModel(TouristLocation item = null)
        {
            Title = item?.Description;
            Item = item;
        }
    }
}
