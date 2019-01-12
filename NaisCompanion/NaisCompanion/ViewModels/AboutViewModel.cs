using NaisCompanion.Models;
using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace NaisCompanion.ViewModels
{
    // ZA SETTINGS
    public class AboutViewModel : BaseViewModel<Tourist>
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}