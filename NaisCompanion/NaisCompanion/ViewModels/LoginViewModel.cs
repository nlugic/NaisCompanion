using NaisCompanion.Models;
using System.Collections.Generic;
using System.Windows.Input;

namespace NaisCompanion.ViewModels
{
    public class LoginViewModel
    {
        private List<Tourist> touristDataStore = new List<Tourist>
        {
            new Tourist { Id = 1, Username = "nlugic", Tokens = 0, Timeout = 24 },
            new Tourist { Id = 2, Username = "malinovic", Tokens = 0, Timeout = 24 },
            new Tourist { Id = 3, Username = "avucic", Tokens = 0, Timeout = 24 },
            new Tourist { Id = 4, Username = "nstefanovic", Tokens = 0, Timeout = 24 }
        };

        public List<Tourist> TouristDataStore
        {
            get { return touristDataStore; }
            set { touristDataStore = value; }
        }

        public string Title { get; private set; }
        public string UserName { get; set; } = string.Empty;
        public int Timeout { get; set; } = 1;
        public ICommand BeginTourCommand { get; private set; }
        public ICommand ContinueTourCommand { get; private set; }

        public LoginViewModel(ICommand begin, ICommand cont)
        {
            Title = "NaisCompanion - Sign in";

            BeginTourCommand = begin;
            ContinueTourCommand = cont;
        }
    }
}
