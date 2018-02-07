using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeWebApi.Models
{
    public class Employees
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Department{ get; set; }
        public DateTime Created_Date{ get; set; }
        public DateTime Updated_Date{ get; set; }
        public  string Created_By { get; set; }
        public string Updated_By { get; set; }
        public string  Roles { get; set; }
        public int flag { get; set; }

    }
}