using EmployeeDirectory.Data;
using EmployeeDirectory.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeDirectory.Common.Services
{
    public class ValidationService
    {
        public static Validation ValidateEmployeeId(string empId)
        {
            List<Employee> employeeDataList = JsonFileHandler.GetEmployeeData();
            Validation validator = new();
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
        public static Validation ValidateFirstName(string firstName)
        {
            Validation validator = new();
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
        public static Validation ValidateLastName(string lastName)
        {
            Validation validator = new();
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

        public static Validation ValidateEmail(string email)
        {
            Validation validator = new();
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
        public static Validation ValidatePhoneNumber(string phoneNo)
        {
            Validation validator = new();
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
        public static Validation ValidateDate(string dob)
        {
            Validation validator = new();
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
        public static Validation ValidateRoleName(string roleName)
        {
            Validation validator = new();
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
        public static Validation ValidateLocation(string location)
        {
            Validation validator = new();
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
        public static Validation ValidateDepartment(string department)
        {
            Validation validator = new();
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
