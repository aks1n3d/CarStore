using System.Linq;
using System.Threading.Tasks;
using CarStore.DAL.Interfaces;
using CarStore.Domain.Entity;

namespace CarStore.DAL.Repositories
{
    public class CarRepository : IBaseRepository<Car>
    {
        private readonly ApplicationDBContext _db;

        public CarRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task Create(Car entity)
        {
            await _db.Cars.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Car> GetAll()
        {
            return _db.Cars;
        }

        public async Task Delete(Car entity)
        {
            _db.Cars.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Car> Update(Car entity)
        {
            _db.Cars.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}















//public bool Create(Shoes entity)
//{
//    throw new NotImplementedException();
//}

//public bool Delete(Shoes entity)
//{
//    throw new NotImplementedException();
//}

//public async Task<Shoes> Get(int Id)
//{
//    return await _db.Shoes.FirstOrDefaultAsync(x => x.Id == Id);
//}

//public Shoes GetByName(string name)
//{
//    throw new NotImplementedException();
//}

//public async Task<List<Shoes>> GetAllAsync()
//{
//    return await _db.Shoes.ToListAsync();
//}

//Shoes IBaseRepository<Shoes>.Get(int Id)
//{
//    throw new NotImplementedException();
//}

//IEnumerable<Shoes> IBaseRepository<Shoes>.GetAllAsync()
//{
//    throw new NotImplementedException();
//}
