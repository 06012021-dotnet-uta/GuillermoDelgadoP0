using Microsoft.EntityFrameworkCore;
using ModelsLibary;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
    public class AccountLogic 
    {

        
        public static CustomerModel save_customer;


        private readonly ShopDB _context;//This class is a dependecy of ShopLogic
        //create constructors.
       




         static AccountLogic()//system asigne the new(keyword) for me () goes to the parameter
        {

            save_customer = new CustomerModel();
        }




    
        public  static void SaveCustomer(CustomerModel customer)
        {

            save_customer = customer;
   
        }


        public static CustomerModel GetCustomer()
        {
            return save_customer;
        }


       
    }
}
