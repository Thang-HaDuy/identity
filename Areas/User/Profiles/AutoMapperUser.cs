using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using identity.Areas.User.Models;
using identity.Areas.User.Dtos.User;

namespace identity.Areas.User.Profiles
{
    public class AutoMapperUser : Profile
    {
        public AutoMapperUser()
        {
            CreateMap<AppUser, GetUserDto>();
            // CreateMap<AddCharacterDto, Character>();
            // CreateMap<UpdateCharacterDto, Character>();
        }
    }
}