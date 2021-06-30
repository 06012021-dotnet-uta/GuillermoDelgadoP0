using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLibary;
using BusinessLayer;
using System.Dynamic;

namespace P1Shop.Controllers
{

    public class CartController : Controller
    {

        private  readonly ICartLogic _cartLogic;
        private readonly IProduct _productLogic;
        private readonly IOrderLogic _orderLogic;
        private readonly IOrderDetailLogic _orderDetailLogic;
        private readonly IStoreLogic _storeLogic;




        public CartController(ICartLogic cartLogic, IProduct productLogic, IOrderDetailLogic orderDetailLogic, IOrderLogic orderLogic, IStoreLogic storeLogic)
        {
            this._cartLogic = cartLogic;
            this._productLogic = productLogic;
            this._orderDetailLogic = orderDetailLogic;
            this._orderLogic = orderLogic;
            this._storeLogic = storeLogic;
            
        }

       

        /// <summary>
        /// Method to display product Info before to buy
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public async Task<ActionResult> ProductInfoCart(ProductModel product)
        {

            var productInfo = await _productLogic.GetProductInfoAsync(product);

            CartModel item = new CartModel();

            item.ProductOne = productInfo;
           
            return View("ProductInfoCart", item);

        }






        /// <summary>
        /// Add Item to a list in CartLogic and return the store for
        /// see more items
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<ActionResult> AddProduct(CartModel item) 
        {

           StoreModel store =  await _cartLogic.AddToCartAsync(item);

          
            return RedirectToAction("ShowProductList","Product",store);
        }





        /// <summary>
        /// Show the list of items in the acrt att the moment
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<ActionResult> CartList()
        {

            List<CartModel> listCart = new List<CartModel>(await _cartLogic.ShowCartList());

            return View("CartList", listCart);
        }







        /// <summary>
        /// Method for set the order to the db
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> SetOrder()
        {
           
           await _cartLogic.AddOrderAsync();
            ///print your order
            return RedirectToAction("ShowStoreList", "Store");
        }




        public IActionResult Index()
        {
            return View();
        }
    }
}
