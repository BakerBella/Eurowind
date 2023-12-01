namespace Domain.DTOs;

public class CommentBasicDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Body { get; set; }

    public CommentBasicDto(int id, string username, string body)
    {
        Id = id;
        Username = username;
        Body = body;
    }
}