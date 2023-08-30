using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identity.Areas.User.Models;
using identity.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using X.PagedList;


namespace identity.Areas.User.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        
        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // public async Task<ServiceResponse<IPagedList<GetUserDto>>> IndexAsync(string CurrentFilter, string SearchString, int? Page)
        // {
        //     var response = new ServiceResponse<IPagedList<GetUserDto>>();
        //     int pageSize = 1;
        //     int pageNumber = (Page ?? 1);
            
        //     if (_context.Users == null)
        //     {
        //         response.Null = true;
        //         return response;
        //     }

        //     if (SearchString != null)
        //     {
        //         Page = 1;
        //     } 
        //     else
        //     {
        //         SearchString = CurrentFilter;

        //     }

        //     if (!String.IsNullOrEmpty(SearchString))
        //     {
        //         // var user = await _context.Users.Where(u => u.UserName.Contains(SearchString)).OrderByDescending(u => u.UserName).ToPagedListAsync(pageNumber, pageSize);
        //         // response.Data = user.Select(u => _mapper.Map<IPagedList<GetUserDto>>(u)).ToList();
        //         var user = await _context.Users.Where(u => u.UserName.Contains(SearchString)).OrderByDescending(u => u.UserName).ToListAsync();
        //         var data = user.Select(u => _mapper.Map<GetUserDto>(u)).ToList();
        //         var model = new StaticPagedList<GetUserDto>(data, 1, 1, user.Count());
        //         response.Data = model;
        //     }
        //     else
        //     {
        //         // var user = await _context.Users.OrderByDescending(u => u.UserName).OrderByDescending(u => u.UserName).ToPagedListAsync(pageNumber, pageSize);
        //         // response.Data = user.Select(u => _mapper.Map<IPagedList<GetUserDto>>(u)).ToList();
        //         var user = await _context.Users.OrderByDescending(u => u.UserName).ToListAsync();
        //         var data = user.Select(u => _mapper.Map<GetUserDto>(u)).ToList();
        //         var model = new StaticPagedList<GetUserDto>(data, 1, 1, user.Count());
        //         response.Data = model;
        //     }

        //     return response;

        // }

        public async Task<ServiceResponse<AppUser>> DetailAsync(string id)
        {
            var response = new ServiceResponse<AppUser>();
            if (id == null || _context.Users == null)
            {
                response.Success = false;
            }
            var appUser = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (appUser == null)
            {
                response.Success = false;
            }
            else
            {
                response.Data =  appUser;
            }
            return response;
        }
    }
}