using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PaymentClaims.Models{
   public class ReimbursmentModel
   {
      public string? Type { get; set; }
      public string? Reason { get; set; }
      public string? Date { get; set; }
   }
}