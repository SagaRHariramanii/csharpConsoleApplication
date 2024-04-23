using EmployeeDirectory.Data;
using EmployeeDirectory.Models;
using EmployeeDirectory.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmployeeDirectory.Services
{
    public class RoleService
    {

        public static void AddRole(Role role)
        {
            List<Role> roleDataList = JsonFileHandler.GetRoleData();
            roleDataList.Add(role);
            JsonFileHandler.AddRoleToJson(roleDataList);
        }
        public static Dictionary<string, string> GetRoleInformation(string roleId)
        {
            List<Role> roleDataList = JsonFileHandler.GetRoleData();
            Dictionary<string, string> roleInfo = [];
            foreach (Role role in roleDataList)
            {
                if (role.RoleId == roleId)
                {
                    roleInfo.Add("Location", role.Location);
                    roleInfo.Add("Department", role.Department);
                    roleInfo.Add("RoleName", role.RoleName);
                    return roleInfo;
                }
            }
            return [];
        }
        public static string? GetRoleId(string location, string department, string roleName)
        {
            List<Role> roleDataList = JsonFileHandler.GetRoleData();
            foreach (Role role in roleDataList)
            {
                if (role.Location == location && role.Department == department && role.RoleName == roleName)
                {
                    return role.RoleId;
                }
            }
            return null;
        }
        public static int GetRoleCount()
        {
            List<Role> roleDataList = JsonFileHandler.GetRoleData();
            return roleDataList.Count;
        }
        public static Role GetRoleDataByIndex(int index)
        {
            List<Role> roleDataList = JsonFileHandler.GetRoleData();
            return roleDataList[index];

        }
        public static List<Role> GetRoleDataList()
        {
            return JsonFileHandler.GetRoleData();
        }

    }
}
