using System.ComponentModel.DataAnnotations;

namespace PaymentClaims.Models;

public class ProjectManagerViewModel 
{
   
   public string? Emp_ID { get; set; }
   public string? Emp_Email { get; set; }
   public string? Type { get; set; }
   public string? Reason { get; set; }
   public string? Date { get; set; }
   public string? Applyed_date { get; set; }
   public string? Status { get; set; }
    
}