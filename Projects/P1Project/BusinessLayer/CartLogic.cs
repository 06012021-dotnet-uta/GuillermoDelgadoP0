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
  
    public class CartLogic : ICartLogic
    {

        //public CartList list = new CartList();
        private  readonly ShopDB _context;//This class is a dependecy of ShopLogic

        
        /// <summary>
        /// Cunstructor
        /// </summary>
        /// <param name="context"></param>
        public CartLogic(ShopDB context)
        {
            this._context = context;
            

        }


      /// <summary>
      /// For get the customer information when they get verify
      /// </summary>
      /// <param name="customer"></param>
      /// <returns></returns>
      public CustomerModel CustomerTransfer(CustomerModel customer)
        {
            
             var cts =  _context.Customers.Where(x => x.Customer_FName == customer.Customer_FName && x.Password == customer.Password).First();

            return cts;
        }



        /// <summary>
        /// Adding Item in the Cart List
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<StoreModel> AddToCartAsync(CartModel item)
        {

             CartList.AddItem(item);
            
             StoreModel store = null;

             store = _context.Stores.Where(x => x.LocationId == item.ProductOne.LocationId).First();

            return store;
        }

     




        /// <summary>
        /// Method for Display chosen items in the cart
        /// </summary>
        /// <returns></returns>
        public async Task<List<CartModel>> ShowCartList()
        {
            return CartList.GetCartList(); 
        }







     /// <summary>
     /// Add Order to the DB 
     /// </summary>
     /// <returns></returns>
        public async Task<bool> AddOrderAsync()
        {
            decimal totalAmount = 0;

            //Get the total amount of the purchase
            foreach(var item in CartList.GetCartList())
            {
                totalAmount += (item.quantity * item.ProductOne.Product_Price);

            }

            //For make a new order assining the values 
            var order = new OrderModel()
            {
                CustomerId = AccountLogic.GetCustomer().CustomerId,
                Total_Purchase = totalAmount,
                TimeDate = DateTime.Now,


            };

            //Add and save order to DB
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();


            //Get the last order by cheking the mas id number
            int orderId = _context.Orders.Max(x => x.OrderId);


            //Adding all items from the list to the DB
            foreach (var item in CartList.GetCartList())
            {
                OrderDetailModel orderDetail = new OrderDetailModel()
                {
                    OrderId = orderId,
                    ProductId = item.ProductOne.ProductId,
                    Obtain_Qty = item.quantity,
                    Total_Qty_Price = (item.quantity * item.ProductOne.Product_Price),

                };

                await _context.OrderDetails.AddAsync(orderDetail);
            }

            await _context.SaveChangesAsync();//save the DB with the orderDetail



            //Updating the Product Stock substrating the quatity of the Stock
            foreach (var item in CartList.GetCartList()) {

                var product = _context.Products.Where(x => x.ProductId == item.ProductOne.ProductId).First();

                product.Product_Stock = Math.Abs(product.Product_Stock - item.quantity);

                await _context.SaveChangesAsync();

            }

            //Clear the list remove all elements
            CartList.ClearCart();
            return true;
        }
    }
}
