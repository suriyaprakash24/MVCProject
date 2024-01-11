using System.ComponentModel.DataAnnotations;

namespace PaymentClaims.Models;

public class ProjectManagerLoginViewModel
{
    [Required,EmailAddress]
    public string? Email { get;set; }
    [Required]
    public string? Password { get;set; }
    
}