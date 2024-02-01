namespace communication.Requests.User;

public record class LoginUserRequest
{
    public string Credentials { get; set; }

    public string Password { get; set; }
}
