using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence.Services
{
    public static class SignService
    {
        //Kimlik doğrulama ve yetkilendirme süreçlerinde kullanmak için simetrik bir güvenlik anahtarı oluşturuldu.
        public static SecurityKey GetSymmetricSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));   
        }
    }

    
}
