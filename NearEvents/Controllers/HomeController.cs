using NearEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NearEvents.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


        public JsonResult GetAll()
        {
            using (DemoContext contextObj = new DemoContext())
            {
                var employeeList = contextObj.employee.ToList();
                return Json(employeeList, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetEmployeeById(string id)
        {
            using (DemoContext contextObj = new DemoContext())
            {
                int Id = Convert.ToInt32(id);
                var getEmployeeById = contextObj.employee.Find(Id);
                return Json(getEmployeeById, JsonRequestBehavior.AllowGet);
            }
        }

        public string UpdateEmployee(Employee emp)
        {
            if (emp != null)
            {
                using (DemoContext contextObj = new DemoContext())
                {
                    int empId = Convert.ToInt32(emp.Id);
                    Employee employee = contextObj.employee.Where(a => a.Id == empId).FirstOrDefault();
                    employee.Name = emp.Name;
                    employee.Email = emp.Email;
                    employee.Age = emp.Age;
                    contextObj.SaveChanges();
                    return "Employee Updated";
                }
            }
            else
            {
                return "Invalid Record";
            }
        }

        public string AddEmployee(Employee employee)
        {
            if (employee != null)
            {
                using (DemoContext contextObj = new DemoContext())
                {
                    contextObj.employee.Add(employee);
                    contextObj.SaveChanges();
                    return "Employee Added";
                }
            }
            else
            {
                return "Invalid Record";
            }
        }

        public string DeleteEmployee(string employeeId)
        {

            if (!String.IsNullOrEmpty(employeeId))
            {
                try
                {
                    int Id = Int32.Parse(employeeId);
                    using (DemoContext contextObj = new DemoContext())
                    {
                        var getEmployee = contextObj.employee.Find(Id);
                        contextObj.employee.Remove(getEmployee);
                        contextObj.SaveChanges();
                        return "Employee Deleted";
                    }
                }
                catch (Exception ex)
                {
                    return "Employee Not Found " + ex;
                }
            }
            else
            {
                return "Invalid Request";
            }
        }
 

    }
}
