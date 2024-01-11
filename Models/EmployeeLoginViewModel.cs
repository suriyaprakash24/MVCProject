using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;


namespace PaymentClaims.Models;

public class EmployeeLoginViewModel
{

    [Required,EmailAddress]
    public string? Email { get;set; }
    
    [Required]
    public string? Password { get;set; }
    
    public string? Emp_ID { get;set; }
    public string? Emp_Name { get;set; }
    public string? Emp_PH { get;set;}
    public string? Emp_Location { get;set; }
    public string? Project_Name { get;set; }
    public string? Manager_Name { get;set; }
    public string? Manager_Email { get;set; }

}