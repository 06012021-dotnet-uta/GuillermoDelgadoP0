using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibary
{

    [Table("Store")]//Giving the name of the table
    public partial class StoreModel
    {

        public StoreModel()
        {
            Products_Model = new HashSet<ProductModel>();
        }

        [Key]//Primary Key
        public int LocationId { get; set; }

        [Required]//Set to Not Null
        [MaxLength(30)]//Can be applied to a property to specify the maximum string length.
        public string Store_Name { get; set; }

        [Required]//Set to Not Null
        [MaxLength(20)]
        public string Store_City { get; set; }

        [Required]//Set to Not Null
        [MaxLength(2)]
        public string Store_State { get; set; }

        public virtual ICollection<ProductModel> Products_Model { get; set;}

    }
}
