using System;

namespace Logger.Models.Interfaces
{
    public interface IError
    {
        DateTime TimeStamp { get; }

        string Message { get; }

        ErrorLevel Level { get; }
    }
}