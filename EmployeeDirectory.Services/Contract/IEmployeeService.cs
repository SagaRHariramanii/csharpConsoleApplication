using EmployeeDirectory.Models;

namespace EmployeeDirectory.Services.Contract
{
    public interface IEmployeeService
    {
        void AddEmployee(Employee employee);
        void EditEmployee(string employeeId, Employee employee);
        void DeleteEmployee(string employeeId, Employee employeeData);
        Employee? GetEmployeeDataById(string employeeId);
        List<Employee> GetEmployeeDataList();
    }
}
