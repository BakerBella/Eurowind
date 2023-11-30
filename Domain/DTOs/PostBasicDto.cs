using System.Collections.Generic;

namespace Domain.DTOs
{
    public class PostBasicDto
    {
        public int Id { get; }
        public string OwnerUsername { get; }
        public string Title { get; set; }
        public string Body { get; set; }
        public ICollection<CommentBasicDto> Comments { get; set; } = new List<CommentBasicDto>();

        public PostBasicDto(int id, string ownerUsername, string title, string body)
        {
            Id = id;
            OwnerUsername = ownerUsername;
            Title = title;
            Body = body;
        }
    }
}