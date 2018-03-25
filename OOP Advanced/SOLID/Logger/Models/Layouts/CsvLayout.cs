using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger.Models.Layouts
{
    public class CsvLayout : ILayout
    {
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";

        private string format = "{0},{1},{2}";

        public string FormatError(IError error)
        {
            var dataString = error.TimeStamp.ToString(DateFormat, CultureInfo.InvariantCulture);
            var formattedError = string.Format(format, dataString, error.Level.ToString(), error.Message);
            return formattedError;
        }
    }
}
