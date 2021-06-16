using ShopDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Item : Product
    {
        public Item() : base()
        {
            this.ProductName = "Default";
            this.ProductPrice = 0;
            this.Stock = 0;
            this.ProductId = 0;
            this.LocationId = 0;
        }
        public Item(string pName, decimal pPrice, int qty, int pId, int locationId)
        {
            this.ProductName = pName;
            this.ProductPrice = pPrice;
            this.Stock = qty;
            this.ProductId = pId;
            this.LocationId = locationId;
        }
    }
}
