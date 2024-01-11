using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using PaymentClaims.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace PaymentClaims.Controllers;

public class AccountController : Controller
{
    
    DetailsDBLayerAccess dBLayerAccess = new DetailsDBLayerAccess();
    List<FinanceManagerViewModel> financeManagerViewModels = new List<FinanceManagerViewModel>();
    SqlConnection con = new SqlConnection();
    SqlCommand com = new SqlCommand();
    SqlDataReader? dr;
    void connectionString()
    {
        con.ConnectionString = "Server=DESKTOP-Q460DNA\\SQLEXPRESS; database=PaymentClaim; Trusted_Connection=True;";
    }
    private void FetchData(){
        try{
            connectionString();
            con.Open();
            com.Connection=con;
            com.CommandText="SELECT * FROM AspNet_AppliedDetails";
            dr=com.ExecuteReader();
            while(dr.Read()){
                var Detail = new FinanceManagerViewModel();
                Detail.Emp_ID=dr["Emp_ID"].ToString();
                Detail.Emp_Email=dr["Emp_Email"].ToString();
                Detail.Type=dr["Type"].ToString();
                Detail.Reason=dr["Reason"].ToString();
                Detail.Date=dr["Date"].ToString();
                Detail.Applyed_date=dr["Applyed_Date"].ToString();
                financeManagerViewModels.Add(Detail);
            }
            con.Close();
        }
        catch(Exception ex){
            throw ex;
        }
    }
    


    [HttpGet]
    public IActionResult EmployeeLogin()
    {
        return View();
    }

    [HttpPost]
    public ActionResult EmpVerify(EmployeeLoginViewModel emp)
    {
        connectionString();
        con.Open();
        com.Connection = con;
        com.CommandText = "select * from AspNet_Emplogin where Email='" + emp.Email + "' and password ='" + emp.Password + "'";
        dr = com.ExecuteReader();

        if (dr.Read())
        {
            dr.Close();
            con.Close();

            connectionString();
            con.Open();
            com.Connection = con;
            string sql = "select * from dbo.AspNet_EmpDetails where Emp_Email='" + emp.Email + "'";
            SqlCommand cmd = new SqlCommand(sql, con);


            var Details = new List<EmployeeLoginViewModel>();
            {

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var Detail = new EmployeeLoginViewModel();
                    Detail.Emp_ID = dr["Emp_ID"].ToString();
                    Detail.Emp_Name = dr["Emp_Name"].ToString();
                    Detail.Email = dr["Emp_Email"].ToString();
                    Detail.Emp_PH = dr["Emp_PH"].ToString();
                    Detail.Emp_Location = dr["Emp_Location"].ToString();
                    Detail.Project_Name = dr["Project_Name"].ToString();
                    Detail.Manager_Name = dr["Manager_Name"].ToString();
                    Detail.Manager_Email = dr["Manager_Email"].ToString();
                    Details.Add(Detail);
                }
            }


            con.Close();
            return View("EmployeePage", Details);
        }

        else
        {
            con.Close();
            ViewBag.Message = "Invaild Login - Please Verify the Email Address and Password";
            return View("EmployeeLogin");
        }
    }


    [HttpGet]
    public IActionResult ProjectManagerLogin()
    {
        return View();
    }


    [HttpPost]
    public ActionResult ProjectManagerLogin(ProjectManagerLoginViewModel project_manager)
    {
        connectionString();
        con.Open();
        com.Connection = con;
        com.CommandText = "select * from AspNet_ProjectManagerlogin where Email='" + project_manager.Email + "' and password ='" + project_manager.Password + "'";
        dr = com.ExecuteReader();
        if (dr.Read())
        {
            dr.Close();
            con.Close();

            connectionString();
            con.Open();
            com.Connection = con;
            string sql = "SELECT * FROM AspNet_AppliedDetails";
            SqlCommand cmd = new SqlCommand(sql, con);


            var Details = new List<ProjectManagerViewModel>();
            {

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var Detail = new ProjectManagerViewModel();
                    Detail.Emp_ID = dr["Emp_ID"].ToString();
                    Detail.Emp_Email= dr["Emp_Email"].ToString();
                    Detail.Type = dr["Type"].ToString();
                    Detail.Reason = dr["Reason"].ToString();
                    Detail.Date= dr["Date"].ToString();
                    Detail.Applyed_date = dr["Applyed_Date"].ToString();
                    Details.Add(Detail);
                }
            }
            con.Close();
            return View("ProjectManagerPage", Details);
        }
        else
        {
            con.Close();
            ViewBag.Message = "Invaild Login - Please Verify the Email Address and Password";
            return View("ProjectManagerLogin");
        }

    }

    [HttpGet]
    public IActionResult FinanceManagerLogin()
    {
        return View();
    }

    [HttpPost]
    public ActionResult FinanceManagerLogin(FinanceManagerLoginViewModel financemanager)
    {
        connectionString();
        con.Open();
        com.Connection = con;
        com.CommandText = "select * from AspNet_FinanceManagerlogin where Email='" + financemanager.Email + "' and password ='" + financemanager.Password + "'";
        dr = com.ExecuteReader();
        if (dr.Read())
        {
            con.Close();
            return View("FinanceManagerPage");
        }
        else
        {
            con.Close();
            ViewBag.Message = "Invaild Login - Please Verify the Email Address and Password";
            return View("FinanceManagerLogin");
        }

    }


    public IActionResult ChangeNewPassword()
    {

        return View();
    }

    [HttpPost]
    public ActionResult ChangepasswordVerify(ChangePasswordModel newpass)
    {

        if (newpass.NewPassword == newpass.ConfirmNewPassword)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            string sql = "UPDATE AspNet_Emplogin SET Password='" + newpass.ConfirmNewPassword + "' where Email='" + newpass.Email + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
        }

        con.Close();
        return View("EmployeeLogin");

    }
    
    [HttpGet]
    public IActionResult ReimbursementPage()
    {
        return View();
    }
    [HttpPost]
    public IActionResult ReimbursementPage([Bind] ReimbursmentModel model)
    {
        try{
            if(ModelState.IsValid){
                string resp = dBLayerAccess.AddDetails(model);
                TempData["msg"]=resp;
            }
        }
        catch(Exception ex){
            TempData["msg"]=ex.Message;
        }
        return View("ReimbursementPage");
    }
    public IActionResult ProjectManagerPage(){
        return View();
    }
    public IActionResult FinanceManagerPage(){
        FetchData();
        return View(financeManagerViewModels);
    }
}