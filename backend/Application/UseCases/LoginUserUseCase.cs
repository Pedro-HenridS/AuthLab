using Application.Interfaces.Token;
using Application.Services.Account;
using Application.Services.Token;
using Application.Services.UserServices;
using Communication.Requests.DTO.Users;
using Communication.Responses.DTO.Token;
using Exception;

namespace Application.UseCases
{
    public class LoginUserUseCase
    {
        private IJwtService _jwtService;
        private FindByEmailService _findByEmailService;
        private VerifyPasswordHashService _verifyPasswordHashService;
        private GetUserByEmail _getUserByEmail;

        public LoginUserUseCase(
            IJwtService jwtService, 
            FindByEmailService findByEmailService, 
            VerifyPasswordHashService verifyPasswordHashService,
            GetUserByEmail getUserByEmail
            )
        {
            _jwtService = jwtService;
            _findByEmailService = findByEmailService;
            _verifyPasswordHashService = verifyPasswordHashService;
            _getUserByEmail = getUserByEmail;
        }

        public async Task<string> LoginUser(UserLoginDTO request)
        {
            var findEmailResult = await _findByEmailService.Execute(request.Email);

            if (!findEmailResult) {
                throw new ErrorOnLLogin("Conta não encontrada");
            }

            var verifyResult = await _verifyPasswordHashService.Execute(request.Password, request.Email);

            if (verifyResult)
            {
                var user = await _getUserByEmail.Execute(request.Email);

                var claims = new JwtClaimsDto
                {
                    UserId = user.Id
                };

                return _jwtService.Execute(claims);
            }

            throw new ErrorOnLLogin("Senha incorreta");
        }
    }
}
