using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLibary;

namespace BusinessLayer
{
    public interface ICartLogic
    {
        Task<StoreModel> AddToCartAsync(CartModel item);
        Task<bool> AddOrderAsync();
        Task<List<CartModel>> ShowCartList();
        CustomerModel CustomerTransfer(CustomerModel customer);


    }
}
