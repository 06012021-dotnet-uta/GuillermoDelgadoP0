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
    public class StoreController : Controller
    {


        private readonly IStoreLogic _storeLogic;
        

        //create a constructor into which i will inject the shoplogic Class from business layer.
        public StoreController(IStoreLogic shopLogic)
        {
            this._storeLogic = shopLogic;     
        }


        /// <summary>
        /// Display the all the store in the Db
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ShowStoreList()
        {
            List<StoreModel> storeList = await _storeLogic.StoreListAsync();

            return View("ShowStoreList", storeList);
        }



        /// <summary>
        /// Method to display Store Info
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public async Task<ActionResult> StoreInfo(StoreModel store)

        {
            var storeInfo = await _storeLogic.GetStoreInfoAsync(store);

            return View("StoreInfo", storeInfo);

        }





        // GET: StoreController
        public ActionResult Index()
        {
            return View();
        }

        // GET: StoreController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StoreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreController/Create
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

        // GET: StoreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StoreController/Edit/5
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

        // GET: StoreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoreController/Delete/5
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
