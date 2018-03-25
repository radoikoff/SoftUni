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

        private LayoutFactory layoutFactory;
        private FileFactory fileFactory;

        public AppenderFactory(LayoutFactory layoutFactory, FileFactory fileFactory)
        {
            this.layoutFactory = layoutFactory;
            this.fileFactory = fileFactory;
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
                    ILogFile logFile = fileFactory.CreateLogFile();
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
