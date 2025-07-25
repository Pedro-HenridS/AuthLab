

using Authlab.Exception;
using AuthLab.Application.Services.Account;
using AuthLab.Communication.Requests.DTO.Users;
using AuthLab.Communication.Requests.Validator;
using AuthLab.Communication.Responses.Create;
using AuthLab.Domain.Repositories;

namespace AuthLab.Application.UseCases
{   
    public class RegisterUserUseCase
    {
        private CreateUserService _createUserService;
        private FindByEmailService _findByEmailService;
        private PasswordHasherService _passwordHasherService;
        private CreateUserValidator _validator;

        public RegisterUserUseCase(
            CreateUserService createUserService, 
            FindByEmailService findByEmailService, 
            PasswordHasherService passwordHasherService, 
            CreateUserValidator createUserValidator)
        {
            _createUserService = createUserService;
            _findByEmailService = findByEmailService;
            _passwordHasherService = passwordHasherService;
            _validator = createUserValidator;
        }

        public async Task<ResponseCreateUserDTO> CreateUser(CreateUserDTO request)
        {
            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid) 
            { 
                throw new ErrorOnValidationException(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }

            var findByEmailResult = _findByEmailService.Execute(request.Email);

            if (await findByEmailResult)
            {
                throw new ErrorOnValidationException("Email já cadastrado");
            }

            var user = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                Password = _passwordHasherService.Execute(request.Password)
            };

            await _createUserService.Execute(user);

            return new ResponseCreateUserDTO 
            {
                UserName = user.UserName 
            };
        }
    }
}
