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
    public class ShopLogic : IShopLogic
    {
        
        private readonly ShopDB _context;//This class is a dependecy of ShopLogic
        //create constructors.
        //first register the context in starup.cs

        public ShopLogic(ShopDB context)//system asigne the new(keyword) for me
        {
            this._context = context;//contex dependecy injection
        }
        

        /// <summary>
        /// Saves a customer to the db If is unsuccesfull, return false, otherwise true
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<bool> RegisterCustomerAsync(CustomerModel customer) 
        {
            //create a try /catch to save the customer
            await _context.Customers.AddAsync(customer);

            try
            {
                await _context.SaveChangesAsync();

            }
            catch(DbUpdateConcurrencyException ex )
            {
                Console.WriteLine($"There is a problem updating => {ex.InnerException}");
                //throw new Exception($"Concurrency Exeption {ex.InnerException}");
                return false;

            }
            catch(DbUpdateException ex)

            {
                Console.WriteLine($"There is a problem updating => {ex.InnerException}");
                //throw new Exception($"Update Exception {ex.InnerException}");
                return false;

            }
           
            return true;
        
        }


        /// <summary>
        /// Method for get the list of customer on the customer table
        /// </summary>
        /// <returns></returns>
        public async Task<List<CustomerModel>> CustomerListAsync()
        {
            List<CustomerModel> customerList = null;
            try
            {
                  customerList = _context.Customers.ToList();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"The was a problem on customer display {ex.InnerException}");
            }

            return customerList;
        }


        /// <summary>
        /// Login Method that search is the customer is in the db by comparin firts name and password
        /// </summary>
        /// <param name="customerLogin"></param>
        /// <returns></returns>
        public async Task<bool> CustomerLoginAsync(CustomerModel customerLogin)
        {
            if( _context.Customers.Where(x => x.Customer_FName == customerLogin.Customer_FName && x.Password == customerLogin.Password).FirstOrDefault() == null)
            {
                return false;
            }
            else
            {
                return true;
            }             

        }


        /// <summary>
        /// Metho to search customers by firts name
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns></returns>
        public async Task<List<CustomerModel>> CustomerSearchAsync(CustomerModel customerName)
        {
            List<CustomerModel> customerInfo = null;

            try
            {
                customerInfo = _context.Customers.Where(x => x.Customer_FName == customerName.Customer_FName).ToList();

            }catch(ArgumentNullException ex)
            {
                Console.WriteLine($"Exception in the CustomerSearch: {ex.InnerException}");
            }

            return customerInfo;
        }

        

        /// <summary>
        /// Method sor display cusomer ifo by searching for First name and Last
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns></returns>
        public  async Task<List<CustomerModel>> CustomerSearchFLAsync(CustomerModel customerName)
        {
            List<CustomerModel> customerInfo = null;

            try
            {
                customerInfo = _context.Customers.Where(x => x.Customer_FName == customerName.Customer_FName && x.Customer_LName == customerName.Customer_LName).ToList();

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Exception in the CustomerSearch: {ex.InnerException}");
            }

            return customerInfo;
        }
    }
}
