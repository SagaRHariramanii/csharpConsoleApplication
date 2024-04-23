using EmployeeDirectory.Common.Model;
using EmployeeDirectory.Common.Services;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmployeeDirectory.UI.Menus
{
    public class RoleManagmentMenu
    {
        public static void RoleManagmentMenuOptions()
        {
            Console.WriteLine("1. Add new role");
            Console.WriteLine("2. Display all Roles");
            Console.WriteLine("3. Go Back");
            Console.Write("Choice = ");
            int roleManagmentChoice=int.Parse(Console.ReadLine()!);
            switch (roleManagmentChoice)
            {
                case 1:
                    OptionAddRole();
                    break;
                case 2:
                    OptionDisplayAllRoles();
                    break;
                case 3:
                    MainMenuOptions.DisplayMainMenuOptions();
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
        public static string GetRoleName()
        {
            Console.Write("Enter the Role Name : ");
            string roleName = Console.ReadLine()!;
            Validation RoleNameValidator = ValidationService.ValidateRoleName(roleName);
            if (!RoleNameValidator.IsValid)
            {
                Console.WriteLine(RoleNameValidator.Message);
                string rName = GetRoleName();
                return rName;
            }
            else
            {
                return roleName;
            }
        }
        public static string GetLocation()
        {
            Console.Write("Enter Location : ");
            string location = Console.ReadLine()!;
            Validation LocationValidator = ValidationService.ValidateLocation(location);
            if (!LocationValidator.IsValid)
            {
                Console.WriteLine(LocationValidator.Message);
                string loc = GetRoleName();
                return loc;
            }
            else
            {
                return location;
            }
        }
        public static string GetDepartment()
        {
            Console.Write("Enter the Department : ");
            string department = Console.ReadLine()!;
            Validation departmentValidator = ValidationService.ValidateDepartment(department);
            if (!departmentValidator.IsValid)
            {
                Console.WriteLine(departmentValidator.Message);
                string dep = GetRoleName();
                return dep;
            }
            else
            {
                return department;
            }
        }
        public static string GetJobTitle()
        {
            Console.Write("Enter the Job Title : ");
            string jobTitle = Console.ReadLine()!;
            return jobTitle;
        }
        public static string GetRoleDescription()
        {
            Console.Write("Enter the Job Description : ");
            string roleDescription = Console.ReadLine()!;
            return roleDescription;
        }
        public static void OptionAddRole()
        {
            Role role = new();
            Console.WriteLine("--------------------- Add Role ---------------------");
            role.RoleName = GetRoleName();
            role.Location = GetLocation();
            role.Description = GetRoleDescription();
            role.Department = GetDepartment();
            string lastRoleId = RoleService.GetRoleDataByIndex(RoleService.GetRoleCount() - 1).RoleId;
            role.RoleId = "R" + (Convert.ToInt16(lastRoleId[1..]) + 1);
            RoleService.AddRole(role);
            Console.WriteLine("Role Added SuccessFully");
            Console.Write("Do you want to add more Role (y/n): ");
            string addMoreChoice = Console.ReadLine()!.ToLower();
            if (addMoreChoice == "y")
            {
                OptionAddRole();
            }
            else
            {
                Environment.Exit(0);
            }
        }
        public static void OptionDisplayAllRoles()
        {
            Console.WriteLine("RoleList");
            int countRoleObj = RoleService.GetRoleCount();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            string header = string.Format("|{0,30}|{1,20}|{2,20}|{3,30}|", "Role Name", "Location", "Department", "Description");
            Console.WriteLine(header);
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            List<Role> roleDataList = RoleService.GetRoleDataList();
            for (int i = 0; i < countRoleObj; i++)
            {
                Role roleData= roleDataList[i];
                string formatedRoleData = string.Format("|{0,30}|{1,20}|{2,20}|{3,30}|", roleData.RoleName, roleData.Location, roleData.Department, roleData.Description);
                Console.WriteLine(formatedRoleData);
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            }
        }
    }
}
