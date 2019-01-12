using NaisCompanion.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NaisCompanion.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage(Tourist active)
        {
            InitializeComponent();

            Children.Add(new MapPage(active)); // formatiranje
        }
    }
}