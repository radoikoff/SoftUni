namespace Company.App.Core.Commands
{
    using Company.App.Core.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ManagerInfoCommand : ICommand
    {
        private readonly IManagerController managerController;

        public ManagerInfoCommand(IManagerController managerController)
        {
            this.managerController = managerController;
        }

        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);

            var managerDto = this.managerController.GetManagerInfo(employeeId);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{managerDto.FirstName} {managerDto.LastName} | Employees: {managerDto.EmployeesCount}");

            foreach (var employee in managerDto.EmployeesDto)
            {
                sb.AppendLine($"    - {employee.FirstName} {employee.LastName} - ${employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
