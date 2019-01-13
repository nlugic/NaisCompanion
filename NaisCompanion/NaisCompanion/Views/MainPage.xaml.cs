using NaisCompanion.Models;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NaisCompanion.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(Tourist active)
        {
            Children.Add(new MapPage(active));
        }

        private async Task<MainPage> InitializeAsync(Tourist active)
        {
            MapPage mapPage = await MapPage.CraeateAsync(active);
            Children.Add(mapPage);

            return await Task.FromResult(this);
        }

        public static Task<MainPage> CreateAsync(Tourist active)
        {
            MainPage ret = new MainPage();
            return ret.InitializeAsync(active);
        }
    }
}