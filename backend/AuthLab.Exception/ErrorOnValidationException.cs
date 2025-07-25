
using AuthLab.Exception;

namespace Authlab.Exception
{
    public class ErrorOnValidationException : AuthLabException
    {
        public List<string> Errors { get; set; } = [];

        public ErrorOnValidationException(string errors)
        {
            Errors = [errors];
        }
        public ErrorOnValidationException(List<string> errors)
        {
            Errors = errors;
        }
    }
}
