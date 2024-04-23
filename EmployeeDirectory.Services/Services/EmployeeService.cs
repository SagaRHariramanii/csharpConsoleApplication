using EmployeeDirectory.Data;
using EmployeeDirectory.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using EmployeeDirectory.Common;

namespace EmployeeDirectory.Services
{
    public class EmployeeService
    {
        public static void AddEmployee(Employee emp)
        {
            List<Employee> employeeDataList = JsonFileHandler.GetEmployeeData();
            employeeDataList.Add(emp);
            JsonFileHandler.AddEmployeeToJson(employeeDataList);
        }
        public static void EditEmployee(string empId, Employee empData)
        {
            List<Employee> employeeDataList = JsonFileHandler.GetEmployeeData();
            int index = employeeDataList.FindIndex(emp => emp.EmpId == empId);
            employeeDataList[index]=empData;
            JsonFileHandler.AddEmployeeToJson(employeeDataList);
        }
        public static Validation DeleteEmployee(string employeeId)
        {
            Validation validator = new();

            List<Employee> employeeDataList = JsonFileHandler.GetEmployeeData();
            int index = employeeDataList.FindIndex(emp => emp.EmpId == employeeId);
            Employee employeeData = GetEmployeeDataById(employeeId)!;
            if (index == -1||employeeData.IsDeleted)
            {
                validator.IsValid = false;
                validator.Message = "Employee with Employee Id " + employeeId + " Not Found!";
                return validator;
            }
            else
            {
                employeeData.IsDeleted = true;
                EditEmployee(employeeId, employeeData);
                validator.IsValid = true;
                validator.Message = "Employee with Employee Id " + employeeId + " Deleted Successfully!";
                return validator;
            }
        }
        public static Employee? GetEmployeeDataById(string empId)
        {
            
            List<Employee> employeeDataList = JsonFileHandler.GetEmployeeData();
            Employee employeeData = (from emp in employeeDataList where emp.EmpId == empId select emp).FirstOrDefault()!;
            if (employeeData == null)
            {
                return null;
            }
            else
            {
                return employeeData;
            }

        }
        public static List<Employee> GetEmployeeDataList()
        {
            return JsonFileHandler.GetEmployeeData();
        }
        

    }
}
