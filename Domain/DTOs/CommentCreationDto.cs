namespace Domain.DTOs;

public class CommentCreationDto
{
    public int PostId { get; set; }
    public string Username { get; set; }
    public string Body { get; set; }
}