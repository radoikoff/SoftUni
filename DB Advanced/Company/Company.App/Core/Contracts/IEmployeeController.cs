namespace Company.App.Core.Contracts
{
    using DTOs;
    using System;
    using System.Collections.Generic;

    public interface IEmployeeController
    {
        void AddEmployee(EmployeeDto employeeDto);

        void SetBirthday(int employeeId, DateTime date);

        void SetAddress(int employeeId, string address);

        EmployeeDto GetEmployeeInfo(int employeeId);

        EmployeePersonalInfoDto GetEmployeePersonalInfo(int employeeId);

        ICollection<EmployeeWithManagerDto> GetEmployeesInfoByAge(int age);
    }
}
