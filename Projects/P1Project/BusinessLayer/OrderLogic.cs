using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLibary;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;

namespace BusinessLayer
{
    public class OrderLogic : IOrderLogic
    {

        private readonly ShopDB _context;//This class is a dependecy of ShopLogic
        //create constructors.
        //first register the context in starup.cs

        public OrderLogic(ShopDB context)//system asigne the new(keyword) for me
        {
            this._context = context;//contex dependecy injection
        }

        /// <summary>
        /// Method for dispaly all the order made by that customer
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public async Task<List<OrderModel>> AllOrders(CustomerModel customerID)
        {
            List<OrderModel> orderList = null;

            orderList = _context.Orders.Where(x => x.CustomerId == customerID.CustomerId).ToList();

            return orderList;
        }
    }
}
