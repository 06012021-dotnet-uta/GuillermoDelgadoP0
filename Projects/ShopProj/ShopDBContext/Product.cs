using System;
using System.Collections.Generic;

#nullable disable

namespace ShopDBContext
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public int Stock { get; set; } = 0;// changed to regular in, defualt 0 bc nullable causes issues.
        public int LocationId { get; set; }

        public virtual StoreLocation Location { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
