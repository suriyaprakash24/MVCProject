using System.ComponentModel.DataAnnotations;

namespace PaymentClaims.Models;

public class FinanceManagerLoginViewModel
{
    [Required,EmailAddress]
    public string? Email { get;set; }
    [Required]
    public string? Password { get;set; }
    
}