using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class NewCustomer
    {
        private string v1;
        private string v2;
        private string v3;
        private string v4;
        private string v5;
        private string v6;
        private string v;

        public NewCustomer(string v1, string v2, string v3, string v4, string v5, string v6)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;
        }




        public NewCustomer(Guid guid, string v1, string v2, string v3, string v4, string v5, string v6)
        {
            Guid = guid;
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;
        }

        public NewCustomer(Guid UserId, string firstName, string lastName, string deliveryAddress, string phone, string email, Guid previousOrders, string isAdmin)
        {
            this.UserId = UserId;
            FirstName = firstName;
            LastName = lastName;
            DeliveryAddress = deliveryAddress;
            Phone = phone;
            Email = email;
            PreviousOrders = previousOrders;
            this.isAdmin = isAdmin;
        }



        //[StringLength(10, MinimumLength = 4)]
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DeliveryAddress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid PreviousOrders { get; set; }
        public string isAdmin { get; set; }
        public Guid Guid { get; }
    }
}