using EmployeeDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Services.Contract
{
    public interface IRole
    {
        void AddRole(Role role);
        Dictionary<string,string> GetRoleInformation(string id);
        string? GetRoleId(string location, string department, string roleName);
        int GetRoleCount();
        Role GetRoleDataByIndex(int index);
        List<Role> GetRoleDataList();

    }
}
