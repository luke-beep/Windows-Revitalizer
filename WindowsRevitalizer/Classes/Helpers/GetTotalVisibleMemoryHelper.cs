using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsRevitalizer.Classes.Helpers
{
    internal class GetTotalVisibleMemoryHelper
    {
        public int GetTotalVisibleMemorySize()
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "wmic";
                process.StartInfo.Arguments = "os get TotalVisibleMemorySize /value";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();

                process.WaitForExit();

                string memSize = output
                    .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .FindLine("TotalVisibleMemorySize");

                if (int.TryParse(memSize?.Split('=')[1].Trim(), out int mem))
                {
                    return mem;
                }

                return 0;
            }
        }
    }
}
