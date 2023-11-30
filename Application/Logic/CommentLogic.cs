using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class CommentLogic : ICommentLogic
{
    private readonly ICommentDao commentDao;

    public CommentLogic(ICommentDao commentDao)
    {
        this.commentDao = commentDao;
    }

    public async Task<Comment> CreateAsync(CommentCreationDto dto)
    {
        ValidateComment(dto);

        // Additional logic if needed

        Comment createdComment = await commentDao.CreateCommentAsync(dto);
        return createdComment;
    }

    public async Task<IEnumerable<Comment>> GetCommentsForPostAsync(int postId)
    {
        return await commentDao.GetCommentsForPostAsync(postId);
    }

    private void ValidateComment(CommentCreationDto commentDto)
    {
        if (string.IsNullOrEmpty(commentDto.Body)) throw new Exception("Comment body cannot be empty.");
        // Add more validation if needed
    }
}