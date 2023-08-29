using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identity.Areas.User.Services
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }

        public bool Success { get; set; } = true;
        public bool Null { get; set; } = false;

        public string Message { get; set; } = string.Empty;
    }
}