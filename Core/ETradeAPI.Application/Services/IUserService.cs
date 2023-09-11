using ETradeAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Services
{
    public interface IUserService
    {
        //kullanıcıyla ilgili methodlar tanımlandı
        Task<CustomResponseDto<UserDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<CustomResponseDto<UserDto>> GetUserByNameAsync(string userName);
        Task<CustomResponseDto<NoContentDto>> DeleteUserAsync(string userName);
    } 
}
