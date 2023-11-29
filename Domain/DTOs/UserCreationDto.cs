namespace Domain.DTOs;

public class UserCreationDto
{
    public string UserName { get;}
    public string Password { get; }
    public string Role { get; }

    public UserCreationDto(string userName, string password, string role = "User")
    {
        UserName = userName;
        Password = password;
        Role = role;
    }
}