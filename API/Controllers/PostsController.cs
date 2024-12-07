namespace API.Controllers;

using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// API controller for managing posts.
/// Provides endpoints to create, retrieve, update, and delete posts.
/// </summary>
/// <param name="service">An instance of <see cref="IPostsService"/> to handle post-related business logic.</param>
[ApiController]
[Authorize]
public class PostsController(IPostsService service) : ControllerBase
{
}
