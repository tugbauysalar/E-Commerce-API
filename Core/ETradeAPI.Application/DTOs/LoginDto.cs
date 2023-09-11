using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.DTOs
{
    public class LoginDto
    {
        // giriş yapan kullanıcı için propertyler tanımlandı.
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
