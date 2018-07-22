namespace Company.App.Core.Commands
{
    using Company.App.Core.Contracts;
    using Company.App.Core.DTOs;
    using System;

    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public EmployeePersonalInfoCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            int id = int.Parse(args[0]);

            EmployeePersonalInfoDto employeeDto = employeeController.GetEmployeePersonalInfo(id);

            string result = $"ID: {employeeDto.Id} - {employeeDto.FirstName} {employeeDto.LastName} -  ${employeeDto.Salary:f2}" + Environment.NewLine +
                            $"Birthday: {employeeDto.BirthDay.Value.ToString("dd-MM-yyyy")}" + Environment.NewLine +
                            $"Address: {employeeDto.Address}";

            return result;
        }
    }
}
