using CarStore.Domain.Response;
using CarStore.Domain.ViewModels.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarStore.Service.Interfaces
{
    public interface IBasketService
    {
        Task<IBaseResponse<IEnumerable<OrderViewModel>>> GetItems(string userName);

        Task<IBaseResponse<OrderViewModel>> GetItem(string userName, long id);
    }
}
