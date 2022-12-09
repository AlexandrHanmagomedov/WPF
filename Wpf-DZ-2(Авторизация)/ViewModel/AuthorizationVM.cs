using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_DZ_2_Заполнение_макета_.Model;

namespace Wpf_DZ_2_Заполнение_макета_.ViewModel {
    internal class AuthorizationVM : NotifyClass {

        public string LoginUser { get; set; }
        public string PasswordUser { get; set; }

        private string _userName;
        public string UserName {
            get { return _userName; }
            set {
                _userName = value;/*OnPropertyChanged ("UserName" );*/
                OnPropertyChanged ( );
            }
        }
        public bool Auth ( ) {
            //сделать проверку регулярные выражения , на достоверность
            if ( LoginUser == null ) return false;
            if ( PasswordUser == null ) return false;

            var context = new UsersDB ( );
            context.Users.Where ( x => x.Login == LoginUser ).FirstOrDefault ( );
            //context.Users.Where(delegate ( User x ) { return x.Login == LoginUser; }).FirstOrDefault(); это тоже самое что и выше

            var access = context.Users.Where ( x => x.Login == LoginUser ).FirstOrDefault ( );

            if ( access != null && access.IsAuthorization ( PasswordUser ) ) {
                Global.User = access;
                UserName=access.Name;
                return true;
            }
            return false;
        }
    }
}
