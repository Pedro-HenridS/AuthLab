using Communication.Responses.DTO.Token;

namespace Application.Interfaces.Token
{
    public interface IJwtService
    {
        string Execute(JwtClaimsDto claimsDto);
    }
}
