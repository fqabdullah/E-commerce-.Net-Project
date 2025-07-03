using System.ComponentModel.DataAnnotations;

namespace BlazorBay.Models;
public class User
{
    public int UserId { get; set; }

    [Required]
    public string Username { get; set; } = "";

    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    public string PasswordHash { get; set; } = "";

    [Required]
    public string Role { get; set; } = "";
}

