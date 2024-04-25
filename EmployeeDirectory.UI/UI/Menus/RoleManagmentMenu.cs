using EmployeeDirectory.Common;
using EmployeeDirectory.Common.Services;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services;

namespace EmployeeDirectory.UI.Menus
{

    public class RoleManagmentMenu
    {
        RoleService roleService = new();
        public static void RoleManagmentMenuOptions()
        {
            RoleManagmentMenu roleManagmentMenu = new();
            Console.WriteLine("1. Add new role");
            Console.WriteLine("2. Display all Roles");
            Console.WriteLine("3. Go Back");
            Console.Write("Choice = ");
            int roleManagmentChoice = Parser.ParseToInt(Console.ReadLine()!);
            if (roleManagmentChoice==-1)
            {
                Console.WriteLine("Invalid Choice Select Again");
                RoleManagmentMenuOptions();
            }
            else
            {
                switch (roleManagmentChoice)
                {
                    case 1:
                        roleManagmentMenu.OptionAddRole();
                        break;
                    case 2:
                        roleManagmentMenu.OptionDisplayAllRoles();
                        break;
                    case 3:
                        MainMenuOptions.DisplayMainMenuOptions();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }

        }
        public static string GetRoleName()
        {
            Console.Write("Enter the Role Name : ");
            string roleName = Console.ReadLine()!;
            ValidationResult RoleNameValidator = ValidationService.ValidateRoleName(roleName);
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
            ValidationResult LocationValidator = ValidationService.ValidateLocation(location);
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
            ValidationResult departmentValidator = ValidationService.ValidateDepartment(department);
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
        public void OptionAddRole()
        {
            Role role = new();
            Console.WriteLine("--------------------- Add Role ---------------------");
            role.Name = GetRoleName();
            role.Location = GetLocation();
            role.Description = GetRoleDescription();
            role.Department = GetDepartment();
            string lastRoleId = roleService.GetRoleDataByIndex(roleService.GetRoleCount() - 1).Id;
            role.Id = "R" + (Convert.ToInt16(lastRoleId[1..]) + 1);
            roleService.AddRole(role);
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
        public void OptionDisplayAllRoles()
        {
            Console.WriteLine("RoleList");
            int countRoleObj = roleService.GetRoleCount();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            string header = string.Format("|{0,30}|{1,20}|{2,20}|{3,30}|", "Role Name", "Location", "Department", "Description");
            Console.WriteLine(header);
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            List<Role> roleDataList = roleService.GetRoleDataList();
            for (int i = 0; i < countRoleObj; i++)
            {
                Role roleData = roleDataList[i];
                string formatedRoleData = string.Format("|{0,30}|{1,20}|{2,20}|{3,30}|", roleData.Name, roleData.Location, roleData.Department, roleData.Description);
                Console.WriteLine(formatedRoleData);
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            }
        }
    }
}
