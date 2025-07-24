using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthLab.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Account : ControllerBase
    {

        [HttpPost]
        [Route("/register")]
        public IActionResult accountRegister()
        {

        }
    }
}
