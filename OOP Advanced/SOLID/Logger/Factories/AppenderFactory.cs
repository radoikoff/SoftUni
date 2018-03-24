using Logger.Models;
using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Factories
{
    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
        }

        public IAppender CreateAppender(string appenderType, string errorLevelAsString, string layoutType)
        {
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            ErrorLevel errorLevel = ParseErrorLevel(errorLevelAsString);

            switch (appenderType)
            {
                case "ConsoleAppender":
                    return new ConsoleAppender(layout, errorLevel);
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
