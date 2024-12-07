﻿namespace Persistence.Repositories;

using Domain.Entities;
using Infrastructure.Data;
using Persistence.Interfaces;

/// <summary>
/// Implements the <see cref="IPostsRepository"/> interface to manage posts in the data store.
/// Provides functionality for creating, retrieving, updating, and deleting posts.
/// </summary>
public class PostsRepository(AppDbContext context) : GenericRepository<Post>(context), IPostsRepository
{
}