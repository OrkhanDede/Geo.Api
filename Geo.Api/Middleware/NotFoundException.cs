using System.Net;

namespace Geo.Api.Middleware
{
    public class NotFoundException:ApplicationException
    {
        public HttpStatusCode StatusCode { get; }
        public NotFoundException(string message,HttpStatusCode statusCode=HttpStatusCode.NotFound) : base(message)
        {
            StatusCode=statusCode;
        }
    }
}
