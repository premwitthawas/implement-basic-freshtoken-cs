using System.ComponentModel.DataAnnotations;

namespace AuthenticationApi.Models;

public class Token
{
    public Guid TokenId { get; set; }
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public string AccessToken { get; set; }
    [Required]
    public string RefreshToken { get; set; }
    public DateTime AcessExpiredTime { get; set; }
    public DateTime RefreshExpiredTime { get; set; }
    public bool IsRevoked { get; set; }    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public User User { get; set; }
    public Token()
    {
        this.AcessExpiredTime = DateTime.UtcNow.AddMinutes(3);
        this.RefreshExpiredTime = DateTime.UtcNow.AddDays(1);
    }
    public bool IsAcessTokenExpired()
    {
        return this.AcessExpiredTime <= DateTime.UtcNow;
    }
    public bool IsRefreshTokenExpired()
    {
        return this.RefreshExpiredTime <= DateTime.UtcNow;
    }
};