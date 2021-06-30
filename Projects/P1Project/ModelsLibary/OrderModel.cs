using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibary
{

    [Table("Order")]//Giving the name of the table
    public partial class OrderModel
    {

        public OrderModel()
        {
            Order_Detail_Model = new HashSet<OrderDetailModel>();
        }

        [Key]//Primary Key
        public int OrderId { get; set; }

        [ForeignKey("Customer")]//Identifying the foreing key
        public int CustomerId { get; set; }

        public decimal Total_Purchase { get; set; }
        public DateTime TimeDate { get; set; }


        public virtual CustomerModel Customer_Model { get; set; }
        public virtual ICollection<OrderDetailModel> Order_Detail_Model { get; set; }

    }
}
