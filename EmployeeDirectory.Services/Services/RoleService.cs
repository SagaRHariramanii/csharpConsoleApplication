using EmployeeDirectory.Data;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services.Contract;
namespace EmployeeDirectory.Services
{
    public class RoleService:IRole
    {

        public  void AddRole(Role role)
        {
            List<Role> roleDataList = JsonFileHandler.GetRoleData();
            roleDataList.Add(role);
            JsonFileHandler.AddRoleToJson(roleDataList);
        }
        public  Dictionary<string, string> GetRoleInformation(string roleId)
        {
            List<Role> roleDataList = JsonFileHandler.GetRoleData();
            Dictionary<string, string> roleInfo = [];
            foreach (Role role in roleDataList)
            {
                if (role.Id == roleId)
                {
                    roleInfo.Add("Location", role.Location);
                    roleInfo.Add("Department", role.Department);
                    roleInfo.Add("RoleName", role.Name);
                    return roleInfo;
                }
            }
            return [];
        }
        public  string? GetRoleId(string location, string department, string roleName)
        {
            List<Role> roleDataList = JsonFileHandler.GetRoleData();
            foreach (Role role in roleDataList)
            {
                if (role.Location == location && role.Department == department && role.Name == roleName)
                {
                    return role.Id;
                }
            }
            return null;
        }
        public  int GetRoleCount()
        {
            List<Role> roleDataList = JsonFileHandler.GetRoleData();
            return roleDataList.Count;
        }
        public  Role GetRoleDataByIndex(int index)
        {
            List<Role> roleDataList = JsonFileHandler.GetRoleData();
            return roleDataList[index];

        }
        public  List<Role> GetRoleDataList()
        {
            return JsonFileHandler.GetRoleData();
        }

    }
}
