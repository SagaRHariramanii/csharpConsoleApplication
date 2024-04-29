using EmployeeDirectory.Common;
using EmployeeDirectory.Common.Services;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services;

namespace EmployeeDirectory.UI.Menus
{
    public class EmployeeManagementMenu
    {
        EmployeeService employeeService = new();
        RoleService roleService = new();

        public static void EmployeeManagmentMenuOptions()
        {
            EmployeeManagementMenu employeeManagementMenu = new ();
            Console.WriteLine("Employee Management Menu");
            Console.WriteLine("1. Add new employee");
            Console.WriteLine("2. Display all Employees");
            Console.WriteLine("3. Display one Employee");
            Console.WriteLine("4. Edit employee Detail");
            Console.WriteLine("5. Delete employee Data");
            Console.WriteLine("6. Go Back");
            Console.Write("Choice = ");
            int employeeMangementChoice = Parser.ParseToInt(Console.ReadLine()!);
            if (employeeMangementChoice==-1)
            {
                Console.WriteLine("Invalid Choice Select Again");
                EmployeeManagmentMenuOptions();
            }
            else
            {
                switch (employeeMangementChoice)
                {
                    case 1:
                        employeeManagementMenu.OptionAddEmployee();
                        break;
                    case 2:
                        employeeManagementMenu.OptionDisplayAllEmployeeData();
                        break;
                    case 3:
                        employeeManagementMenu.OptionDisplayEmployeeById();
                        break;
                    case 4:
                        Console.WriteLine("--------------------- Edit Particular Employee Data ---------------------");
                        Console.Write("Enter Employee No. = ");
                        string employeeID = Console.ReadLine()!;
                        Employee employeeData = employeeManagementMenu.employeeService.GetEmployeeDataById(employeeID)!;
                        if (!(employeeData == null || employeeData.IsDeleted))
                        {
                            employeeManagementMenu.DisplayEmployeeData(employeeData);
                            employeeManagementMenu.OptionEditEmployee(employeeData, employeeID);
                        }
                        else
                        {
                            Console.WriteLine("Employee with Employee id " + employeeID + " Not Found");
                        }
                        break;
                    case 5:
                        employeeManagementMenu.OptionDeleteParticularEmployeeData();
                        break;
                    case 6:
                        MainMenuOptions.DisplayMainMenuOptions();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;

                }
            }
        }
        public static string GetEmployeeId()
        {
            Console.Write("Enter Employee No. : ");
            string employeeId = (Console.ReadLine()!);
            ValidationResult employeeIdValidator = ValidationService.ValidateEmployeeId(employeeId);
            if (!employeeIdValidator.IsValid)
            {
                Console.WriteLine(employeeIdValidator.Message);
                string empId = GetEmployeeId();
                return empId;
            }
            else
            {
                return employeeId;
            }
        }
        public static string GetFirstName()
        {
            Console.Write("Enter First Name : ");
            string firstName = (Console.ReadLine()!);
            ValidationResult firstNameValidator = ValidationService.ValidateFirstName(firstName);
            if (!firstNameValidator.IsValid)
            {
                Console.WriteLine(firstNameValidator.Message);
                string empFirstName = GetFirstName();
                return empFirstName;
            }
            else
            {
                return firstName;
            }
        }
        public static string GetLastName()
        {
            Console.Write("Enter Last Name : ");
            string lastName = (Console.ReadLine()!);
            ValidationResult lastNameValidator = ValidationService.ValidateLastName(lastName);
            if (!lastNameValidator.IsValid)
            {
                Console.WriteLine(lastNameValidator.Message);
                string empLastName = GetLastName();
                return empLastName;
            }
            else
            {
                return lastName;
            }
        }
        public static DateOnly GetDob()
        {
            Console.Write("Enter Date of Birth : ");
            string Dob = (Console.ReadLine()!);
            ValidationResult dobValidator = ValidationService.ValidateDate(Dob);
            if (!dobValidator.IsValid)
            {
                Console.WriteLine(dobValidator.Message);
                return GetDob();
            }
            else
            {
                return DateOnly.Parse(Dob);
            }

        }
        public static string GetEmail()
        {
            Console.Write("Enter Email : ");
            string email = (Console.ReadLine()!);
            ValidationResult emailValidator = ValidationService.ValidateEmail(email);
            if (!emailValidator.IsValid)
            {
                Console.WriteLine(emailValidator.Message);
                string empEmail = GetEmail();
                return empEmail;
            }
            else
            {
                return email;
            }
        }
        public static string GetPhoneNumber()
        {
            Console.Write("Enter Mobile Number : ");
            string phoneNo = (Console.ReadLine()!);
            ValidationResult phoneNumberValidator = ValidationService.ValidatePhoneNumber(phoneNo);
            if (!phoneNumberValidator.IsValid)
            {
                Console.WriteLine(phoneNumberValidator.Message);
                string empPhoneNo = GetPhoneNumber();
                return empPhoneNo;
            }
            else
            {
                return phoneNo;
            }
        }
        public static DateOnly GetJoiningDate()
        {
            Console.Write("Enter Joining Date : ");
            string joiningDate = (Console.ReadLine()!);
            ValidationResult joiningDateValidator = ValidationService.ValidateDate(joiningDate);
            if (joiningDateValidator.IsValid)
            {
                return DateOnly.Parse(joiningDate);
            }
            else
            {
                Console.WriteLine(joiningDateValidator.Message);
                return GetJoiningDate();
            }

        }
        public string GetLocation()
        {
            int i = 1;
            List<string> locations = [];
            for (int j = 1; j <= roleService.GetRoleCount(); j++)
            {
                locations.Add(roleService.GetRoleDataById("R"+j).Location);
            }
            string[] uniqueLocations = locations.Distinct().ToArray();
            Console.WriteLine("--------------------- Locations ---------------------");
            foreach (string loc in uniqueLocations)
            {
                Console.WriteLine(i + ". " + loc);
                i++;
            }
            Console.Write("\nEnter the location : ");
            int selectedOption = int.Parse(Console.ReadLine()!);
            if (selectedOption > (uniqueLocations.Length + 1))
            {
                Console.WriteLine("Invalid Choice..");
                string empLocation = GetLocation();
                return empLocation;
            }
            else
            {
                string location = uniqueLocations[selectedOption - 1];
                return location;
            }
        }
        public string GetDepartment(string location)
        {
            string selectedLocation = location;
            int i = 1;
            List<string> departments = [];
            for (int j = 1; j <= roleService.GetRoleCount(); j++)
            {
                if (selectedLocation == roleService.GetRoleDataById("R"+j).Location)
                {
                    departments.Add(roleService.GetRoleDataById("R"+j).Department);
                }
            }
            string[] uniqueDepartments = departments.Distinct().ToArray();
            Console.WriteLine("--------------------- Departments ---------------------");
            foreach (string dep in uniqueDepartments)
            {
                Console.WriteLine(i + ". " + dep);
                i++;
            }
            Console.Write("\nEnter the Department : ");
            int departmentChoice = int.Parse(Console.ReadLine()!);
            if (departmentChoice > (uniqueDepartments.Length + 1))
            {
                Console.WriteLine("Invalid Choice..");
                string empDepartment = GetDepartment(selectedLocation);
                return empDepartment;
            }
            else
            {
                string department = uniqueDepartments[departmentChoice - 1];
                return department;
            }
        }
        public string GetJobTitle(string location, string department)
        {
            string selectedLocation = location;
            string selectedDepartment = department;
            List<string> jobTitles = [];
            int i = 1;
            for (int j = 1; j <= roleService.GetRoleCount(); j++)
            {
                if (selectedLocation == roleService.GetRoleDataById("R"+j).Location)
                {
                    if (selectedDepartment == roleService.GetRoleDataById("R"+j).Department)
                    {
                        jobTitles.Add(roleService.GetRoleDataById("R"+j).Name);
                    }
                }
            }
            string[] uniqueJobTitles = jobTitles.Distinct().ToArray();
            Console.WriteLine("--------------------- Job Titles ---------------------");
            foreach (string jobtitle in uniqueJobTitles)
            {
                Console.WriteLine(i + ". " + jobtitle);
                i++;
            }

            Console.Write("\n Enter the Job Title : ");
            int jobTitleChoice = int.Parse(Console.ReadLine()!);
            if (jobTitleChoice > (uniqueJobTitles.Length + 1))
            {
                Console.WriteLine("Invalid Choice..");
                string empJobTitle = GetJobTitle(selectedLocation, selectedDepartment);
                return empJobTitle;
            }
            else
            {
                string jobTitle = uniqueJobTitles[jobTitleChoice - 1];
                return jobTitle;
            }
        }
        public static string GetManager()
        {
            Console.Write("Enter the ManagerName : ");
            string manager = Console.ReadLine()!;
            return manager;
        }
        public static string GetProject()
        {
            Console.Write("Enter the ProjectName : ");
            string project = Console.ReadLine()!;
            return project;
        }
        public void OptionDisplayEmployeeById()
        {
            Console.WriteLine("--------------------- Displaying a particular Employee Data ---------------------");
            Console.Write("Enter Employee No. : ");
            string employeeId = Console.ReadLine()!;
            Employee employeeData = employeeService.GetEmployeeDataById(employeeId)!;
            if (employeeData == null || employeeData.IsDeleted)
            {
                Console.WriteLine("Employee with Employee id " + employeeId + " Not Found");
            }
            else
            {
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                string header = string.Format("|{0,10}|{1,25}|{2,30}|{3,20}|{4,15}|{5,20}|{6,20}|{7,20}|", "EmpID", "Name", "Role", "Department", "Location", "Join Date", "Manager Name", "Project Name");
                Console.WriteLine(header);
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                Role roleDetail = roleService.GetRoleInformation(employeeData.RoleId)!;
                Console.WriteLine("|{0,10}|{1,25}|{2,30}|{3,20}|{4,15}|{5,20}|{6,20}|{7,20}|", employeeData.EmpId, employeeData.FirstName + " " + employeeData.LastName, roleDetail.Name, roleDetail.Department, roleDetail.Location, employeeData.JoiningDate, employeeData.ManagerName, employeeData.ProjectName);
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            }

        }
        public void OptionAddEmployee()
        {
            Employee emp = new();
            Console.WriteLine("--------------------- Add employee ---------------------");
            emp.EmpId = GetEmployeeId();
            emp.FirstName = GetFirstName();
            emp.LastName = GetLastName();
            emp.Dob = GetDob();
            emp.Email = GetEmail();
            emp.PhoneNo = GetPhoneNumber();
            emp.JoiningDate = GetJoiningDate();
            string location = GetLocation();
            string department = GetDepartment(location);
            string jobTitle = GetJobTitle(location, department);
            emp.ManagerName = GetManager();
            emp.ProjectName = GetProject();
            emp.RoleId = roleService.GetRoleId(jobTitle,location, department)!;
            emp.IsDeleted = false;
            employeeService.AddEmployee(emp);
            Console.WriteLine("Employee Added SuccessFully");
            Console.Write("Do you want to add more Employee (y/n): ");
            string addMoreChoice = Console.ReadLine()!.ToLower();
            if (addMoreChoice == "y")
            {
                OptionAddEmployee();
            }
            else
            {
                Environment.Exit(0);
            }
        }
        public void OptionDisplayAllEmployeeData()
        {
            Console.WriteLine("--------------------- Displaying all Employees Data ---------------------\n");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            string header = string.Format("|{0,10}|{1,25}|{2,30}|{3,20}|{4,15}|{5,20}|{6,20}|{7,20}|", "EmpID", "Name", "Role", "Department", "Location", "Join Date", "Manager Name", "Project Name");
            Console.WriteLine(header);
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            List<Employee> employeeDataList = employeeService.GetEmployeeDataList();
            for (int i = 0; i < employeeDataList.Count; i++)
            {
                Employee empData = employeeDataList[i];
                if (empData.IsDeleted)
                {
                    continue;
                }
                else
                {
                    Role roleDetail = roleService.GetRoleInformation(empData.RoleId)!;
                    string employeeData = string.Format("|{0,10}|{1,25}|{2,30}|{3,20}|{4,15}|{5,20}|{6,20}|{7,20}|", empData.EmpId, empData.FirstName + " " + empData.LastName, roleDetail.Name, roleDetail.Department, roleDetail.Location, empData.JoiningDate, empData.ManagerName, empData.ProjectName);
                    Console.WriteLine(employeeData);
                    Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                }
            }
            Console.WriteLine();
        }
        public void DisplayEmployeeData(Employee employeeData)
        {
            Console.WriteLine("1.  First Name: " + employeeData.FirstName);
            Console.WriteLine("2.  Last Name: " + employeeData.LastName);
            Console.WriteLine("3.  Date of Birth: " + employeeData.Dob);
            Console.WriteLine("4.  Email: " + employeeData.Email);
            Console.WriteLine("5.  Phone number: " + employeeData.PhoneNo);
            Console.WriteLine("6.  Joining Date: " + employeeData.JoiningDate);
            Role roleDetail = roleService.GetRoleInformation(employeeData.RoleId)!;
            if (roleDetail != null)
            {
                Console.WriteLine("7.  Location: " + roleDetail.Location);
                Console.WriteLine("8.  Job Title: " + roleDetail.Name);
                Console.WriteLine("9.  Department: " + roleDetail.Department);
            }
            else
            {
                Console.WriteLine("7.  Location: " + "");
                Console.WriteLine("8.  Job Title: " + "");
                Console.WriteLine("9.  Department: " + "");
            }
            Console.WriteLine("10. Manager Name: " + employeeData.ManagerName);
            Console.WriteLine("11. Project Name: " + employeeData.ProjectName);
        }
        public void OptionEditEmployee(Employee employeeData, string employeeID)
        {
            Console.Write("Which Field you want to Change:");
            int choice = int.Parse(Console.ReadLine()!);
            switch (choice)
            {
                case 1:
                    string firstName = GetFirstName();
                    employeeData.FirstName = firstName;
                    employeeService.EditEmployee(employeeID, employeeData);
                    Console.WriteLine("First Name Changed SuccessFully");
                    break;
                case 2:
                    string lastName = GetLastName();
                    employeeData.LastName = lastName;
                    employeeService.EditEmployee(employeeID, employeeData);
                    Console.WriteLine("Last Name Changed SuccessFully");
                    break;
                case 3:
                    DateOnly dob = GetDob();
                    employeeData.Dob = dob;
                    employeeService.EditEmployee(employeeID, employeeData);
                    Console.WriteLine("Date Of Birth Changed SuccessFully");
                    break;
                case 4:
                    string email = GetEmail();
                    employeeData.Email = email;
                    employeeService.EditEmployee(employeeID, employeeData);
                    Console.WriteLine("Email Changed SuccessFully");
                    break;
                case 5:
                    string phoneNo = GetPhoneNumber();
                    employeeData.PhoneNo = phoneNo;
                    employeeService.EditEmployee(employeeID, employeeData);
                    Console.WriteLine("Phone Number Changed SuccessFully");
                    break;
                case 6:
                    DateOnly joiningDate = GetJoiningDate();
                    employeeData.JoiningDate = joiningDate;
                    employeeService.EditEmployee(employeeID, employeeData);
                    Console.WriteLine("Joining Date Changed SuccessFully");
                    break;
                case 7:
                    string changedLocation = GetLocation();
                    string changedDepartment = GetDepartment(changedLocation);
                    string changedJobTitle = GetJobTitle(changedLocation, changedDepartment);
                    string roleId = roleService.GetRoleId(changedJobTitle,changedLocation, changedDepartment)!;
                    employeeData.RoleId = roleId;
                    employeeService.EditEmployee(employeeID, employeeData);
                    Console.WriteLine("Location,Department,Job Title Changed SuccessFully");
                    break;
                case 8:
                    goto case 7;
                case 9:
                    goto case 7;
                case 10:
                    string manager = GetManager();
                    employeeData.ManagerName = manager;
                    employeeService.EditEmployee(employeeID, employeeData);
                    Console.WriteLine("ManagerName Changed Successfully");
                    break;
                case 11:
                    string project = GetProject();
                    employeeData.ProjectName = project;
                    employeeService.EditEmployee(employeeID, employeeData);
                    Console.WriteLine("ProjectName Changed Successfully");
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
            Console.Write("\nDo you want to add more Employee (y/n): ");
            string addMoreChoice = Console.ReadLine()!.ToLower();
            if (addMoreChoice == "y")
            {
                OptionEditEmployee(employeeData, employeeID);
            }
            else
            {
                Console.WriteLine("---------------------  Updated Data --------------------- ");
                DisplayEmployeeData(employeeData);
                Environment.Exit(0);
            }
        }
        public void OptionDeleteParticularEmployeeData()
        {
            Console.WriteLine("--------------------- Delete a Particular Employee Data ---------------------");
            Console.Write("Enter the EmployeeId of Employee : ");
            string empId = Console.ReadLine()!;
            Employee employeeData = employeeService.GetEmployeeDataById(empId)!;
            if (employeeData == null || employeeData.IsDeleted)
            {
                Console.WriteLine("Employee with Employee Id " + empId + " Not Found!");
            }
            else
            {
                employeeService.DeleteEmployee(empId, employeeData);
                Console.WriteLine("Employee with Employee Id " + empId + " Deleted SuccessFully!");
            }

        }
    }

}
