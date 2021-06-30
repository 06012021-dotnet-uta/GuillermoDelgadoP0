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
    public class OrderController : Controller
    {
        
        private readonly IOrderLogic _orderLogic;
        private readonly IOrderDetailLogic _orderDetailLogic;

        public OrderController(IOrderLogic orderLogic, IOrderDetailLogic orderDetailLogic)
        {

            this._orderLogic = orderLogic;
            this._orderDetailLogic = orderDetailLogic;
           

        }


        /// <summary>
        /// Display orders belong to that specific customer
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ShowCustomerOrders()
        {
            
            var customer = AccountLogic.GetCustomer();

            List<OrderModel> orders = null;

             orders = await _orderLogic.AllOrders(customer);


            return View("ShowCustomerOrders", orders);
        }
















        // GET: OderController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OderController/Create
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

        // GET: OderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OderController/Edit/5
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

        // GET: OderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OderController/Delete/5
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
