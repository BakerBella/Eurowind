using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class CommentLogic : ICommentLogic
{
    private readonly ICommentDao commentDao;
    private readonly IUserDao userDao;

    public CommentLogic(ICommentDao commentDao, IUserDao userDao)
    {
        this.commentDao = commentDao;
        this.userDao = userDao;
    }

    public async Task<Comment> CreateAsync(CommentCreationDto dto)
    {
        ValidateComment(dto);

        User? user = await userDao.GetByUsernameAsync(dto.Username);
        if (user == null)
        {
            throw new Exception($"User {dto.Username} was not found.");
        }

        Comment createdComment = await commentDao.CreateCommentAsync(dto);
        return createdComment;
    }

    public async Task<IEnumerable<Comment>> GetCommentsForPostAsync(int postId)
    {
        try
        {
            var comments = await commentDao.GetCommentsForPostAsync(postId);
            return comments;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<Comment>> GetCommentsForUserAsync(string username)
    {
        try
        {
            var comments = await commentDao.GetCommentsForUserAsync(username);
            return comments;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Comment> GetCommentByIdAsync(int commentId)
    {
        try
        {
            var comment = await commentDao.GetCommentByIdAsync(commentId);
            return comment;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<string> GetCommentOwnerUsernameAsync(int commentId)
    {
        try
        {
            var ownerUsername = await commentDao.GetCommentOwnerUsernameAsync(commentId);
            return ownerUsername;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task UpdateCommentAsync(int commentId, UpdateCommentDto dto)
    {
        ValidateCommentUpdate(dto);

        Comment existingComment = await commentDao.GetCommentByIdAsync(commentId);
        if (existingComment == null)
        {
            throw new Exception($"Comment with ID {commentId} not found!");
        }

        await commentDao.UpdateCommentAsync(commentId, dto);
    }

    public async Task DeleteCommentAsync(int commentId)
    {
        Comment existingComment = await commentDao.GetCommentByIdAsync(commentId);
        if (existingComment == null)
        {
            throw new Exception($"Comment with ID {commentId} not found!");
        }

        await commentDao.DeleteCommentAsync(commentId);
    }

    // ... (existing methods)

    private void ValidateComment(CommentCreationDto commentDto)
    {
        if (string.IsNullOrEmpty(commentDto.Body)) throw new Exception("Comment body cannot be empty.");
        // Add more validation if needed
    }

    private void ValidateCommentUpdate(UpdateCommentDto dto)
    {
        // Add validation logic if needed
    }
}