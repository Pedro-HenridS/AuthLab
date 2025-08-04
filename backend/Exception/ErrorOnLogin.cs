

namespace Exception
{
    public class ErrorOnLLogin : AuthLabException
    {
        public List<string> Errors { get; set; } = [];

        public ErrorOnLLogin(string errors)
        {
            Errors = [errors];
        }
        public ErrorOnLLogin(List<string> errors)
        {
            Errors = errors;
        }
    }
}
