using Logger.Models;
using Logger.Models.Appenders;
using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Factories
{
    public class AppenderFactory
    {
        private const string DefaultFileName = "LogFile{0}.txt";

        private LayoutFactory layoutFactory;
        private int fileNumber;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
            this.fileNumber = 0;
        }

        public IAppender CreateAppender(string appenderType, string errorLevelAsString, string layoutType)
        {
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            ErrorLevel errorLevel = ParseErrorLevel(errorLevelAsString);

            switch (appenderType)
            {
                case "ConsoleAppender":
                    return new ConsoleAppender(layout, errorLevel);
                case "FileAppender":
                    ILogFile logFile = new LogFile(string.Format(DefaultFileName, fileNumber));
                    return new FileAppender(layout, errorLevel, logFile);
                default:
                    throw new ArgumentException("Invalid Appender Type!");
            }

        }

        private ErrorLevel ParseErrorLevel(string errorLevelAsString)
        {
            ErrorLevel errorLevel;
            bool conversionSuccessful = Enum.TryParse(errorLevelAsString, out errorLevel);
            if (!conversionSuccessful)
            {
                throw new ArgumentException("Invalid ErrorLevel Type!");
            }

            return errorLevel;
        }
    }
}
