using System.Net;

namespace Platinus.Domain.Exceptions
{
    public abstract class PlatinusException : SystemException
    {
        public PlatinusException(string errorMessage) : base(errorMessage)
        { }

        public abstract List<string> GetErrors();
        public abstract HttpStatusCode GetHttpStatusCode();
    }
}
