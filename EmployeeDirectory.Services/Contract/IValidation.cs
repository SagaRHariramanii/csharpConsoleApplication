using EmployeeDirectory.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Services.Contract
{
    public interface IValidation
    {
        ValidationResult ValidateEmployeeId(string employeeId);
        ValidationResult ValidateFirstName(string firstName);
        ValidationResult ValidateLastName(string lastName);
        ValidationResult ValidateEmail(string email);
        ValidationResult ValidatePhoneNumber(string phoneNo);
        ValidationResult ValidateDate(string dob);
        ValidationResult ValidateRoleName(string roleName);
        ValidationResult ValidateLocation(string location);
        ValidationResult ValidateDepartment(string department);

    }
}
