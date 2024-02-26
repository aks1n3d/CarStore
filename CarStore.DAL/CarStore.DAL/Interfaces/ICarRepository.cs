using CarStore.Domain.Entity;
using System.Threading.Tasks;

namespace CarStore.DAL.Interfaces
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        Task<Car> GetByName(string name);
    }
}
