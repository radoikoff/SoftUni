namespace BusTicketsSystem.App.Core
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string Read(string[] input)
        {
            string inputCommand = ConstructCommandText(input[0]) + "Command";

            string[] args = input.Skip(1).ToArray();

            var type = Assembly.GetCallingAssembly()
                               .GetTypes()
                               .FirstOrDefault(x => x.Name == inputCommand);

            if (type == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            var constructor = type.GetConstructors().First();

            var constructorParameters = constructor.GetParameters()
                                                   .Select(x => x.ParameterType)
                                                   .ToArray();

            var service = constructorParameters.Select(serviceProvider.GetService)
                                               .ToArray();

            var command = (ICommand)constructor.Invoke(service);

            string result = command.Execute(args);

            return result;
        }

        private string ConstructCommandText(string input)
        {
            var tokens = input.Split('-', StringSplitOptions.RemoveEmptyEntries).Select(x=> char.ToUpper(x[0]) + x.Substring(1));

            var command = string.Join(string.Empty, tokens);

            return command;

        }
    }
}
