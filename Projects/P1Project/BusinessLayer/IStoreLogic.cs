using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLibary;

namespace BusinessLayer
{
   public interface IStoreLogic
    {
        Task<List<StoreModel>> StoreListAsync();
        Task<StoreModel> GetStoreInfoAsync(StoreModel storeId);
    }
}
