using TestApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    internal class UserContext
    {
        private UserContext(User user)
        {
            _user = user;
            _currentUserContext = this;  // не очень понятно
            OnPropertyChanged("CurrentUserContext");                // Статический NotifyPropertyChanged
        }


        private User _user;                                 
        public User User
        {
            get { return _user; }
        }


        private static UserContext _currentUserContext;
        public static UserContext CurrentUserContext    //текущий пользователь
        {
            get { return _currentUserContext; }
        }

        public void ClearUser()
        {
            _currentUserContext = null;
        }

        public static void CreateUserContext(User user)
        {
            if (CurrentUserContext != null)
            {
                new UserContext(user);
            }
        }

        // Статический NotifyPropertyChanged
        public static event PropertyChangedEventHandler PropertyChanged;
        protected static void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(CurrentUserContext, new PropertyChangedEventArgs(property));
        }
    }
}
