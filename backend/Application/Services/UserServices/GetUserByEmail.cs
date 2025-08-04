
using Communication.Responses.DTO.User;
using Domain.Interfaces.Users;


namespace Application.Services.UserServices
{
   
    public class GetUserByEmail
    {
        private IGetUser _getUser;
    
        public GetUserByEmail(IGetUser getUser)
        {
            _getUser = getUser;
        }

        public async Task<UserDtoResponse> Execute(string email)
        {
            var userDb = await _getUser.GetUserByEmail(email);

            return new UserDtoResponse { Id = userDb.Id, Email = email, UserName = userDb.UserName };
        }
    }
}
