using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface ICommentLogic
{
    Task<Comment> CreateAsync(CommentCreationDto dto);
    Task<IEnumerable<Comment>> GetCommentsForPostAsync(int postId);
    Task<IEnumerable<Comment>> GetCommentsForUserAsync(string username);
    Task<Comment> GetCommentByIdAsync(int commentId);
    Task<string> GetCommentOwnerUsernameAsync(int commentId);
    Task UpdateCommentAsync(int commentId, UpdateCommentDto dto);
    Task DeleteCommentAsync(int commentId);
}