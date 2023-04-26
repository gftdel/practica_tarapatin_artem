using System;
using System.Collections.Generic;

namespace WebApplication8.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Status { get; set; } = null!;
        public string DeliveryMethod { get; set; } = null!;

        public virtual User User { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
