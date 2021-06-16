using System;
using System.Collections.Generic;

#nullable disable

namespace ShopDBContext
{
    public partial class StoreLocation
    {
        public StoreLocation()
        {
            Products = new HashSet<Product>();
        }

        public int LocationId { get; set; }
        public string StoreName { get; set; }
        public string StoreCity { get; set; }
        public string StoreState { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
