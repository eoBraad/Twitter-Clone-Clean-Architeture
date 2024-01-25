namespace Communication.Responses;

public class CreateUserResponse
{
    public string Token { get; set; }
    public string Message { get; set; }

    public CreateUserResponse(string token, string message)
    {
        Token = token;
        Message = message;
    }
}
