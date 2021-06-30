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
    public class StoreLogic : IStoreLogic 
    {

        private readonly ShopDB _context;//This class is a dependecy of StoreLogic
        //create constructors.
        //first register the context in starup.cs

        public StoreLogic(ShopDB context)//system asigne the new(keyword) for me
        {
            this._context = context;//contex dependecy injection
        }

        /// <summary>
        /// Method that past the list of all the stores to the controller
        /// </summary>
        /// <returns></returns>
        public async Task<List<StoreModel>> StoreListAsync()
        {

            List<StoreModel> storeList = null;

            try
            {

                storeList = _context.Stores.ToList();

            }catch(ArgumentNullException ex)
            {

                Console.WriteLine($"Error in the StoreListAsync{ex.InnerException}");
            }

            return storeList;
        }


        /// <summary>
        /// Method to get a specific store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public async Task<StoreModel> GetStoreInfoAsync(StoreModel store)
        {

             StoreModel storeFound = null;

             storeFound =  _context.Stores.Where(x => x.LocationId == store.LocationId).First();

            return storeFound;
        }
    }
}
