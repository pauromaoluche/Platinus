using System.Net;

namespace Platinus.Domain.Exceptions
{
    public class NotFoundException : PlatinusException
    {
        public NotFoundException(string errorMessage) : base(errorMessage)
        {
        }
        public override List<string> GetErrors() => [Message];
        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
    }
}
