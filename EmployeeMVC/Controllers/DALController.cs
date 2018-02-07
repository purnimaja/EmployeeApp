using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace EmployeeMVC.Controllers
{

    public class DALController : Controller
    {
        // GET: DAL
        SqlConnection conn = null;
        public  DALController()
        {
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = "server=.;database=Employee;integrated security=true";
                conn.Open();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


        public ActionResult Index()
        {
            return View();
        }

       
    }
}