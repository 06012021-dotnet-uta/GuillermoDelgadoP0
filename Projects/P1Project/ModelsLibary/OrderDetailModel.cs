using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibary
{

    [Table("OrderDetail")]//Giving the name of the table
    public partial class OrderDetailModel
    {
        [Key]//Primary key compose
        [Column(Order = 1)]
        [ForeignKey("Order")]//Forgein Key
        public int OrderId { get; set; }

        [Key]//Primary key compose
        [Column(Order = 2)]//Can be applied to a property to configure the corresponding column name.
        [ForeignKey("Product")]//Forgein Key
        public int ProductId { get; set; }
        public int Obtain_Qty { get; set; }
        public decimal Total_Qty_Price { get; set;}

        public virtual OrderModel Order_Model { get; set; }
        public virtual ProductModel Product_Model { get; set; }
    }
}
