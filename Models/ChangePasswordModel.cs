using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;


namespace PaymentClaims.Models;

public class ChangePasswordModel
{
  
public string ? Email {get;set;}
public string? NewPassword { get;set; }
 public string? ConfirmNewPassword { get;set; }


}