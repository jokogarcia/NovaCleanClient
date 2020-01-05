using System.Net;

namespace NovaCleanClient.Exceptions
{
    public class BackendServiceBusinessException : BackendServiceException
    {
        public BackendServiceBusinessException(HttpStatusCode statusCode, int backendResult, string errorCode, string message)
            : base(statusCode, backendResult, errorCode, message)
        {

        }
    }
}
