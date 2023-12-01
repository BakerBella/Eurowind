using Domain.DTOs;
using Domain.Models;

namespace Application.DaoInterfaces;

public interface ICommentDao
{
    Task<Comment> CreateCommentAsync(CommentCreationDto commentDto);
    Task<IEnumerable<Comment>> GetCommentsForPostAsync(int postId);
    Task<IEnumerable<Comment>> GetCommentsForUserAsync(string username);
    Task<Comment> GetCommentByIdAsync(int commentId);
    Task<string> GetCommentOwnerUsernameAsync(int commentId);
    Task UpdateCommentAsync(int commentId, UpdateCommentDto dto);
    Task DeleteCommentAsync(int commentId);
}