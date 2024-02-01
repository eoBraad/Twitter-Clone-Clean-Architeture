namespace communication.Responses;

public record class LoginUserResponse
{
    public string Token { get; init; }
}
