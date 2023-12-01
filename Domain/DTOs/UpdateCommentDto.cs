// Domain.DTOs/UpdateCommentDto.cs
namespace Domain.DTOs
{
    public class UpdateCommentDto
    {
        public int Id { get; }
        public string? Body { get; set; }
        public string? Username { get; set; }

        public UpdateCommentDto(int id)
        {
            Id = id;
        }
    }
}