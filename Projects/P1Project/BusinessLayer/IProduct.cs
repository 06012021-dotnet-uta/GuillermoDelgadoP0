using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLibary;

namespace BusinessLayer
{
    public interface IProduct
    {

        Task<List<ProductModel>> ProductAtStore(StoreModel store);
        Task<ProductModel> GetProductInfoAsync(ProductModel product);
    }
}
