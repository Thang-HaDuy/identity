using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identity.Models;
using Microsoft.AspNetCore.Identity;

namespace identity.Areas.User.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}