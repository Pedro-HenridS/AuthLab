

using Domain.Interfaces.Users;
using Domain.Repositories;

namespace Application.Services.Account
{
    public class CreateUserService 
    {
        private IUserRegisterRepository _userRegisterRepository;
    
        public CreateUserService(IUserRegisterRepository userRegisterRepository)
        {
            _userRegisterRepository = userRegisterRepository;
        }

        public async Task Execute(User user)
        {
            await _userRegisterRepository.CreateAsync(user);
        }
    }
}
