using System;
using System.Collections.Generic;

#nullable disable

namespace ShopDBContext
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public int UserId { get; set; }
        public decimal? TotalPurches { get; set; }
        public DateTime? TimeDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
