﻿namespace Domain.Entities;

/// <summary>
/// Represents a user entity with personal and authentication details.
/// </summary>
public class User : BaseEntity
{
    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the surname (last name) of the user.
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the user.
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the hashed password of the user.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Gets or sets the cryptographic salt used for password hashing.
    /// </summary>
    public byte[] Salt { get; set; }

    /// <summary>
    /// Gets or sets the URL of the user's profile image.
    /// </summary>
    public string ImgUrl { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the user was created.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the user was last updated.
    /// </summary>
    public DateTimeOffset UpdatedAt { get; set; }
}