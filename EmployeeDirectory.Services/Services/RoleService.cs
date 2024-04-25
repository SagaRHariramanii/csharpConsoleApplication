using EmployeeDirectory.Data;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services.Contract;
namespace EmployeeDirectory.Services
{
    public class RoleService : IRoleService
    {
        public void AddRole(Role role)
        {
            List<Role> roleDataList = JsonFileHandler.GetData<Role>();
            roleDataList.Add(role);
            JsonFileHandler.AddDataToJson(roleDataList);
        }
        public Role? GetRoleInformation(string roleId)
        {
            List<Role> roleDataList = JsonFileHandler.GetData<Role>();
            Role roleObj = new();
            foreach (Role role in roleDataList)
            {
                if (role.Id == roleId)
                {
                    roleObj.Name = role.Name;
                    roleObj.Location = role.Location;
                    roleObj.Department = role.Department;
                    return roleObj;
                }
            }
            return null;
        }
        public string? GetRoleId(string roleName, string location, string department)
        {
            List<Role> roleDataList = JsonFileHandler.GetData<Role>();
            string roleId = (from role in roleDataList where role.Name == roleName && role.Location == location && role.Department == department select role.Id).FirstOrDefault()!;
            return roleId;
        }
        public int GetRoleCount()
        {
            List<Role> roleDataList = JsonFileHandler.GetData<Role>();
            return roleDataList.Count;
        }
        public Role GetRoleDataByIndex(int index)
        {
            //dont depend on index
            List<Role> roleDataList = JsonFileHandler.GetData<Role>();
            return roleDataList[index];

        }
        public List<Role> GetRoleDataList()
        {
            return JsonFileHandler.GetData<Role>();
        }

    }
}
