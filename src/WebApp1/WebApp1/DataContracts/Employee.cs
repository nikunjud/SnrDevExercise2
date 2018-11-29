using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp1.DataContracts
{
    public class Employee
    {
        public long EmployeeNo { get; set; }

        
        public string Name { get; set; }

        
        public DateTime DateOfBirth { get; set; }

        
        public string Address { get; set; }

        
        public string Role { get; set; }

        
        public string Dept { get; set; }
    }
}