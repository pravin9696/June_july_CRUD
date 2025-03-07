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