using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Contract
{
    public interface IRoleManagmentMenu
    {
        string GetDepartment();
        string GetJobTitle();
        string GetLocation();
        string GetRoleDescription();
        string GetRoleName();
        void OptionAddRole();
        void OptionDisplayAllRoles();
        //void RoleManagmentMenuOptions();
    }
}
