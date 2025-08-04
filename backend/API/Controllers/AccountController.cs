using Application.UseCases;
using Communication.Requests.DTO.Users;
using Communication.Responses.Create;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly RegisterUserUseCase _registerUserUseCase;
        private readonly LoginUserUseCase _loginUserUseCase;

        public AccountController(
            RegisterUserUseCase registerUserUseCase,
            LoginUserUseCase loginUserUseCase)
        {
            _registerUserUseCase = registerUserUseCase;
            _loginUserUseCase = loginUserUseCase;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> AccountRegister([FromBody] CreateUserDTO request)
        {
            var result = await _registerUserUseCase.CreateUser(request);

            return Created(string.Empty, result); 
        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> UserLogin([FromBody] UserLoginDTO request)
        {
            var result = await _loginUserUseCase.LoginUser(request);

            return Created(string.Empty, result);
        }
    }
}
