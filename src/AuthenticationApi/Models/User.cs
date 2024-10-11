using System.ComponentModel.DataAnnotations;

namespace AuthenticationApi.Models;

public class User
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MinLength(6)]
    public string Password { get; set; }
    public string ImageUrl { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public Role Role { get; set; } = Role.USER;
    public ICollection<Token> Tokens { get; set; } = [];
}