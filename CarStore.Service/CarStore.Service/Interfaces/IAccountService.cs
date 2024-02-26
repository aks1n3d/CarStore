using CarStore.Domain.Models;
using CarStore.Domain.Response;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarStore.Service.Interfaces
{
    public interface IAccountService
    {
        Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);

        Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);

        Task<BaseResponse<bool>> ChangePassword(ChangePasswordViewModel model);
    }
}
