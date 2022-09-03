using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class ViewOrder
    {
        public ViewOrder(Guid orderId, string bookName, decimal cost, string firstName, string lastName, string deliveryAddress, Guid orderTracker)
        {
            OrderId = orderId;
            BookName = bookName;
            Cost = cost;
            FirstName = firstName;
            LastName = lastName;
            DeliveryAddress = deliveryAddress;
            OrderTracker = orderTracker;
        }

        public Guid OrderId { get; set; }
        public string BookName { get; set; }
        public decimal Cost { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DeliveryAddress { get; set; }
        public Guid OrderTracker { get; set; }

    }
}