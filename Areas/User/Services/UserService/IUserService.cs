using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identity.Areas.User.Dtos.User;

namespace identity.Areas.User.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<GetUserDto>>> IndexAsync();
        Task<ServiceResponse<GetUserDto>> DetailAsync(string id);
    }
}