﻿using Domain.DTOs;
using Domain.Models;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters);
    Task UpdateAsync(Post post);
    Task DeleteAsync(int id);
    Task<Post?> GetByIdAsync(int id);
    Task<Comment> CreateCommentAsync(CommentCreationDto commentDto);
    Task<IEnumerable<Comment>> GetCommentsForPostAsync(int postId);
}