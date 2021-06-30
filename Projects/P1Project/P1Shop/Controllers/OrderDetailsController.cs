using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using ModelsLibary;

namespace P1Shop.Controllers
{
    public class OrderDetailsController : Controller
    {


        private readonly ICartLogic _cartLogic;
        private readonly IProduct _productLogic;
        private readonly IOrderLogic _orderLogic;
        private readonly IOrderDetailLogic _orderDetailLogic;
        private readonly IStoreLogic _storeLogic;




        public OrderDetailsController(ICartLogic cartLogic, IProduct productLogic, IOrderDetailLogic orderDetailLogic, IOrderLogic orderLogic, IStoreLogic storeLogic)
        {
            this._cartLogic = cartLogic;
            this._productLogic = productLogic;
            this._orderDetailLogic = orderDetailLogic;
            this._orderLogic = orderLogic;
            this._storeLogic = storeLogic;

        }

        /// <summary>
        /// For customer
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<ActionResult> OrderDetails(OrderModel order)
        {

            var orderdetail =await _orderDetailLogic.GetOrderDetailAsync(order);

            return View("OrderDetails", orderdetail);
        }


        //+++++++++++++++++++++++++++ TEST +++++++++++++++++++++++++++++++++++++

        /// <summary>
        /// List of oder for store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
       /* public async Task<ActionResult> ListOfOrders(StoreModel store)
        {
            List<ProductAndOrderDetailModel> list = null;
            
            list =  _orderDetailLogic.GetStoreOrdersAsync(store);

          

            return View("ListOfOrders",list);
        }*/
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++



        /// <summary>
        /// List of oder for store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public async Task<ActionResult> HistoryOrders(StoreModel store)
        {
            List<OrderHistoryModel> list = null;
            list = await _orderDetailLogic.GetStoreOrdersAsync(store);
            return View("HistoryOrders",list);
        }







            // GET: OrderDetails
            public ActionResult Index()
        {
            return View();
        }

        // GET: OrderDetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderDetails/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderDetails/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
