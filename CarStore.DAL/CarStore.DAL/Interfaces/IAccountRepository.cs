using CarStore.Domain.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarStore.DAL.Interfaces
{
    public interface IAccountRepository
    {
        Task<ClaimsIdentity> Register(RegisterViewModel model);
        Task<ClaimsIdentity> Login(LoginViewModel model);
    }
}
