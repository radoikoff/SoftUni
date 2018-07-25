namespace Company.App.Core.Commands
{
    using Company.App.Core.Contracts;
    using Company.App.Core.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public ListEmployeesOlderThanCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            int age = int.Parse(args[0]);

            ICollection<EmployeeWithManagerDto> employeeWithManagerDto = this.employeeController.GetEmployeesInfoByAge(age);

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employeeWithManagerDto)
            {
                string managerNames = "";
                if (employee.ManagerFirstName != null)
                {
                    managerNames = employee.ManagerFirstName + " " + employee.ManagerLastName;
                }
                else
                {
                    managerNames = "[no manager]";
                }

                sb.AppendLine($"{employee.FirstName} {employee.LastName} - ${employee.Salary:f2} - Manager: {managerNames}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
