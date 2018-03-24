using Logger.Models;
using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger.Factories
{
    public class ErrorFactory
    {
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public IError CreateError(string timeStampAsString, string errorLevelAsString, string message)
        {
            DateTime timestamp = DateTime.ParseExact(timeStampAsString, DateFormat, CultureInfo.InvariantCulture); //to check if parse is OK
            ErrorLevel errorLevel = ParseErrorLevel(errorLevelAsString);
            return new Error(timestamp, message, errorLevel);
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
