using System;
using System.Collections.Generic;

namespace Group_Project.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
