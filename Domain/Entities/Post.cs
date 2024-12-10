namespace Domain.Entities;

/// <summary>
/// Represents a post entity, typically used to store information about a listing or advertisement.
/// </summary>
public class Post : BaseEntity
{
    /// <summary>
    /// Gets or sets the price associated with the post.
    /// </summary>
    public int Price { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the post is active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the post is marked as hot.
    /// </summary>
    public bool IsHot { get; set; }

    /// <summary>
    /// Gets or sets the status of the post (e.g. pending, published, canceled).
    /// </summary>
    public required string Status { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the post was published.
    /// </summary>
    public DateTimeOffset PublishAt { get; set; }

    /// <summary>
    /// Gets or sets the date and time until the vehicle or listing remains active.
    /// </summary>
    public DateTimeOffset ActiveTo { get; set; }

    /// <summary>
    /// Gets or sets the associated vehicle details for the post.
    /// </summary>
    public virtual required Vehicle Vehicle { get; set; }

    /// <summary>
    /// Gets or sets the owner for the post.
    /// </summary>
    public virtual required User Owner { get; set; }
}
