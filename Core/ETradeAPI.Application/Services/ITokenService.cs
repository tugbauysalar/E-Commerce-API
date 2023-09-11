using ETradeAPI.Application.DTOs;
using ETradeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Services
{
    public interface ITokenService
    {
        // token oluşturmak için method tanımlandı
        TokenDto CreateToken(User user);
    }
}
