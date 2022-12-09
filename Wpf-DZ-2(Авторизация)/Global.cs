using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_DZ_2_Заполнение_макета_ {
    internal class Global {

        private static User _user;
        public static User User {
            get { return _user; }
            set { if ( value != null ) _user = value; }
        }
    }
}
