using June_july_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace June_july_CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        public EMP_DB_CRUD_June_JulyEntities dbo = new EMP_DB_CRUD_June_JulyEntities();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SearchEmp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchEmp(tblEmployee e)
        {
            var emp = dbo.tblEmployees.FirstOrDefault(x => x.empID == e.empID);
            if (emp != null)
            {
                return RedirectToAction("EditEmp", emp);
            }
            else
            {
                ViewBag.Message = "Employee not found";
                return View();  
            }

           
        }
        public ActionResult EditEmp(tblEmployee ee)
        {
            List<tblDesignation> designationList = dbo.tblDesignations.ToList();

            ViewBag.DesignationList = designationList;


            return View(ee);
        }
        [HttpPost]
        [ActionName("EditEmp")]
        public ActionResult EditEmp1(tblEmployee ee)
        {
            var emp = dbo.tblEmployees.FirstOrDefault(x => x.empID == ee.empID);
            if (emp!=null)
            {
                emp.Name = ee.Name;
                emp.Address = ee.Address;   
                emp.Contact = ee.Contact;
                emp.Salary = ee.Salary;
                emp.Designation_id = ee.Designation_id;
                emp.Gender=ee.Gender;
                emp.Terms_condition_Accepted = ee.Terms_condition_Accepted;
                int n = dbo.SaveChanges();
                if (n>0)
                {
                    return RedirectToAction("index");
                }                
            }

            List<tblDesignation> designationList = dbo.tblDesignations.ToList();

            ViewBag.DesignationList = designationList;


            return View(ee);
        }
        public ActionResult AddEmp()
        {
            List<tblDesignation> designationList=dbo.tblDesignations.ToList();

            ViewBag.DesignationList = designationList;

          
            return View();
        }
        [HttpPost]
        public ActionResult AddEmp(tblEmployee e)
        {
            // insert CRUD operation
            if (e.Terms_condition_Accepted == true)
            {
                dbo.tblEmployees.Add(e);
                int n = dbo.SaveChanges();
                if (n > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();//
                }
            }
            else
            {
                List<tblDesignation> designationList = dbo.tblDesignations.ToList();

                ViewBag.DesignationList = designationList;
                ViewBag.Message = "Please accept terms and conditions";
                return View();
            }

        }
    }
}