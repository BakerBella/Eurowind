using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface ICommentService
{
    Task<Comment> CreateCommentAsync(CommentCreationDto commentDto);
    Task<IEnumerable<Comment>> GetCommentsForPostAsync(int postId);
    Task<Comment> GetCommentByIdAsync(int commentId);
    Task<string> GetCommentOwnerUsernameAsync(int commentId);
    Task UpdateCommentAsync(int commentId, UpdateCommentDto dto);
    Task DeleteCommentAsync(int commentId);
}
