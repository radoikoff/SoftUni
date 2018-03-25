using Logger.Factories;
using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine(ILogger logger, ErrorFactory errorFactory)
        {
            this.logger = logger;
            this.errorFactory = errorFactory;
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    var args = input.Split('|');
                    string level = args[0];
                    string timeStamp = args[1];
                    string message = args[2];

                    IError error = this.errorFactory.CreateError(timeStamp, level, message);
                    this.logger.Log(error);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("Logger info");
            foreach (IAppender appender in this.logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
