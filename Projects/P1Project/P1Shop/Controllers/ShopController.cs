using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLibary;
using P1Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P1Shop.Controllers
{

    /// <summary>
    /// Class ShopCpntroller inhereting from Controller
    /// </summary>
    public class ShopController : Controller
    {
        private readonly IShopLogic _shopLogic;
        
        private readonly ICartLogic _cartLogic;

       

        //create a constructor into which i will inject the shoplogic Class from business layer.
        public ShopController(IShopLogic shopLogic, ICartLogic cartLogic)
        {
            this._shopLogic = shopLogic;
            
            this._cartLogic = cartLogic;
        }


        

        // GET: ShopController
        /// <summary>
        /// Actiom method Login for enter in the program and validate the user
        /// </summary>
        /// <returns></returns>
        public async Task <ActionResult> Login(CustomerModel customerLogin)
        {

           bool validation = await _shopLogic.CustomerLoginAsync(customerLogin);

            if (validation)
            {
               var cts = _cartLogic.CustomerTransfer(customerLogin);
               AccountLogic.SaveCustomer(cts);

                return View("LoggeInLandingPage",customerLogin);
            }
            else {
                return View("Login"); 
            
            }
        }





        /// <summary>
        /// Return to main
        /// </summary>
        /// <returns></returns>
        public ActionResult Main()
        {
            return View("LoggeInLandingPage", AccountLogic.GetCustomer());
        }






        // GET: ShopController/Details/5
        /// <summary>
        /// Actiom method Details the comment on top is the looks of the url
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: ShopController/Create - This is conventional routing.
        /// <summary>
        /// Action method Create the comment on top is the looks of the url
        /// This method take you to the view were you can enter the new customer info
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View("CreateNewCustomer");
        }

        


        //[Route("Create")]//for routing to a sertian page
        //This is Model Biding system take the data form &
        //matches it to the props models.
        /// <summary>
        /// This method Display the customer info before adding him to the 
        /// DB
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateNewCustomer(CustomerModel customer)
        {

            if (!ModelState.IsValid)
            {
                RedirectToAction("Create");
            }     

                return View("DisplayNewCustomer", customer); 
            
        }






        /// <summary>
        /// this action methos add a new customer on the db
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<ActionResult> AddCustomer(CustomerModel customer)
        {
            //check that the model binding work
            if (!ModelState.IsValid)
            {
                RedirectToAction("Create");
            }

            //call a method in the business layer
            bool sucessfullAdded = await _shopLogic.RegisterCustomerAsync(customer);//for mockin the testing is a interface for implementing in unit testing

            if (sucessfullAdded)
            {
                ViewBag.Welcome = "You are in addCustomer action";

                return View("Login");
            }
            else
            {
                ViewBag.ErrorViewBag = "AddCustomer hava a error";
                return View("Error");
            }     
        }



        /// <summary>
        /// Display option for enter search by name or last name
        /// </summary>
        /// <param name="customerFName"></param>
        /// <returns></returns>
        public ActionResult SearchByName()
        {

            return View("SearchByName");
        }


        /// <summary>
        /// Search Customer by First Name
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns></returns>
        public async Task<ActionResult> SearchForCustomer(CustomerModel customerName)
        {

            List<CustomerModel> customerSearch = await _shopLogic.CustomerSearchAsync(customerName);

            if(customerSearch == null)
            {
                RedirectToAction("LoggeInLandingPage");
            }

            return View("SearchForCustomer", customerSearch);
        }


        /// <summary>
        /// Search Customer by FirstName and Last Name
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns></returns>
        public async Task<ActionResult> SearchForCustomerFL(CustomerModel customerName)
        {

            List<CustomerModel> customerSearch = await _shopLogic.CustomerSearchFLAsync(customerName);

            if (customerSearch == null)
            {
                RedirectToAction("LoggeInLandingPage");
            }

            return View("SearchForCustomer", customerSearch);
        }


        /// <summary>
        /// This method display a list of all customers
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ShowCustomerList()
        {
            List<CustomerModel> customerList = await _shopLogic.CustomerListAsync();

            return View("ShowCustomerList",customerList);
        }

















        // POST: ShopController/Create
        [HttpPost]//anotations -->This make the action method HTTP Post method only
        [ValidateAntiForgeryToken]//anotation
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


        // GET: ShopController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        // POST: ShopController/Edit/5
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


        // GET: ShopController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShopController/Delete/5
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
