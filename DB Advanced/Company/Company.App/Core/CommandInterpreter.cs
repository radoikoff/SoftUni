namespace Company.App.Core
{
    using Company.App.Core.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IServiceProvider provider;

        public CommandInterpreter(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public string Read(string[] input)
        {
            string commandName = input[0] + "Command";

            string[] args = input.Skip(1).ToArray();

            var type = Assembly.GetCallingAssembly()
                               .GetTypes()
                               .FirstOrDefault(t => t.Name == commandName);

            if (type == null)
            {
                throw new ArgumentException("Invalid Command Type!");
            }

            if (!typeof(ICommand).IsAssignableFrom(type))
            {
                throw new ArgumentException($"{input} is not a command type!");
            }

            var constructor = type.GetConstructors().First();

            var constructorParams = constructor.GetParameters().Select(pi => pi.ParameterType).ToArray();

            var service = constructorParams.Select(provider.GetService).ToArray();

            var command = (ICommand)constructor.Invoke(service);

            string result = command.Execute(args);

            return result;
        }
    }
}
