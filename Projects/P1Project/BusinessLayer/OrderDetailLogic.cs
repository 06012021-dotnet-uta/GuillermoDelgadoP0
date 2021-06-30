using Microsoft.EntityFrameworkCore;
using ModelsLibary;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLibary;

namespace BusinessLayer
{
    public class OrderDetailLogic : IOrderDetailLogic
    {

        public List<ProductAndOrderDetailModel> _list;
        private readonly ShopDB _context;//This class is a dependecy of ShopLogic
        //create constructors.
        //first register the context in starup.cs

        public OrderDetailLogic(ShopDB context)//system asigne the new(keyword) for me
        {
            this._context = context;//contex dependecy injection
        }

        /// <summary>
        /// get a single order history
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<List<OrderDetailModel>> GetOrderDetailAsync(OrderModel order)
        {
            var orderDetail = _context.OrderDetails.Where(x => x.OrderId == order.OrderId).ToList();//get all the items in that specific order

            return orderDetail;
        }


        /// <summary>
        /// get order history of the store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        /*public async Task<List<ProductAndOrderDetailModel>> GetStoreOrdersAsync(StoreModel store) //////Testtttt
        {

            List<ProductAndOrderDetailModel> Test = null;
           
        var order = from od in _context.OrderDetails
                join p in _context.Products on od.ProductId equals p.ProductId
                where p.LocationId == store.LocationId
                orderby od.OrderId
                select new ProductAndOrderDetailModel { OrderDetailPAOD = od, ProductPAOD = p };

            return order ;
        }*/



        /// <summary>
        /// get order history of the store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public async Task<List<OrderHistoryModel>> GetStoreOrdersAsync(StoreModel store) //////Testtttt
        {

            List<OrderHistoryModel> Test = new List<OrderHistoryModel>();
           

            ///Query for get all the orders in a specific store
                var order = (from od in _context.OrderDetails                           
                             join p in _context.Products on od.ProductId equals p.ProductId
                             where p.LocationId == store.LocationId
                             orderby od.OrderId
                             select new
                             {
                                 p.ProductId,
                                 p.Product_Name,
                                 p.Product_Price,
                                 od.OrderId,
                                 p.LocationId
                             }).ToListAsync();
           


            foreach (var item in await order) //retrieve each item and assign to model
            {
                
                Test.Add(new OrderHistoryModel()
                {
                    ProductId = item.ProductId,
                    Product_Name = item.Product_Name,
                    Product_Price = item.Product_Price,
                    OrderId = item.OrderId,
                    LocationId = item.LocationId,
                });

                
            }

            return Test;
        }
    }
}
