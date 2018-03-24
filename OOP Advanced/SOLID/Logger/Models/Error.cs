using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models
{
    public class Error : IError
    {
        public Error(DateTime timeStamp, string message, ErrorLevel level)
        {
            this.TimeStamp = timeStamp;
            this.Message = message;
            this.Level = level;
        }

        public DateTime TimeStamp { get; }

        public string Message { get; }

        public ErrorLevel Level { get; }
    }
}
