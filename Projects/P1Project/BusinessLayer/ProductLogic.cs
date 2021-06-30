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
   public class ProductLogic : IProduct
    {
        private readonly ShopDB _context;//This class is a dependecy of ShopLogic
        //create constructors.
        //first register the context in starup.cs

        public ProductLogic(ShopDB context)//system asigne the new(keyword) for me
        {
            this._context = context;//contex dependecy injection
        }

        /// <summary>
        /// Method for get all the product in a specific store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public async Task<List<ProductModel>> ProductAtStore(StoreModel store)
        {

             List<ProductModel> productList = null;

             productList =   _context.Products.Where(x => x.LocationId == store.LocationId).ToList();

            return productList;
        }


        /// <summary>
        /// Method for get one specific Product information
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<ProductModel> GetProductInfoAsync(ProductModel product)
        {
            ProductModel productInfo = null;

            productInfo = _context.Products.Where(x => x.ProductId == product.ProductId).First();

            return productInfo;
        }

    }
}
