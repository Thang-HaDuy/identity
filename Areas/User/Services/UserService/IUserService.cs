using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identity.Areas.User.Models;

namespace identity.Areas.User.Services.UserService
{
    public interface IUserService
    {
        // Task<ServiceResponse<IPagedList<GetUserDto>>> IndexAsync(string CurrentFilter, string SearchString, int? Page);
        Task<ServiceResponse<AppUser>> IndexAsync(string CurrentFilter, string SearchString, int? Page);
        Task<ServiceResponse<AppUser>> DetailAsync(string id);
    }
}