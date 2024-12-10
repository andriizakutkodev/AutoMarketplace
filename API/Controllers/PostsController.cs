namespace API.Controllers;

using Microsoft.AspNetCore.Authorization;

/// <summary>
/// Represents actions related to work with posts.
/// </summary>
[Authorize]
public class PostsController() : BaseAPIController
{
}
