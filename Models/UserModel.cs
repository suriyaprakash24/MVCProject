using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PaymentClaims.Models
{
    public class UserModel
    {
        [Key]
        public int EmpID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? MobileNo { get; set; }
        public string? Address { get; set; }
        public string? Designation { get; set; }
        public string? Password { get; set; }
        public string? Location { get; set; }
    }
}