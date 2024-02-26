using CarStore.Domain.Entity;
using CarStore.Domain.Response;
using CarStore.Domain.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Service.Interfaces
{
    public interface IProfileService
    {
        Task<BaseResponse<ProfileViewModel>> GetProfile(string userName);

        Task<BaseResponse<Profile>> Save(ProfileViewModel model);
    }
}
