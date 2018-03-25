using Logger.Models;
using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Factories
{
    public class FileFactory
    {
        private const string DefaultFileName = "LogFile{0}.txt";
        private int fileNumber;

        public FileFactory()
        {
            this.fileNumber = 0;
        }

        public ILogFile CreateLogFile()
        {
            var fileName = string.Format(DefaultFileName, fileNumber);

            ILogFile logFile = new LogFile(string.Format(DefaultFileName, fileNumber));
            fileNumber++;
            return logFile;
        }
    }
}
