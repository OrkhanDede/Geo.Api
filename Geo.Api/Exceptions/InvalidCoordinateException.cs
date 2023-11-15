namespace Geo.Api.Exceptions;

public class InvalidCoordinateException : Exception
{
    public InvalidCoordinateException()
    {
    }

    public InvalidCoordinateException(string message)
        : base(message)
    {
    }

    public InvalidCoordinateException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}