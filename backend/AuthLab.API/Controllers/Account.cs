using AuthLab.Application.UseCases;
using AuthLab.Communication.Requests.DTO.Users;
using AuthLab.Communication.Responses.Create;
using Microsoft.AspNetCore.Mvc;

namespace AuthLab.API.Controllers
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

                return Created(string.Empty, result); // Ou use Ok(result) se preferir
            }
            catch 
            {
                // Logar o erro seria melhor para debug
                return BadRequest("");
            }
        }
    }
}
