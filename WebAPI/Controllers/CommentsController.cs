using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ICommentLogic commentLogic;

    public CommentsController(ICommentLogic commentLogic)
    {
        this.commentLogic = commentLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Comment>> CreateAsync([FromBody] CommentCreationDto dto)
    {
        try
        {
            Comment created = await commentLogic.CreateAsync(dto);
            return Created($"/comments/{created.Id}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("posts/{postId:int}")]
    public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsForPostAsync([FromRoute] int postId)
    {
        try
        {
            var comments = await commentLogic.GetCommentsForPostAsync(postId);
            return Ok(comments);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("users/{username}")]
    public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsForUserAsync([FromRoute] string username)
    {
        try
        {
            var comments = await commentLogic.GetCommentsForUserAsync(username);
            return Ok(comments);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("comments/{commentId:int}")]
    public async Task<ActionResult<Comment>> GetCommentByIdAsync([FromRoute] int commentId)
    {
        try
        {
            var comment = await commentLogic.GetCommentByIdAsync(commentId);
            return Ok(comment);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{commentId:int}/owner")]
    public async Task<ActionResult<string>> GetCommentOwnerUsernameAsync([FromRoute] int commentId)
    {
        try
        {
            var ownerUsername = await commentLogic.GetCommentOwnerUsernameAsync(commentId);
            return Ok(ownerUsername);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPatch("comments/{commentId:int}")]
    public async Task<IActionResult> UpdateCommentAsync([FromRoute] int commentId, [FromBody] UpdateCommentDto dto)
    {
        try
        {
            await commentLogic.UpdateCommentAsync(commentId, dto);
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete("comments/{commentId:int}")]
    public async Task<IActionResult> DeleteCommentAsync([FromRoute] int commentId)
    {
        try
        {
            await commentLogic.DeleteCommentAsync(commentId);
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}