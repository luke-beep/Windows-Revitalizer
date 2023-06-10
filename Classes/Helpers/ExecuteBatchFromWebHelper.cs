using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsRevitalizer.Interfaces;

namespace WindowsRevitalizer.Classes.Helpers
{
    internal class ExecuteBatchFromWebHelper
    {
        public async void ExecuteBatchScriptFromWeb(string scriptUrl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string scriptContent = await client.GetStringAsync(scriptUrl);

                    string tempScriptPath = "temp_script.bat";
                    await File.WriteAllTextAsync(tempScriptPath, scriptContent);

                    Process process = new Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = "/C " + tempScriptPath;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    Console.WriteLine("Script executed successfully.");
                    File.Delete(tempScriptPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing batch script: " + ex.Message);
            }
        }
    }
}
