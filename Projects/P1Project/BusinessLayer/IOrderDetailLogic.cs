using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLibary;

namespace BusinessLayer
{
    public interface IOrderDetailLogic
    {
        Task<List<OrderHistoryModel>> GetStoreOrdersAsync(StoreModel store);
        Task<List<OrderDetailModel>> GetOrderDetailAsync(OrderModel order);
    }
}
