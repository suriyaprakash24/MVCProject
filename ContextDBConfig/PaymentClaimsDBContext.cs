using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PaymentClaims.Models;

namespace PaymentClaims.ContextDBConfig
{
public class PaymentClaimsDBContext: DbContext{        
       public PaymentClaimsDBContext(DbContextOptions options) : base(options)
        {
        }  
        public DbSet<UserModel>? UserModel{ get; set; }
    } 
}



