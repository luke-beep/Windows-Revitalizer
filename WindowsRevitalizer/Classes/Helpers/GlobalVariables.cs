using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsRevitalizer.Classes.Helpers
{
    internal class GlobalVariables
    {
#pragma warning disable CS8601 // Possible null reference assignment.
        public static string systemDrive = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
#pragma warning restore CS8601 // Possible null reference assignment.
        public static string SavePath = $"{systemDrive}\\WindowsRevitalizer\\";
    }
}
