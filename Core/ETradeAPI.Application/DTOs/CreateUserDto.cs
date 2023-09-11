using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.DTOs
{
    public class CreateUserDto
    {
        // kullanıcı oluşturmada kullanılacak olan propertyler tanımlandı. 
        public string UserName { get; set;}
        public string Password { get; set;}
        public string ConfirmPassword { get; set;}
        public string Email { get; set;}

    }
}
