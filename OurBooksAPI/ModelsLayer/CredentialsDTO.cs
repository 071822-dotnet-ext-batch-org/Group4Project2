using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class CredentialsDTO
    {
        public string Email { get; set; }
        public CredentialsDTO() {}
        //parameterized constructor
        public CredentialsDTO(string email)
        {
            this.Email = email;
        }
    }
}