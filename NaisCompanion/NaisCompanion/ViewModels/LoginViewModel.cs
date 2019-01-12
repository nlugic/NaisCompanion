using NaisCompanion.Models;
using NaisCompanion.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NaisCompanion.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public TouristMockDataStore TouristDataStore
        {
            get
            {
                return DependencyService.Get<TouristMockDataStore>() ?? new TouristMockDataStore(new List<Tourist>
                {
                    new Tourist { Id = 1, Username = "user1", Tokens = 0, Timeout = 24 },
                    new Tourist { Id = 2, Username = "user2", Tokens = 0, Timeout = 24 },
                    new Tourist { Id = 3, Username = "user3", Tokens = 0, Timeout = 24 },
                    new Tourist { Id = 4, Username = "user4", Tokens = 0, Timeout = 24 }
                });
            }
        }
        
        private string userName = string.Empty;
        public string UserName
        {
            get { return userName; }
            set { SetProperty(ref userName, value); }
        }

        private int timeout = 1;
        public int Timeout
        {
            get { return timeout; }
            set { SetProperty(ref timeout, value); }
        }

        public ICommand BeginTourCommand { get; set; }
        public ICommand ContinueTourCommand { get; set; }

        public LoginViewModel(ICommand begin, ICommand cont)
        {
            Title = "Sign in";

            BeginTourCommand = begin;
            ContinueTourCommand = cont;
        }
    }
}
