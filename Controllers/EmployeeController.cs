using PaymentClaims.ContextDBConfig;
using Microsoft.AspNetCore.Mvc;
using PaymentClaims.Models;

namespace PaymentClaims.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly PaymentClaimsDBContext _context;

        public EmployeeController(PaymentClaimsDBContext context)
        {
            this._context = context;
        }

// [HttpGet]
    //     public IActionResult ProjectManagerPage()
    //     {
    //         var employees = _context.Employees.ToList();
    //         List<ProjectManagerViewModel> employeeList = new List<ProjectManagerViewModel>();

    //         if(employees !=null)
    //         {
                
    //             foreach (var employee in employees)
    //             {
    //                 var ProjectManagerViewModel = new ProjectManagerViewModel()
    //                 {
    //                     Emp_ID=employee.Emp_ID,
    //                     Emp_Email=employee.Emp_Email,
    //                     Reimbursement_type=employee.Reimbursement_type,
    //                     Reason=employee.Reason,
    //                     Bill_date=employee.Bill_date,
    //                     Applyed_date=employee.Applyed_date,
    //                     Status=employee.Status
    //                 };
    //                 employeeList.Add(ProjectManagerViewModel);
    //             }
    //             return View(employeeList);
    //         }

    //         return View(employeeList);
    //     }



    //     [HttpGet]
    //     public IActionResult FinanceManagerPage()
    //     {
    //         var employees = _context.Employees.ToList();
    //         List<FinanceManagerViewModel> employeeList = new List<FinanceManagerViewModel>();

    //         if(employees !=null)
    //         {
                
    //             foreach (var employee in employees)
    //             {
    //                 var FinanceManagerViewModel = new FinanceManagerViewModel()
    //                 {
    //                     Emp_ID=employee.Emp_ID,
    //                     Emp_Email=employee.Emp_Email,
    //                     Reimbursement_type=employee.Reimbursement_type,
    //                     Reason=employee.Reason,
    //                     Bill_date=employee.Bill_date,
    //                     Applyed_date=employee.Applyed_date,
    //                     Status=employee.Status
    //                 };
    //                 employeeList.Add(FinanceManagerViewModel);
    //             }
    //             return View(employeeList);
    //         }

    //         return View(employeeList);
    //     }
     }

}