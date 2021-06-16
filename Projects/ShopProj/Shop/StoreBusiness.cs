using ShopDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
   public class StoreBusiness : StoreLocation
    {

        public StoreBusiness(){}


        /// <summary>
        /// Display all the store location and info
        /// </summary>
        public void DisplayStoresInfo()
        {
            using (var context = new ShopContext())
            {
                var store = context.StoreLocations.ToList();

                foreach (var s in store)
                {
                    Console.WriteLine($"\t\tStore Name: {s.StoreName}\n\t\tStore City: {s.StoreCity}\n\t\tStore Sate: {s.StoreState}" +
                        $"\n\t\tLocationID: {s.LocationId}\n\n");
                }
                
            }
        }

    }
}
