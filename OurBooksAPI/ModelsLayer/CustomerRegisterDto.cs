using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class CustomerRegisterDto : NewCustomer
    {
        //constructor
        public CustomerRegisterDto(Guid UserId, string firstName, string lastName, string deliveryAddress, string phone, string email, Guid previousOrders, string isAdmin, string password) : base(UserId, firstName, lastName, deliveryAddress, phone, email, previousOrders, isAdmin)
        {
            this.password = password;
        }
        public string password { get; set; }
    }
}
