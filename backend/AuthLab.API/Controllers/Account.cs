using Application.UseCases;
using Communication.Requests.DTO.Users;
using Communication.Responses.Create;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Account : ControllerBase
    {
        private readonly RegisterUserUseCase _registerUserUseCase;

        public Account(RegisterUserUseCase registerUserUseCase)
        {
            _registerUserUseCase = registerUserUseCase;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> AccountRegister([FromBody] CreateUserDTO request)
        {
            try
            {
                var result = await _registerUserUseCase.CreateUser(request);

                return Created(string.Empty, result); 
            }
            catch 
            {
                return BadRequest("");
            }
        }
    }
}
