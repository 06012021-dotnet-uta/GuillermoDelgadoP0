using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibary
{
    [Table("Customer")]//Giving the name of the table
    public partial class CustomerModel
    {
        public CustomerModel()
        {
            Orders_Model = new HashSet<OrderModel>();
        }

        
        [Key]//Primary Key
        public int CustomerId { get; set; }

        [Display(Name = "First Name: ")]
        [Required(ErrorMessage = "Forgot to enter your firts name!!")]//Set to Not Null
        [MaxLength(20)]
        public string Customer_FName { get; set; }

        [Display(Name = "Last Name: ")]
        [Required (ErrorMessage ="Forgot to enter your last name!!")]//Set to Not Null
        [MaxLength(20)]
        public string Customer_LName { get; set; }

        
        [Required(ErrorMessage ="Password is require!!")]//Set to Not Null
        public string Password { get; set; }

        [Display(Name = "Address: ")]
        [MaxLength(50)]//Can be applied to a property to specify the maximum string length.
        public string Customer_Address { get; set; }

        [Display(Name = "City: ")]
        [MaxLength(20)]
        public string Customer_City { get; set; }

        [Display(Name = "State:")]
        [MaxLength(2)]
        public string Customer_State { get; set; }


        public virtual ICollection<OrderModel> Orders_Model { get; set; }

    }
}
