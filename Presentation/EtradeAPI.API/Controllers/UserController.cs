using ETradeAPI.Application.DTOs;
using ETradeAPI.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtradeAPI.API.Controllers
{
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;

        //userservice içerisinde yazdığımız methodlar kullanılarak istekler yapıldı. 
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            return CreateIActionResult(await _userService.CreateUserAsync(createUserDto));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return CreateIActionResult(await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string userName)
        {
            return CreateIActionResult(await _userService.DeleteUserAsync(userName));
        }
     
    }
}
