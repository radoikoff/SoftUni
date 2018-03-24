using Logger.Factories;
using Logger.Models;
using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Logger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ILogger logger = InitializeLogger();
            ErrorFactory errorFactory= new ErrorFactory();
            Engine engine = new Engine(logger, errorFactory);
            engine.Run();
        }

        static ILogger InitializeLogger()
        {
            ICollection<IAppender> appenders = new List<IAppender>();

            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);

            int appenderCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < appenderCount; i++)
            {
                var args = Console.ReadLine().Split();
                var appenderType = args[0];
                var layoutType = args[1];
                var errorLevel = "INFO";

                if (args.Length == 3)
                {
                    errorLevel = args[2];
                }

                IAppender appender = appenderFactory.CreateAppender(appenderType, errorLevel, layoutType);
                appenders.Add(appender);
            }

            ILogger logger = new MainLogger(appenders);
            return logger;
        }
    }
}
