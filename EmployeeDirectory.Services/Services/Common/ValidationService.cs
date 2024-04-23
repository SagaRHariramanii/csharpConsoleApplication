using EmployeeDirectory.Data;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services.Contract;
using System.Globalization;
using System.Text.RegularExpressions;

namespace EmployeeDirectory.Common.Services
{
    public class ValidationService:IValidation
    {
        public  ValidationResult ValidateEmployeeId(string empId)
        {
            List<Employee> employeeDataList = JsonFileHandler.GetEmployeeData();
            ValidationResult validator = new();
            var employeeIdRegex = @"^TZ\d{4}$";
            bool isEmployeeIdValid = Regex.IsMatch(empId, employeeIdRegex);
            bool isEmployeeIdUnique = true;
            foreach (Employee emp in employeeDataList)
            {
                if (emp.EmpId == empId)
                {
                    isEmployeeIdUnique = false;
                    break;
                }
                else
                {
                    isEmployeeIdUnique = true;
                }
            }
            if (!string.IsNullOrEmpty(empId))
            {
                if (isEmployeeIdValid)
                {
                    if (isEmployeeIdUnique)
                    {
                        validator.IsValid = true;
                        return validator;
                    }
                    else
                    {
                        validator.IsValid = false;
                        validator.Message = "This Employee Id already Exist in the DataBase Try Different one..";
                        return validator;
                    }
                }
                else
                {
                    validator.IsValid = false;
                    validator.Message = "This Employee Id Isn't valid Try in this formate (TZ1234)";
                    return validator;
                }
            }
            else
            {
                validator.IsValid = false;
                validator.Message = "This is Required Field , this can't be Empty";
                return validator;
            }
        }
        public  ValidationResult ValidateFirstName(string firstName)
        {
            ValidationResult validator = new();
            var firstNameRegex = @"^(?!\s+$)[a-zA-Z\s]+$";
            bool isFirstNameValid = Regex.IsMatch(firstName, firstNameRegex);
            if (string.IsNullOrEmpty(firstName))
            {
                validator.IsValid = false;
                validator.Message = "This is Required Field , this can't be Empty";
                return validator;
            }
            else
            {
                if (isFirstNameValid)
                {
                    validator.IsValid = true;
                    return validator;
                }
                else
                {
                    validator.IsValid = false;
                    validator.Message = "Please Enter Alphabets only";
                    return validator;
                }
            }
        }
        public  ValidationResult ValidateLastName(string lastName)
        {
            ValidationResult validator = new();
            var lastNameRegex = @"^(?!\s+$)[a-zA-Z\s]+$";
            bool isLastNameValid = Regex.IsMatch(lastName, lastNameRegex);
            if (isLastNameValid)
            {
                validator.IsValid = true;
                return validator;

            }
            else
            {
                validator.IsValid = false;
                validator.Message = "Please Enter Alphabets only";
                return validator;
            }
        }

        public  ValidationResult ValidateEmail(string email)
        {
            ValidationResult validator = new();
            var emailRegex = @"^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$";
            bool isEmailValid = Regex.IsMatch(email, emailRegex);
            if (string.IsNullOrEmpty(email))
            {
                validator.IsValid = false;
                validator.Message = "This is Required Field , this can't be Empty";
                return validator;
            }
            else
            {
                if (isEmailValid)
                {
                    validator.IsValid = true;
                    return validator;
                }
                else
                {
                    validator.IsValid = false;
                    validator.Message = "Please enter the correct Email";
                    return validator;
                }
            }
        }
        public  ValidationResult ValidatePhoneNumber(string phoneNo)
        {
            ValidationResult validator = new();
            var phoneNoRegex = @"^\d{10}$";
            bool isPhoneNoValid = Regex.IsMatch(phoneNo, phoneNoRegex);
            if (string.IsNullOrEmpty(phoneNo))
            {
                validator.IsValid = false;
                validator.Message = "This is Required Field , this can't be Empty";
                return validator;
            }
            else
            {
                if (!isPhoneNoValid)
                {
                    validator.IsValid = false;
                    validator.Message = "Enter the Valid Phone No. of 10 Digits";
                    return validator;
                }
                else
                {
                    validator.IsValid = true;
                    return validator;
                }
            }
        }
        public  ValidationResult ValidateDate(string dob)
        {
            ValidationResult validator = new();
            bool isDateValid = DateOnly.TryParse(dob, CultureInfo.CurrentCulture, out DateOnly date);
            if (isDateValid)
            {
                validator.IsValid = true;
                return validator;
            }
            else
            {
                validator.IsValid = false;
                validator.Message = "Invalid Date Input ";
                return validator;
            }
        }
        public  ValidationResult ValidateRoleName(string roleName)
        {
            ValidationResult validator = new();
            var roleNameRegex = @"^(?!\s+$)[a-zA-Z\s]+$";
            bool isRoleNameValid = Regex.IsMatch(roleName, roleNameRegex);
            if (string.IsNullOrEmpty(roleName))
            {
                validator.IsValid = false;
                validator.Message = "This is Required Field , this can't be Empty";
                return validator;
            }
            else
            {
                if (isRoleNameValid)
                {
                    validator.IsValid = true;
                    return validator;
                }
                else
                {
                    validator.IsValid = false;
                    validator.Message = "Please Enter Alphabets only";
                    return validator;
                }
            }
        }
        public  ValidationResult ValidateLocation(string location)
        {
            ValidationResult validator = new();
            var locationNameRegex = @"^(?!\s+$)[a-zA-Z\s]+$";
            bool isLocationValid = Regex.IsMatch(location, locationNameRegex);
            if (string.IsNullOrEmpty(location))
            {
                validator.IsValid = false;
                validator.Message = "This is Required Field , this can't be Empty";
                return validator;
            }
            else
            {
                if (isLocationValid)
                {
                    validator.IsValid = true;
                    return validator;
                }
                else
                {
                    validator.IsValid = false;
                    validator.Message = "Please Enter Alphabets only";
                    return validator;
                }
            }
        }
        public  ValidationResult ValidateDepartment(string department)
        {
            ValidationResult validator = new();
            var departmentNameRegex = @"^(?!\s+$)[a-zA-Z\s]+$";
            bool isDepartmentValid = Regex.IsMatch(department, departmentNameRegex);
            if (string.IsNullOrEmpty(department))
            {
                validator.IsValid = false;
                validator.Message = "This is Required Field , this can't be Empty";
                return validator;
            }
            else
            {
                if (isDepartmentValid)
                {
                    validator.IsValid = true;
                    return validator;
                }
                else
                {
                    validator.IsValid = false;
                    validator.Message = "Please Enter Alphabets only";
                    return validator;
                }
            }
        }

    }
}
