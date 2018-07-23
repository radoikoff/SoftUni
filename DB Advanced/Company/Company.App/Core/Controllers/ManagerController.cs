namespace Company.App.Core.Controllers
{
    using AutoMapper;
    using Company.App.Core.Contracts;
    using Company.App.Core.DTOs;
    using Company.Data;
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class ManagerController : IManagerController
    {
        private readonly CompanyContext context;
        private readonly IMapper mapper;

        public ManagerController(CompanyContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ManagerDto GetManagerInfo(int employeeId)
        {
            var employee = context.Employees
                                  .Include(x => x.ManagerEmployees)
                                  .Where(e => e.Id == employeeId)
                                  .SingleOrDefault();

            if (employee == null)
            {
                throw new ArgumentException("Invalid Employee Id");
            }

            var managerDto = mapper.Map<ManagerDto>(employee);

            return managerDto;
        }

        public void SetManager(int employeeId, int managerId)
        {
            var employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Provided Employee Id is invalid!");
            }

            var manager = context.Employees.Find(managerId);

            if (manager == null)
            {
                throw new ArgumentException("Provided Manager Id is invalid!");
            }

            employee.Manager = manager;
            context.SaveChanges();
        }
    }
}
