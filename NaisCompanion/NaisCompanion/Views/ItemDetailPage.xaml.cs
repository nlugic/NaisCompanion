using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NaisCompanion.Models;
using NaisCompanion.ViewModels;

namespace NaisCompanion.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new TouristLocation
            {
                //Text = "Item 1", [OBRISATI]
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}