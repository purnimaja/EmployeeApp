using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using  EmployeeWebApi.Models;

namespace EmployeeWebApi.Controllers
{
    [RoutePrefix("Employee")]
    public class EmployeesController : ApiController
    {
        SqlConnection conn = new SqlConnection();
       
 

        public EmployeesController()
        {
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = "server=.;database=Employee;integrated security=true";
                conn.Open();
              
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex .Message);

            }

        }

        [Route("GetAll")]
        public HttpResponseMessage GetAllEmployees()
        {
            List<Employees> Employee = null;
            try
            {
                 Employee = new List<Employees>();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection=conn;
                cmd.CommandText = "Select * from Employees";
                SqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    Employees e = new Employees
                    {


                        ID = int.Parse(rdr["ID"].ToString()),
                        Name = rdr["Name"].ToString(),
                        Gender = rdr["Gender"].ToString(),
                        City = rdr["City"].ToString(),
                        Department = rdr["Department"].ToString(),

                        Created_Date = DateTime.Parse(rdr["Created Date"].ToString()),
                        Updated_Date = DateTime.Parse(rdr["Updated Date"].ToString()),

                        Created_By = rdr["Created By"].ToString(),
                        Updated_By = rdr["Updated By"].ToString(),
                        Roles = rdr["Roles"].ToString(),
                        flag = int.Parse(rdr["Flag"].ToString())
                    };
                    Employee.Add(e);

              }
                rdr.Close();
                conn.Close();
                return Request.CreateResponse(HttpStatusCode.OK,Employee);
            }
            catch(Exception ext)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ext.Message);

            }
        }


        [Route("Employee{id}")]
        public HttpResponseMessage GetEmployeeById(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,ex.Message);

            }
        }








    }
}
