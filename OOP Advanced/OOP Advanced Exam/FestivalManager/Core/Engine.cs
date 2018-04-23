
using System;
using System.Linq;
namespace FestivalManager.Core
{
    using System.Reflection;
    using Contracts;
    using Controllers;
    using Controllers.Contracts;
    using IO.Contracts;

    class Engine : IEngine
    {
        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        private IReader reader;
        private IWriter writer;

        public Engine(IFestivalController festivalCоntroller, ISetController setCоntroller, IReader reader, IWriter writer)
        {
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                string input = this.reader.ReadLine();

                if (input == "END")
                {
                    break;
                }

                try
                {
                    string result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }
            }

            string report = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(report);
        }

        public string ProcessCommand(string input)
        {
            string result = string.Empty;

            string[] cmdArgs = input.Split();

            string command = cmdArgs.First();
            string[] args = cmdArgs.Skip(1).ToArray();

            if (command == "LetsRock")
            {
                result = this.setCоntroller.PerformSets();
                return result;
            }

            MethodInfo festivalControllerMethodInfo = this.festivalCоntroller.GetType().GetMethods().FirstOrDefault(m => m.Name == command);
            
            try
            {
                result = (string)festivalControllerMethodInfo.Invoke(this.festivalCоntroller, new object[] { args });
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }

            return result;
        }
    }
}