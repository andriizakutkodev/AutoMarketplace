namespace API.Controllers;

using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

[Authorize]
public class PostsController(IPostsService service) : BaseAPIController
{
}
