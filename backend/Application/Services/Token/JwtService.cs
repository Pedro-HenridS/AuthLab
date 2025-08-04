using Domain.Repositories;
using Microsoft.Extensions.Options;
using Application.Interfaces.Token;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Communication.Responses.DTO.Token;
using System.Security.Claims;


namespace Application.Services.Token
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;   
        public JwtService(IOptions<JwtSettings> jwtSettings) {
            _jwtSettings = jwtSettings.Value;
        }

        public string Execute(JwtClaimsDto claimsDto)
        {

            var securityKey = SymmetricSecurityKey();
            var credentials = Credentials(securityKey);
            var claims = Claims(claimsDto);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials
                );

            var jwtString = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtString;
        } 

        private SymmetricSecurityKey SymmetricSecurityKey()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            return securityKey;
        }
        private SigningCredentials Credentials(SymmetricSecurityKey securityKey)
        {   
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            return credentials;
        }
        private List<Claim> Claims(JwtClaimsDto claimsDto)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, claimsDto.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

            return claims;
        }
    }
}
