using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class CheckoutDTO
    {   
        /// <summary>
        /// Constructor for the checkout process
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="bookName"></param>
        /// <param name="money"></param>
        /// <param name="isUser"></param>
        public CheckoutDTO(Guid cartId, string bookName, decimal money, bool isUser)
        {
            CartId = cartId;
            BookName = bookName;
            Money = money;
            IsUser = isUser;
        }
       
        public Guid CartId { get; set; }
        public string BookName { get; set; }
        public decimal Money { get; set; }
        public bool IsUser { get; set; }
    }
}
