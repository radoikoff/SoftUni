namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    class Engine : IRunnable
    {
        //private IRepository repository;
        //private IUnitFactory unitFactory;
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    IExecutable command = commandInterpreter.InterpretCommand(data, commandName);
                    
                    MethodInfo method = typeof(IExecutable).GetMethods().First();
                    try
                    {
                        string result = (string)method.Invoke(command, null);
                        Console.WriteLine(result);
                    }
                    catch (TargetInvocationException ex)
                    {
                        throw ex.InnerException;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        


        //private string ReportCommand(string[] data)
        //{
        //    string output = this.repository.Statistics;
        //    return output;
        //}


        //private string AddUnitCommand(string[] data)
        //{
        //    string unitType = data[1];
        //    IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
        //    this.repository.AddUnit(unitToAdd);
        //    string output = unitType + " added!";
        //    return output;
        //}
    }
}
