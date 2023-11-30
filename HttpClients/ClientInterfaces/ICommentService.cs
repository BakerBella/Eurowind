using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface ICommentService
{
    Task<Comment> CreateCommentAsync(CommentCreationDto commentDto);
    Task<IEnumerable<Comment>> GetCommentsForPostAsync(int postId);
}
