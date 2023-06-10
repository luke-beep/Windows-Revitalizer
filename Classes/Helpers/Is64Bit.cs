using Spectre.Console.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsRevitalizer.Interfaces;

namespace WindowsRevitalizer.Classes.Helpers
{
    internal class Is64Bit
    {
        public static bool Is64BitOperatingSystem()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                return true;
            }
            else 
            { 
                return false; 
            }
        }
    }
}
