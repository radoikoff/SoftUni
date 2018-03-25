using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Logger.Models
{
    public class LogFile : ILogFile
    {
        private string DefaultPath = "./data/";

        public LogFile(string fileName)
        {
            this.Path = DefaultPath + fileName;
            InitilaizeFile();
            this.Size = 0;
        }

        private void InitilaizeFile()
        {
            Directory.CreateDirectory(DefaultPath);
            File.AppendAllText(Path, "");
        }

        public string Path { get; }

        public int Size { get; private set; }

        public void WriteToFile(string errorLog)
        {
            File.AppendAllText(this.Path, errorLog + Environment.NewLine);

            int addedSize = 0;
            for (int i = 0; i < errorLog.Length; i++)
            {
                addedSize += errorLog[i];
            }

            this.Size += addedSize;
        }
    }
}
