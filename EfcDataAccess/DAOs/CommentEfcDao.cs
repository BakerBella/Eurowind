using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class CommentEfcDao : ICommentDao
{
    private readonly PostContext context;

    public CommentEfcDao(PostContext context)
    {
        this.context = context;
    }

    public async Task<Comment> CreateCommentAsync(CommentCreationDto commentDto)
    {
        var comment = new Comment
        {
            Body = commentDto.Body,
            PostId = commentDto.PostId,
            Username = commentDto.Username
        };

        EntityEntry<Comment> added = await context.Comments.AddAsync(comment);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<IEnumerable<Comment>> GetCommentsForPostAsync(int postId)
    {
        return await context.Comments
            .Where(comment => comment.PostId == postId)
            .ToListAsync();
    }
}