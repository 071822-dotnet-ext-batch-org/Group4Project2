using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class Credentials
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Credentials() {}
        //parameterized constructor
        public Credentials(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}