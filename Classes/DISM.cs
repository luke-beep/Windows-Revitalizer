using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsRevitalizer.Interfaces;

namespace WindowsRevitalizer.Classes
{
    internal class DISM : ICommand
    {
        public void Execute()
        {

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose between CheckHealth, ScanHealth & RestoreHealth.")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more features)[/]")
                    .HighlightStyle(Color.Red)
                    .AddChoices(new[] {
                        "CheckHealth - Checks whether the image has been flagged as corrupted by a failed process and whether the corruption can be repaired.",
                        "ScanHealth - Scans the image for component store corruption. This operation will take several minutes.",
                        "RestoreHealth - Scans the image for component store corruption, and then performs repair operations automatically. This operation will take several minutes.",
                    }));

            //Clear everything after " - "
            var index = choice.IndexOf(" - ");
            var result = choice.Substring(0, index);

            var processStartInfo = new ProcessStartInfo
            {
                FileName = "dism.exe",
                Arguments = $"/Online /Cleanup-Image /{result} /LogLevel:4 /NoRestart",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = new Process();
            process.StartInfo = processStartInfo;
            
            process.OutputDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrWhiteSpace(e.Data))
                {
                    Console.WriteLine(e.Data);
                }
            };

            process.ErrorDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrWhiteSpace(e.Data))
                {
                    Console.WriteLine("Error: " + e.Data);
                }
            };

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
        }
    }
}
