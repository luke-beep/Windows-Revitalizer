using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsRevitalizer.Interfaces;

namespace WindowsRevitalizer.Classes.Helpers
{
    internal class OutputLoggerHelper : TextWriter
    {
        private readonly ILogger logger;
        private readonly TextWriter originalOutput;

        public OutputLoggerHelper(ILogger logger)
        {
            this.logger = logger;
            originalOutput = Console.Out;
        }

        public override void Write(char value)
        {
            logger.Log(value.ToString());
            originalOutput.Write(value);
        }

        public override void Write(string value)
        {
            logger.Log(value);
            originalOutput.Write(value);
        }

        public override Encoding Encoding => originalOutput.Encoding;
    }
}
