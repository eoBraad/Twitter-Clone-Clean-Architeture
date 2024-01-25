namespace Domain.Exceptions;

public class UseCaseException : BaseException
{  
    public override string Message { get; }
    public int StatusCode { get; set; }

    public UseCaseException(String message, int statusCode)
    {
        Message = message;
        StatusCode = statusCode;
    }
}
