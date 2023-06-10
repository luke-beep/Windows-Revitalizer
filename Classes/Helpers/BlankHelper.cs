using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsRevitalizer.Classes.Helpers
{
    internal class BlankHelper
    {
        static void AddBlankLineAfterLine(string line, string targetLine)
        {
            if (line.Contains(targetLine))
            {
                Console.WriteLine();
            }
        }
    }
}
