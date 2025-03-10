﻿using Core.Security.Entities;

namespace MovieProject.Model.Dtos.Users;

public sealed class UserResponseDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? UserName { get; set; } = string.Empty;
    public bool Status { get; set; }
    public string? ImageUrl { get; set; } = string.Empty;
    public List<string> Roles { get; set; } = new List<string>();
    public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
    public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
}
