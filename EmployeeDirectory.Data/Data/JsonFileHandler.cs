using EmployeeDirectory.Models;
using System.Text.Json;

namespace EmployeeDirectory.Data
{
    public class JsonFileHandler
    {
        public static readonly string RoleFilePath = Path.GetFullPath("../../../../EmployeeDirectory.Data/Data/role.json");
        public static readonly string EmployeeFilePath = Path.GetFullPath("../../../../EmployeeDirectory.Data/Data/employee.json");
        public static List<Employee> GetEmployeeData()
        {
            string employeeData = File.ReadAllText(EmployeeFilePath);
            List<Employee> employeeDataList = JsonSerializer.Deserialize<List<Employee>>(employeeData)!;
            return employeeDataList;
        }
        public static List<Role> GetRoleData()
        {
            string roleData = File.ReadAllText(RoleFilePath);
            List<Role> roleDataList = JsonSerializer.Deserialize<List<Role>>(roleData)!;
            return roleDataList;
        }
        public static void AddRoleToJson(List<Role> roleDataList)
        {
            string jsonToString = JsonSerializer.Serialize(roleDataList);
            File.WriteAllText(RoleFilePath, jsonToString);
        }
        public static void AddEmployeeToJson(List<Employee> employeeDataList)
        {
            string jsonToOutput = JsonSerializer.Serialize(employeeDataList);
            File.WriteAllText(EmployeeFilePath, jsonToOutput);
        }
    }
}
