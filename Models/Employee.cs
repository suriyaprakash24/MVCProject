using System.ComponentModel.DataAnnotations;

namespace PaymentClaims.Models;

public class Employee 
{
   
   public string? Emp_ID { get; set; }
   public string? Emp_Email { get; set; }
   public string? Reimbursement_type { get; set; }
   public string? Reason { get; set; }
   public DateTime? Bill_date { get; set; }
   public DateTime? Applyed_date { get; set; }
   public string? Status { get; set; }
    
}