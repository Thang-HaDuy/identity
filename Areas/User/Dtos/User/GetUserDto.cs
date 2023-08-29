using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace identity.Areas.User.Dtos.User
{
    public class GetUserDto
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime CreateAt { get; set; } 
    }
}