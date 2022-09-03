using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class ProfileDTO
    {
        public ProfileDTO(string fname, string lname, string email, string daddress, string phone)
        {
            FirstName = fname;
            LastName = lname;
            Email = email;
            DeliveryAddress = daddress;
            Phone = phone;
        }

        public ProfileDTO() {}

        // Properties for constructors
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DeliveryAddress { get; set; }
        public string Phone { get; set; }
    }
}
