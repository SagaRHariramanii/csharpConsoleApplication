using EmployeeDirectory.Common;
using EmployeeDirectory.Data;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services.Contract;

namespace EmployeeDirectory.Services
{

    public class EmployeeService : IEmployeeService
    {
        public void AddEmployee(Employee emp)
        {
            List<Employee> employeeDataList = JsonFileHandler.GetData<Employee>();
            employeeDataList.Add(emp);
            JsonFileHandler.AddDataToJson(employeeDataList);
        }
        public void EditEmployee(string empId, Employee empData)
        {
            List<Employee> employeeDataList = JsonFileHandler.GetData<Employee>();
            //write string extension methods to compare by ignoring cases.
            int index = employeeDataList.FindIndex(emp => emp.EmpId.Equals(empId));
            employeeDataList[index] = empData;
            JsonFileHandler.AddDataToJson(employeeDataList);
        }
        public void DeleteEmployee(string employeeId,Employee employeeData)
        {
                employeeData.IsDeleted = true;
                EditEmployee(employeeId, employeeData);
        }
        public Employee? GetEmployeeDataById(string empId)
        {
            List<Employee> employeeDataList = JsonFileHandler.GetData<Employee>();
            Employee employeeData = (from emp in employeeDataList where emp.EmpId == empId select emp).FirstOrDefault()!;
            return employeeData;
        }
        public List<Employee> GetEmployeeDataList()
        {
            return JsonFileHandler.GetData<Employee>();
        }
    }
}
