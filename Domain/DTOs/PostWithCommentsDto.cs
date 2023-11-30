namespace Domain.DTOs;

public class PostWithCommentsDto : PostBasicDto
{
    public ICollection<CommentBasicDto> Comments { get; set; } = new List<CommentBasicDto>();

    public PostWithCommentsDto(int id, string ownerUsername, string title, string body) : base(id, ownerUsername, title,
        body)
    {
    }
}