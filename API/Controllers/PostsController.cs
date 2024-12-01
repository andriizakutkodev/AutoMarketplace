namespace API.Controllers;

using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// API controller for managing posts.
/// Provides endpoints to create, retrieve, update, and delete posts.
/// </summary>
/// <param name="service">An instance of <see cref="IPostsService"/> to handle post-related business logic.</param>
[ApiController]
public class PostsController(IPostsService service) : ControllerBase
{
    [HttpGet("posts")]
    public IActionResult GetAll()
    {
        return Ok();
    }

    [HttpGet("posts/{id}")]
    public IActionResult GetById(Guid id)
    {
        return Ok();
    }

    [HttpPost("posts")]
    public IActionResult Create()
    {
        return Ok();
    }

    [HttpPut("posts")]
    public IActionResult Update()
    {
        return Ok();
    }

    [HttpDelete("posts/{id}")]
    public IActionResult Delete(Guid id)
    {
        return Ok();
    }
}
