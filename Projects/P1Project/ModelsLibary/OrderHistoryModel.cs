using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibary
{
   public class OrderHistoryModel
    {
        public int ProductId { get; set; }
        public string Product_Name { get; set; }
        public decimal Product_Price { get; set; }
        public int OrderId { get; set; }
        public int LocationId { get; set; }
    }
}
