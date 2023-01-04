using HW_markup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Model;

namespace TestApp.ViewModel
{
    internal class AuthorizationVM : NotifyClass
    {
        //Количество неудачных попыток
        const int FAIL_COUNT = 3;
        //Количество секунд блокировки авторизации
        const int PAUSE = 10;
        public AuthorizationVM()
        {
            Message = $"У вас {FAIL_COUNT} попыток.";
            FailCount = FAIL_COUNT;
            IsEnabledAuth = true;
        }

        public string LoginUser { get; set; }
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value; /*OnPropertyChanged("UserName");*/
                OnPropertyChanged();
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged(); }
        }

        private int _failCount;
        public int FailCount
        {
            get { return _failCount; }
            set
            {
                if (value > 0)
                {
                    _failCount = value;
                    Message = $"Количество неудачных попыток {_failCount}";
                }
                else
                {
                    var t = StartPause();
                    _failCount = FAIL_COUNT;
                }

            }
        }

        private bool _isEnabledAuth;
        public bool IsEnabledAuth
        {
            get { return _isEnabledAuth; }
            set { _isEnabledAuth = value; OnPropertyChanged(); }
        }
        public bool Auth(string password)
        {
            if (LoginUser == null) return false;
            if (password == null) return false;
            var context = UsersDB.Context;
            //context.Users.Where(delegate(User x) { return x.Login == CurrentUser.Login; }).FirstOrDefault();
            var access = context.Users.Where(x => x.Login == LoginUser).FirstOrDefault();
            if (access != null && access.IsAuthorization(password))
            {
                UserContext.CreateUserContext(access);
                UserName = access.Name;
                return true;
            }
            FailCount--;
            return false;
        }

        private async Task StartPause()
        {
            IsEnabledAuth = false;
            for (int i = PAUSE; i > 0; i--)
            {
                Message = $"Авторизация заблокирована на {i} секунд";
                await Task.Delay(1000);
            }
            //OnPropertyChanged(Message);
            IsEnabledAuth = true;
            Message = "Повторите попытку.";
        }
    }
}
