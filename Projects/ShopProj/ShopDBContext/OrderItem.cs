using System;
using System.Collections.Generic;

#nullable disable

namespace ShopDBContext
{
    public partial class OrderItem
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int? ObtainQty { get; set; }
        public decimal? TotalQtyPrice { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
