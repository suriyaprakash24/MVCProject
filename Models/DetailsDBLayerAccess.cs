using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using PaymentClaims.Models;

namespace PaymentClaims.Models
{
    public class DetailsDBLayerAccess
    {
        SqlConnection connection = new SqlConnection("Server=DESKTOP-Q460DNA\\SQLEXPRESS; database=PaymentClaim;integrated security=true; Trusted_Connection=True;");
        public string AddDetails(ReimbursmentModel model){
            try{
                SqlCommand command = new SqlCommand("Add_Detail",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type",model.Type);
                command.Parameters.AddWithValue("@Reason",model.Reason);
                command.Parameters.AddWithValue("@DateonBill",model.Date);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return ("Request sent successfully");
            }
            catch(Exception ex){
                if(connection.State==ConnectionState.Open){
                    connection.Close();
                }
                return (ex.Message.ToString());
            }
        }
    }
}