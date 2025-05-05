using System.Net;

namespace Platinus.Domain.Exceptions
{
    public class ErrorOnValidationException : PlatinusException
    {
        private readonly List<string> _errors;
        public ErrorOnValidationException(List<string> errorMessage) : base(string.Empty)
        {
            _errors = errorMessage;
        }

        public override List<string> GetErrors() => _errors;

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;
    }
}
