using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Model
{
    internal class User
    {
        public User(string name, string login, string password)
        {
            Name = name;
            Login = login;
            Password = password;
        }

        public string Name { get; private set; }
        public string Login { get; private set; }
        private string Password { get; set; }
        public bool IsAuthorization(string password) => password == Password;
        //{
        //    //if (password == Password)
        //    //    return true;
        //    //return false;
        //}
    }
}
