using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostLogic postLogic;
    private readonly ICommentLogic commentLogic;

    public PostsController(IPostLogic postLogic, ICommentLogic commentLogic)
    {
        this.postLogic = postLogic;
        this.commentLogic = commentLogic;
    }
    
    [HttpGet("{id:int}/comments")]
    public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsForPostAsync([FromRoute] int id)
    {
        try
        {
            var comments = await commentLogic.GetCommentsForPostAsync(id);
            return Ok(comments);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync([FromBody]PostCreationDto dto)
    {
        try
        {
            Post created = await postLogic.CreateAsync(dto);
            return Created($"/posts/{created.Id}", created);
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetAsync([FromQuery] string? userName, [FromQuery] string? titleContains)
    {
        try
        {
            SearchPostParametersDto parameters = new(userName, titleContains);
            var todos = await postLogic.GetAsync(parameters);
            return Ok(todos);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPatch]
    public async Task<ActionResult> UpdateAsync([FromBody] PostUpdateDto dto)
    {
        try
        {
            await postLogic.UpdateAsync(dto);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int id)
    {
        try
        {
            await postLogic.DeleteAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<PostBasicDto>> GetById([FromRoute] int id)
    {
        try
        {
            PostBasicDto result = await postLogic.GetByIdAsync(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}