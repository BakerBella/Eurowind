using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models;

public class User
{
    [Key]
    public string Username { get; set; }
    public string Password { get;  set; }
    public string Role { get; set; }
    [JsonIgnore]
    public ICollection<Post> Posts { get; set; }

    public User()
    {
        //empty
    }
    public User(string username, string password)
    {
        Username = username;
        Password = password;
        Role = "User";
    }
}