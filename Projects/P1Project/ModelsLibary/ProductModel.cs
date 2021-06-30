using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibary
{

    [Table("Product")]//Giving the name of the table
    public partial class ProductModel
    {

        public ProductModel()
        {
            Order_Detail_Models = new HashSet<OrderDetailModel>();
        }

        [Key]
        public int ProductId { get; set; }

        [Required]//Set to Not Null
        [MaxLength(50)]//Can be applied to a property to specify the maximum string length.
        public string Product_Name { get; set; }


        [Required]//Set to Not Null
        [MaxLength(50)]
        public string Product_Description { get; set; }

        [Required]//Set to Not Null
        public decimal Product_Price { get; set; }

        [Required]//Set to Not Null
        public int Product_Stock { get; set; } = 0;// changed to regular in, defualt 0 bc nullable causes issues.

        [ForeignKey("Store")]//Forgein Key
        public int LocationId { get; set; }

        public virtual StoreModel Location { get; set; }
        public virtual ICollection<OrderDetailModel> Order_Detail_Models { get; set; }

    }
}
