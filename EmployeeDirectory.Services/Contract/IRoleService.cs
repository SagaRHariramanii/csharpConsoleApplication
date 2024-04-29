using EmployeeDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Services.Contract
{
    public interface IRoleService
    {
        void AddRole(Role role);
        Role? GetRoleInformation(string id);
        string? GetRoleId(string location, string department, string roleName);
        int GetRoleCount();
        Role GetRoleDataById(string roleId);
        List<Role> GetRoleDataList();

    }
}
