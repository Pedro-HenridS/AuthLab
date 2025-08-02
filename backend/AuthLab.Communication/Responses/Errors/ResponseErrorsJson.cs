

namespace Communication.Responses.Errors
{
    public class ResponseErrorsJson
    {
        public List<string> Error { get; set; } = [];
        public ResponseErrorsJson(string error)
        {
            Error = [error];
        }
        public ResponseErrorsJson(List<string> error)
        {
            Error = error;
        }
    }
}
