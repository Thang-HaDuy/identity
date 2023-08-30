using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using identity.Areas.User.Models;
using identity.Areas.User.Dtos.User;
using X.PagedList;

namespace identity.Areas.User.Profiles
{
    public class AutoMapperUser : Profile
    {
        private readonly IMapper mapper;
        public AutoMapperUser()
        {
            CreateMap<AppUser, GetUserDto>();
            // CreateMap<List<AppUser>, IPagedList<GetUserDto>>();
            // CreateMap(typeof(IPagedList<>), typeof(IPagedList<>));
            // CreateMap<AddCharacterDto, Character>();
            // CreateMap<UpdateCharacterDto, Character>();
        }
    }
}