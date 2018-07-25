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
    using Microsoft.EntityFrameworkCore;

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

        public ICollection<EmployeeWithManagerDto> GetEmployeesInfoByAge(int age)
        {
            if (age <= 0)
            {
                throw new ArgumentException("Provided age cannot be negative!");
            }

            var employees = context.Employees
                                   .Include(x => x.Manager)
                                   .Where(e => (DateTime.Now - e.BirthDay.Value).TotalDays > age * 365)
                                   .ProjectTo<EmployeeWithManagerDto>(mapper.ConfigurationProvider)
                                   .ToArray();

            return employees;

        }
    }
}
