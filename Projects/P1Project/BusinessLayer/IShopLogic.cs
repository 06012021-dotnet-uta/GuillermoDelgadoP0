using ModelsLibary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public interface IShopLogic
    {
        Task<bool> RegisterCustomerAsync(CustomerModel customer);
        Task<List<CustomerModel>> CustomerListAsync();
        Task<bool> CustomerLoginAsync(CustomerModel customerLogin);
        Task<List<CustomerModel>> CustomerSearchAsync(CustomerModel customerName);
        Task<List<CustomerModel>> CustomerSearchFLAsync(CustomerModel customerName);
    }
}
