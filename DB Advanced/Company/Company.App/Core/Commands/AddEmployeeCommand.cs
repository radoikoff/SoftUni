namespace Company.App.Core.Commands
{
    using Company.App.Core.Contracts;
    using Company.App.Core.Controllers;
    using Company.App.Core.DTOs;

    public class AddEmployeeCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public AddEmployeeCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            string firstName = args[0];
            string lastName = args[1];
            decimal salary = decimal.Parse(args[2]);

            EmployeeDto employeeDto = new EmployeeDto
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            this.employeeController.AddEmployee(employeeDto);

            return $"{firstName} {lastName} was added sucessfuly.";
        }
    }
}
