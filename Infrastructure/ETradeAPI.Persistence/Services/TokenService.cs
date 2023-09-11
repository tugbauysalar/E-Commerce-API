using ETradeAPI.Application.DTOs;
using ETradeAPI.Application.Services;
using ETradeAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence.Services
{
    public class TokenService : ITokenService
    {
 
        private readonly CustomTokenOption _customTokenOption;

        public TokenService(IOptions<CustomTokenOption> options)
        { 
            _customTokenOption = options.Value;
        }

        // refresh token oluşturuldu
        private string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }

        // token içerisinde bulunan claimler oluşturuldu
        private IEnumerable<Claim> GetClaim(User user)
        {

            var userList = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            return userList;

        }

        // token oluşturuldu 
        public TokenDto CreateToken(User user)
        {
            // access token ve refresh token ın sona erme süreleri hesaplandı. 
            var accessTokenExpiration = DateTime.Now.AddMinutes(_customTokenOption.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.Now.AddMinutes(_customTokenOption.RefreshTokenExpiration);

            // token imzası için güvenlik anahtarı oluşturuldu.
            var securityKey = SignService.GetSymmetricSecurityKey(_customTokenOption.SecurityKey);

            // token imzası için güvenlik anahtarını ve nasıl hashleneceğini tutan signingcredentials nesnesi oluşturuldu.
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            
           
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: _customTokenOption.Issuer,
            audience: _customTokenOption.Audience,
            expires: accessTokenExpiration,
            notBefore:  DateTime.Now,
            claims: GetClaim(user),
            signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);

            var tokenDto = new TokenDto
            {
                AccessToken = token,
                RefreshToken = CreateRefreshToken(),
                AccessTokenExpiration = accessTokenExpiration,
                RefreshTokenExpiration = refreshTokenExpiration
            };

            return tokenDto;

        }
    }
}
