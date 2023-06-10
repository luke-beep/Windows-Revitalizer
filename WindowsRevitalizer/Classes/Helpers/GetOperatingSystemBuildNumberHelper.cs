using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsRevitalizer.Classes.Helpers
{
    internal class GetOperatingSystemBuildNumberHelper
    {
        public string GetOperatingSystemBuildNumber()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "wmic.exe";
            startInfo.Arguments = "OS get BuildNumber /value";
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            string buildNumber = output
                .Split(new char[] { '=', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .LastOrDefault()
                ?.Trim();

            return buildNumber;
        }
    }
}
