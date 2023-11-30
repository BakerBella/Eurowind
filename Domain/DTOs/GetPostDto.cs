namespace Domain.DTOs;

public class GetPostDto
{
    public int Id { get; }
    public int? OwnerId { get; set; }
    public string? OwnerUsername { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public ICollection<CommentBasicDto> Comments { get; set; } = new List<CommentBasicDto>();

    public GetPostDto(int id)
    {
        Id = id;
    }
}