using EmployeeDirectory.Models;
using EmployeeDirectory.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Services.Contract
{
    public interface IEmployee
    {
        void AddEmployee(Employee employee);
        void EditEmployee(string employeeId, Employee employee);
        ValidationResult DeleteEmployee(string employeeId);
        Employee GetEmployeeDataById(string employeeId);
        List<Employee> GetEmployeeDataList();
    }
}
