namespace Company.App.Core.Controllers
{
    using Contracts;
    using DTOs;
    using Data;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AutoMapper;
    using Company.Models;
    using System.Linq;
    using AutoMapper.QueryableExtensions;

    public class EmployeeController : IEmployeeController
    {
        private readonly CompanyContext context;
        private readonly IMapper mapper;

        public EmployeeController(CompanyContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddEmployee(EmployeeDto employeeDto)
        {
            var employee = this.mapper.Map<Employee>(employeeDto);

            this.context.Employees.Add(employee);
            this.context.SaveChanges();
        }

        public void SetAddress(int employeeId, string address)
        {
            var employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid Employee Id");
            }

            employee.Address = address;
            context.SaveChanges();
        }

        public void SetBirthday(int employeeId, DateTime date)
        {
            var employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid Employee Id");
            }

            employee.BirthDay = date;
            context.SaveChanges();
        }

        public EmployeeDto GetEmployeeInfo(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid Employee Id");
            }

            var employeeDto = mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public EmployeePersonalInfoDto GetEmployeePersonalInfo(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid Employee Id");
            }

            var employeePersonalInfoDto = mapper.Map<EmployeePersonalInfoDto>(employee);

            return employeePersonalInfoDto;
        }
    }
}
