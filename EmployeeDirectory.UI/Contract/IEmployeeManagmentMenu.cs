using EmployeeDirectory.Models;

namespace EmployeeDirectory.Contract
{
    public interface IEmployeeManagementMenu
    {
        void DisplayEmployeeData(Employee employeeData);
//        string GetDepartment(string location);
        DateOnly GetDob();
        string GetEmail();
        string GetEmployeeId();
        string GetFirstName();
        string GetJobTitle(string location, string department);
        DateOnly GetJoiningDate();
        string GetLastName();
        string GetLocation();
        string GetManager();
        string GetPhoneNumber();
        string GetProject();
        void OptionAddEmployee();
        void OptionDeleteParticularEmployeeData();
        void OptionDisplayAllEmployeeData();
        void OptionDisplayEmployeeById();
        void OptionEditEmployee(Employee employeeData, string employeeID);
    }

}
