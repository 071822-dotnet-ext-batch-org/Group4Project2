using System;
using System.Collections.Generic;
using System.Numerics;

namespace ModelsLayer
{
    public class RegisterAccount
    {
        public RegisterAccount(Guid guid, string v1, string v2, string v3, int v4, string v5, string v6)
        {
            Guid = guid;
            V1 = v1;
            V2 = v2;
            V3 = v3;
            V4 = v4;
            V5 = v5;
            V6 = v6;
        }

        public RegisterAccount(Guid userId, string? firstName, string? lastName, string? deliveryAddress, int phone, string? email, Guid previousOrders, string? isAdmin)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            DeliveryAddress = deliveryAddress;
            Phone = phone;
            Email = email;
            PreviousOrders = previousOrders;
            this.isAdmin = isAdmin;
        }

        public Guid UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DeliveryAddress { get; set; }
        public int Phone { get; set; }
        public string? Email { get; set; }
        public Guid PreviousOrders{ get; set; }
        public string? isAdmin { get; set; }

        public Guid Guid { get; }
        public string V1 { get; }
        public string V2 { get; }
        public string V3 { get; }
        public int V4 { get; }
        public string V5 { get; }
        public string V6 { get; }
    }
}