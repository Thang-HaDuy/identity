using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identity.Areas.User.Dtos.User;
using identity.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


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

        public async Task<ServiceResponse<List<GetUserDto>>> IndexAsync()
        {
            var response = new ServiceResponse<List<GetUserDto>>();
            if (_context.Users != null)
            {
                var user = await _context.Users.ToListAsync();
                response.Data = user.Select(u => _mapper.Map<GetUserDto>(u)).ToList();
            }
            else
            {
                response.Null = true;
            }
            return response;

        }

        public async Task<ServiceResponse<GetUserDto>> DetailAsync(string id)
        {
            var response = new ServiceResponse<GetUserDto>();
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
                response.Data =  _mapper.Map<GetUserDto>(appUser);
            }
            return response;
            // if (id == null || _context.Roles == null)
            // {
            //     return NotFound();
            // }

            // var appRole = await _context.Roles
            //     .FirstOrDefaultAsync(m => m.Id == id);
            // if (appRole == null)
            // {
            //     return NotFound();
            // }

            // return View(appRole);
        }
    }
}