namespace Company.App.Core.Commands
{
    using Company.App.Core.Contracts;
    using System.Linq;

    public class SetAddressCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public SetAddressCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            int id = int.Parse(args[0]);
            string address = string.Join(' ', args.Skip(1));

            this.employeeController.SetAddress(id, address);

            return "Address sucessfuly updated";
        }
    }
}
