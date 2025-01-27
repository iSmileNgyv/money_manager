using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MoneyManager.Domain.Entities.Identity;

public class User: IdentityUser<Guid>
{
    [MaxLength(50)]
    public required string Name { get; set; }
    [MaxLength(50)]
    public required string Surname { get; set; }
    [MaxLength(255)]
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenEndDate { get; set; }
}