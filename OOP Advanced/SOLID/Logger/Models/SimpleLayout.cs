using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger.Models
{
    public class SimpleLayout : ILayout
    {
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public string FormatError(IError error)
        {
            var dataString = error.TimeStamp.ToString(DateFormat, CultureInfo.InvariantCulture);
            var formattedError = string.Format($"{dataString} - {error.Level.ToString()} - {error.Message}");
            return formattedError;
        }
    }
}
