using AutoMapper;
using ETradeAPI.Application.DTOs;
using ETradeAPI.Application.Services;
using ETradeAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        // yeni kullanıcı oluşturan method yazıldı
        public async Task<CustomResponseDto<UserDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = new User
            {
                UserName = createUserDto.UserName,
                Email = createUserDto.Email,
            };
            
            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if(!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();
                return CustomResponseDto<UserDto>.Fail(400, errors);
            }
            return CustomResponseDto<UserDto>.Success(200, _mapper.Map<UserDto>(user));
        }

        // parametre olarak alınan kullanıcı adıyla ilişkili kullanıcının silinmesini sağlayan method yazıldı
        public async Task<CustomResponseDto<NoContentDto>> DeleteUserAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return CustomResponseDto<NoContentDto>.Fail(404, "User name not found");
            }
            await _userManager.DeleteAsync(user);
            return CustomResponseDto<NoContentDto>.Success(204);

        }

        // kullanıcı adıyla kullanıcının bilgilerini getiren method yazıldı
        public async Task<CustomResponseDto<UserDto>> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if(user == null)
            {
                return CustomResponseDto<UserDto>.Fail(404, "User name not found");
            }
            return CustomResponseDto<UserDto>.Success(200, _mapper.Map<UserDto>(user));
        }
    }

}
