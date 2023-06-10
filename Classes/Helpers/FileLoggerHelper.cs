using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsRevitalizer.Interfaces;

namespace WindowsRevitalizer.Classes.Helpers
{
    internal class FileLoggerHelper : ILogger
    {
        private readonly string logFilePath;

        public FileLoggerHelper(string logFilePath)
        {
            this.logFilePath = logFilePath;
        }

        public void Log(string message)
        {
            string directoryPath = Path.GetDirectoryName(logFilePath);
            Directory.CreateDirectory(directoryPath);
            File.AppendAllText(logFilePath, message + Environment.NewLine);
        }

        public void ClearLogFile()
        {
            if (File.Exists(logFilePath))
            {
                File.Delete(logFilePath);
            }
        }
    }
}
