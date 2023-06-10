using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsRevitalizer.Classes.Helpers
{
    internal static class FileExtensionsHelper
    {
        public static string? FindLine(this string[] lines, string keyword)
        {
            foreach (string line in lines)
            {
                if (line.StartsWith(keyword))
                {
                    return line;
                }
            }

            return null;
        }
    }
}
