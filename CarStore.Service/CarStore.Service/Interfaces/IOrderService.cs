using CarStore.Domain.Entity;
using CarStore.Domain.Response;
using CarStore.Domain.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Service.Interfaces
{
    public interface IOrderService
    {
        Task<IBaseResponse<Order>> Create(CreateOrderViewModel model);

        Task<IBaseResponse<bool>> Delete(long id);
    }
}
