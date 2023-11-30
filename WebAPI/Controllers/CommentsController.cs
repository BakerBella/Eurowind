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

        [HttpGet("{postId:int}")]
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
        }