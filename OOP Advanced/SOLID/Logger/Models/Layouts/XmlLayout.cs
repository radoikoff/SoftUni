using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger.Models.Layouts
{
    public class XmlLayout : ILayout
    {
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";

        private string format =
            $"<log>" + Environment.NewLine +
                "\t<date>{0}</date>" + Environment.NewLine +
                "\t<level>{1}</level>" + Environment.NewLine +
                "\t<message>{2}</message>" + Environment.NewLine +
            "</log>";

        public string FormatError(IError error)
        {
            var dataString = error.TimeStamp.ToString(DateFormat, CultureInfo.InvariantCulture);
            var formattedError = string.Format(format, dataString, error.Level.ToString(), error.Message);
            return formattedError;
        }
    }
}
