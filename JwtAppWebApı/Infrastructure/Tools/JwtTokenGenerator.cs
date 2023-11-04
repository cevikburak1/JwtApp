using JwtAppWebApı.Core.Application.Dto;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAppWebApı.Infrastructure.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseDto GenereateToken(CheckUserResponseDto dto)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            SigningCredentials credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>();
            if (!string.IsNullOrEmpty(dto.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, dto.Role));
            }
             claims.Add(new Claim(ClaimTypes.NameIdentifier,dto.Id.ToString()));
            if (!string.IsNullOrEmpty(dto.UserName))
            {
                claims.Add(new Claim("UserName", dto.UserName));

            }
            var expireDate = DateTime.UtcNow.AddMinutes(JwtTokenDefaults.Expire);


            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(JwtTokenDefaults.ValidIssuer, JwtTokenDefaults.ValidAudience, claims:null,notBefore:DateTime.UtcNow,expires: expireDate, signingCredentials: credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return new TokenResponseDto(handler.WriteToken(jwtSecurityToken), expireDate);
        }
    }

}
