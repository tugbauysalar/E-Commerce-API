using ETradeAPI.Application.DTOs;
using ETradeAPI.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtradeAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AuthController : CustomBaseController 
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        // post isteğiyle access token oluşturuldu
        [HttpPost]
        public async Task<IActionResult> CreateToken(LoginDto loginDto)
        {
            var result = await _authenticationService.CreateTokenAsync(loginDto);
            return CreateIActionResult(result);
        }

        // post isteğiyle refresh token oluşturuldu
        [HttpPost]
        public async Task<IActionResult> CreateRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var result = await _authenticationService.CreateRefreshTokenAsync(refreshTokenDto.Token);
            return CreateIActionResult(result);
        }

        // refresh token kaldırıldı
        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var result = await _authenticationService.RevokeRefreshToken(refreshTokenDto.Token);
            return CreateIActionResult(result);
        }
    }
}
