namespace Company.App.Core.Commands
{
    using Company.App.Core.Contracts;
    using Company.App.Core.DTOs;

    public class EmployeeInfoCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public EmployeeInfoCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            int id = int.Parse(args[0]);

            EmployeeDto employeeDto = employeeController.GetEmployeeInfo(id);

            return $"ID: {employeeDto.Id} - {employeeDto.FirstName} {employeeDto.LastName} -  ${employeeDto.Salary:f2}";
        }
    }
}
