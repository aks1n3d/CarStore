using CarStore.Domain.Entity;
using CarStore.Domain.Response;
using CarStore.Domain.ViewModels.Car;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarStore.Service.Interfaces
{
    public interface ICarService
    {
        BaseResponse<Dictionary<int, string>> GetTypes();

        IBaseResponse<List<Car>> GetCars();

        Task<IBaseResponse<CarViewModel>> GetCar(long id);

        Task<BaseResponse<Dictionary<long, string>>> GetCar(string term);

        Task<IBaseResponse<Car>> Create(CarViewModel car, byte[] imageData);

        Task<IBaseResponse<bool>> DeleteCar(long id);

        Task<IBaseResponse<Car>> Edit(long id, CarViewModel model);
    }
}
