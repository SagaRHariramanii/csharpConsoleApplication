using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Models
{

        public class Employee
        {
            public string EmpId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public DateOnly Dob { get; set; }
            public string PhoneNo { get; set; }
            public DateOnly JoiningDate { get; set; }
            public string ManagerName { get; set; }
            public string ProjectName { get; set; }
            public string RoleId { get; set; }
            public bool IsDeleted { get; set; }

    }
    }
