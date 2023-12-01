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

    public async Task<IEnumerable<Comment>> GetCommentsForUserAsync(string username)
    {
        return await context.Comments
            .Where(comment => comment.Username == username)
            .ToListAsync();
    }
    
    public async Task<Comment> GetCommentByIdAsync(int commentId)
    {
        return await context.Comments
            .FirstOrDefaultAsync(comment => comment.Id == commentId);
    }

    public async Task<string> GetCommentOwnerUsernameAsync(int commentId)
    {
        var comment = await context.Comments
            .Where(comment => comment.Id == commentId)
            .Select(comment => comment.Username)
            .FirstOrDefaultAsync();

        return comment;
    }

    public async Task UpdateCommentAsync(int commentId, UpdateCommentDto dto)
    {
        var comment = await context.Comments.FindAsync(commentId);

        if (comment != null)
        {
            comment.Body = dto.Body ?? comment.Body; // Update Body if provided
            // Add other properties to update as needed

            context.Comments.Update(comment); // Explicitly mark as modified
            await context.SaveChangesAsync();
        }
        else
        {
            throw new InvalidOperationException($"Comment with ID {commentId} not found.");
        }
    }

    public async Task DeleteCommentAsync(int commentId)
    {
        var comment = await context.Comments.FindAsync(commentId);

        if (comment != null)
        {
            context.Comments.Remove(comment);
            await context.SaveChangesAsync();
        }
        else
        {
            throw new InvalidOperationException($"Comment with ID {commentId} not found.");
        }
    }
}