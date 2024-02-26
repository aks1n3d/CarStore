using CarStore.DAL.Interfaces;
using CarStore.DAL.Repositories;
using CarStore.Domain.Entity;
using CarStore.Service.Implementations;
using CarStore.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CarStore
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Car>, CarRepository>();
            services.AddScoped<IBaseRepository<User>, UserRepository>();
            services.AddScoped<IBaseRepository<Profile>, ProfileRepository>();
            services.AddScoped<IBaseRepository<Basket>, BasketRepository>();
            services.AddScoped<IBaseRepository<Order>, OrderRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
